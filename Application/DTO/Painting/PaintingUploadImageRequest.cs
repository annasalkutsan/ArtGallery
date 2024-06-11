using Microsoft.AspNetCore.Http;

namespace Application.DTO.User;

public class PaintingUploadImageRequest:PaintingCreateRequest
{
    public IFormFile? Image { get; set; }
}