using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ALP_Tim1_Nathan
{
    public partial class Form_Main : Form
    {
        string connectionString = "server=localhost; uid=root; pwd=; database=abc";
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuery;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
          
        }

        private void Link_Main_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Register form_Register = new Form_Register();
            this.Visible = false;
            form_Register.Show();
        }

        private void BTN_Main_Submit_Click(object sender, EventArgs e)
        {
            string username = TB_Main_username.Text;
            string password = TB_Main_Password.Text;

            sqlConnect = new MySqlConnection(connectionString);
            sqlQuery = $"SELECT COUNT(*) FROM customers WHERE username = '{username}' AND pass = '{password}';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);

            sqlCommand.Parameters.AddWithValue($"'{username}'", username);
            sqlCommand.Parameters.AddWithValue($"{password}", password);

            int count = (int)sqlCommand.ExecuteScalar();

            if (count > 0)
            {
                Form_MainMenu form_MainMenu = new Form_MainMenu();
                form_MainMenu.Show();
            }
            else
            {
                MessageBox.Show("Please enter the username / password correctly!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_MainMenu form_MainMenu = new Form_MainMenu();
            this.Visible = false;
            form_MainMenu.Show();
        }
    }
}
