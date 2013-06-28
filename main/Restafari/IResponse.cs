using System.IO;

namespace Restafari
{
    public interface IResponse
    {
        Stream GetResponseStream();
    }
}