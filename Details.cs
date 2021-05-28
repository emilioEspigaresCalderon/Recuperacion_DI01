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
        Button colorButtonSelected = new Button();
        Button sizeButtonSelected = new Button();
        List<Products> products = new List<Products>();
        List<string> sizes = new List<string>();
        List<string> colors = new List<string>();
        public Details(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            products = DataAccess.GetProducts(id);

            textBoxName.Text = products[0].ProductModel;
            textBoxDescription.Text = products[0].description;
            textBoxPrice.Text = products[0].priceList.ToString() + "$";
            textBoxProductID.Text = products[0].productID.ToString();

            textBoxName.ReadOnly = true;
            textBoxDescription.ReadOnly = true;
            textBoxPrice.ReadOnly = true;
            textBoxProductID.ReadOnly = true;
            textBoxProductID.ReadOnly = true;

            int numProducts = products.Count;
            for (int i = 0; i < numProducts; i++)
            {
                sizes.Add(products[i].size);
                colors.Add(products[i].color);
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

                if (x < 100)
                {
                    sizeButton.BackColor = Color.DarkGray;
                    sizeButtonSelected = sizeButton;
                }
                    
                sizeButton.Click += sizeButton_Click;
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

                if (y < 100)
                {
                    colorButton.BackColor = Color.DarkGray;
                    colorButtonSelected = colorButton;
                }

                colorButton.Click += colorButton_Click;

                Controls.Add(colorButton);

                y += 100;
            }
        }

        private void sizeButton_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b = ((Button)sender);

            if (b.Text != sizeButtonSelected.Text)
            {
                b.BackColor = Color.DarkGray;
                sizeButtonSelected.BackColor = Color.Transparent;
                sizeButtonSelected = b;
                refreshInfo();
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b = ((Button)sender);

            if (b.Text != colorButtonSelected.Text)
            {
                b.BackColor = Color.DarkGray;
                colorButtonSelected.BackColor = Color.Transparent;
                colorButtonSelected = b;
                refreshInfo();
                getImage();
            }
        }

        public void getImage()
        {
            ProductImage productImage = DataAccess.GetImage(id, colorButtonSelected.Text);
            byte[] photo = productImage.LargePhoto;
            MemoryStream ms = new MemoryStream(photo);
            Image image = Image.FromStream(ms);
            imagePictureBox.Image = image;
        }

        private void refreshInfo()
        {
            foreach (Products p in products)
            {
                if ((p.size == sizeButtonSelected.Text) && (p.color == colorButtonSelected.Text))
                {
                    textBoxPrice.Text = p.priceList.ToString() + "$";
                    textBoxProductID.Text = p.productID.ToString();
                }
            }
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
            string largePhotoFileName = route.Split('\\').Last();

            try
            {
                DataAccess.SaveImage(largePhotoFileName, imagePictureBox.Image);
                MessageBox.Show("Image inserted correctly", "Success", MessageBoxButtons.OK);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            
        }
    }
}
