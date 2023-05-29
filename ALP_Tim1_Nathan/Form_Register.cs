using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using MySql;
using MySql.Data.MySqlClient;

namespace ALP_Tim1_Nathan
{
    public partial class Form_Register : Form
    {
        string connectionString = "server=localhost; uid=root; pwd=; database=abc";
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        MySqlDataReader reader;
        string sqlQuery;
        DataTable registered = new DataTable();

        int id_customers = 0;
        public Form_Register()
        {
            InitializeComponent();
        }

        private void Link_Main_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Main form_main = new Form_Main();
            this.Visible = false;
            form_main.Show();
        }

        private void BTN_Main_Submit_Click(object sender, EventArgs e)
        {
            string email;
            string username;
            string password;

            email = TB_Register_Email.Text;
            username = TB_Register_username.Text;
            password = TB_Register_Password.Text;

            if (string.IsNullOrEmpty(TB_Register_Email.Text) || string.IsNullOrEmpty(TB_Register_Password.Text) || string.IsNullOrEmpty(TB_Register_username.Text))
            {
                MessageBox.Show("Please fill the empty textbox!");
            }
            else
            {
                sqlQuery = $"insert into customers (customer_id, email, username, pass) values ('{id_customers + 1}', '{email}', '{username}', '{password}');";
                sqlConnect = new MySqlConnection(connectionString);
                sqlConnect.Open();  
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                reader = sqlCommand.ExecuteReader();
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(registered);



                TB_Register_Email.Clear();
                TB_Register_username.Clear();
                TB_Register_Password.Clear();
                MessageBox.Show(username + "'s" + " account Saved.");
                id_customers += 1;
            }

        }

        private void BTN_Register_Password_Hide_Click(object sender, EventArgs e)
        {
            if (TB_Register_Password.PasswordChar == '\0')
            {
                BTN_Register_Password_Show.BringToFront();
                TB_Register_Password.PasswordChar = '*';
            }
        }

        private void BTN_Register_Password_Show_Click_1(object sender, EventArgs e)
        {
            if (TB_Register_Password.PasswordChar == '*')
            {
                BTN_Register_Password_Hide.BringToFront();
                TB_Register_Password.PasswordChar = '\0';
            }
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {

        }
    }
}
