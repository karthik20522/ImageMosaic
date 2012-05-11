using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageMosaic
{
    public class Mosaic
    {
        public Image Image { get; set; }
        public List<MosaicTile> Tiles { get; set; }
    }
}
