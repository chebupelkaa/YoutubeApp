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
using System.Xml.Linq;

namespace VideoApp
{
    public partial class collectionForm : Form
    {
        public collectionForm(string name,string url)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = url;
        }

        private void collectionForm_Load(object sender, EventArgs e)
        {

        }

        public void SaveToCollection(string name, string url)
        {
            if (!File.Exists("collection.txt"))
            {
                File.Create("collection.txt").Close();
            }
            using (StreamWriter writer = new StreamWriter("collection.txt", true))
            {
                writer.WriteLine($"{name};{url}");
            }
        }

        private void buttonSaveToCollection_Click(object sender, EventArgs e)
        {
            SaveToCollection(textBox1.Text, textBox2.Text);
        }
    }
}
