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
        public List<ProductModels> GetProductModels(String product, String language, int subcategoryID, Boolean check)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<ProductModels> products = new List<ProductModels>();

                if (check)
                {
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
                        $"WHERE ProductModelProductDescriptionCulture.CultureID = '{ language }' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{ product }%' AND Production.Product.ProductSubcategoryID = '{ subcategoryID }' ORDER BY ProductModel";
                    products = conn.Query<ProductModels>(select).ToList();
                }
                else
                {
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
                        $"WHERE ProductModelProductDescriptionCulture.CultureID = '{ language }' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{ product }%' ORDER BY ProductModel";
                    products = conn.Query<ProductModels>(select).ToList();
                }
                

                List<ProductModels> noRepeat = new List<ProductModels>();
                foreach (var prod in products)
                {
                    Boolean x = true;
                    foreach (var prod2 in noRepeat)
                    {
                        if (prod2.ProductModelID == prod.ProductModelID)
                        {
                            x = false;
                        }
                    }
                    if (x == true)
                    {
                        noRepeat.Add(prod);
                    }
                }
                return noRepeat;
            }
        }

        public List<Category> GetCategory()
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Category> category = new List<Category>();

                string select = "SELECT ProductCategoryID, Name FROM Production.ProductCategory ORDER BY ProductCategoryID";
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

                string select = $"SELECT ProductSubcategoryID, Name FROM Production.ProductSubcategory WHERE ProductCategoryID = '{ productCategoryID }' ORDER BY ProductSubcategoryID";
                subcategory = conn.Query<Category>(select).ToList();
                return subcategory;
            }
        }

        public List<Products> GetProducts(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Products> details = new List<Products>();

                string select = "SELECT DISTINCT " +
                        "Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, " +
                        "Production.Product.ListPrice AS priceList, " +
                        "Production.Product.Size, Production.Product.Color " +
                        "FROM " +
                        "Production.Product " +
                        "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
                        "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
                        "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
                        "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
                        "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
                        $"WHERE Product.ProductModelID = '{ id }' AND ProductModelProductDescriptionCulture.CultureID = 'en' ORDER BY ProductModel";
                details = conn.Query<Products>(select).ToList();
                return details;
            }
        }
    }
}
