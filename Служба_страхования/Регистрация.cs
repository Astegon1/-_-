
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;


namespace Служба_страхования
{
    public partial class Form1 : Form
    {
        db db = new db();

        string UserLogin = "";
        string UserPass = "";
        string ScndName = "";
        string ThrdName = "";
        string Date_birth = "";
        string Phone = "";
        string Email = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScndName = textBox2.Text;
            Name = textBox3.Text;
            ThrdName = textBox4.Text;
            Date_birth = dateTimePicker1.Text;
            Phone = maskedTextBox1.Text;
            Email = textBox8.Text;
            UserLogin = textBox9.Text;
            UserPass = textBox1.Text;
            if (UserLogin == "" || UserPass == "" || ScndName == "" || Name == "" || ThrdName == "" || Date_birth == "" || Phone == "" || Email == "")
            {
                MessageBox.Show("Пожалуйста, введите логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            registration();
        }

        public void registration()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            string quere = $"select Логин,Пароль from клиенты where Логин='{UserLogin}'";
            SqlCommand cmd = new SqlCommand(quere, db.con);
            adapter.SelectCommand = cmd;
            adapter.Fill(Table);
            db.con.Open();
            //если введены новые данные которые не существуют в бд, регистрация прошла успешно
            if (Table.Rows.Count == 0)
            {
                SqlCommand insertCommand = new SqlCommand($"insert into клиенты(Логин,Пароль,Фамилия,Отчество,Дата_рождения,Имя,Телефон,Email) values ('{UserLogin}','{UserPass}', '{ScndName}','{ThrdName}', '{Date_birth}', '{Name}', '{Phone}', '{Email}')", db.con);
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Регистрация прошла успешно!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Авторизация r = new Авторизация();
                    r.Show();
                }
                //если введены существующие данные(которые есть в бд) будет ошибка
                else
                {
                    MessageBox.Show("Такой логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            db.con.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Авторизация avtr = new Авторизация();
            avtr.Show();
        }
    }
}
