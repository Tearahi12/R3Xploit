using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class NamedPipes2
    {
        public static string luapipename = "9w49yJgL5Vg8VHwHvxZNtBAb";

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        public static bool NamedPipeExist(string pipeName)
        {
            bool flag;
            try
            {
                int timeout = 0;
                if (!NamedPipes2.WaitNamedPipe(Path.GetFullPath(string.Format("\\\\\\\\.\\\\pipe\\\\{0}", (object)pipeName)), timeout))
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
            if (NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))
            {
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", NamedPipes2.luapipename, PipeDirection.Out))
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
                int num1 = (int)MessageBox.Show("Inject " + Functions2.exploitdllname + " before Using this!", "Error");
            }
        }
    }
}