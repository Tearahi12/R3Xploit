using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class NamedPipes
    {
        public static string luapipename = "furkisgay";

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        public static bool NamedPipeExist(string pipeName)
        {
            try
            {
                if (!NamedPipes.WaitNamedPipe("\\\\.\\pipe\\" + pipeName, 0))
                {
                    switch (Marshal.GetLastWin32Error())
                    {
                        case 0:
                            return false;
                        case 2:
                            return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void LuaPipe(string script)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
            {
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", NamedPipes.luapipename, PipeDirection.Out))
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
                        int num2 = (int)MessageBox.Show("Pipe connect failed");
                    }
                    catch (Exception)
                    {
                        int num2 = (int)MessageBox.Show("Failed!");
                    }
                })).Start();
            }
            else
            {
                int num1 = (int)MessageBox.Show("Inject!");
            }
        }
    }
}
