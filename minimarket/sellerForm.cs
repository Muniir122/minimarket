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
    public partial class sellerForm : Form
    {
        dbconnect dbcon = new dbconnect();
        public sellerForm()
        {
            InitializeComponent();
        }


        private void gettabe()
        {
            string selectquerry = "select*from seller";
            SqlCommand command = new SqlCommand(selectquerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_seller.DataSource = table;

        }

        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();
            textBox_age.Clear();
            textBox_phone.Clear();
            textBox_password.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //add items
            try
            {
                string insertquery = "insert into seller values(" + textBox_id.Text + ",'" + textBox_name.Text + "','" + textBox_age.Text + "','" + textBox_phone.Text + "','" + textBox_password.Text + "') ";
                SqlCommand command = new SqlCommand(insertquery, dbcon.GetCon());
                dbcon.opencon();
                command.ExecuteNonQuery();
                MessageBox.Show("product added succsesfully", "Add information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbcon.closecon();
               gettabe();
                //clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sellerForm_Load(object sender, EventArgs e)
        {
            gettabe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_age.Text == "" ||textBox_phone.Text == ""||textBox_password.Text=="")
                {
                    MessageBox.Show("missing information", "missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    string updatequery = "update seller set sellername='" + textBox_name + "',sellerAge='" + textBox_age.Text + "',sellerPhone='" + textBox_phone.Text + "',sellerpass='" + textBox_password.Text + "'Where sellerid=" + textBox_id.Text + "";
                    SqlCommand command = new SqlCommand(updatequery, dbcon.GetCon());
                    dbcon.opencon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("seller update succsesfully", "update information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataGridView_seller_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_seller.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text= DataGridView_seller.SelectedRows[0].Cells[1].Value.ToString();
            textBox_age.Text= DataGridView_seller.SelectedRows[0].Cells[2].Value.ToString();
            textBox_phone.Text= DataGridView_seller.SelectedRows[0].Cells[3].Value.ToString();
            textBox_password.Text= DataGridView_seller.SelectedRows[0].Cells[4].Value.ToString();
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
                    if (MessageBox.Show("are you sure you want deletethis record?", "delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        string deletequery = "delete from seller where sellerid=" + textBox_id.Text + "";
                        SqlCommand command = new SqlCommand(deletequery, dbcon.GetCon());
                        dbcon.opencon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("seller deleted succsesfully", "delete information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbcon.closecon();
                        gettabe();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            loginForm1 login = new loginForm1();
            login.Show();
            this.Hide();
        }

        private void label_logout_MouseEnter(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Red;
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Blue;
        }

        private void button_product_Click(object sender, EventArgs e)
        {
            productForm1 product = new productForm1();
            product.Show();
            this.Hide();
        }

        private void button_categories_Click(object sender, EventArgs e)
        {
            categoryForm1 category = new categoryForm1();
            category.Show();
            this.Hide();
        }
    }
    }

