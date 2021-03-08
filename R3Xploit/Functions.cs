using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class Functions
    {
        public static string exploitdllname = "ZeusX.dll";

        public static void Inject()
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
            {
                int num1 = (int)MessageBox.Show("Already Injected!");
            }
            else
            {
                if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
                    return;
                switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions.exploitdllname))
                {
                    case Injector.DllInjectionResult.DllNotFound:
                        int num2 = (int)MessageBox.Show("Couldnt find ZeusX.dll!");
                        goto case Injector.DllInjectionResult.InjectionFailed;
                    case Injector.DllInjectionResult.GameProcessNotFound:
                        int num3 = (int)MessageBox.Show("Roblox not found!");
                        goto case Injector.DllInjectionResult.InjectionFailed;
                    case Injector.DllInjectionResult.InjectionFailed:
                        break;
                    default:
                        Thread.Sleep(3000);
                        if (!NamedPipes.NamedPipeExist(NamedPipes.luapipename))
                            goto case Injector.DllInjectionResult.InjectionFailed;
                        else
                            goto case Injector.DllInjectionResult.InjectionFailed;
                }
            }
        }
    }
    
}
