using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace memo_1
{

    public partial class Form1 : Form
    {



        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern uint PostMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern uint ChatLoad(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern uint ChatUpdate(int hwnd, int wMsg, int wParam, int lParam);


        [DllImport("user32.dll")]
        public static extern uint Menu_Friend(int hwnd, int wMsg, int wParam, int lParam);



        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(int hWnd);


        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const Int32 VK_RETURN = 0x0D;
        const int VK_ENTER = 0x0D;
        const int VK_CONTROL = 0xA2;
        const int VK_A = 0x41;
        const int VK_C = 0x43;
        const int VK_V = 0x56;
        const int VK_SHIFT = 0x10;
        const int VK_TAB = 0x09;

        string target_title;

        //int msgCount = 0;

        public Form1()
        {
            InitializeComponent();

            this.friend_list_cbox.SelectedIndexChanged += friend_list_cbox_SelectedIndexChanged;
            load_list();

        }




        public void load_list()
        {
            friend_list_cbox.Items.Clear();

            StreamReader sr;
            sr = new StreamReader(System.Environment.CurrentDirectory + @"f_list.dat", Encoding.UTF8);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                friend_list_cbox.Items.Add(line);
            }
            sr.Close();

        }




        public void SendMessage(string title, string msg)
        {
            int hd01 = FindWindow(null, title);

            //SetForegroundWindow(hd01);
            int hd03 = FindWindowEx(hd01, 0, "RichEdit50W", "");
            SendMessage(hd03, 0x000c, 0, msg);
            PostMessage(hd03, 0x0100, 0xD, 0x1C001);
            System.Threading.Thread.Sleep(10);

        }


        public void ChatLoad()
        {
            //int hd01 = FindWindow(null, title);
            int hd01 = FindWindow(null, target_title);
            //SetForegroundWindow(hd01);
            int hd03 = FindWindowEx(hd01, 0, "EVA_VH_ListControl_Dblclk", "");
            int sleep_time = 10;

            //전체 선택
            PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("65", 16)), 0);
            System.Threading.Thread.Sleep(sleep_time);

            //복사
            PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("64", 16)), 0);
            System.Threading.Thread.Sleep(sleep_time);
                 
            //빈 곳 클릭
            PostMessage(hd03, 0x201, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
            PostMessage(hd03, 0x202, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
            System.Threading.Thread.Sleep(sleep_time);

            string orign_msg = this.chat_textbox.Text;
            string[] origin_chat = orign_msg.Split('\n');

            for (int i = 0; i < origin_chat.Length; i += 1)
                origin_chat[i] = origin_chat[i].Trim();

            List<string> org_chat = new List<string>(origin_chat);

            Console.WriteLine("----org_chat-------");

            foreach (string chat in org_chat)
                Console.WriteLine(chat);

            Console.WriteLine("----org_chat end-------");



            string msg = System.Windows.Forms.Clipboard.GetText();
            string[] copy_chat = msg.Split('\n');

            for (int i = 0; i < copy_chat.Length; i += 1)
                copy_chat[i] = copy_chat[i].Trim();

            List<string> cp_chat = new List<string>(copy_chat);


            Console.WriteLine("----cp_chat-------");

            foreach (string chat in cp_chat)
                Console.WriteLine(chat);

            Console.WriteLine("----cp_chat end-------");



            List<string> new_chat = cp_chat.Except(org_chat).ToList();


            Console.WriteLine("----new_chat-------");

            foreach (string chat in new_chat)
                Console.WriteLine(chat);

            foreach (string chat in new_chat)
                this.chat_textbox.AppendText(String.Join("\n", chat) + Environment.NewLine);
            Console.WriteLine("----new_chat end-------");



        }



        public void ChatUpdate()
        {
            if (this.chat_textbox.InvokeRequired)
            {

                while (true)
                {
                    //int hd01 = FindWindow(null, title);
                    int hd01 = FindWindow(null, target_title);
                    //SetForegroundWindow(hd01);
                    int hd03 = FindWindowEx(hd01, 0, "EVA_VH_ListControl_Dblclk", "");
                    int sleep_time = 10;

                    //전체 선택
                    PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("65", 16)), 0);
                    System.Threading.Thread.Sleep(sleep_time);
                    System.Threading.Thread.Sleep(500);

                    //복사
                    PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("64", 16)), 0);
                    System.Threading.Thread.Sleep(sleep_time);
                    System.Threading.Thread.Sleep(500);

                    //빈 곳 클릭
                    PostMessage(hd03, 0x201, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
                    PostMessage(hd03, 0x202, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
                    System.Threading.Thread.Sleep(500);
                    //int hd04 = FindWindow(null, target_title + " - Windows 메모장");
                    //SetForegroundWindow(hd04);

                    string orign_msg = this.chat_textbox.Text;
                    string[] origin_chat = orign_msg.Split('\n');

                    for (int i = 0; i < origin_chat.Length; i += 1)
                        origin_chat[i] = origin_chat[i].Trim();

                    List<string> org_chat = new List<string>(origin_chat);

                    Console.WriteLine("----org_chat-------");

                    foreach (string chat in org_chat)
                        Console.WriteLine(chat);

                    Console.WriteLine("----org_chat end-------");

                    System.Threading.Thread.Sleep(500);

                    string msg = System.Windows.Forms.Clipboard.GetText();
                    string[] copy_chat = msg.Split('\n');

                    for (int i = 0; i < copy_chat.Length; i += 1)
                        copy_chat[i] = copy_chat[i].Trim();

                    List<string> cp_chat = new List<string>(copy_chat);


                    Console.WriteLine("----cp_chat-------");

                    foreach (string chat in cp_chat)
                        Console.WriteLine(chat);

                    Console.WriteLine("----cp_chat end-------");



                    List<string> new_chat = cp_chat.Except(org_chat).ToList();

                    Console.WriteLine("----new_chat-------");

                    foreach (string chat in new_chat)
                        Console.WriteLine(chat);

                    foreach (string chat in new_chat)
                        this.chat_textbox.AppendText(String.Join("\n", chat) + Environment.NewLine);
                    Console.WriteLine("----new_chat end-------");

                    System.Threading.Thread.Sleep(1000);

                }

            }

        }

        public void Check_ChatRoom(string title)
        {
                
        }

        public void Menu_Friend()
        {
            int sleep_time = 10;

            int hd01 = FindWindow(null, "카카오톡");
            SetForegroundWindow(hd01);
            int hd02 = FindWindowEx(hd01, 0, "EVA_ChildWindow", "");
            System.Threading.Thread.Sleep(sleep_time);
            int hd03 = FindWindowEx(hd02, 0, "EVA_Window", "");
            System.Threading.Thread.Sleep(sleep_time);
            PostMessage(hd03, 0x201, (int)(Convert.ToInt64("0002044E", 16)), (int)(Convert.ToInt64("02010001", 16)));
            PostMessage(hd03, 0x202, (int)(Convert.ToInt64("0002044E", 16)), (int)(Convert.ToInt64("02010001", 16)));
            SendMessage(hd03, 0x000c, 0, "asd");
            System.Threading.Thread.Sleep(sleep_time);





            //int hd02 = FindWindowEx(hd01, 0, "EVA_ChildWindow", "");
            //int hd03 = FindWindowEx(hd02, 0, "EVA_Window", "");
            //int hd04 = FindWindowEx(hd03, 0, "Edit", "");

            //SendMessage(hd04, 0x000c, 0, "asd");
            //PostMessage(hd03, 0x0118, (int)(Convert.ToInt64("0000FFFF", 16)), (int)(Convert.ToInt64("00000118", 16)));


            //int hd01 = FindWindow(null, "카카오톡");
            //SetForegroundWindow(hd01);
            //int hd02 = FindWindowEx(hd01, 0, "EVA_ChildWindow", "");
            //int hd03 = FindWindowEx(hd02, 0, "EVA_Window", "");
            //int hd04 = FindWindowEx(hd)

            //PostMessage(hd03, 0x201, 00020096, 02010001);
            //PostMessage(hd03, 0x202, 00020096, 02010001);

            //PostMessage(hd02, 0x202, 00000201, (int)(Convert.ToInt64("003601C5",16)));

            System.Threading.Thread.Sleep(sleep_time);
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.TextLength > 0)
                {
                    if (friend_list_cbox.SelectedItem == null)
                    {
                        this.chat_textbox.Text += textBox1.Text + Environment.NewLine;
                    }

                    if (friend_list_cbox.SelectedItem != null)
                    {
                        SendMessage(friend_list_cbox.SelectedItem.ToString(), textBox1.Text);
                        
                        ChatLoad();
                        
                        //ChatUpdate();
                        
                        System.Threading.Thread.Sleep(10);

                        int hd04 = FindWindow(null, friend_list_cbox.SelectedItem.ToString() + " - Windows 메모장");
                        SetForegroundWindow(hd04);
                    }
                    this.textBox1.Clear();
                    
                }   
            }
        }

        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newform2 = new Form2(this);
            newform2.ShowDialog();
        }
                


        private void friend_list_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chat_textbox.Clear();
            if (friend_list_cbox.Items.Count >= 1)
            {
                this.Text = friend_list_cbox.SelectedItem.ToString() + " - Windows 메모장";
                target_title = friend_list_cbox.SelectedItem.ToString();

                ChatLoad();

                Thread th1 = new Thread(new ThreadStart(ChatUpdate));
                th1.Start();
                ChatUpdate();

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chat_textbox.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            int hd01 = FindWindow(null, target_title);
            //SetForegroundWindow(hd01);
            int hd03 = FindWindowEx(hd01, 0, "EVA_VH_ListControl_Dblclk", "");
            int sleep_time = 10;

            //전체 선택
            PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("65", 16)), 0);
            System.Threading.Thread.Sleep(sleep_time);

            //복사
            PostMessage(hd03, 0x07E9, (int)(Convert.ToInt64("64", 16)), 0);
            System.Threading.Thread.Sleep(sleep_time);

            //빈 곳 클릭
            PostMessage(hd03, 0x201, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
            PostMessage(hd03, 0x202, 00000002, (int)(Convert.ToInt64("002B0007", 16)));
            System.Threading.Thread.Sleep(sleep_time);

            //int hd04 = FindWindow(null, target_title + " - Windows 메모장");
            //SetForegroundWindow(hd04);

            string orign_msg = this.chat_textbox.Text;
            string[] origin_chat = orign_msg.Split('\n');

            for (int i = 0; i < origin_chat.Length; i += 1)
                origin_chat[i] = origin_chat[i].Trim();

            List<string> org_chat = new List<string>(origin_chat);

            Console.WriteLine("----org_chat-------");

            foreach (string chat in org_chat)
                Console.WriteLine(chat);

            Console.WriteLine("----org_chat end-------");



            string msg = System.Windows.Forms.Clipboard.GetText();
            string[] copy_chat = msg.Split('\n');

            for (int i = 0; i < copy_chat.Length; i += 1)
                copy_chat[i] = copy_chat[i].Trim();

            List<string> cp_chat = new List<string>(copy_chat);


            Console.WriteLine("----cp_chat-------");

            foreach (string chat in cp_chat)
                Console.WriteLine(chat);

            Console.WriteLine("----cp_chat end-------");



            List<string> new_chat = cp_chat.Except(org_chat).ToList();
           // List<string> new_chat = org_chat.Except(cp_chat).ToList();


            //if (new_chat.Count > 0)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}

            Console.WriteLine("----new_chat-------");

            foreach (string chat in new_chat)
                Console.WriteLine(chat);

            foreach (string chat in new_chat)
                this.chat_textbox.AppendText(String.Join("\n", chat) + Environment.NewLine);
            Console.WriteLine("----new_chat end-------");

            


        }
    }

}