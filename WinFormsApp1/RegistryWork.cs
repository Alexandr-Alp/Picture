using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture
{
    internal class RegistryWork
    {
        private RegistryKey _key = Registry.CurrentUser.CreateSubKey(@"Software\Picture");

        public void addAutoStart()
        {
            string PICTURE = "Picture.exe";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            string valueInRun = setNotNuleble(key.GetValue(PICTURE) as string);
            string pathExe = "\"" + Environment.CurrentDirectory + "\\" + PICTURE + "\" silent";
            if (valueInRun != pathExe)
            {
                key.SetValue(PICTURE, pathExe);
            }
            key.Close();
        }

        private string getKeyValue(string parametr)
        {
            return setNotNuleble(_key.GetValue(parametr) as string);

        }

        private string setNotNuleble(string? value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public string initPath()
        {
            return getKeyValue("path");
        }
        public string initMaxCount()
        {
            return getKeyValue("count");
        }

        public void setMinCount(int maxCount) {
            _key.SetValue("count", maxCount.ToString());
        }

        public void setPath(string path)
        {
            _key.SetValue("path", path);
        }

        public void keyClose()
        {
            _key.Close();
        }
    }
}
