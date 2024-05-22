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
    public partial class Оформление: Form
    {
        db db = new db();
        string region = "";
        string gorod = "";
        string stspts = "";
        string vin = "";
        string kategor = "";
        string marka = "";
        string god = "";
        string expluat = "";
        public Оформление(string usern)
        {
            InitializeComponent();
            textBox8.Text = usern;

        }
        public void zayav()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            string quere = $"select * from Автостраховка";
            SqlCommand cmd = new SqlCommand(quere, db.con);
            adapter.SelectCommand = cmd;
            adapter.Fill(Table);
            db.con.Open();
            //если введены новые данные которые не существуют в бд, регистрация прошла успешно
           
           
                SqlCommand insertCommand = new SqlCommand($"insert into Автостраховка(Аккаунт,РегионРайон,Город,СТСПТС,VIN,КатегорияТранспорта,МаркаМодель,ГодВыпуска,ЭксплуатацияАвтомобиля,Услуга,Банк) values ('{textBox8.Text}','{region}','{gorod}', '{stspts}','{vin}', '{kategor}', '{marka}', '{god}', '{expluat}','{label10.Text}','{textBox10.Text}')", db.con);
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Оформление прошло успешно!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            
            db.con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            region = textBox1.Text;
            gorod = textBox2.Text;
            stspts = textBox3.Text;
            vin = textBox4.Text;
            kategor = textBox6.Text;
            marka = textBox7.Text;
            god = dateTimePicker1.Text;
            expluat = textBox9.Text;
            if (region == "" || gorod == "" || stspts == "" || Name == "" || vin == "" || kategor == "" || marka == "" || god == "" || expluat == "")
            {
                MessageBox.Show("Пожалуйста, заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                zayav();
            }
        }

        public void Banks(string p)
        {
            textBox10.Text = p;
        }

        public void Str(string p)
        {
            label10.Text = p;
        }
    }
}
