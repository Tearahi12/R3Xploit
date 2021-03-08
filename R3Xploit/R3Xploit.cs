using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Api
using EasyExploits;
using ShadowCheats;
using OxygenU_API;
using ApiModule;

namespace R3Xploit
{
    public partial class R3Xploit : Form
    {
        EasyExploits.Module module = new EasyExploits.Module(); //EasyExploits
        ShadowCheats.Module shadow = new ShadowCheats.Module(); //ShadowCheats
        OxygenU_API.Client oxygen = new OxygenU_API.Client(); //OxygenU
        ApiModule.Module proxo = new ApiModule.Module(); //Proxo

        //Sona One Start
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
        int dwDesiredAccess,
        bool bInheritHandle,
        int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(
          IntPtr hProcess,
          IntPtr lpAddress,
          uint dwSize,
          uint flAllocationType,
          uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          byte[] lpBuffer,
          uint nSize,
          out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(
          IntPtr hProcess,
          IntPtr lpThreadAttributes,
          uint dwStackSize,
          IntPtr lpStartAddress,
          IntPtr lpParameter,
          uint dwCreationFlags,
          IntPtr lpThreadId);
        //Sona One End

        public R3Xploit()
        {
            InitializeComponent();
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Fungsi.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Fungsi.PopulateListBox(listBox1, "./Scripts", "*.lua");


            //search
            listcollection.Clear();
            foreach(string str in listBox1.Items)
            {
                listcollection.Add(str);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel6.SendToBack();
            panel6.Visible = false;
            panel5.Visible = true; 
            panel5.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.SendToBack();
            panel5.Visible = false;
            panel6.Visible = true;
            panel6.BringToFront();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            //Application.Exit();
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Height -= 5;
            if (this.Height <=11)
            {
                timer1.Stop();
            }
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Width -= 10;
            if (this.Width <= 11)
            {
                timer2.Stop();
                Application.Exit();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer3.Stop();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    module.ExecuteScript(fastColoredTextBox1.Text); //EasyExploits
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    shadow.ExecuteScript(fastColoredTextBox1.Text); //ShadowCheats
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton3.Checked)
            {
                try
                {
                    if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
                    {
                        NamedPipes.LuaPipe(this.fastColoredTextBox1.Text);
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("Please inject!");
                    }
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton4.Checked)
            {
                try
                {
                    if (NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))
                    {
                        NamedPipes2.LuaPipe(this.fastColoredTextBox1.Text);
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("Please inject!");
                    }
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton5.Checked)
            {
                int num = (int)MessageBox.Show("Press Insert / fn + pgdown inside Roblox");
            }
            else if (radioButton6.Checked)
            {
                try
                {
                    oxygen.Execute(fastColoredTextBox1.Text);
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            
            else if (radioButton8.Checked)
            {
                try
                {
                    proxo.ExecuteScript(fastColoredTextBox1.Text); //Proxo
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Fungsi.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Fungsi.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                module.LaunchExploit(); //EasyExploits
            }
            else if (radioButton2.Checked)
            {
                shadow.Attach(); //ShadowExploits
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream s = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(s);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
                fastColoredTextBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("An unexpected error has occured", "OOF!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] localByName = Process.GetProcessesByName("RobloxPlayerBeta");
                foreach (Process p in localByName)
                {
                    p.Kill();
                }
            }
            catch (Exception)
            {
                int num1 = (int)MessageBox.Show("Failed, Pls restart the executor!");
            }
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                int num = (int)MessageBox.Show("This API only Support inside Roblox");
            }

            else
            {
                OpenFileDialog opendialogfile = new OpenFileDialog();
                opendialogfile.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
                opendialogfile.FilterIndex = 2;
                opendialogfile.RestoreDirectory = true;
                if (opendialogfile.ShowDialog() != DialogResult.OK)
                    return;
                try
                {
                    System.IO.Stream stream;
                    if ((stream = opendialogfile.OpenFile()) == null)
                        return;
                    using (stream)
                        if (radioButton1.Checked)
                        {
                            module.ExecuteScript(System.IO.File.ReadAllText(opendialogfile.FileName)); //EasyExploits
                        }
                        else if (radioButton2.Checked)
                        {
                            shadow.ExecuteScript(System.IO.File.ReadAllText(opendialogfile.FileName)); //Shadowcheats
                        }
                        else if (radioButton3.Checked)
                        {
                            if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
                            {
                                NamedPipes.LuaPipe(System.IO.File.ReadAllText(opendialogfile.FileName)); //ZeusX
                            }
                            else
                            {
                                int num = (int)MessageBox.Show("Please inject!");
                            }
                        }
                        else if (radioButton4.Checked)
                        {
                            if (NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))
                            {
                                NamedPipes2.LuaPipe(System.IO.File.ReadAllText(opendialogfile.FileName)); //Skisploit API
                            }
                            else
                            {
                                int num = (int)MessageBox.Show("Please inject!");
                            }
                        }
                        else if (radioButton6.Checked)
                        {
                            oxygen.Execute(System.IO.File.ReadAllText(opendialogfile.FileName)); //Oxygen
                        }
                        
                        else if (radioButton8.Checked)
                        {
                            proxo.ExecuteScript(System.IO.File.ReadAllText(opendialogfile.FileName)); //Proxo
                        }
                       
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("An unexpected error has occured", "OOF!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    module.LaunchExploit(); //EasyExploits
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    shadow.Attach(); //ShadowExploits
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton3.Checked)
            {
                try
                {
                    Functions.Inject();
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton4.Checked)
            {
                try
                {
                    Functions2.Inject();
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton5.Checked)
            {
                try
                {
                    string str3 = Directory.GetCurrentDirectory() + "\\lua 5.1.dll";
                    if (Process.GetProcessesByName("RobloxPlayerBeta").Length == 0)
                    {
                        int num1 = (int)MessageBox.Show("Roblox isn't open!");
                    }
                    else
                    {
                        int num1 = (int)MessageBox.Show("Press Insert / fn + Pgdown to open menu");
                        IntPtr hProcess = OpenProcess(1082, false, Process.GetProcessesByName("RobloxPlayerBeta")[0].Id);
                        IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                        IntPtr num = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((str3.Length + 1) * Marshal.SizeOf(typeof(char))), 12288U, 4U);
                        UIntPtr lpNumberOfBytesWritten;
                        WriteProcessMemory(hProcess, num, Encoding.Default.GetBytes(str3), (uint)((str3.Length + 1) * Marshal.SizeOf(typeof(char))), out lpNumberOfBytesWritten);
                        CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, num, 0U, IntPtr.Zero);
                    }
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
            else if (radioButton6.Checked)
            {
                try
                {
                    oxygen.Attach();
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
           
            else if (radioButton8.Checked)
            {
                try
                {
                    proxo.LaunchExploit(); //Proxo
                }
                catch (Exception)
                {
                    int num1 = (int)MessageBox.Show("Failed!");
                }
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string address = "https://gitlab.com/dllupdates/yesyes/-/raw/master/ZeusX.dll";
            string fileName = "ZeusX.dll";
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(address, fileName);
            }
            catch
            {
                int num = (int)MessageBox.Show("Failed!");
            }
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = ((double)(trackBar1.Value) / 10.0);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = Directory.GetCurrentDirectory() + "\\Skisploit.dll";
                if (System.IO.File.Exists(str1))
                {
                    System.IO.File.Delete(str1);
                    WebClient wc = new WebClient();
                    string url = wc.DownloadString("http://api.thundermods.com/dlldownload.txt");
                    wc.DownloadFile(url, "./Skisploit.dll");
                    url = (string)null;
                }
                else
                {
                    WebClient wc = new WebClient();
                    string url = wc.DownloadString("http://api.thundermods.com/dlldownload.txt");
                    wc.DownloadFile(url, "./Skisploit.dll");
                    url = (string)null;
                }
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("Failed!");
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                string str1 = Directory.GetCurrentDirectory() + "\\lua 5.1.dll";
                if (System.IO.File.Exists(str1))
                {
                    System.IO.File.Delete(str1);
                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile("https://raw.githubusercontent.com/VIPIRU545/Sona/master/lua 5.1.dll", str1);
                }
                else
                {
                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile("https://raw.githubusercontent.com/VIPIRU545/Sona/master/lua 5.1.dll", str1);
                }
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("Failed!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("Failed!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void panel10_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label9_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        List<string> listcollection = new List<string>();    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(textBox1.Text)==false)
            {
                listBox1.Items.Clear();
                foreach(string str in listcollection)
                {
                    if(str.ToUpper().Contains(textBox1.Text.ToUpper()))
                    {
                        listBox1.Items.Add(str);
                    }
                }
            }
           else if (textBox1.Text=="")
            {
                listBox1.Items.Clear();
                foreach (string str in listcollection)
                {
                    listBox1.Items.Add(str);
                }
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void fastColoredTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://discord.gg/7PsKnXxBPC");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
