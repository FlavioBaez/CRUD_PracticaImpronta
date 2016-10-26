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
    public partial class selecCarrera : Form
    {
        public String cad;
            public int x;
        public selecCarrera()
        {
            InitializeComponent();
            setComboBox();
        }

        private void selecCarrera_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.cad = Carreras.Text;
            this.x = Carreras.SelectedIndex;
            this.Close();
        }
    }
}
