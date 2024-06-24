using Application.DTO.Painting.Pag;
using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class PaintingService
    {
        private readonly IPaintingRepository _paintingRepository;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public PaintingService(IPaintingRepository paintingRepository, IMapper mapper, ImageService imageService)
        {
            _paintingRepository = paintingRepository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public PaintingResponse GetById(Guid id)
        {
            var painting = _paintingRepository.GetById(id);
            var response = _mapper.Map<PaintingResponse>(painting);
            return response;
        }

        public List<PaintingResponse> GetAll()
        {
            var paintings = _paintingRepository.GetAll();
            var response = _mapper.Map<List<PaintingResponse>>(paintings);
            return response;
        }


        public async Task<PaintingResponse> CreateAsync(PaintingUploadImageRequest request)
        {
            var painting = _mapper.Map<Painting>(request);
            if (request.Image != null)
            {
                var imP = await _imageService.SaveImages(request.Image);
                painting.ImagePath = imP;
            }

            var createdPainting = _paintingRepository.Create(painting);
            await _paintingRepository.SaveChanges();
            var response = _mapper.Map<PaintingResponse>(createdPainting);
            return response;
        }

        public async Task<PaintingResponse> Update(PaintingUpdateRequest request)
        {
            /* var painting = _mapper.Map<Painting>(request);
             var updatedPainting = _paintingRepository.Update(painting);
             await _paintingRepository.SaveChanges();
             var response = _mapper.Map<PaintingResponse>(updatedPainting);
             return response;*/

            var getPainting = _paintingRepository.GetById(request.Id);
            if (getPainting == null)
            {
                throw new Exception("Painting not found");
            }

            var painting = _mapper.Map<Painting>(request);

            // Ensure ImagePath is not null
            if (string.IsNullOrEmpty(painting.ImagePath))
            {
                painting.ImagePath = painting.ImagePath;
            }

            var updatedPainting = _paintingRepository.Update(painting);
            await _paintingRepository.SaveChanges();
            var response = _mapper.Map<PaintingResponse>(updatedPainting);
            return response;
        }

        public bool Delete(Guid id)
        {
            return _paintingRepository.Delete(id);
        }

        public PaintingListResponse GetPagedPainting(PaintingListRequest request)
        {
            var paintings = _paintingRepository.GetPagedPainting(request);
            return paintings;
        }
    }
}