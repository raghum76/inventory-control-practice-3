using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_control_practice
{
    public partial class frmMain : Form
    {
        private Inventory inventory = new Inventory();

        public frmMain()
        {
            InitializeComponent();

            /*
            inventory.add(new Product(1, 1.ToString(), 1, 1));
            inventory.add(new Product(2, 2.ToString(), 2, 2));
            inventory.add(new Product(3, 3.ToString(), 3, 3));
            inventory.add(new Product(4, 4.ToString(), 4, 4));
            inventory.add(new Product(5, 5.ToString(), 5, 5));
            */
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            inventory.add(new Product(int.Parse(txtCode.Text), txtName.Text, int.Parse(txtQuantity.Text), double.Parse(txtPrice.Text)));

            txtCode.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            txtReports.Text = inventory.report();
        }

        private void cmdRead_Click(object sender, EventArgs e)
        {
            Product product = inventory.search(txtSearch.Text);

            if (product != null)
                txtReports.Text = product.ToString();
            else
                MessageBox.Show("No se encontro el producto");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            inventory.delete(txtSearch.Text);
        }
    }
}
