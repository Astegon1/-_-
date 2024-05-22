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
    public partial class Недвижимость : Form
    {
       
        public Недвижимость(string usern)
        {
            InitializeComponent();
            textBox1.Text = usern;
        }
        //Задание как переменная для дальнейшего использования в коде
        public void UpdateControls(string labelText)
        {
            label.Text = labelText;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void Lak2(string label1Text)
        {
            label1.Text = label1Text;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void For2(string forms)
        {
            this.Text = forms;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void LoadImage(Image image)
        {
            pictureBox.Image = image;
        }

        public void Bank(string bebe) 
        {
            label2.Text = bebe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Оформление_недвижимости i = new Оформление_недвижимости(textBox1.Text);
            i.Show();
            i.Banks(label2.Text);
            i.Str(label.Text);
        }


    }
}
