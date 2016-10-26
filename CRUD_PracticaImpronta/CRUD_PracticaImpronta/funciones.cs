using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_PracticaImpronta
{
    public class funciones
    {
        public static int agregarAlumno(Alumno add)
        {
            SqlConnection cone = Conexion.getConection();
            
            SqlCommand cmd = cone.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into students (student_ctrl_number,student_name,student_last_name,student_carreer,student_registered_date) values('"+ add.Num_control+"','"+ add.nombre+
                "','"+ add.apellido + "','"+add.id_carrera+ "','"+ add.fecha+ "')";
        

           return cmd.ExecuteNonQuery();
        }
        public static int agregarCarrera(Carrera add)
        {
            SqlConnection cone = Conexion.getConection();

            SqlCommand cmd = cone.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into carreer (carreer_name,carreer_status) values('" + add.c_Name + "','" + add.stado + "')";

            
            return cmd.ExecuteNonQuery();
        }
        public void ActualizarGrid(DataGridView DG,string Querty)
        {
            //SqlConnection cone = Conexion.getConection();
            System.Data.DataSet dataset = new System.Data.DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter(Querty, Conexion.getConection());
            dataadapter.Fill(dataset,"students");
            DG.DataSource = dataset;
            DG.DataMember = "students";
            Conexion.conexion.Close();



        }
        public void ActualizarGridC(DataGridView DG, string Querty)
        {
            //SqlConnection cone = Conexion.getConection();
            System.Data.DataSet dataset = new System.Data.DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter(Querty, Conexion.getConection());
            dataadapter.Fill(dataset, "carreer");
            DG.DataSource = dataset;
            DG.DataMember = "carreer";
            Conexion.conexion.Close();


        }


        public static int obtenerCID(String name)
        {
            int id=0;

            SqlConnection cone = Conexion.getConection();
            SqlCommand cmd = cone.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *FROM carreer where carreer_name = '"+name+"'";
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
               id = read.GetInt32(0);
            }

            return id;
        }

        public static String obtenerCarreraName(int id)
        {
            String name="";

            SqlConnection cone = Conexion.getConection();
            SqlCommand cmd = cone.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *FROM carreer where carreer_id = " +id;
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                name = read.GetString(1);
            }

            return name;
        }

        public static int ModificarA(Alumno alumno)
        {
            
            SqlConnection cone = Conexion.getConection();
            SqlCommand cmd = cone.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE students SET student_ctrl_number="+alumno.Num_control+
                              ",student_name='"+alumno.nombre+
                              "',student_last_name='"+alumno.apellido+
                              "',student_carreer='"+alumno.id_carrera+"' WHERE student_id="+alumno.id;

            return cmd.ExecuteNonQuery();
        }
        public static Alumno obtenerAlumno(int id)
        {
            Alumno aRet = new Alumno();
            SqlConnection cone = Conexion.getConection();
            SqlCommand cmd = cone.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *FROM students where student_id=" + id ;
            SqlDataReader read=cmd.ExecuteReader();
            while(read.Read())
            {
                aRet.id = read.GetInt32(0);
                aRet.Num_control = read.GetString(1);
                aRet.nombre = read.GetString(2);
                aRet.apellido = read.GetString(3);
                aRet.id_carrera = read.GetInt32(4);
                aRet.fecha = read.GetDateTime(5);

            }

            

            return aRet;
        }



        public static int eliminar(int id)
        {
            
            SqlConnection cone = Conexion.getConection();
            SqlCommand cmd = cone.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE from students where student_id = "+id;

            return cmd.ExecuteNonQuery();
        }

    }
}
