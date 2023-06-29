

using Microsoft.Win32;
using Picture;
using System.IO;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ComperePictures comperePictures = new ComperePictures();

        public Form1(bool autoStart)
        {
            comperePictures.setAutoStart(autoStart);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            comperePictures.setPictureList();
            comperePictures.comperePictures();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                textbox_path.Text = path;
                comperePictures.setPath(path);
            }
        }

        private void init()
        {
            textbox_path.Text = comperePictures.initPath();
            textBox_maxCount.Text = comperePictures.initMaxCount().ToString();
        }

        private void textBox_maxCount_TextChanged(object sender, EventArgs e)
        {
            comperePictures.setMaxCount(int.Parse(textBox_maxCount.Text));
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            comperePictures.keyClose();
        }

        private void textBox_maxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }
    }
}