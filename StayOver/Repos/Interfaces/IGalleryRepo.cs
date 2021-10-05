using StayOver.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Repos.Interfaces
{
    public interface IGalleryRepo
    {
        public Task AddImagesToGalleryAsync(Accommodation accommodation);
        public Task<IEnumerable<GalleryModel>> GetAccommodationGalleryAsync(int? id);
        public Task DeleteGalleryAsync(int accommodationId, string webRootPath);
        public Task DeleteGalleryImageAsync(int imageId, string webRootPath);
    }
}
