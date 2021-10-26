using StayOver.Models;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepo _repo;

        public GalleryService(IGalleryRepo repo)
        {
            _repo = repo;
        }

        public async Task AddImagesToGalleryAsync(Accommodation accommodation)
        {
            await _repo.AddImagesToGalleryAsync(accommodation);
        }

        public async Task<IEnumerable<GalleryModel>> GetAccommodationGalleryAsync(int? id)
        {
            return await _repo.GetAccommodationGalleryAsync(id);
        }

        public async Task DeleteGalleryAsync(int accommodationId)
        {
            await _repo.DeleteGalleryAsync(accommodationId);
        }

        public async Task DeleteGalleryImageAsync(int imageId)
        {
            await _repo.DeleteGalleryImageAsync(imageId);
        }
    }
}
