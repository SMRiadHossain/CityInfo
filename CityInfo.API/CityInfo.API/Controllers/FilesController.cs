using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : Controller
    {
        //for supporting every filetype
        private readonly FileExtensionContentTypeProvider _fileExtensionxtensionContentTypeProvider;

        public FilesController(
            FileExtensionContentTypeProvider fileExtensionxtensionContentTypeProvider)
        {
            _fileExtensionxtensionContentTypeProvider = fileExtensionxtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(fileExtensionxtensionContentTypeProvider));
        }

        //for downloading any file
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "creating-the-api-and-returning-resources-slides.pdf";
            if (!System.IO.File.Exists(pathToFile)) 
            {
                return NotFound();
            }
            if (!_fileExtensionxtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
