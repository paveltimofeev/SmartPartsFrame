using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace SmartPartsFrame.Model.DatabaseTools.SQL
{
    internal class SqlModel : IDisposable
    {
        private SqlConnection sqlconnection = null;
        private SqlCommand sqlcommand = null;
        private SqlTransaction transaction = null;
        private StringBuilder logger = null;
        private SqlDataAdapter da = null;

        internal delegate void SqlCallHandler();
        internal delegate void SqlCallParameterdHandler(SqlCommand parameter);
        internal delegate object SqlResultHandler();
        internal delegate int SqlNonQueryHandler();

        #region Constructors

        public SqlModel() : this("", "", true) { ;}
        
        public SqlModel(string sqlcommand) : this("", sqlcommand, true) { ;}
        
        public SqlModel(string sqlconnection, string sqlcommand) : this(sqlconnection, sqlcommand, false) { ;}
        
        /// <summary>
        /// SqlModel constructor
        /// </summary>
        /// <param name="sqlconnection">Connection string for connect to SQL server</param>
        /// <param name="sqlcommand">TSQL command</param>
        /// <param name="read">Set True for read connection string from configuration file (replace 'sqlconnection' parameter), False for use sqlconnection parameter</param>
        public SqlModel(string sqlconnection, string sqlcommand, bool read)
        {
            logger = new StringBuilder();

            if (read)
                sqlconnection = ConnectionModel.ConnectionString;

            this.Add(sqlconnection, sqlcommand);
        }

        #endregion

        #region Model configuration methods

        /// <summary>
        /// Set sql commection
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(SqlConnection sqlconnection)
        {
            this.sqlconnection = sqlconnection;
            return this;
        }
        /// <summary>
        /// Set T-SQL command
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(string sqlcommand)
        {
            return this.Add(new SqlCommand(sqlcommand, sqlconnection));
        }
        /// <summary>
        /// Set T-SQL command
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(SqlCommand sqlcommand)
        {
            this.sqlcommand = sqlcommand;
            return this;
        }
        /// <summary>
        /// Set T-SQL command
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(string sqlconnectionstring, string sqlcommand)
        {
            this.sqlconnection = new SqlConnection(sqlconnectionstring);
            return this.Add(new SqlCommand(sqlcommand, this.sqlconnection));
        }
        /// <summary>
        /// Set command type equals Stored Procedure
        /// </summary>
        /// <returns></returns>
        public SqlModel IsStoredProcedure()
        {
            return this.Add(CommandType.StoredProcedure);
        }
        /// <summary>
        /// Set command type
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(CommandType type)
        {
            sqlcommand.CommandType = type;
            return this;
        }
        /// <summary>
        /// Add TSQL command parameter without value
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(string parameterName, SqlDbType type)
        {
            sqlcommand.Parameters.Add(parameterName, type);
            return this;
        }
        /// <summary>
        /// Add TSQL command parameter with value
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(string parameterName, SqlDbType type, object value)
        {
            sqlcommand.Parameters.Add(parameterName, type).Value = value;
            return this;
        }
        /// <summary>
        /// Add TSQL command parameter
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(SqlParameter sqlparameter)
        {
            sqlcommand.Parameters.Add(sqlparameter);
            return this;
        }
        /// <summary>
        /// Add TSQL command parameters
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(SqlParameter[] sqlparameters)
        {
            sqlcommand.Parameters.AddRange(sqlparameters);
            return this;
        }
        /// <summary>
        /// Set timeout
        /// </summary>
        /// <returns></returns>
        public SqlModel Add(int timeout)
        {
            sqlcommand.CommandTimeout = timeout;
            return this;
        }

        /// <summary>
        /// Setup parameters of command (if command is stored procedure) automaticly.
        /// </summary>
        /// <returns></returns>
        public SqlModel SetAutoParameters()
        {
            SqlCall(new SqlCallParameterdHandler(SqlCommandBuilder.DeriveParameters), this.sqlcommand);

            //SqlCommandBuilder.DeriveParameters(this.sqlcommand);
            return this;
        }
        /// <summary>
        /// Setup parameters of command (if command is stored procedure) automaticly.
        /// </summary>
        /// <returns></returns>
        public SqlModel SetParameterValue(string parameterName, object value)
        {
            sqlcommand.Parameters[parameterName].Value = value;
            return this;
        }
        /// <summary>
        /// Setup values of parameters and create new parameter if this is absent.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="create">True for create parameter if this is absent</param>
        /// <returns></returns>
        public SqlModel SetParameterValue(string parameterName, object value, bool create)
        {
            bool isNew = true;
            foreach (SqlParameter p in sqlcommand.Parameters)
            {
                if (p.ParameterName == parameterName)
                    isNew = false;
            }

            if (isNew)
                sqlcommand.Parameters.AddWithValue(parameterName, value);
            else
                sqlcommand.Parameters[parameterName].Value = value;

            return this;
        }

        /// <summary>
        /// Get value of the parameter
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="parameterName">Parameter name</param>
        /// <returns></returns>
        public T GetParameterValue<T>(string parameterName)
        {
            return (T)sqlcommand.Parameters[parameterName].Value;
        }

        #endregion

        #region Model use methods

        /// <summary>
        /// Execute non-query sqlcomand
        /// </summary>
        public int ExecuteNonQuery()
        {
            return SqlExecuteNonQuery(new SqlNonQueryHandler(sqlcommand.ExecuteNonQuery));
        }
        /// <summary>
        /// Execute scalar sqlcomand
        /// </summary>
        public object ExecuteScalar()
        {
            return SqlExecute(new SqlResultHandler(sqlcommand.ExecuteScalar));
        }
        /// <summary>
        /// Fill dataset
        /// </summary>
        public void Fill(ref DataSet dataset)
        {
            da = new SqlDataAdapter(sqlcommand);
            da.Fill(dataset);
        }
        /// <summary>
        /// Fill dataset asyncronously
        /// </summary>
        public void Fill(ref DataTable datatable, AsyncCallback callback)
        {
            AsyncData data = new AsyncData(datatable, callback);

            sqlconnection.Open();
            IAsyncResult ar = sqlcommand.BeginExecuteReader(new AsyncCallback(callbackFill), data);
        }
        /// <summary>
        /// asyncronous Filling of datatabe.
        /// </summary>
        /// <param name="ar"></param>
        private void callbackFill(IAsyncResult ar)
        {
            AsyncData asyncData = (AsyncData)ar.AsyncState;
            try
            {
                SqlDataReader dr = sqlcommand.EndExecuteReader(ar);
                asyncData.Datatable.Load(dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }

            asyncData.Callback.Invoke(new FillResult(asyncData.Datatable));
        }

        /// <summary>
        /// This class boxes user-data to pass their to callback procedure
        /// </summary>
        internal class AsyncData
        {
            public AsyncData(DataTable Datatable, AsyncCallback Callback)
            {
                this.Datatable = Datatable;
                this.Callback = Callback;
            }
            public DataTable Datatable { get; private set; }
            public AsyncCallback Callback { get; private set; }
        }

        /// <summary>
        /// Internal implementation of interface IAsyncResult for return asynhcronouse results of Fill method
        /// </summary>
        internal class FillResult : IAsyncResult
        {
            DataTable data;

            public FillResult(DataTable data)
            {
                this.data = data;
            }
            public object AsyncState
            {
                get { return data; }
            }

            public WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }

            public bool CompletedSynchronously
            {
                get { return false; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }
        }

        /// <summary>
        /// Fill datatable
        /// </summary>
        public void Fill(ref DataTable datatable)
        {
            da = new SqlDataAdapter(sqlcommand);
            da.Fill(datatable);
        }

        /// <summary>
        /// Fill an array from any column of query result set
        /// </summary>
        /// <typeparam name="T">Type of the result array</typeparam>
        /// <param name="columnIndex">Zero-based index of result set column</param>
        /// <returns></returns>
        public T[] Fill<T>(int columnIndex)
            where T : IConvertible
        {
            List<object> temp = new List<object>();
            try
            {
                sqlconnection.Open();
                SqlDataReader dr = GetDataReader(); // sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(dr[columnIndex]);
                }

            }
            catch (Exception ex)
            {
                logger.AppendLine(ex.Message);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }

            T[] result = new T[temp.Count];
            for (int i = 0; i < temp.Count; i++)
            {
                result[i] = (T)Convert.ChangeType(temp[i].ToString(), typeof(T));
            }

            return result;
        }

        private SqlDataReader GetDataReader()
        {
            return sqlcommand.ExecuteReader();
        }

        /// <summary>
        /// Fill an array from any column of query result set
        /// </summary>
        /// <typeparam name="T">Type of the result array</typeparam>
        /// <param name="columnIndex">Zero-based index of result set column</param>
        /// <returns></returns>
        public Dictionary<TKey, TVal> Fill<TKey, TVal>(int columnKey, int columnVal)
        {
            Dictionary<TKey, TVal> result = new Dictionary<TKey, TVal>();
            try
            {
                sqlconnection.Open();
                SqlDataReader dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    TKey key = (TKey)Convert.ChangeType(dr[columnKey].ToString(), typeof(TKey));
                    TVal val = (TVal)Convert.ChangeType(dr[columnVal].ToString(), typeof(TVal));
                    result.Add(key, val);
                }
            }
            catch (Exception ex)
            {
                logger.AppendLine(ex.Message);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Begin sql-transaction
        /// </summary>
        /// <returns></returns>
        public SqlModel TrBegin()
        {
            transaction = (SqlTransaction)SqlExecute(new SqlResultHandler(sqlconnection.BeginTransaction));
            return this;
        }
        /// <summary>
        /// Commit sql-transaction
        /// </summary>
        /// <returns></returns>
        public SqlModel TrCommit()
        {
            if (transaction != null)
                SqlCall(new SqlCallHandler(transaction.Commit));
            return this;
        }
        /// <summary>
        /// Rollback sql-transaction
        /// </summary>
        /// <returns></returns>
        public SqlModel TrRollback()
        {
            if (transaction != null)
                SqlCall(new SqlCallHandler(transaction.Rollback));
            return this;
        }

        #endregion

        #region Optimistic concurrecncy

        #endregion

        #region Invoke handlers

        private void SqlCall(SqlCallHandler hndl)
        {
            try
            {
                sqlconnection.Open();
                hndl.Invoke();
            }
            catch (SqlException sqlex)
            {
                ThrowException(sqlex);
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }
        }
        private void SqlCall(SqlCallParameterdHandler hndl, SqlCommand parameter)
        {
            try
            {
                sqlconnection.Open();
                hndl.Invoke(parameter);
            }
            catch (SqlException sqlex)
            {
                ThrowException(sqlex);
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }
        }
        private object SqlExecute(SqlResultHandler handler)
        {
            object result = null;

            try
            {
                sqlconnection.Open();
                result = handler.Invoke();
            }
            catch (SqlException sqlex)
            {
                ThrowException(sqlex);
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }
            return result;
        }
        private int SqlExecuteNonQuery(SqlNonQueryHandler handler)
        {
            int result = -1;

            try
            {
                sqlconnection.Open();
                result = handler.Invoke();
            }
            catch (SqlException sqlex)
            {
                ThrowException(sqlex);
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }
            return result;
        }

        #endregion

        internal void Rollback()
        {
            if (transaction != null)
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        /// <summary>
        /// Write log, rollback transaction and close connection;
        /// </summary>
        /// <param name="ex"></param>
        protected virtual void ThrowException(Exception ex)
        {
            try
            {
                logger.AppendLine(ex.Message);
                Rollback();
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }

            throw ex;
        }

        protected virtual void ThrowException(SqlException ex)
        {
            try
            {
                logger.AppendFormat("SQL Error. Proc:{0}, Line:{1}. Message: {2}\r\n", ex.Procedure, ex.LineNumber, ex.Message);
                Rollback();
            }
            finally
            {
                if (sqlconnection.State != ConnectionState.Closed)
                    sqlconnection.Close();
            }

            throw ex;
        }
        
        /// <summary>
        /// Get log.
        /// </summary>
        public string Log
        {
            get { return logger.ToString(); }
        }
        
        public void Dispose()
        {
            if (sqlconnection.State != ConnectionState.Closed)
                sqlconnection.Close();
        }
    }
}
