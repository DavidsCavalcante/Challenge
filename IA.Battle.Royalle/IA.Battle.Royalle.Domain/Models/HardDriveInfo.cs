/// <summary>
/// IA.Battle.Royalle.Domain.Models
/// </summary>

namespace IA.Battle.Royalle.Domain.Models
{
    using System;

    /// <summary>
    /// HardDriveInfo
    /// </summary>
    public class HardDriveInfo
    {

        /// <summary>
        /// HardDriveInfo
        /// </summary>
        /// <param name="diskName">string diskName</param>
        /// <param name="freeSpaceInBytes">long freeSpaceInBytes</param>
        /// <param name="totalSizeInBytes">long totalSizeInBytes</param>
        public HardDriveInfo(string diskName, long freeSpaceInBytes, long totalSizeInBytes)
        {
            DiskName = diskName;
            FreeSpace = FormatBytes(freeSpaceInBytes);
            TotalSize = FormatBytes(totalSizeInBytes);
        }

        /// <summary>
        /// DiskName
        /// </summary>
        public string DiskName { get; private set; }

        /// <summary>
        /// FreeSpace
        /// </summary>
        public string FreeSpace { get; private set; }

        /// <summary>
        /// TotalSize
        /// </summary>
        public string TotalSize { get; private set; }

        /// <summary>
        /// FormatBytes
        /// </summary>
        /// <param name="bytes">long bytes</param>
        /// <returns>string FormatBytes</returns>
        private string FormatBytes(long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024;
            }
            
            return String.Format("{0:0.##} {1}", dblSByte, suffix[i]);
        }
    }
}