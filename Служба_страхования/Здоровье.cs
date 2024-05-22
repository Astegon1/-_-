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

namespace Служба_страхования
{
    public partial class Здоровье : Form
    {
        public Здоровье(string username)

        {
            InitializeComponent();
            textBox1.Text = username;
        }
        //Задание как переменная для дальнейшего использования в коде
        public void UpdateControls(string labelText)
        {
            label.Text = labelText;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void Lak1(string label1Text)
        {
            label1.Text = label1Text;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void For1(string forms)
        {
            this.Text = forms;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void LoadImage(Image image)
        {
            pictureBox.Image = image;
        }

        public void Bank(string baba) 
        { 
            label2.Text = baba;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Оформление_здоровья z = new Оформление_здоровья(textBox1.Text);
            z.Show();
            z.Banks(label2.Text);
            z.Str(label.Text);
        }

 
    }
}
