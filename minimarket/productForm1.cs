using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace minimarket
{
    public partial class productForm1 : Form
    {
        dbconnect dbcon = new dbconnect();
        public productForm1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void productForm1_Load(object sender, EventArgs e)
        {
            getcategory();
            gettabe();
        }
        private void getcategory()
        {

            string selectquerry = "select*from category";
            SqlCommand command = new SqlCommand(selectquerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_category.DataSource = table;
            comboBox_category.ValueMember = "catname";
            comboBox_search.DataSource = table;
            comboBox_search.ValueMember = "catname";
        }

        private void button_categories_Click(object sender, EventArgs e)
        {
            categoryForm1 category = new categoryForm1();
            category.Show();
            this.Hide();
        }
        private void gettabe()
        {
            string selectquerry = "select*from product";
            SqlCommand command = new SqlCommand(selectquerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;

        }
        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();
            textBox_price.Clear();
            textBox_quantity.Clear();
            comboBox_category.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ADD
            try
            {
                string insertquery = "insert into product values(" + textBox_id.Text + ",'" + textBox_name.Text + "'," + textBox_price.Text + "," + textBox_quantity.Text+ ",'" + comboBox_category.Text + "') ";
                SqlCommand command = new SqlCommand(insertquery, dbcon.GetCon());
                dbcon.opencon();
                command.ExecuteNonQuery();
                MessageBox.Show("product added succsesfully", "Add information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbcon.closecon();
                gettabe();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_price.Text == "" || textBox_quantity.Text == "")
                {
                    MessageBox.Show("missing information", "missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    string updatequery = "update product set prodname='" + textBox_name + "',prodprice=" + textBox_price.Text + ",prodqty=" + textBox_quantity.Text + ",prodcat='" + comboBox_category.Text + "'Where prodid=" + textBox_id.Text + "";
                    SqlCommand command = new SqlCommand(updatequery, dbcon.GetCon());
                    dbcon.opencon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("product update succsesfully", "update information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.closecon();
                    gettabe();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_product_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView_product_Click_1(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text = DataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            textBox_price.Text = DataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            textBox_quantity.Text = DataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
            comboBox_category.SelectedValue = DataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "")
                {
                    MessageBox.Show("missing information", "missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {


                    string deletequery = "delete from product where prodid=" + textBox_id.Text + "";
                    SqlCommand command = new SqlCommand(deletequery, dbcon.GetCon());
                    dbcon.opencon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("product deleted succsesfully", "delete information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.closecon();
                    gettabe();
                    clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            gettabe();
        }

        private void comboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string selectquerry = "select*from product where prodcat='"+comboBox_search.SelectedValue.ToString()+"'";
            SqlCommand command = new SqlCommand(selectquerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }

        private void label_logout_MouseEnter(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Red;
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Blue;
        }

        private void button_categories_MouseEnter(object sender, EventArgs e)
        {
            button_categories.ForeColor = Color.Red;
        }

        private void button_categories_MouseLeave(object sender, EventArgs e)
        {
            button_categories.ForeColor = Color.Blue;
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            loginForm1 login = new loginForm1();
            login.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            sellerForm seller = new sellerForm();
            seller.Show();
            this.Hide();
        }
    }
}
