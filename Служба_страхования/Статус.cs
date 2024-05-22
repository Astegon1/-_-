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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Служба_страхования
{
    public partial class Статус : Form
    {
        db db = new db();
        public Статус(string name)
        {
            InitializeComponent();
            label1.Text = name;
        }


        private void Auto()
        {
            dataGridView1.Columns.Add("РегионРайон", "Регион район");
            dataGridView1.Columns.Add("Город", "Город");
            dataGridView1.Columns.Add("СТСПТС", "СТСПТС");
            dataGridView1.Columns.Add("VIN", "VIN");
            dataGridView1.Columns.Add("КатегорияТранспорта", "Категория транспорта");
            dataGridView1.Columns.Add("МаркаМодель", "Марка модель");
            dataGridView1.Columns.Add("ГодВыпуска", "Год выпуска");
            dataGridView1.Columns.Add("ЭксплуатацияАвтомобиля", "Эксплуатация автомобиля");
            dataGridView1.Columns.Add("Услуга", "Услуга");
            dataGridView1.Columns.Add("Банк", "Банк");
            dataGridView1.Columns.Add("Статус", "Статус");
        }

        private void Zdorov()
        {
            dataGridView2.Columns.Add("Фамилия", "Фамилия");
            dataGridView2.Columns.Add("Имя", "Имя");
            dataGridView2.Columns.Add("Отчество", "Отчество");
            dataGridView2.Columns.Add("ДатаРождения", "Дата рождения");
            dataGridView2.Columns.Add("Регион", "Регион");
            dataGridView2.Columns.Add("Город", "Город");
            dataGridView2.Columns.Add("Улица", "Улица");
            dataGridView2.Columns.Add("Дом", "Дом");
            dataGridView2.Columns.Add("СтроениеКорпус", @"Строение\Корпус");
            dataGridView2.Columns.Add("Квартира", "Квартира");
            dataGridView2.Columns.Add("Услуга", "Услуга");
            dataGridView2.Columns.Add("Банк", "Банк");
            dataGridView2.Columns.Add("Статус", "Статус");
        }

        private void Nedviz()
        {
            dataGridView3.Columns.Add("Город", "Город");
            dataGridView3.Columns.Add("Улица", "Улица");
            dataGridView3.Columns.Add("Дом", "Дом");
            dataGridView3.Columns.Add("СтроениеКорпус", @"Строение\Корпус");
            dataGridView3.Columns.Add("Квартира", "Квартира");
            dataGridView3.Columns.Add("Услуга", "Услуга");
            dataGridView3.Columns.Add("Банк", "Банк");
            dataGridView3.Columns.Add("Статус", "Статус");
        }

        private void AutoRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10));
        }

        private void ZdorovRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetDateTime(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9),record.GetString(10), record.GetString(11), record.GetString(12));
        }

        private void NedvizRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7));
        }

        // Функция для обновления данных в таблице
        private void RefreshAuto(DataGridView dgw)
        {
            // Очистка строк в таблице
            dgw.Rows.Clear();

            // Создание запроса для получения данных из таблицы CultInst для указанного пользователя
            string query = $"select РегионРайон, Город, СТСПТС, VIN, КатегорияТранспорта,МаркаМодель, ГодВыпуска, ЭксплуатацияАвтомобиля, Услуга, Банк, Статус from Автостраховка where Аккаунт = '{label1.Text}'";

            // Создание команды для выполнения запроса
            SqlCommand cmd = new SqlCommand(query, db.con);

            // Открытие соединения с базой данных
            db.con.Open();

            // Выполнение запроса и получение результата
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            // Чтение данных из результата и создание строк в таблице
            while (sqlDataReader.Read())
            {
                AutoRows(dgw, sqlDataReader);
            }

            // Закрытие соединения с базой данных
            sqlDataReader.Close();
            db.con.Close();
        }

        private void RefreshZdorov(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select Фамилия, Имя, Отчество, ДатаРождения, Регион,Город, Улица, Дом, СтроениеКорпус, Квартира,Услуга, Банк, Статус from Здоровье where Аккаунт = '{label1.Text}'";

            SqlCommand cmd = new SqlCommand(query, db.con);

            db.con.Open();

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ZdorovRows(dgw, sqlDataReader);
            }

            sqlDataReader.Close();
            db.con.Close();
        }

        private void RefreshNedviz(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select Город, Улица, Дом, СтроениеКорпус, Квартира,Услуга, Банк, Статус from Недвижимость where Аккаунт = '{label1.Text}'";

            SqlCommand cmd = new SqlCommand(query, db.con);

            db.con.Open();

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                NedvizRows(dgw, sqlDataReader);
            }

            sqlDataReader.Close();
            db.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Статус_Load(object sender, EventArgs e)
        {
            Auto();
            RefreshAuto(dataGridView1);

            Zdorov();
            RefreshZdorov(dataGridView2);

            Nedviz();
            RefreshNedviz(dataGridView3);   
        }
    }
}
