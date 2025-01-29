using Dapper;
using MySql.Data.MySqlClient;
using WebAPIEcommerceCoreMVC.IService;
using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.Service
{
    public class EmpresaService : IEmpresaService
    {
                        
        MySqlConnection connection = new MySqlConnection(BDService.conection());

        public Task<bool> Remove(Int64 id)
        {
            try
            {
                var parametro = new DynamicParameters();
                parametro.Add("codigo", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                var users = connection.Query<Empresa>("RemoveEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
        public Task<bool> RemoveNome(string nome)
        {
            try
            {
                var parametro = new DynamicParameters();
                parametro.Add("nome", nome, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var users = connection.Query<Empresa>("RemoveEmpresaNome", parametro, commandType: System.Data.CommandType.StoredProcedure);

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
        public Task<bool> AddOrUpdate(Empresa emp)
        {
            try
            {
                                
                var parametro = new DynamicParameters();
                parametro.Add("codigo", emp.id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                parametro.Add("nome_fantasia", emp.nome_fantasia, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("cnpj", emp.cnpj, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("cep", emp.cep, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("logradouro", emp.logradouro, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("complemento", emp.complemento, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("cadastro", emp.cadastro, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("numero", emp.numero, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var users = connection.Query<Empresa>("RegisterOrUpdateEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);
                
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<Empresa> empresa(Int64 id)
        {
            try
            {

                Empresa empresa = new Empresa();


                var parametro = new DynamicParameters();

                parametro.Add("codigo", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

                var users = connection.Query<Empresa>("GetEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);

                string.Join(Environment.NewLine, users.Select(emp => $"{empresa.id = emp.id},{empresa.nome_fantasia = emp.nome_fantasia},{empresa.cadastro = emp.cadastro}"));
                return Task.FromResult(empresa);

            }
            catch
            {
                return Task.FromResult(new Empresa());
            }
        }
        public async Task<List<Empresa>> empresas()
        {
            Empresa empresa = new Empresa();
            List<Empresa> teste = new List<Empresa>();
            return (await connection.QueryAsync<Empresa>("GetEmpresas", commandType: System.Data.CommandType.StoredProcedure).ConfigureAwait(false)).AsList();           
        }

        public Task<bool> Remove(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
