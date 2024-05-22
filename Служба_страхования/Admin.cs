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
    public partial class Admin : Form
    {
        db db = new db();
        public Admin()
        {
            InitializeComponent();
        }

        
        int selectedrows;

        public void c(object sender, DataGridViewCellEventArgs e)
        {
            selectedrows = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedrows];

                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Выбрано пустое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox2.Text = row.Cells[0].Value.ToString();
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            c(sender, e);
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public DataGridViewRow row;
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                row = dataGridView4.Rows[selectedrows];
                Документ d = new Документ();
                d.textBox1.Text = $"Уважаемый/ая {row.Cells["к.Фамилия"].Value.ToString()} {row.Cells["к.Имя"].Value.ToString()} {row.Cells["к.Отчество"].Value.ToString()},\r\n\r\nПожалуйста, посетите ближайшее отделение {row.Cells["Банк"].Value.ToString()} для подтверждения страхового покрытия,\nпо поданной заявки с идентификационным номером {row.Cells["id"].Value.ToString()} \r\n\r\nПринесите с собой подтверждающие документы, такие как полис страхования, паспорт, СНИЛС.\r\n\r\nЭто необходимо для подтверждения вашего страхового покрытия\nв рамках процесса утверждения по услуге {row.Cells["Услуга"].Value.ToString()}\r\n\r\nСпасибо за сотрудничество.\r\n\r\nС уважением,\r\nСлужба страхования «Нотокуктус»\r\n";
                d.ShowDialog();
                PRY();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                row = dataGridView5.Rows[selectedrows];
                Документ d = new Документ();
                d.textBox1.Text = $"Уважаемый/ая {row.Cells["Фамилия"].Value.ToString()} {row.Cells["Имя"].Value.ToString()} {row.Cells["Отчество"].Value.ToString()},\r\n\r\nПожалуйста, посетите ближайшее отделение {row.Cells["Банк"].Value.ToString()} для подтверждения страхового покрытия,\nпо поданной заявки c идентификационным номером {row.Cells["id"].Value.ToString()} \r\n\r\nПринесите с собой подтверждающие документы, такие как полис страхования, паспорт, СНИЛС.\r\n\r\nЭто необходимо для подтверждения вашего страхового покрытия\nв рамках процесса утверждения по услуге {row.Cells["Услуга"].Value.ToString()}\r\n\r\nСпасибо за сотрудничество.\r\n\r\nС уважением,\r\nСлужба страхования «Нотокуктус»\r\n";
                d.ShowDialog();
                PRY();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                row = dataGridView6.Rows[selectedrows];
                Документ d = new Документ();
                d.textBox1.Text =  $"Уважаемый/ая {row.Cells["к.Фамилия"].Value.ToString()} {row.Cells["к.Имя"].Value.ToString()} {row.Cells["к.Отчество"].Value.ToString()},\r\n\r\nПожалуйста, посетите ближайшее отделение {row.Cells["Банк"].Value.ToString()} для подтверждения страхового покрытия,\n по поданной заявки с идентификационным номером {row.Cells["id"].Value.ToString()} \r\n\r\nПринесите с собой подтверждающие документы, такие как полис страхования, паспорт, СНИЛС.\r\n\r\nЭто необходимо для подтверждения вашего страхового покрытия\nв рамках процесса утверждения по услуге {row.Cells["Услуга"].Value.ToString()}\r\n\r\nСпасибо за сотрудничество.\r\n\r\nС уважением,\r\nСлужба страхования «Нотокуктус»\r\n";
                d.ShowDialog();
                PRY();
            }
        }

        public void Auto()
        {
            dataGridView4.Columns.Add("id", "id");
            dataGridView4.Columns.Add("к.Фамилия", "Фамилия");
            dataGridView4.Columns.Add("к.Имя", "Имя");
            dataGridView4.Columns.Add("к.Отчество", "Отчество");
            dataGridView4.Columns.Add("РегионРайон", "Регион район");
            dataGridView4.Columns.Add("Город", "Город");
            dataGridView4.Columns.Add("СТСПТС", "СТСПТС");
            dataGridView4.Columns.Add("VIN", "VIN");
            dataGridView4.Columns.Add("КатегорияТранспорта", "Категория транспорта");
            dataGridView4.Columns.Add("МаркаМодель", "Марка модель");
            dataGridView4.Columns.Add("ГодВыпуска", "Год выпуска");
            dataGridView4.Columns.Add("ЭксплуатацияАвтомобиля", "Эксплуатация автомобиля");
            dataGridView4.Columns.Add("Услуга", "Услуга");
            dataGridView4.Columns.Add("Банк", "Банк");
            dataGridView4.Columns.Add("Статус", "Статус");

        }

        public void Zdorov()
        {
            dataGridView5.Columns.Add("id", "id");
            dataGridView5.Columns.Add("Фамилия", "Фамилия");
            dataGridView5.Columns.Add("Имя", "Имя");
            dataGridView5.Columns.Add("Отчество", "Отчество");
            dataGridView5.Columns.Add("ДатаРождения", "Дата рождения");
            dataGridView5.Columns.Add("Регион", "Регион");
            dataGridView5.Columns.Add("Город", "Город");
            dataGridView5.Columns.Add("Улица", "Улица");
            dataGridView5.Columns.Add("Дом", "Дом");
            dataGridView5.Columns.Add("СтроениеКорпус", @"Строение\Корпус");
            dataGridView5.Columns.Add("Квартира", "Квартира");
            dataGridView5.Columns.Add("Услуга", "Услуга");
            dataGridView5.Columns.Add("Банк", "Банк");
            dataGridView5.Columns.Add("Статус", "Статус");
        }

        public void Nedviz()
        {
            dataGridView6.Columns.Add("id", "id");
            dataGridView6.Columns.Add("к.Фамилия", "Фамилия");
            dataGridView6.Columns.Add("к.Имя", "Имя");
            dataGridView6.Columns.Add("к.Отчество", "Отчество");
            dataGridView6.Columns.Add("Город", "Город");
            dataGridView6.Columns.Add("Улица", "Улица");
            dataGridView6.Columns.Add("Дом", "Дом");
            dataGridView6.Columns.Add("СтроениеКорпус", @"Строение\Корпус");
            dataGridView6.Columns.Add("Квартира", "Квартира");
            dataGridView6.Columns.Add("Услуга", "Услуга");
            dataGridView6.Columns.Add("Банк", "Банк");
            dataGridView6.Columns.Add("Статус", "Статус");
        }

        private void AutoRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), record.GetString(13), record.GetString(14));
        }

        private void ZdorovRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), record.GetString(13));
        }

        private void NedvizRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11));
        }

        // Функция для обновления данных в таблице
        private void RefreshAuto(DataGridView dgw)
        {
            // Очистка строк в таблице
            dgw.Rows.Clear();

            // Создание запроса для получения данных из таблицы CultInst для указанного пользователя
            string query = $"select а.id,к.Фамилия,к.Имя,к.Отчество,а.РегионРайон, а.Город, а.СТСПТС, а.VIN, а.КатегорияТранспорта,а.МаркаМодель, а.ГодВыпуска, а.ЭксплуатацияАвтомобиля, а.Услуга, а.Банк, а.Статус from Автостраховка а, Клиенты к where к.Логин = а.Аккаунт";

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

            string query = $"select id,Фамилия, Имя, Отчество, ДатаРождения, Регион,Город, Улица, Дом, СтроениеКорпус, Квартира,Услуга, Банк, Статус from Здоровье";

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

            string query = $"select н.id,к.Фамилия,к.Имя,к.Отчество,н.Город, н.Улица, н.Дом, н.СтроениеКорпус, н.Квартира,н.Услуга, н.Банк, н.Статус from Недвижимость н, клиенты к where к.Логин = н.Аккаунт";

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

        private void PR()
        {
            if (textBox2.Text == "")
            {
                Exception ex = new Exception();
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            else
            {
                string query = $"update {label2.Text} set Статус = 'Отказано' where id = '{textBox2.Text}'";

                SqlCommand command = new SqlCommand(query, db.con);

                try
                {
                    db.con.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    db.con.Close();
                }
                catch (Exception ex)
                {
                    // Отображение сообщения об ошибке в случае возникновения исключения
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                RefreshAuto(dataGridView4);
                RefreshZdorov(dataGridView5);
                RefreshNedviz(dataGridView6);
            }
        }

        private void PRY()
        {
            if (textBox2.Text == "")
            {
                Exception ex = new Exception();
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            else
            {
                string query = $"update {label2.Text} set Статус = 'Одобрено' where id = '{textBox2.Text}'";

                SqlCommand command = new SqlCommand(query, db.con);

                try
                {
                    db.con.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    db.con.Close();
                }
                catch (Exception ex)
                {
                    // Отображение сообщения об ошибке в случае возникновения исключения
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                RefreshAuto(dataGridView4);
                RefreshZdorov(dataGridView5);
                RefreshNedviz(dataGridView6);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PR();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            label2.Text = tabControl1.SelectedTab.Text;

            Auto();
            RefreshAuto(dataGridView4);

            Zdorov();
            RefreshZdorov(dataGridView5);

            Nedviz();
            RefreshNedviz(dataGridView6);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrows = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView6.Rows[selectedrows];

                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Выбрано пустое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox2.Text = row.Cells[0].Value.ToString();
                }
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrows = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[selectedrows];

                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Выбрано пустое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox2.Text = row.Cells[0].Value.ToString();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = tabControl1.SelectedTab.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Авторизация авторизация = new Авторизация();
            авторизация.ShowDialog();
        }
    }
}

