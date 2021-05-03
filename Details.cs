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
        Button colorsButton = new Button();
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
                sizeButton.Text = product[i].size;
                sizeButton.Location = new Point(50 + x, 145);
                Controls.Add(sizeButton);
                x += 100;
            }
        }
    }
}
