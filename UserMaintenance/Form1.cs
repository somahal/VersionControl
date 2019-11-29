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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label2.Text = Resource1.FullName; // label1
            button1.Text = Resource1.Add; // button1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
            button2.Text = Resource1.Save;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox2.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            using(StreamWriter sw =new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var item in users)
                {
                    sw.Write(item.ID);
                    sw.Write(';');
                    sw.Write(item.FullName);
                    sw.WriteLine();
                }
            }
        }
    }
}
