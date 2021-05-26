using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuperacion_Tarea_DI01
{
    public partial class Details : Form
    {
        public int id;
        string route;
        List<Products> product = new List<Products>();
        List<string> sizes = new List<string>();
        List<string> colors = new List<string>();
        public Details(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            product = DataAccess.GetProducts(id);

            textBoxName.Text = product[0].ProductModel;
            textBoxDescription.Text = product[0].description;
            textBoxPrice.Text = product[0].priceList.ToString() + "$";

            textBoxName.ReadOnly = true;
            textBoxDescription.ReadOnly = true;
            textBoxPrice.ReadOnly = true;
            textBoxProductID.ReadOnly = true;

            int numProducts = product.Count;
            for (int i = 0; i < numProducts; i++)
            {
                sizes.Add(product[i].size);
                colors.Add(product[i].color);
            }
            sizes = removeDuplicates(sizes);
            colors = removeDuplicates(colors);
            createButtons();
            getImage();
        }

        public List<string> removeDuplicates(List<string> duplicated)
        {
            List<string> noDuplicated = new List<string>();
            foreach (var prod in duplicated)
            {
                Boolean x = true;
                foreach (var prod2 in noDuplicated)
                {
                    if (prod2 == prod)
                    {
                        x = false;
                    }
                }
                if (x == true)
                {
                    noDuplicated.Add(prod);
                }
            }
            return noDuplicated;
        }

        public void createButtons()
        {
            int x = 20;
            int y = 20;

            foreach (string s in sizes)
            {
                Button sizeButton = new Button();

                if (s == null)
                    sizeButton.Text = "NULL";
                else
                    sizeButton.Text = s;
            
                sizeButton.Location = new Point(50 + x, 100);
                Controls.Add(sizeButton);

                x += 100;
            }

            foreach (string c in colors)
            {
                Button colorButton = new Button();

                if (c == null)
                    colorButton.Text = "NULL";
                else
                    colorButton.Text = c;

                colorButton.Location = new Point(50 + y, 140);
                Controls.Add(colorButton);

                y += 100;
            }
        }

        public void getImage()
        {
            ProductImage productImage = DataAccess.GetImage(id);
            byte[] photo = productImage.LargePhoto;
            MemoryStream ms = new MemoryStream(photo);
            Image image = Image.FromStream(ms);
            imagePictureBox.Image = image;
        }

        private void imagePictureBox_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                route = openFileDialog1.FileName;
                imagePictureBox.Image = Image.FromFile(route);
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            DataAccess.SaveImage(route);
        }
    }
}
