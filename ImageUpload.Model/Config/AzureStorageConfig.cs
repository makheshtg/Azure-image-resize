// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureStorageConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The azure storage config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Model.Config
{
    /// <summary>
    /// The azure storage config.
    /// </summary>
    public class AzureStorageConfig
    {
        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        public string AccountKey { get; set; }
        
        /// <summary>
        /// Gets or sets the image container.
        /// </summary>
        public string ImageContainer { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail container.
        /// </summary>
        public string ThumbnailContainer { get; set; }
    }
}