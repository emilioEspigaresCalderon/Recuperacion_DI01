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
    public partial class Details : Form
    {
        public int id;
        List<Products> product = new List<Products>();
        string[] sizes;
        string[] colors;
        public Details(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            product = da.GetProducts(id);

            textBoxName.Text = product[0].ProductModel;
            textBoxDescription.Text = product[0].description;
            textBoxPrice.Text = product[0].priceList.ToString() + "$";

            textBoxName.ReadOnly = true;
            textBoxDescription.ReadOnly = true;
            textBoxPrice.ReadOnly = true;

            int numProducts = product.Count;
            sizes = new string[numProducts];
            colors = new string[numProducts];

            for (int i = 0; i < numProducts; i++)
            {
                sizes[i] = product[i].size;
                colors[i] = product[i].color;
            }
            
            createButtons();
        }

        public void createButtons()
        {
            int x = 20;
            for (int i = 0; i < product.Count; i++)
            {
                Button sizeButton = new Button();
                Button colorButton = new Button();

                if ((i == 0) || (product[i].size != product[i - 1].size))
                {
                    if (product[i].size == null)
                        sizeButton.Text = "NULL";
                    else
                        sizeButton.Text = product[i].size;

                    sizeButton.Location = new Point(50 + x, 100);
                    Controls.Add(sizeButton);
                }

                if ((i == 0) || (product[i].color != product[i - 1].color))
                {
                    if (product[i].color == null)
                        colorButton.Text = "NULL";
                    else
                        colorButton.Text = product[i].color;

                    colorButton.Location = new Point(50 + x, 140);
                    Controls.Add(colorButton);
                }
                x += 100;
            }
        }
    }
}
