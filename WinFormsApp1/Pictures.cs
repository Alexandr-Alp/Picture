using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Pictures
    {
        private string content = string.Empty;
        private string fileName;
        
        public Pictures(string fileName)
        {
            this.fileName = fileName;
        }
        public string GetContent()
        {
            if (content == string.Empty)
            {
                this.content = File.ReadAllText(fileName);
            }
            return content;
        }

        public string getFileName() { return fileName; }
    }
}
