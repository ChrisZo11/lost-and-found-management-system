using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LostAndFound
{
    public interface IPhotoStorageService
    {
        string SaveItemPhoto(Image image);
        string SaveClaimPhoto(Image image, string sourcePath);
        string ResolvePath(string storedPath);
        void DeleteIfExists(string filePath);
    }

    public sealed class PhotoStorageService : IPhotoStorageService
    {
        private const string PhotoStorageRootSetting = "PhotoStorageRoot";
        private const string ItemImageFolder = "Images";
        private const string ClaimPhotoFolder = "ClaimPhotos";
        private readonly string storageRoot;

        public PhotoStorageService(string storageRoot)
        {
            if (string.IsNullOrWhiteSpace(storageRoot))
            {
                throw new ArgumentException("Photo storage root cannot be empty.", nameof(storageRoot));
            }

            this.storageRoot = ResolveStorageRoot(storageRoot);
        }

        public static PhotoStorageService CreateDefault()
        {
            string configuredRoot = ConfigurationManager.AppSettings[PhotoStorageRootSetting];
            if (string.IsNullOrWhiteSpace(configuredRoot))
            {
                configuredRoot = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "LostAndFound");
            }

            return new PhotoStorageService(configuredRoot);
        }

        public string SaveItemPhoto(Image image)
        {
            if (image == null)
            {
                return null;
            }

            string relativePath = BuildRelativePath(ItemImageFolder, BuildUniqueFileName(string.Empty, ".jpg"));
            string imagePath = ResolvePath(relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            image.Save(imagePath, ImageFormat.Jpeg);
            return relativePath;
        }

        public string SaveClaimPhoto(Image image, string sourcePath)
        {
            if (image != null)
            {
                string relativePath = BuildRelativePath(ClaimPhotoFolder, BuildUniqueFileName("claim_", ".jpg"));
                string imagePath = ResolvePath(relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                image.Save(imagePath, ImageFormat.Jpeg);
                return relativePath;
            }

            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new InvalidOperationException("Lampirkan foto verifikasi klaim.");
            }

            string extension = Path.GetExtension(sourcePath);
            string relativeDestinationPath = BuildRelativePath(
                ClaimPhotoFolder,
                BuildUniqueFileName("claim_", NormalizeExtension(extension)));
            string destinationPath = ResolvePath(relativeDestinationPath);
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
            File.Copy(sourcePath, destinationPath, true);
            return relativeDestinationPath;
        }

        public string ResolvePath(string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
            {
                return null;
            }

            string expandedPath = Environment.ExpandEnvironmentVariables(storedPath);
            if (Path.IsPathRooted(expandedPath))
            {
                return Path.GetFullPath(expandedPath);
            }

            return Path.GetFullPath(Path.Combine(storageRoot, expandedPath));
        }

        public void DeleteIfExists(string filePath)
        {
            string resolvedPath = ResolvePath(filePath);
            if (!string.IsNullOrWhiteSpace(resolvedPath) && File.Exists(resolvedPath))
            {
                File.Delete(resolvedPath);
            }
        }

        private static string ResolveStorageRoot(string root)
        {
            string expandedRoot = Environment.ExpandEnvironmentVariables(root);
            if (!Path.IsPathRooted(expandedRoot))
            {
                expandedRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, expandedRoot);
            }

            return Path.GetFullPath(expandedRoot);
        }

        private static string BuildRelativePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }

        private static string BuildUniqueFileName(string prefix, string extension)
        {
            return prefix + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" +
                Guid.NewGuid().ToString("N").Substring(0, 8) + extension.ToLowerInvariant();
        }

        private static string NormalizeExtension(string extension)
        {
            return string.IsNullOrWhiteSpace(extension) ? ".jpg" : extension;
        }
    }
}
