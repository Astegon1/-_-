using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Служба_страхования
{
    public partial class Оформление_недвижимости : Form
    {
        db db = new db();
        public Оформление_недвижимости(string usern)
        {
            InitializeComponent();
            textBox6.Text = usern;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void Banks(string p)
        {
            textBox7.Text = p;
        }

        public void Str(string p)
        {
            label3.Text = p;
        }

        public void zayav()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            string quere = $"select * from Недвижимость";
            SqlCommand cmd = new SqlCommand(quere, db.con);
            adapter.SelectCommand = cmd;
            adapter.Fill(Table);
            db.con.Open();
            //если введены новые данные которые не существуют в бд, регистрация прошла успешно


            SqlCommand insertCommand = new SqlCommand($"insert into Недвижимость(Аккаунт,Город,Улица,Дом,СтроениеКорпус,Квартира,Услуга,Банк) values ('{textBox6.Text}','{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{label3.Text}','{textBox7.Text}')", db.con);
            if (insertCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Оформление прошло успешно!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }

            db.con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
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
