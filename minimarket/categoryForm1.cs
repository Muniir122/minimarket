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
    public partial class categoryForm1 : Form
    {
        dbconnect dbcon = new dbconnect();
        public categoryForm1()
        {
            InitializeComponent();
            
        }
        private void gettable()
        {
            string selectquerry = "select*from category";
            SqlCommand command = new SqlCommand(selectquerry,dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_categorym.DataSource = table;
        }
        private void categoryForm1_Load(object sender, EventArgs e)
        {
            gettable();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_description.Text == "")
                {
                    MessageBox.Show("missing information", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updatequery = "update category set catname='" + textBox_name.Text + "',catdes='" + textBox_description.Text + "'WHERE catId =" + textBox_id.Text + "  ";
                    SqlCommand command = new SqlCommand(updatequery, dbcon.GetCon());
                    dbcon.opencon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("caregory update succsesfully", "update information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.closecon();
                    gettable();
                    clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertequery = "insert into category values(" + textBox_id.Text + ",'" + textBox_name.Text + "','" + textBox_description.Text + "');";
                SqlCommand command = new SqlCommand(insertequery,dbcon.GetCon());
                dbcon.opencon();
                command.ExecuteNonQuery();
                MessageBox.Show("caregory added succsesfully","Add information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dbcon.closecon();
                gettable();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridView_category_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_category.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text= DataGridView_category.SelectedRows[0].Cells[1].Value.ToString();
            textBox_description.Text= DataGridView_category.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();
            textBox_description.Clear();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string deletequery = "delete from category where catId=" + textBox_id.Text + "";
                SqlCommand command = new SqlCommand(deletequery, dbcon.GetCon());
                dbcon.opencon();
                command.ExecuteNonQuery();
                MessageBox.Show("caregory deleted succsesfully", "delete information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbcon.closecon();
                gettable();
                clear();
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label__logout_MouseEnter(object sender, EventArgs e)
        {
            label__logout.ForeColor = Color.Black;

        }

        private void label__logout_MouseLeave(object sender, EventArgs e)
        {
            label__logout.ForeColor = Color.Red;
        }

        private void label__logout_Click(object sender, EventArgs e)
        {
            loginForm1 login = new loginForm1();
            login.Show();
            this.Hide();
        }

        private void button_categories_Click(object sender, EventArgs e)
        {
            productForm1 product = new productForm1();
            product.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button_selling_Click(object sender, EventArgs e)
        {

        }

        private void button_seller_Click(object sender, EventArgs e)
        {

        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button_selling_Click_1(object sender, EventArgs e)
        {

        }

        private void button_seller_Click_1(object sender, EventArgs e)
        {
            sellerForm seller = new sellerForm();
            seller.Show();
            this.Hide();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox_description_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_id_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void DataGridView_categorym_Click(object sender, EventArgs e)
        {
        }
    }
}
