using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageMosaic
{
    public class MosaicGenerator
    {
        public Mosaic Generate(string imageToMash, string srcImageDirectory)
        {
            var _imageProcessing = new ImageProcessing();
            var _imageInfos = new List<ImageInfo>();
            var _mosaic = new Mosaic();

            var di = new DirectoryInfo(srcImageDirectory);
            var files = di.GetFiles("*.jpg", SearchOption.AllDirectories).ToList();

            Parallel.ForEach(files, f =>
            {
                using (var inputBmp = _imageProcessing.Resize(f.FullName))
                {
                    var _info = _imageProcessing.GetAverageColor(inputBmp, f.FullName);
                    
                    if(_info != null)
                        _imageInfos.Add(_info);
                }
            });

            using (var source = new Bitmap(imageToMash))
            {
                var _colorMap = _imageProcessing.CreateMap(source);
                _mosaic = _imageProcessing.Render(source, _colorMap, _imageInfos);
            }

            return _mosaic;
        }
    }
}
