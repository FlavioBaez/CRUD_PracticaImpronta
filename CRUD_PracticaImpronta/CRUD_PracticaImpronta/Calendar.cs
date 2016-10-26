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
    public partial class Calendar : Form
    {
        public  String cad;
        public Calendar()
        {
            InitializeComponent();
        }

        public void Calendar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.cad = dateTimePicker1.Text;
            this.Close();
        }

        public  void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         
        }
    }
}
