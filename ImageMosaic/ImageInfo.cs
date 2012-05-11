using System;
using System.Collections;
using System.Drawing;

namespace ImageMosaic
{
    public class ImageInfo
    {
        public Color AverageTL { get; set; }
        public Color AverageTR { get; set; }
        public Color AverageBL { get; set; }
        public Color AverageBR { get; set; }
        public string Path { get; set; }
        private ArrayList _data;
        public ArrayList Data
        {
            get
            {
                if (_data == null)
                    _data = new ArrayList();

                return _data;
            }
            set
            {
                if (_data == null)
                    _data = new ArrayList();

                _data = value;
            }
        }

        public ImageInfo(string filePath)
        {
            this.Path = filePath;
        }
    }
}
