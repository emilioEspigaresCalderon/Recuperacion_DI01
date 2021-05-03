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
        List<Category> subcategories = new List<Category>();
        Category c = new Category();
        String language = "en";
        int subcategoryID, categoryID;
        Boolean check;
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
            if (checkBoxFilters.Checked)
                check = true;
            else
                check = false;
            pm = db.GetProductModels(textBoxSearch.Text, language, subcategoryID, check);
            reload();
        }

        private void reload()
        {
            
            listBoxResults.DataSource = pm;
            listBoxResults.DisplayMember = "FullInfo";

            comboBoxCategoria.DataSource = categories;
            comboBoxCategoria.DisplayMember = "FullInfo";
        }

        private void buttonEnglish_Click(object sender, EventArgs e)
        {
            language = "en";
            searchButton_Click(sender, e);
        }

        private void buttonFrench_Click(object sender, EventArgs e)
        {
            language = "Fr";
            searchButton_Click(sender, e);
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryID = comboBoxCategoria.SelectedIndex + 1;
            subcategories = db.GetSubcategory(categoryID);

            comboBoxSubcategoria.DataSource = subcategories;
            comboBoxSubcategoria.DisplayMember = "FullInfo";
        }

        private void comboBoxSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(categoryID)
            {
                case 1:
                    subcategoryID = comboBoxSubcategoria.SelectedIndex + 1;
                    break;
                case 2:
                    subcategoryID = comboBoxSubcategoria.SelectedIndex + 4;
                    break;
                case 3:
                    subcategoryID = comboBoxSubcategoria.SelectedIndex + 18;
                    break;
                case 4:
                    subcategoryID = comboBoxSubcategoria.SelectedIndex + 26;
                    break;
            }
        }

        private void listBoxResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ((ProductModels)listBoxResults.SelectedItem).ProductModelID;
            Details details = new Details(id);
            details.ShowDialog();
        }
    }
}
