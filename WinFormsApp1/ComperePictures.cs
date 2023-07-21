﻿using System;
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

        private RegistryWork registryWork = new RegistryWork();

        public  ComperePictures(bool autoStart)
        {
            setAutoStart(autoStart);
        }

        public void setAutoStart(bool autoStart)
        {
            this.autoStart = autoStart;
        }

        public string initPath()
        {
            this.path = registryWork.initPath();
            return this.path;
        }

        public int initMaxCount()
        {
            try
            {
                this.maxCount = int.Parse(registryWork.initMaxCount());
            }
            catch
            {
                this.maxCount = 400;
            }
            return this.maxCount;
        }

        public void setMaxCount(int maxCount)
        {
            this.maxCount = maxCount;
            registryWork.setMinCount(maxCount);
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

                comperePictures();
            }
        }

        private void comperePictures()
        {
            string[] filesName = Directory.GetFiles(this.pathWindows);

            foreach (string file in filesName)
            {
                try
                {
                    Image image = Image.FromFile(file);
                    if (image.Height >= 1080 && image.Width > image.Height)
                    {
                        if (isNewPicture(file))
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
            compliteApplication();
        }

        private bool isNewPicture(string file)
        {
            Pictures pictureWindows = new Pictures(file);
            foreach (Pictures picture in pictureList)
            {
                if (pictureWindows.GetContent() == picture.GetContent())
                {
                    return false;
                }
            }
            return true;
        }

        private void compliteApplication()
        {
            if (autoStart)
            {
                Application.Exit();
            }
            else
            {
                registryWork.addAutoStart();
            }
        }

        public void setPath(string path)
        {
            this.path = path;
            registryWork.setPath(path);
        }

        public void keyClose()
        {
            registryWork.keyClose();
        }

    }
}
