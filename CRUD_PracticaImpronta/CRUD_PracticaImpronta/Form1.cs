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
    public partial class Form1 : Form
    {
        private String fecha;
        public Alumno alumnoSelec { set; get; }
        Calendar cal = new Calendar();
        selecCarrera car = new selecCarrera();
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            setComboBox();
            setListView();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textMatricula.Text != "" && textNombre.Text != "" && textApellido.Text != "" && Carreras.Text != "")
            {
                DateTime d = DateTime.Today;
                Alumno agregar = new Alumno();
                agregar.Num_control = textMatricula.Text;
                agregar.nombre = textNombre.Text;
                agregar.apellido = textApellido.Text;

                agregar.id_carrera = funciones.obtenerCID(Carreras.Text.ToString());
                agregar.fecha = d;
                int verifica = funciones.agregarAlumno(agregar);
                setListView();
                Conexion.conexion.Close();
                textApellido.Text="";
                textNombre.Text = "";
                textMatricula.Text = "";
            }
            else MessageBox.Show("Falta(n) de LLenar Algun(os) campo(s)");
            

        }

        private void setComboBox()
        {
            DataSet dsd = new DataSet();

            SqlDataAdapter dad = new SqlDataAdapter("SELECT carreer_id,carreer_name FROM carreer",Conexion.getConection());
            dad.Fill(dsd, "carrrer");//indica con que tabla se llena
            Carreras.DataSource = dsd.Tables[0].DefaultView;
            //indicamos el valor de los mienbros
            Carreras.ValueMember = "carreer_id";
            //se indica el valor a despregar en el conbobox
            Carreras.DisplayMember = "carreer_name";
            Conexion.conexion.Close();

        }
        private void setListView()
        {
            funciones f = new funciones();
            f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer");

        }

        private void Carreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegitroCarrera rc = new RegitroCarrera();
            this.Enabled = false;
            //evento para validar caundo se cierra el formulario de Rcarreras
            rc.FormClosing += new FormClosingEventHandler(form_FormClosing);
            rc.Show();


        }
       


        private void form_FormClosing(object sender,FormClosingEventArgs e)
        {
            this.Enabled = true;
            setComboBox();
            Carreras.Refresh();
            setListView();
            if(catalogobusq.SelectedIndex==3)
            {
                buscar.Text = car.cad;
            }
            else
            {
                buscar.Text = cal.cad;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cad = buscar.Text;
            funciones f = new funciones();
           
            
            int opc = catalogobusq.SelectedIndex;
            
            switch (opc)
            {
                case 0: {
                       
                        f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer AND students.student_ctrl_number="+cad);
                        dataGridView1.Refresh();
                        break; }
                case 1: { 
                        f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer AND students.student_name='"+cad+"'");
                        dataGridView1.Refresh();
                        break;
                    }
                case 2: {
                        f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer AND students.student_last_name='"+cad+"'");
                        dataGridView1.Refresh();
                        break;
                    }
                case 3: { 
                        cad = car.cad;
                        f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer AND students.studen_carreer="+(car.x+1));
                        dataGridView1.Refresh();
                        break;
                    }
                case 4: {
                        
                        fecha = cal.cad;
                        cad = fecha;
                        f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer AND students.student_registered_date='"+cad+"'");
                        dataGridView1.Refresh();
                        break; }
                default:  { MessageBox.Show("Tienes que seleccionar un filtro de busqueda"); break; }
            }
          
           // f.ActualizarGrid(dataGridView1, "SELECT students.student_id,students.student_ctrl_number,students.student_name,students.student_last_name,carreer.carreer_name,students.student_registered_date FROM students,carreer where carreer.carreer_id=students.student_carreer");

        }

        private void catalogobusq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(catalogobusq.SelectedIndex==3||catalogobusq.SelectedIndex == 4)
            {
                buscar.Enabled = false;
                cal = new Calendar();
                if(catalogobusq.SelectedIndex == 3)
                {
                    car = new selecCarrera();
                    car.FormClosing += new FormClosingEventHandler(form_FormClosing);
                    car.Show();
                    this.Enabled = false;

                }
                else
                {
                    cal.FormClosing += new FormClosingEventHandler(form_FormClosing);
                    cal.Show();
                    this.Enabled = false;

                }
            }
            else
            {
                buscar.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //alumnoSelec = funciones.obtenerAlumno(id);
                int op=funciones.eliminar(id);
                if(op>0)
                {
                    MessageBox.Show("Registro eliminado");
                    setListView();
                }
                else
                {
                    MessageBox.Show("No se Elimino");
                }
            }
            else
            {
                MessageBox.Show("No selecciono ningun dato");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                alumnoSelec = funciones.obtenerAlumno(id);
                Modificar modify = new Modificar(alumnoSelec);
                modify.FormClosing += new FormClosingEventHandler(form_FormClosing);
                this.Enabled = false;
                modify.Show();

            }
            else
            {
                MessageBox.Show("No selecciono ningun dato");
            }

        }

      
    }
}
