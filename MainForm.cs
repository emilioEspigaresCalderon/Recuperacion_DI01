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
        List<ProductModel> pm = new List<ProductModel>();
        List<Category> categories = new List<Category>();
        List<Category> subcategories = new List<Category>();
        String language = "en";
        DataAccess db = new DataAccess();
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
            pm = db.GetProductModels(textBoxSearch.Text, language);
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
            subcategories = db.GetSubcategory(comboBoxCategoria.SelectedIndex);

            comboBoxSubcategoria.DataSource = subcategories;
            comboBoxSubcategoria.DisplayMember = "FullInfo";
        }
    }
}
