using System;
using System.IO;
using System.Threading.Tasks;

namespace CrazyWallPaper.Services
{
    public interface IFileService
    {

        //Task<Stream> GetImageStreamAsync();

        void SavePicture(string name, Stream data, string location = "temp");

        void SaveImageFromByte(byte[] imageByte, string filename);
    }
}
