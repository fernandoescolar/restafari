namespace Restafari
{
    public interface IRequestFactory
    {
        IRequest Create(string url);
    }
}