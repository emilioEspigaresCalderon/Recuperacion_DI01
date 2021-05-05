using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuperacion_Tarea_DI01
{
    public partial class MainForm : Form
    {
        DataAccess db = new DataAccess();
        List<ProductModels> pm = new List<ProductModels>();
        List<Category> categories = new List<Category>();
        Category c = new Category();
        int subcategoryID, categoryID;
        public int idProductModel;
        
        public MainForm()
        {
            InitializeComponent();            
            reload();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            categories = db.GetCategory();            
            reload();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            pm = db.GetProductModels(textBoxSearch.Text, subcategoryID);
            reload();
        }

        private void reload()
        {
            listBoxResults.DataSource = pm;
            listBoxResults.DisplayMember = "FullInfo";

            comboBoxCategoria.DataSource = categories;
            comboBoxCategoria.DisplayMember = "FullInfo";
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Category> subcategories = new List<Category>();
            List<Category> aux = new List<Category>();
            categoryID = comboBoxCategoria.SelectedIndex + 1;
            aux = db.GetSubcategory(categoryID);

            subcategories.Add(c);
            foreach (Category c in aux)
                subcategories.Add(c);

            comboBoxSubcategoria.DataSource = subcategories;
            comboBoxSubcategoria.DisplayMember = "FullInfo";
        }

        private void comboBoxSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubcategoria.SelectedIndex != 0)
            {
                switch (categoryID)
                {
                    case 1:
                        subcategoryID = comboBoxSubcategoria.SelectedIndex;
                        break;
                    case 2:
                        subcategoryID = comboBoxSubcategoria.SelectedIndex + 3;
                        break;
                    case 3:
                        subcategoryID = comboBoxSubcategoria.SelectedIndex + 17;
                        break;
                    case 4:
                        subcategoryID = comboBoxSubcategoria.SelectedIndex + 25;
                        break;
                }
            }
            else
            {
                subcategoryID = 0;
            }
            pm = db.GetProductModels(textBoxSearch.Text, subcategoryID);
            reload();
        }

        private void listBoxResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ((ProductModels)listBoxResults.SelectedItem).ProductModelID;
            Details details = new Details(id);
            details.ShowDialog();
        }
    }
}
