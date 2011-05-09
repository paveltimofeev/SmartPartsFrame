using System;
using System.Collections.Generic;
using System.Text;
using SmartPartsFrame.Model.DatabaseTools.SQL;
using System.Data;

namespace SmartPartsFrame.Model
{
    internal class DefaultModel
    {
        public string GetCurrentTitle()
        {
            return DateTime.Now.ToLongTimeString();
        }

        public string[] Descs()
        {
            SqlModel s = new SqlModel("select description from tags");
            return s.Fill<string>(0);
        }
    }
}
