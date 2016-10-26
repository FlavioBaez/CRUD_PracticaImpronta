using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_PracticaImpronta
{
    public class Conexion
    {
        public static SqlConnection conexion;
        public static SqlConnection getConection()
        {
            conexion = new SqlConnection(@"Data Source=FLAVIO_BAEZ\BAEZSQLBD;Initial Catalog=PruebaCRUD;Integrated Security=True");
            conexion.Open();
            return conexion;
        }
    }
}
