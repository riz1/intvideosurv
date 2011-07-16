using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.Xpo.DB;

namespace CameraViewer.Model
{
    class OracleProvider : DevExpress.Xpo.DB.OracleConnectionProvider
    {
        public OracleProvider(IDbConnection connection, AutoCreateOption autoCreateOption) : base(connection, autoCreateOption)
        {
        }

        protected override string GetSeqName(string tableName)
        {
            if (tableName == "tog_vehmon")
            {
                return "CLXXBH_SEQ";
            }

            return "";
        }
    }
}
