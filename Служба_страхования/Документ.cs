using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Служба_страхования
{
    public partial class Документ : Form
    {

        public Документ()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            string textToSave = textBox1.Text;
            Random r = new Random();

            string fileName = "Документ #" + r.Next(1000,1000000) + " " + DateTime.Now.ToString("yyyy-MM-dd h-m-s") + ".txt";

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            File.WriteAllText(filePath, textToSave);

            this.Hide();
        }
    }
}
