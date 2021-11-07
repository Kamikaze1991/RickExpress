using Common.DataAccess;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            clsConnection cn = new clsConnection();

            cn.executeCommand("spi_cliente '131324555-2','amateur','sarrapastoso','tornegoprg@gmail.com'", null);
            


        }
    }
}
