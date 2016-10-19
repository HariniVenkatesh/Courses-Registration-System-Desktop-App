﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBproject
{
    public partial class Login : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmd = new MySqlCommand("select count(*) from employee where firstname =@user and pword = @pass ;", con);
                cmd.Parameters.AddWithValue("user", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                if (count > 0 )
                {
                    //MessageBox.Show("Success");
                    Form1 f = new Form1();
                    Hide();
                    f.ShowDialog();
                    //Close();                                
                }
                else
                    MessageBox.Show("User name or password is wrong"); 
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {            
            con = new MySqlConnection("server=localhost;database=coursessystem;uid=root;pwd=root");
            con.Open();
            textBox2.PasswordChar = ' ';
        }
    }
}
