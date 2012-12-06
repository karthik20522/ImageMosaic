ImageMosaic
===========

Image Mosaic using C# - Library used in <a href='http://kufli.blogspot.com/2012/08/yearinimagescom-how-did-i-build-this.html'>http://yearinimages.com</a> website (powered by GettyImages images)
Note that the library was customized to produce the yearinimages grid and there is no guarantee that it 
would produce similar results when generating using this library.

Read more on "how did i build yearinimages.com" at : <a href='http://kufli.blogspot.com/2012/08/yearinimagescom-how-did-i-build-this.html'>http://kufli.blogspot.com/2012/08/yearinimagescom-how-did-i-build-this.html</a>

Example usage:
--------------

        var _mosaicGenerator = new MosaicGenerator();

        var srcImage = "..\\..\\..\\ImageMosaicTest\\144146014.jpg";
        var imageFolder = "..\\..\\..\\ImageMosaicTest\\TestImages\\entertainment";
        
        var _mosaic = _mosaicGenerator.Generate(srcImage,imageFolder );
        _mosaic.Image.Save(string.Format("c:\\Temp\\{0}.jpg", Guid.NewGuid().ToString("N")));
        _mosaic.Image.Dispose();