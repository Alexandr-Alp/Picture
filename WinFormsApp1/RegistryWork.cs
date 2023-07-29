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
        private readonly RegistryKey _key = Registry.CurrentUser.CreateSubKey(@"Software\Picture");

        public void AddAutoStart()
        {
            string PICTURE = "Picture.exe";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            string valueInRun = SetNotNuleble(key.GetValue(PICTURE) as string);
            string pathExe = "\"" + Environment.CurrentDirectory + "\\" + PICTURE + "\" silent";
            if (valueInRun != pathExe)
            {
                key.SetValue(PICTURE, pathExe);
            }
            key.Close();
        }

        private string GetKeyValue(string parametr)
        {
            return SetNotNuleble(_key.GetValue(parametr) as string);

        }

        private string SetNotNuleble(string? value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public string InitPath()
        {
            return GetKeyValue("path");
        }
        public string initMaxCount()
        {
            return GetKeyValue("count");
        }

        public void SetMinCount(int maxCount) {
            _key.SetValue("count", maxCount.ToString());
        }

        public void SetPath(string path)
        {
            _key.SetValue("path", path);
        }

        public void KeyClose()
        {
            _key.Close();
        }
    }
}
