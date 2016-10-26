using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_PracticaImpronta
{
    public partial class RegitroCarrera : Form
    {
        public static string Name_Carrera;
        public RegitroCarrera()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name_Carrera = textBox1.Text;
            Carrera agregar = new Carrera();
            agregar.c_Name = Name_Carrera; ;
            agregar.stado = true;

            int verifica = funciones.agregarCarrera(agregar);
            
            this.Close();
            Conexion.conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void RegitroCarrera_Load(object sender, EventArgs e)
        {

        }
    }
}
