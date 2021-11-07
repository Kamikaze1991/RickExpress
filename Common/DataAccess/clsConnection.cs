using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataAccess
{
    public class clsConnection
    {
        const string strConnection = "Data Source=192.168.1.1,username=sa,password=Aezakami123";
        SqlConnection mSqlConnection;
        public DataSet objResult { get; set; }

        /// <summary>
        /// typical construc
        /// </summary>
        public clsConnection() {
            mSqlConnection = new SqlConnection(strConnection);
        }

        /// <summary>
        /// method for execute any querys and response a dataset
        /// </summary>
        /// <param name="strCommand"></param>
        /// <param name="lstParameters"></param>
        /// <returns>return a dataset value</returns>
        bool executeCommand(string strCommand, clsSqlParameter [] lstParameters)
        {
            try {
                SqlCommand mCommand=new SqlCommand(strCommand, mSqlConnection);
                SqlParameter[] defparameters=new SqlParameter[lstParameters.Length];

                for (int i = 0; i < lstParameters.Length; i++) 
                {
                    defparameters[i] = new SqlParameter();
                    defparameters[i].ParameterName = lstParameters[i].name;
                    defparameters[i].Value = lstParameters[i].value;
                    defparameters[i].SqlDbType = lstParameters[i].type;
                    defparameters[i].Size = lstParameters[i].size;
                    defparameters[i].Precision = lstParameters[i].presision;
                    defparameters[i].Direction = lstParameters[i].direction;
                    defparameters[i].Scale = lstParameters[i].scale;
                }



                return true;
            }
            catch
            {
                return false;
            }
            
        }



    }
}
