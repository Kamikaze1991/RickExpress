using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class clsSqlParameter
    {
        public string name { get; set; }
        public object value { get; set; }
        public SqlDbType type { get; set; }
        public ParameterDirection direction { get; set; }
        public int size { get; set; }
        public byte presision { get; set; }
        public byte scale { get; set; }

        /// <summary>
        /// Construct method for manage the parameters
        /// </summary>
        /// <param name="p1">name</param>
        /// <param name="p2">value</param>
        /// <param name="p3">type</param>
        /// <param name="p4">direction</param>
        /// <param name="p5">size</param>
        public clsSqlParameter(string p1, object p2, SqlDbType p3, ParameterDirection p4, int p5) {
            name = p1;
            value = p2;
            type = p3;
            direction = p4;
            size = p5;
            presision = 0;
            scale = 0;
        }

    }
}
