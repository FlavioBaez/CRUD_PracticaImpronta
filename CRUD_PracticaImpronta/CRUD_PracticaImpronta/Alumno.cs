using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PracticaImpronta
{
    public class Alumno
    {
        public int id { get; set; }
        public string Num_control { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int id_carrera { get; set; }
        public DateTime fecha { get; set; }

        public Alumno() { }
        public Alumno(int id, string matricula,string nombre,string apelleido,int idCarrera,DateTime fecha)
        {
            this.id = id;
            this.Num_control = matricula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.id_carrera = idCarrera;
            this.fecha = fecha;

        }
    }
}
