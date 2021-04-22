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
        public List<ProductModel> GetProductModels(String product, String language)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<ProductModel> products = new List<ProductModel>();

                string select = "SELECT DISTINCT " +
                    "Production.ProductModel.ProductModelID, " +
                    "Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, " +
                    "Production.Product.Name,Production.Product.ListPrice AS priceList " +
                    "FROM " +
                    "Production.Product " +
                    "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
                    "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
                    "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
                    "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
                    "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
                    $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{product}%' ORDER BY ProductModel";
                products = conn.Query<ProductModel>(select).ToList();
                return products;
            }
        }

        public List<Category> GetCategory()
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Category> category = new List<Category>();

                string select = "SELECT ProductCategoryID, Name FROM Production.ProductCategory";
                category = conn.Query<Category>(select).ToList();
                return category;
            }
        }

        public List<Category> GetSubcategory(int productCategoryID)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Category> subcategory = new List<Category>();

                string select = $"SELECT ProductSubcategoryID, Name FROM Production.ProductSubcategory WHERE ProductCategoryID = '{productCategoryID}'";
                subcategory = conn.Query<Category>(select).ToList();
                return subcategory;
            }
        }
    }
}
