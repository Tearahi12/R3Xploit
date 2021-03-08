using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class NamedPipes3
    {
        public static string luapipename = "krnlpipe";

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        public static bool NamedPipeExist(string pipeName)
        {
            bool flag;
            try
            {
                int timeout = 0;
                if (!NamedPipes3.WaitNamedPipe(Path.GetFullPath(string.Format("\\\\\\\\.\\\\pipe\\\\{0}", (object)pipeName)), timeout))
                {
                    switch (Marshal.GetLastWin32Error())
                    {
                        case 0:
                            return false;
                        case 2:
                            return false;
                    }
                }
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public static void LuaPipe(string script)
        {
            if (NamedPipes3.NamedPipeExist(NamedPipes3.luapipename))
            {
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", NamedPipes3.luapipename, PipeDirection.Out))
                        {
                            pipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter((Stream)pipeClientStream, Encoding.Default, 999999))
                            {
                                streamWriter.Write(script);
                                streamWriter.Dispose();
                            }
                            pipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                        int num2 = (int)MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!");
                    }
                    catch (Exception ex)
                    {
                        int num2 = (int)MessageBox.Show(ex.Message.ToString());
                    }
                })).Start();
            }
            else
            {
                int num1 = (int)MessageBox.Show("Inject " + Functions3.exploitdllname + " before Using this!", "Error");
            }
        }
    }
}