using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetFormsApp
{
    public partial class SimpleGrocery : Form
    {
        public SimpleGrocery()
        {
            InitializeComponent();
        }

     

        ProductDal _products = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            getAll();
        }

        private void getAll()
        {
            dgwProducts.DataSource = _products.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _products.Add(new Product{
            Name = tbxName.Text,
            Price = Convert.ToDecimal(tbxPrice.Text),
            StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            getAll();
            MessageBox.Show("Məhsul Əlavə edildi!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product { 
            Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            Name = tbxNameUpdate.Text.ToString(),
            Price = Convert.ToDecimal(tbxPriceUpdate.Text),
            StockAmount = Convert.ToInt32(tbxStockUpdate.Text),
            };
            _products.Update(product);
            getAll();
            MessageBox.Show("Yeniləndi");
        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _products.Delete(id);
            getAll();
            MessageBox.Show("Silindi");
        }
    }
}
