using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.IService
{
    public interface IProdutoService
    {
        public Task<List<Empresa>> empresas();
        public Task<Empresa> empresa(Int64 id);
        public Task<bool> AddOrUpdate(Empresa emp);
        public Task<bool> Remove(Int64 id);
        public Task<bool> Remove(string nome);
    }
}
