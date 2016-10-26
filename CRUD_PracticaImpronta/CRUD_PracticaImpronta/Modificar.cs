using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_PracticaImpronta
{
    public partial class Modificar : Form
    {
        public static Alumno al { set; get; }
        public Modificar(Alumno alumno )
        {
            InitializeComponent();
            setComboBox();
            al = new Alumno();
            textMatricula.Text = alumno.Num_control;
            textNombre.Text = alumno.nombre;
            textApellido.Text = alumno.apellido;
            Carreras.Text = funciones.obtenerCarreraName(alumno.id_carrera);
            al.fecha = alumno.fecha;
            al.id = alumno.id;
        }

        private void setComboBox()
        {
            DataSet dsd = new DataSet();

            SqlDataAdapter dad = new SqlDataAdapter("SELECT carreer_id,carreer_name FROM carreer", Conexion.getConection());
            dad.Fill(dsd, "carrrer");//indica con que tabla se llena
            Carreras.DataSource = dsd.Tables[0].DefaultView;
            //indicamos el valor de los mienbros
            Carreras.ValueMember = "carreer_id";
            //se indica el valor a despregar en el conbobox
            Carreras.DisplayMember = "carreer_name";
            Conexion.conexion.Close();

        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            al.Num_control = textMatricula.Text;
            
            al.nombre = textNombre.Text;
            al.apellido = textApellido.Text;
            al.id_carrera = funciones.obtenerCID(Carreras.Text) ;
            int op = funciones.ModificarA(al);
            if (op > 0)
            {
                MessageBox.Show("Registro Modificado");
                
            }
            else
            {
                MessageBox.Show("No se Modifico");
            }
        
            this.Close();
           
        }
    }
}
