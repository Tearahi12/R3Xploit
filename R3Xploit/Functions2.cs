using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    internal class Functions2
    {
        public static string exploitdllname = "Skisploit.dll";

        public static void Inject()
        {
            if (NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))
            {
                int num1 = (int)MessageBox.Show("Already Injected!");
            }
            else
            {
                if (NamedPipes2.NamedPipeExist(NamedPipes2.luapipename) || NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))
                    return;
                switch (Injector2.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions2.exploitdllname))
                {
                    case Injector2.DllInjectionResult.DllNotFound:
                        int num2 = (int)MessageBox.Show("Couldnt find Skisploit.dll!");
                        goto case Injector2.DllInjectionResult.InjectionFailed;
                       
                    case Injector2.DllInjectionResult.GameProcessNotFound:
                        int num3 = (int)MessageBox.Show("Roblox not found!");
                        goto case Injector2.DllInjectionResult.InjectionFailed;
            
                    case Injector2.DllInjectionResult.InjectionFailed:
                        break;
                    default:
                        Thread.Sleep(3000);
                        if (!NamedPipes2.NamedPipeExist(NamedPipes2.luapipename))

                            break;
                        break;
                }
            }
            
        }
    }

}
