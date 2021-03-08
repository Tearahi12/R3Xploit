using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class Functions4
    {
        public static string exploitdllname = "ElectronDLL.dll";

        public static void Inject()
        {
            if (NamedPipes4.NamedPipeExist(NamedPipes4.luapipename))
            {
                int num1 = (int)MessageBox.Show("Already Injected!");
            }
            else
            {
                if (NamedPipes4.NamedPipeExist(NamedPipes4.luapipename) || NamedPipes4.NamedPipeExist(NamedPipes4.luapipename))
                    return;
                switch (Injector4.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions4.exploitdllname))
                {
                    case Injector4.DllInjectionResult.DllNotFound:
                        int num2 = (int)MessageBox.Show("Couldnt find ElectronDLL.dll!");
                        goto case Injector4.DllInjectionResult.InjectionFailed;

                    case Injector4.DllInjectionResult.GameProcessNotFound:
                        int num3 = (int)MessageBox.Show("Roblox not found!");
                        goto case Injector4.DllInjectionResult.InjectionFailed;

                    case Injector4.DllInjectionResult.InjectionFailed:
                        break;
                    default:
                        Thread.Sleep(3000);
                        if (!NamedPipes4.NamedPipeExist(NamedPipes4.luapipename))

                            break;
                        break;
                }
            }
        }
    }
}