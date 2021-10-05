using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Models
{
    public class GalleryModel
    {
        public int GalleryModelId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public virtual Accommodation Accommodation { get; set; }
    }
}
