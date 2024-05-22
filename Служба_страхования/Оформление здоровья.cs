using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Служба_страхования
{
    public partial class Оформление_здоровья : Form
    {
        db db = new db();
        public Оформление_здоровья(string usern)
        {
            InitializeComponent();
            textBox10.Text = usern;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void Banks(string p)
        {
            textBox11.Text = p;
        }

        public void Str(string p)
        {
            label14.Text = p;
        }

        public void zayav()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            string quere = $"select * from Здоровье";
            SqlCommand cmd = new SqlCommand(quere, db.con);
            adapter.SelectCommand = cmd;
            adapter.Fill(Table);
            db.con.Open();
            //если введены новые данные которые не существуют в бд, регистрация прошла успешно


            SqlCommand insertCommand = new SqlCommand($"insert into Здоровье(Аккаунт,Фамилия,Имя,Отчество,ДатаРождения,Регион,Город,Улица,Дом,СтроениеКорпус,Квартира,Услуга,Банк) values ('{textBox10.Text}','{textBox1.Text}','{textBox2.Text}', '{textBox3.Text}','{dateTimePicker1.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}','{textBox8.Text}','{textBox9.Text}','{label14.Text}','{textBox11.Text}')", db.con);
            if (insertCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Оформление прошло успешно!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }

            db.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                zayav();
            } 
            
        }
    }
}
