namespace Restafari
{
    public interface IRequestDecorator
    {
        void Decorate(IRequest request, RequestSettings settings);

        bool CanDecorate(RequestSettings settings);
    }
}
