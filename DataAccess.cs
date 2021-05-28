using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Recuperacion_Tarea_DI01
{
    class DataAccess
    {
        public static List<ProductModels> GetProductModels(String product, int subcategoryID)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<ProductModels> products = new List<ProductModels>();

                if (subcategoryID == 0)
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
                        $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{ product }%' ORDER BY ProductModel";
                    products = conn.Query<ProductModels>(select).ToList();
                }
                else {
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
                        $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{ product }%' AND Production.Product.ProductSubcategoryID = '{ subcategoryID }' ORDER BY ProductModel";
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

        public static List<Category> GetCategory()
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

        public static List<Category> GetSubcategory(int productCategoryID)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Category> subcategory = new List<Category>();

                if (productCategoryID != 0)
                {
                    string select = $"SELECT ProductSubcategoryID, Name FROM Production.ProductSubcategory WHERE ProductCategoryID = '{ productCategoryID }' ORDER BY ProductSubcategoryID";
                    subcategory = conn.Query<Category>(select).ToList();
                }
                return subcategory;
            }
        }

        public static List<Products> GetProducts(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<Products> details = new List<Products>();

                string select = "SELECT DISTINCT " +
                        "Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, " +
                        "Production.Product.ListPrice AS priceList, " +
                        "Production.Product.Size, Production.Product.Color," +
                        "Production.Product.ProductID " +
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

        public static ProductImage GetImage(int id, string color)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            ProductImage product = new ProductImage();

            using (IDbConnection conn = new SqlConnection(connString))
            {
                string select = "";

                if (color != "NULL")
                {
                    select = "SELECT " +
                            "Product.ProductId, Name, ProductPhoto.ProductPhotoID, ThumbnailPhoto, ThumbnailPhotoFileName, " +
                            "LargePhoto, LargePhotoFileName " +
                            "FROM " +
                            "Production.Product " +
                            "INNER JOIN Production.ProductProductPhoto ON Product.ProductID=ProductProductPhoto.ProductID " +
                            "INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID=ProductPhoto.ProductPhotoID " +
                            $"WHERE Product.ProductModelId = '{ id }' AND Production.Product.Color = '{ color }'";
                } else
                {
                    select = "SELECT " +
                            "Product.ProductId, Name, ProductPhoto.ProductPhotoID, ThumbnailPhoto, ThumbnailPhotoFileName, " +
                            "LargePhoto, LargePhotoFileName " +
                            "FROM " +
                            "Production.Product " +
                            "INNER JOIN Production.ProductProductPhoto ON Product.ProductID=ProductProductPhoto.ProductID " +
                            "INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID=ProductPhoto.ProductPhotoID " +
                            $"WHERE Product.ProductModelId = '{ id }'";
                }
               product = conn.Query<ProductImage>(select).FirstOrDefault();
               return product;
            }
        }

        public static int SaveImage(string route, Image image)
        {
            string connString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection conn = new SqlConnection(connString))
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] largePhoto = ms.ToArray();

                string insert = "INSERT INTO Production.ProductPhoto" +
                    " (ThumbNailPhoto, ThumbnailPhotoFileName, LargePhoto, LargePhotoFileName) " +
                    "VALUES (NULL, NULL, @lrgPhoto, @lrgPhotoFileName)";
                var parametrs = new { lrgPhoto = largePhoto, lrgPhotoFileName = route };
                int rowsAffected = conn.Execute(insert, parametrs);
                if (rowsAffected != 1)
                {
                    throw new Exception("Error inserting image to DB");
                } else
                {
                    return 1;
                }
            }
        }
    }
}
