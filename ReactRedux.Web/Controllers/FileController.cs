using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ReactRedux.Web.Controllers
{
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly string _uploadsFolder;

        public FileController(IHostingEnvironment environment)
        {
            _uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
            Directory.CreateDirectory(_uploadsFolder);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            string file = Directory.GetFiles(_uploadsFolder, $"{id}.*").SingleOrDefault();
            if (file == null)
            {
                return NotFound("File not found");
            }

            string fileName = Path.GetFileName(file);
            var contentType = new ContentType
            {
                CharSet = Encoding.UTF8.WebName,
                MediaType = GetContentType(fileName),
            };

            return PhysicalFile(file, contentType.ToString());
        }

        [HttpPost]
        public async Task<Guid> Post([FromForm] UploadFileModel model)
        {
            // Автоматически почему-то не биндится
            model.ExtraParams = JsonConvert.DeserializeObject<IDictionary<string, string>>(Request.Form[nameof(UploadFileModel.ExtraParams)]);
            Guid fileId = model.FileId == Guid.Empty ? Guid.NewGuid() : model.FileId;
            string filePath = Path.Combine(_uploadsFolder, $"{fileId}{Path.GetExtension(model.File.FileName)}");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }

            return fileId;
        }

        private string GetContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            return provider.TryGetContentType(fileName, out string contentType)
                ? contentType
                : "application/octet-stream";
        }

        public class UploadFileModel
        {
            public Guid FileId { get; set; }

            public IFormFile File { get; set; }

            public IDictionary<string, string> ExtraParams { get; set; }
        }
    }
}