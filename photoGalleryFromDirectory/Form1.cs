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

namespace photoGalleryFromDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ImageGallery
        {
            public List<string> images = new List<string>();
            public ImageGallery() { }
           
            public void AddImage(string image) { images.Add(image); }
            public void RemoveImage(string image) { images.Remove(image); }
            public string GetImage(int index) { return images[index]; }
            public int counter = 0;
            public int current = 0;

           

        }
        public DirectoryInfo dinf;
        public IEnumerable<FileInfo> infos;

        public ImageGallery ig = new ImageGallery();

        public void search()
        {
            foreach (FileInfo info in infos)
            {

                this.textBox1.Text += info.Name;
                this.textBox1.Text += "\r\n";
                ig.AddImage(info.Name.ToString());



                ig.counter++;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.Text = this.folderBrowserDialog1.SelectedPath.ToString();
            dinf = new DirectoryInfo(this.folderBrowserDialog1.SelectedPath);









            infos = dinf.EnumerateFiles("*.png");
            this.textBox1.Text += "\r\n";
            search();
            infos = dinf.EnumerateFiles("*.jpeg");
            this.textBox1.Text += "\r\n";
            search();
            infos = dinf.EnumerateFiles("*.jpg");
            this.textBox1.Text += "\r\n";
            search();
            infos = dinf.EnumerateFiles("*.gif");
            this.textBox1.Text += "\r\n";
            search();
            infos = dinf.EnumerateFiles("*.bmp");
            this.textBox1.Text += "\r\n";
            search();






            this.Text = Application.ExecutablePath;


            for (int i = 0; i < ig.counter; i++)
            {
                ig.images.Add(ig.images[i]);
            }

            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.BackgroundImage = Image.FromFile(dinf + "\\" + ig.images[0]); 
            ig.current = 0;

            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ig.current == 0)
            {
                ig.current = ig.counter;
            }
            else
            {
                ig.current--;
            }

            try
            {
                this.pictureBox1.BackgroundImage = Image.FromFile(dinf + "\\" + ig.images[ig.current]); 
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ig.current == ig.counter)
            {
                ig.current = 0;
            }
            else
            {
                ig.current++;
            }
            try
             {
                this.pictureBox1.BackgroundImage = Image.FromFile(dinf + "\\" + ig.images[ig.current]);
            }
            catch { }
        }
    }
}
