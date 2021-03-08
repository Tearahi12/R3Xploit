using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class Functions3
    {
        public static string exploitdllname = "krnl.dll";

        public static void Inject()
        {
            if (NamedPipes3.NamedPipeExist(NamedPipes3.luapipename))
            {
                int num1 = (int)MessageBox.Show("Already Injected!");
            }
            else
            {
                if (NamedPipes3.NamedPipeExist(NamedPipes3.luapipename) || NamedPipes3.NamedPipeExist(NamedPipes3.luapipename))
                    return;
                switch (Injector3.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions3.exploitdllname))
                {
                    case Injector3.DllInjectionResult.DllNotFound:
                        int num2 = (int)MessageBox.Show("Couldnt find krnl.dll!");
                        goto case Injector3.DllInjectionResult.InjectionFailed;

                    case Injector3.DllInjectionResult.GameProcessNotFound:
                        int num3 = (int)MessageBox.Show("Roblox not found!");
                        goto case Injector3.DllInjectionResult.InjectionFailed;

                    case Injector3.DllInjectionResult.InjectionFailed:
                        break;
                    default:
                        Thread.Sleep(3000);
                        if (!NamedPipes3.NamedPipeExist(NamedPipes3.luapipename))

                            break;
                        break;
                }
            }
        }
    }
}