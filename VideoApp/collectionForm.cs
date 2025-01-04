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
        public event Action<string> UrlSelected;
        public collectionForm(Video video)
        {
            InitializeComponent();
            LoadCollection();
            textBox1.Text = video.Title;
            textBox2.Text = video.Url;
            this.Icon = new Icon("youtube-icon2.ico");
        }

        private void LoadCollection()
        {
            listBox1.Items.Clear();
            if (File.Exists("collection.txt"))
            {
                var lines = File.ReadAllLines("collection.txt");
                foreach (var line in lines)
                {
                    listBox1.Items.Add(line); 
                }
            }
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
            //MessageBox.Show("Видео добавлено в коллекцию");
            LoadCollection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                SaveCollection();
                LoadCollection();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите видео для удаления.");
            }
        }
        private void SaveCollection()
        {
            File.WriteAllLines("collection.txt", listBox1.Items.Cast<string>());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("collection.txt", string.Empty);
            LoadCollection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItem = listBox1.SelectedItem.ToString();
                var url = selectedItem.Split(';')[1];
                UrlSelected?.Invoke(url);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите видео для просмотра.");
            }
        }


    }
}
