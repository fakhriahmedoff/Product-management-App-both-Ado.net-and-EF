using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _products = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void GetProducts()
        {
            dgwProducts.DataSource = _products.getAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _products.Add(new Product
            {
                Name = tbxName.Text.ToString(),
                Price = Convert.ToDecimal(tbxPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
            });
            GetProducts();
            MessageBox.Show("Elave edildi");
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _products.Update(new Product { 
            Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            Name = tbxNameUpdate.Text.ToString(),
            Price = Convert.ToDecimal(tbxPriceUpdate.Text),
            StockAmount= Convert.ToInt32(tbxStockUpdate.Text),
            });
            GetProducts();
            MessageBox.Show("Yenilendi");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _products.Delete(new Product
            {
            Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            MessageBox.Show("Silindi");
            GetProducts();
        }
    }
}
