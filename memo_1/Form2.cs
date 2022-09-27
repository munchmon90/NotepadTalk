using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace memo_1
{
    public partial class Form2 : Form
    {
        Form1 frm1;
        public Form2(Form1 _form)
        {
            InitializeComponent();
            frm1 = _form;
            this.ActiveControl = add_friend;

            load_list();

        }



        public void load_list()
        {
            StreamReader sr;
            sr = new StreamReader(System.Environment.CurrentDirectory + "f_list.dat", Encoding.UTF8);
            
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                friend_list.Items.Add(line);
            }
            sr.Close();

        }

        private void add_friend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (add_friend.Text.Length > 0)
                {
                    add_btn_Click(sender, e);
                }
                
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (add_friend.Text.Length > 0)
            {
                this.friend_list.Items.Add(add_friend.Text);
                this.add_friend.Clear();
            }
            
        }

        private void rm_btn_Click(object sender, EventArgs e)
        {
            if (this.friend_list.Items.Count > 0)
            {
                this.friend_list.Items.RemoveAt(friend_list.SelectedIndex);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            save_list();
            this.Close();
            frm1.load_list();
        }

        public void save_list()
        {
            StreamWriter sw;
            sw = new StreamWriter(System.Environment.CurrentDirectory + "f_list.dat");
            
            int nCount = friend_list.Items.Count;
            for (int i = 0; i < nCount; i++)
            {
                sw.WriteLine(friend_list.Items[i].ToString());
            }
            sw.Close();

            
        }
    }
}
