using System.IO;
using System.Threading.Tasks;

namespace TPO_Lab3_Mobile
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}