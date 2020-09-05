using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Bild *.jpg;|*.jpg";
            ofd.Title = "Bildwahl";
            
            string dateiname = String.Empty;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dateiname = ofd.FileName;
                string newPath = "Bilder\\" + textBox1.Text + ".jpg";
                int i = 0;

                while (File.Exists(newPath))
                {                   
                    newPath = "Bilder\\" + textBox1.Text + i.ToString() + ".jpg";
                    i++;
                }

                label1.Text = newPath;
                File.Copy(dateiname, newPath); // oder: File.Move()
                pictureBox1.Image = Image.FromFile(newPath);
                
            }
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string[] fnarr = fileList[0].Split('\\');

            if (fnarr[fnarr.Length - 1].ToLower().Contains(".jpg"))
            {
                string dateiname = fileList[0];
                string newPath = "Bilder\\" + textBox1.Text + ".jpg";
                int i = 0;

                while (File.Exists(newPath))
                {
                    newPath = "Bilder\\" + textBox1.Text + i.ToString() + ".jpg";
                    i++;
                }

                label1.Text = newPath;
                File.Copy(dateiname, newPath); // oder: File.Move()
                pictureBox1.Image = Image.FromFile(newPath);
            }
              

        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
