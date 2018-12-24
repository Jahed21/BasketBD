using System;
using System.Collections.Generic;

namespace BasketBD.Models.Data
{
    public partial class SlidePictures
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PicturePath { get; set; }
    }
}
