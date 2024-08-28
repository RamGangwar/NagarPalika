using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using System.Drawing;
using System.IO;

namespace NagarPalika.Data.OtherRepository
{
    public class CommonMethod : ICommonMethod
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IHostingEnvironment _env;
        public CommonMethod(IUnitofWork unitofWork, IHostingEnvironment env)
        {
            _unitofWork = unitofWork;
            _env = env;
        }
        public async Task<string> UploadFile(int Id, string Type, string base64string)
        {
            string ReturnURL = string.Empty;
            string newfilename = "Base_" + Id.ToString() + "_" + DateTime.Now.Ticks + ".jpg";
            string uploadpath = string.Empty;
            if (Type.ToLower() == "profile")
            {
                uploadpath = _env.WebRootPath + "\\Uploads\\Profile\\";
            }
            else { uploadpath = _env.WebRootPath + "\\Uploads\\Attachment\\"; }

            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }

            string imgPath = Path.Combine(uploadpath, newfilename);

            byte[] imageBytes = Convert.FromBase64String(base64string);

            await File.WriteAllBytesAsync(imgPath, imageBytes);

            ReturnURL = uploadpath + newfilename;

            return ReturnURL;

        }

        public async Task<string> SaveAttachment(int Id, string Type, IFormFile file)
        {
            string ReturnURL = string.Empty;
            string extension = Path.GetExtension(file.FileName);
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            string newfilename = Id + "_" + filename + "_" + DateTime.Now.Ticks + extension;
            string uploadpath = string.Empty;
            if (Type.ToLower() == "profile")
            {
                uploadpath = _env.WebRootPath + "\\Uploads\\Profile\\";
            }
            else if (Type.ToLower() == "propertytype")
            {
                uploadpath = _env.WebRootPath + "\\Uploads\\PropertyType\\";
            }
            else { uploadpath = _env.WebRootPath + "\\Uploads\\Attachment\\"; }


            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }
            using (FileStream filestream = System.IO.File.Create(uploadpath + newfilename))
            {
                await file.CopyToAsync(filestream);
                filestream.Flush();
                ReturnURL = uploadpath + newfilename;

            }

            return ReturnURL;
        }
        public bool DeleteAttachment(string url)
        {
            bool response = false;
            FileInfo file = new FileInfo(url);
            if (file.Exists)
            {
                file.Delete();
                response = true;
            }


            return response;
        }
    }
}
