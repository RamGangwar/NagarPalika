using Microsoft.AspNetCore.Http;

namespace NagarPalika.Application.OtherRepository
{
    public interface ICommonMethod
    {
        Task<string> UploadFile(int Id, string Type, string base64string);
        Task<string> SaveAttachment(int Id, string Type, IFormFile file);
        bool DeleteAttachment(string url);


    }
}
