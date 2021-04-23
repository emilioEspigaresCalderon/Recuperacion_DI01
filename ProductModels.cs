using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuperacion_Tarea_DI01
{
    public class ProductModels
    {
        public int ProductModelID { get; set; }
        public string ProductModel { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float priceList { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ ProductModel } | { description } | { priceList }$";
            }
        }
    }
}
