using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperacion_Tarea_DI01
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ name }";
            }
        }
    }
}
