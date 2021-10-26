using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StayOver.Data;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StayOver.Repos
{
    public class GalleryRepo : IGalleryRepo
    {
        private readonly StayOverDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GalleryRepo(StayOverDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddImagesToGalleryAsync(Accommodation accommodation)
        {
            string folder = "accommodations/gallery/";
            accommodation.Gallery = new List<GalleryModel>();
            if (accommodation.GalleryFiles != null)
            {
                foreach (var file in accommodation.GalleryFiles)
                {
                    var gallery = new GalleryModel()
                    {
                        Name = file.FileName,
                        URL = await UploadImage(folder, file)
                    };

                    accommodation.Gallery.Add(gallery);
                }
            }
        }

        public async Task<IEnumerable<GalleryModel>> GetAccommodationGalleryAsync(int? id)
        {
            return await _context.Galleries.AsNoTracking().Where(g => g.Accommodation.AccommodationId == id).ToListAsync();
        }

        public async Task DeleteGalleryAsync(int accommodationId)
        {
            var galery = await _context.Galleries.AsNoTracking().Where(g => g.Accommodation.AccommodationId == accommodationId).ToListAsync();

            if (galery.Count > 0)
            {
                foreach (var file in galery)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, file.URL);

                    // Delete image from wwwroot/accommodations/gallery
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                    _context.Galleries.Remove(file);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteGalleryImageAsync(int imageId)
        {
            var image = await _context
                .Galleries
                .Where(g => g.GalleryModelId == imageId)
                .FirstOrDefaultAsync();

            if (image != null)
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, image.URL);

                // Delete image from wwwroot/accommodations/gallery
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                _context.Galleries.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            var newFile = folderPath + Guid.NewGuid().ToString() + "_" + file.FileName;

            string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, newFile);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return newFile;
        }
    }
}
