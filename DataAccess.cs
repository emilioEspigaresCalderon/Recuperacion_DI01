using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Recuperacion_Tarea_DI01
{
    public class DataAccess
    {
        public List<ProductModel> GetProductModels()
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<ProductModel> products = new List<ProductModel>();

                string select = "SELECT DISTINCT ProductID, Name FROM Production.Product";
                products = conn.Query<ProductModel>(select).ToList();
                return products;
            }
        }
    }
}
