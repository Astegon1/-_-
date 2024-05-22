using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Служба_страхования
{
    public partial class Авторизация : Form
    {
        db db = new db();
        public Авторизация()
        {
            InitializeComponent();
        }
        string UserLogin = "";
        string UserPass = "";
        public string username;

        private void login()
        {
           username = textBox1.Text;
            //подключение к бд
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string quere = $"select Логин, Пароль from клиенты where Логин='{UserLogin}' and Пароль='{UserPass}'";
            SqlCommand command = new SqlCommand(quere, db.con);
            adapter.SelectCommand = command;
            adapter.Fill(Table);
            //условие входа( если данные из бд совпадают с данным введенными в textbox, вход успешен)
            if (Table.Rows.Count == 1)
            {

                MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //если в поля авторизации были введены данные admin, происходит вход в аккаунт админа
                if (UserLogin == "admin")
                {
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    СписокСтраховок r = new СписокСтраховок(username);
                    r.Show();
                }

                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                this.Hide();
                db.con.Close();

            }             //если данные аккаунта не совпадают с существующими данными в бд,вход не будет совершен
            else
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin = textBox1.Text;
            UserPass = textBox2.Text;

            if (UserLogin == "" || UserPass == "")
            {
                MessageBox.Show("Пожалуйста, введите логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            login();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 reg = new Form1();
            reg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Авторизация_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }
    }
}
