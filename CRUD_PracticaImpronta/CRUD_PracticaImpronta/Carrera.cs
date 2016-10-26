using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PracticaImpronta
{
    public class Carrera
    {
        public int id { get; set; }
        public string c_Name{ get; set; }
        public Boolean stado { get; set; }
    

        public Carrera() { }
        public Carrera(int id,string c_Name, Boolean stado)
        {
            this.id = id;
            this.c_Name = c_Name;
            this.stado = stado;


        }
    }
}
