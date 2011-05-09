using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security;
using SmartPartsFrame.Model.DatabaseTools.SQL;
using System.Data;
using SmartPartsFrame.Properties;

namespace SmartPartsFrame.Model.Security
{
    /// <summary>
    /// Identity и Principal класс представляющий текущего пользователя.
    /// </summary>
    internal class UserIdentity : IPrincipal, IIdentity
    {
        //public int Id { get; private set; }

        protected virtual void SettingUpInitializedUser()
        {
            ///получаем из базы/определяем и задаём свойства для пользовакеля

            //SqlModel sql = new SqlModel("SELECT role FROM roles WHERE user = @user");
            //this.Roles = sql.Add("@user", SqlDbType.VarChar, this.UserAccount).Fill<string>(0);

            ///или

            //this.Roles = new string[3];
            //this.Roles[0] = "Administrators";
            //this.Roles[1] = "ReadWriteUsers";
            //this.Roles[2] = "Anykeyers";
            
            //this.Id = ...
        }

        #region

        static object syncObj = new Object();
        private volatile IIdentity identity;

        public string[] Roles { get; protected set; }
        public string UserName { get; protected set; }
        public string UserAccount { get; protected set; }

        bool isAuthenticated = false;
        string authenticationType = "SMARTPARTWINDOWSBASED";

        protected UserIdentity()
        {
            Roles = new string[0];

            WindowsIdentity wi = WindowsIdentity.GetCurrent(false);
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (wi.IsAuthenticated & !wi.IsAnonymous)
            {
                try
                {

                    this.identity = wp.Identity;
                    this.UserAccount = wi.Name;
                    this.UserName = wi.Name;
                    this.isAuthenticated = wi.IsAuthenticated;

                    SettingUpInitializedUser();
                }
                catch (Exception ex)
                {
                    this.isAuthenticated = false;
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Задает текущему потоку объект principal равный экземпляру класс UserIdentityBase для текущего пользователя.
        /// </summary>
        public static void Authorization()
        {
            lock (syncObj)
            {
                UserIdentity u = new UserIdentity();
                if (u != null)
                {
                    Thread.CurrentPrincipal = u;
                }
                else
                {
                    throw new SecurityException(Resources.UserIdentity_AuthorizationError);
                }
            }
        }

        /// <summary>
        /// Возвращает объект Principal текущего потока, преобразованный в UserIdentityBase.
        /// </summary>
        public static UserIdentity GetCurrentPrincipal()
        {
            UserIdentity u = Thread.CurrentPrincipal as UserIdentity;
            if (u != null)
            {
                return u;
            }
            else
            {
                throw new SecurityException(Resources.UserIdentity_AuthorizationError);
            }
        }

        /// <summary>
        /// Возвращает объект Principal текущего потока, преобразованный в UserIdentity.
        /// </summary>
        public static UserIdentity CurrentPrincipal
        {
            get { return UserIdentity.GetCurrentPrincipal(); }
        }

        public IIdentity Identity
        {
            get { return this.identity; }
        }

        public bool IsInRole(string role)
        {
            bool result = false;

            for (int i = 0; i < Roles.Length; i++)
            {
                if (Roles[i].Equals(role))
                    result = true;
            }

            return result;
        }

        public string AuthenticationType
        {
            get { return this.authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public string Name
        {
            get { return this.UserName; }
        }

        #endregion
    }
}
