using Dapper;
using MySql.Data.MySqlClient;
using WebAPIEcommerceCoreMVC.IService;
using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.Service
{
    public class EmpresaService : IEmpresaService
    {
        
        
        //MySqlConnection connection = new MySqlConnection(Environment.GetEnvironmentVariable("connection"));
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=petshop_store;Uid=root;Pwd=root;");
        /*public EmpresaService()
        {
            connection = new MySqlConnection();
            
            connection.ConnectionString = Environment.GetEnvironmentVariable("connection");
        }*/
        public async Task<bool> Remove(Int64 id)
        {
            try
            {
                var parametro = new DynamicParameters();
                parametro.Add("codigo", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                var users = connection.Query<Empresa>("RemoveEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> AddOrUpdate(Empresa emp)
        {
            try
            {
                for (int i = 0; i < 1000001; i++)
                {                    
                    var parametro = new DynamicParameters();                    
                    var users = connection.Query<Empresa>("RegisterOrUpdateEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Empresa> empresa(Int64 id)
        {
            try
            {

                Empresa empresa = new Empresa();


                var parametro = new DynamicParameters();

                parametro.Add("codigo", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

                var users = connection.Query<Empresa>("GetEmpresa", parametro, commandType: System.Data.CommandType.StoredProcedure);

                string.Join(Environment.NewLine, users.Select(emp => $"{empresa.id = emp.id},{empresa.nome_fantasia = emp.nome_fantasia},{empresa.data_cadastro = emp.data_cadastro}"));
                return empresa;

            }
            catch
            {
                return new Empresa();
            }
        }
        public async Task<List<Empresa>> empresas()
        {
            Empresa empresa = new Empresa();
            List<Empresa> teste = new List<Empresa>();
            return (await connection.QueryAsync<Empresa>("GetEmpresas", commandType: System.Data.CommandType.StoredProcedure).ConfigureAwait(false)).AsList();           
        }
    }
}
