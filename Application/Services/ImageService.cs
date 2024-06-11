
using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class ImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }


        public async Task<string> SaveImages(IFormFile file)
        {
            if (file is null) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var pathFolder = Path.Combine("wwwroot", "images");
            Directory.CreateDirectory(pathFolder);

            var filePath = Path.Combine(pathFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("images", fileName);
        }
    }
    

