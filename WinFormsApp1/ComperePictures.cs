using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace Picture
{
    internal class ComperePictures
    {
        private List<Pictures> pictureList = new List<Pictures>();
        private readonly string pathWindows = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
        private string path = string.Empty;
        private int maxCount;
        private bool autoStart;

        private readonly RegistryWork _registryWork = new();

        public  ComperePictures(bool autoStart)
        {
            this.autoStart = autoStart;
        }

        public string InitPath()
        {
            this.path = _registryWork.InitPath();
            return this.path;
        }

        public int InitMaxCount()
        {
            try
            {
                this.maxCount = int.Parse(_registryWork.initMaxCount());
            }
            catch
            {
                this.maxCount = 400;
            }
            return this.maxCount;
        }

        public void SetMaxCount(int maxCount)
        {
            this.maxCount = maxCount;
            _registryWork.SetMinCount(maxCount);
        }

        public void SetAndComperePictureList()
        {
            if (path != string.Empty)
            {
                string[] filesName = Directory.GetFiles(path, "*.jpg");

                if (maxCount <= filesName.Length && autoStart)
                {
                    Application.Exit();
                }

                foreach (string file in filesName)
                {
                    pictureList.Add(new Pictures(file));
                }

                CompereWinPictures();
            }
        }

        private void CompereWinPictures()
        {
            string[] filesName = Directory.GetFiles(this.pathWindows);

            foreach (string file in filesName)
            {
                try
                {
                    Image image = Image.FromFile(file);
                    if (image.Height >= 1080 && image.Width > image.Height)
                    {
                        if (IsNewPicture(file))
                        {
                            File.Copy(file,
                                    path + "\\" + DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))
                                    .TotalSeconds.ToString().Replace(",", "") + ".jpg");
                        }
                    }
                    image.Dispose();
                }
                catch { }
                
            }
            CompliteApplication();
        }

        private bool IsNewPicture(string file)
        {
            Pictures pictureWindows = new(file);
            foreach (Pictures picture in pictureList)
            {
                if (pictureWindows.GetContent() == picture.GetContent())
                {
                    return false;
                }
            }
            return true;
        }

        private void CompliteApplication()
        {
            if (autoStart)
            {
                Application.Exit();
            }
            else
            {
                _registryWork.AddAutoStart();
            }
        }

        public void SetPath(string path)
        {
            this.path = path;
            _registryWork.SetPath(path);
        }

        public void keyClose()
        {
            _registryWork.KeyClose();
        }

    }
}
