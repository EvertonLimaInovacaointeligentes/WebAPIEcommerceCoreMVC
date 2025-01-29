using Dapper;
using MySql.Data.MySqlClient;
using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.Service
{
    public class ChatService
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
        public Task<bool> AddOrUpdate(Chat chat)
        {
            try
            {

                var parametro = new DynamicParameters();
                parametro.Add("codigo", chat.id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                parametro.Add("assundo", chat.assunto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("tezto", chat.texto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("empresaId", chat.empresaId, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                parametro.Add("usuarioId", chat.usuarioId, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                parametro.Add("data_chat", chat.data_chat, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var users = connection.Query<Empresa>("RegisterOrUpdateChat", parametro, commandType: System.Data.CommandType.StoredProcedure);

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<Chat> chat(Int64 id)
        {
            try
            {

                Chat chat = new Chat();


                var parametro = new DynamicParameters();

                parametro.Add("codigo", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

                var users = connection.Query<Chat>("GetChat", parametro, commandType: System.Data.CommandType.StoredProcedure);

                string.Join(Environment.NewLine, users.Select(emp => $"{chat.id = emp.id},{chat.assunto = emp.assunto},{chat.texto = emp.texto}"));
                return Task.FromResult(chat);

            }
            catch
            {
                return Task.FromResult(new Chat());
            }
        }
        public async Task<List<Chat>> empresas()
        {
            Chat empresa = new Chat();
            List<Chat> teste = new List<Chat>();
            return (await connection.QueryAsync<Chat>("GetChats", commandType: System.Data.CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
        }

        public Task<bool> Remove(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
