using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OrderProcessingSystem.DL
{
    class DBCon
    {
      public static void getData()
        {
            string cs = @"Data Source = PASANYASARA; Initial Catalog = OrderDB; Integrated Security = True; User Instance = False";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            
        }  
    }
}
