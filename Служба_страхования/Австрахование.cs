using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Служба_страхования
{
    public partial class Австрахование : Form
    {
      
     
        public Австрахование(string username)

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
        public void Lak(string label1Text)
        {
            label1.Text = label1Text;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void For(string forms)
        {
            this.Text = forms;

        }
        //Задание как переменная для дальнейшего использования в коде
        public void LoadImage(Image image)
        {
            pictureBox.Image = image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Оформление a = new Оформление(textBox1.Text);
            a.Show();
            a.Banks(label2.Text);
            a.Str(label.Text);
        }

        public void Bank(string label1Text)
        {
            label2.Text = label1Text;
        }
    }
}
