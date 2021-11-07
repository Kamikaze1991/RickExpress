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
        const string strConnection = "Data Source=192.168.1.11,1433;User ID=sa;password=Aezakami123;Initial Catalog=db_cliente";
        SqlConnection mSqlConnection;
        SqlCommand mSqlCommand;
        public DataSet objResult { get; set; }

        /// <summary>
        /// typical construc
        /// </summary>
        public clsConnection() {
            mSqlConnection = new SqlConnection(strConnection);
        }


        /// <summary>
        /// Quick method to connect
        /// </summary>
        /// <param name="strSentence"></param>
        /// <param name="objCommandType"></param>
        /// <returns></returns>
        private bool conectar(string strSentence, CommandType objCommandType) {
            try
            {
                mSqlConnection = new SqlConnection(strConnection);
                mSqlCommand = new SqlCommand(strSentence, mSqlConnection);
                mSqlCommand.CommandType = objCommandType;
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// method for execute any querys and response a dataset
        /// </summary>
        /// <param name="strCommand"></param>
        /// <param name="lstParameters"></param>
        /// <returns>return a dataset value</returns>
        public bool executeCommand(string strCommand, clsSqlParameter [] lstParameters)
        {
            try {
                if (conectar(strCommand, CommandType.Text))
                {
                    
                    SqlParameter[] defparameters = new SqlParameter[lstParameters.Length];

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
                        mSqlCommand.Parameters.Add(defparameters[i]);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter()) {
                        da.SelectCommand = mSqlCommand;
                        objResult = new DataSet();
                        da.Fill(objResult);
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
            
        }



    }
}
