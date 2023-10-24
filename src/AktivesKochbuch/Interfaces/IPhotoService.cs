using System.Net.Mime;
using CloudinaryDotNet.Actions;

namespace AktivesKochbuch.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile formFile);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
}