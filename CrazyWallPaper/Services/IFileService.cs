using System;
using System.IO;
using System.Threading.Tasks;

namespace CrazyWallPaper.Services
{
    public interface IFileService
    {

        //Task<Stream> GetImageStreamAsync();

        void SaveImageFromByte(byte[] imageByte, string filename);
    }
}
