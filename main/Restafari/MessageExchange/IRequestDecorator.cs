namespace Restafari.MessageExchange
{
    internal interface IRequestDecorator
    {
        void Decorate(IRequest request);
    }
}
