// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureStorageAccount.cs" company="">
//   
// </copyright>
// <summary>
//   The azure storage account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageUpload.Service
{
    using ImageUpload.Model.Config;

    using Microsoft.Extensions.Options;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// The azure storage account.
    /// </summary>
    public class AzureStorageAccount : IAzureStorageAccount
    {
        /// <summary>
        /// The azure storage config.
        /// </summary>
        private readonly AzureStorageConfig azureStorageConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageAccount"/> class.
        /// </summary>
        /// <param name="azureStorageConfig">
        /// The azure storage config.
        /// </param>
        public AzureStorageAccount(IOptions<AzureStorageConfig> azureStorageConfig)
        {
            this.azureStorageConfig = azureStorageConfig.Value;
        }

        /// <summary>
        /// The get cloud storage account.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudStorageAccount"/>.
        /// </returns>
        public CloudStorageAccount GetCloudStorageAccount()
        {
            var storageCredentials = new StorageCredentials(
                this.azureStorageConfig.AccountName,
                this.azureStorageConfig.AccountKey);

            var storageAccount = new CloudStorageAccount(storageCredentials, false);

            return storageAccount;
        }

        /// <summary>
        /// The get cloud blob client.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobClient"/>.
        /// </returns>
        public CloudBlobClient GetCloudBlobClient()
        {
            return this.GetCloudStorageAccount().CreateCloudBlobClient();
        }

        /// <summary>
        /// The get image blob container.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobContainer"/>.
        /// </returns>
        public CloudBlobContainer GetImageBlobContainer()
        {
            return this.GetCloudBlobClient()
                .GetContainerReference(this.azureStorageConfig.ImageContainer);
        }

        /// <summary>
        /// The get thumbnail container.
        /// </summary>
        /// <returns>
        /// The <see cref="CloudBlobContainer"/>.
        /// </returns>
        public CloudBlobContainer GetThumbnailContainer()
        {
            return this.GetCloudBlobClient()
                .GetContainerReference(this.azureStorageConfig.ThumbnailContainer);
        }
    }
}