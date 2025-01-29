using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.IService
{
    public interface ITagueamento
    {
        public Task<bool> add(Tagueamentos tag);
    }
}
