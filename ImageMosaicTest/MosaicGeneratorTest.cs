using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageMosaic;
using System.Drawing;

namespace ImageMosaicTest
{
    [TestClass]
    public class MosaicGeneratorTest
    {
        ImageProcessing _imageProcessing;
        string sourceFile = "..\\..\\..\\ImageMosaicTest\\144196672.jpg";

        [TestInitialize]
        public void Init()
        {
            _imageProcessing = new ImageProcessing();
        }

        [TestMethod]
        public void ResizeTest()
        {
            using (var resizedBmp = _imageProcessing.Resize(sourceFile))
            {
                Assert.IsTrue(resizedBmp != null);
                Assert.IsTrue(resizedBmp.Height == 119);
                Assert.IsTrue(resizedBmp.Width == 119);
            }
        }

        [TestMethod]
        public void AverageColorTest()
        {
            using (var input = Bitmap.FromFile(sourceFile))
            {
                var inputBmp = new Bitmap(input);
                var imageInfo = _imageProcessing.GetAverageColor(inputBmp, sourceFile);

                Assert.IsTrue(!string.IsNullOrEmpty(imageInfo.Path));
                Assert.IsTrue(!imageInfo.AverageBL.IsEmpty);
                Assert.IsTrue(!imageInfo.AverageBR.IsEmpty);
                Assert.IsTrue(!imageInfo.AverageTL.IsEmpty);
                Assert.IsTrue(!imageInfo.AverageTR.IsEmpty);
            }
        }

        [TestMethod]
        public void CreateMapTest()
        {
            using (var input = Bitmap.FromFile(sourceFile))
            {
                var inputBmp = new Bitmap(input);
                var _createMap = _imageProcessing.CreateMap(inputBmp);

                Assert.IsTrue(_createMap.Length > 0);
            }
        }

        [TestMethod]
        public void MosaicGenerator_Test_END_TO_END()
        {
            var _mosaicGenerator = new MosaicGenerator();
var srcImage = "..\\..\\..\\ImageMosaicTest\\144146014.jpg";
var imageFolder = "..\\..\\..\\ImageMosaicTest\\TestImages\\entertainment";

            var _mosaic = _mosaicGenerator.Generate(srcImage,imageFolder );

            _mosaic.Image.Save(string.Format("c:\\Temp\\{0}.jpg", Guid.NewGuid().ToString("N")));
            _mosaic.Image.Dispose();
        }
    }
}

