using StayOver.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Services.Interfaces
{
    public interface IGalleryService
    {
        public Task AddImagesToGalleryAsync(Accommodation accommodation);
        public Task<IEnumerable<GalleryModel>> GetAccommodationGalleryAsync(int? id);
        public Task DeleteGalleryAsync(int accommodationId, string webRootPath);
        public Task DeleteGalleryImageAsync(int imageId, string webRootPath);
    }
}
