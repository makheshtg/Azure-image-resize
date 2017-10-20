// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageController.cs" company="">
//   
// </copyright>
// <summary>
//   The image controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ImageUpload.Helper;
    using ImageUpload.Service;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The image controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        /// <summary>
        /// The image storage.
        /// </summary>
        private readonly IImageStorage imageStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageController"/> class.
        /// </summary>
        /// <param name="imageStorage">
        /// The image storage.
        /// </param>
        public ImageController(IImageStorage imageStorage)
        {
            this.imageStorage = imageStorage;
        }

        /// <summary>
        /// The upload.
        /// </summary>
        /// <param name="files">
        /// The files.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [Route("[Action]")]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            if (files.Count == 0)
            {
                return this.BadRequest("No files received from the upload");
            }

            var isUploaded = false;

            foreach (var formFile in files.Where(ImageHelper.IsImage))
            {
                using (var stream = formFile.OpenReadStream())
                {
                    isUploaded = await this.imageStorage.UploadFileToStorage(stream, formFile.FileName);
                }
            }

            if (isUploaded)
            {
                return new AcceptedResult();
            }

            return this.BadRequest("Failed to upload the image(s).");
        }

        /// <summary>
        /// The get thumbnails.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetThumbnails()
        {
            var thumbnails = await this.imageStorage.GetThumbnailsUrls();

            return this.Ok(thumbnails);
        }
    }
}