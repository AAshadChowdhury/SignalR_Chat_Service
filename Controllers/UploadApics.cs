using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SignalR_Chat_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadApics : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadApics(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Post(IFormFile files)
        {
            string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
            filename = this.EnsureCorrectFilename(filename);
            using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                await files.CopyToAsync(output);
            return Ok();
        }
        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
        }
        private string GetPathAndFilename(string filename)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "uploads", filename);
        }
    }
}
