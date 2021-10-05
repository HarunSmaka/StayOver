using AutoMapper;
using StayOver.Data.Dtos;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IAccommodationRepo _repo;
        private readonly IGalleryService _galleryService;
        private readonly IMapper _mapper;

        public AccommodationService(IAccommodationRepo repo, IGalleryService galleryService, IMapper mapper)
        {
            _repo = repo;
            _galleryService = galleryService;
            _mapper = mapper;
        }


        public async Task<AccommodationReadDto> GetAccommodationByIdAsync(int? id)
        {
            var result =  await _repo.GetAccommodationByIdAsync(id);
            var accommodation = _mapper.Map<AccommodationReadDto>(result);

            return accommodation;
        }

        public IQueryable<AccommodationReadDto> GetAccommodations()
        {
            return _repo.GetAccommodations();
        }


        public IQueryable<AccommodationReadDto> GetUsersAccommodations(string userId)
        {
            return _repo.GetUsersAccommodations(userId);
        }

        public async Task AddAccommodationAsync(AccommodationCreateDto accommodationCreateDto)
        {
            var accommodation = _mapper.Map<Accommodation>(accommodationCreateDto);
            accommodation.GalleryFiles = accommodationCreateDto.GalleryFiles;

            await _galleryService.AddImagesToGalleryAsync(accommodation);

            await _repo.AddAccommodationAsync(accommodation);
        }

        public async Task<bool> UpdateAccommodationAsync(AccommodationUpdateDto accommodationUpdateDto)
        {
            var accommodation = _mapper.Map<Accommodation>(accommodationUpdateDto);
            accommodation.GalleryFiles = accommodationUpdateDto.GalleryFiles;

            await _galleryService.AddImagesToGalleryAsync(accommodation);

            return await _repo.UpdateAccommodationAsync(accommodation);
        }

        public async Task<bool> DeleteAccommodationAsync(int id)
        {
            return await _repo.DeleteAccommodationAsync(id);
        }
    
        public IQueryable<AccommodationReadDto> GetSearchedAccommodations(string titleSearch, string citySearch, int guestNumber, DateTime startDate, DateTime endDate)
        {
            return _repo.GetSearchedAccommodations(titleSearch, citySearch, guestNumber, startDate, endDate);
        }

        public async Task<bool> OwnsAccommodations(string userId)
        {
            return await _repo.OwnsAccommodations(userId);
        }

        private async Task GetAccommodationsGallery(IEnumerable<Accommodation> result)
        {
            foreach (var item in result)
            {
                var gallery = await _galleryService.GetAccommodationGalleryAsync(item.AccommodationId);

                item.Gallery = gallery.ToList();
            }
        }
    }
}
