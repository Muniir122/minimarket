namespace minimarket
{
    public partial class loginForm1 : Form
    {
        public loginForm1()
        {
            InitializeComponent();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }

        private void btncancel_MouseEnter(object sender, EventArgs e)
        {
            btnclear.ForeColor = Color.Green;
        }

        private void btncancel_MouseLeave(object sender, EventArgs e)
        {
            btnclear.ForeColor = Color.Yellow;
        }

        private void btnlogin_MouseEnter(object sender, EventArgs e)
        {
            btnlogin.ForeColor = Color.Green;
        }

        private void btnlogin_MouseLeave(object sender, EventArgs e)
        {
            btnlogin.ForeColor = Color.Red;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
         
            if (textBoxusername.Text == "")
            {
                MessageBox.Show("please enter username");
            }
            else if (textBox_password.Text=="")
            {
                MessageBox.Show("pleas4e enter password");
            }
            else
            {
                MessageBox.Show("login successfully");
            }
            productForm1 product = new productForm1();
            product.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            textBoxusername.Clear();
            textBox_password.Clear();
        }
    }
}