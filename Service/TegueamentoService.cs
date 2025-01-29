using Dapper;
using MySql.Data.MySqlClient;
using WebAPIEcommerceCoreMVC.IService;
using WebAPIEcommerceCoreMVC.Model;

namespace WebAPIEcommerceCoreMVC.Service
{
    public class TegueamentoService: ITagueamento
    {
        MySqlConnection connection = new MySqlConnection(BDService.conection());
        //control mais ; comenta o codigo
        public async Task<bool> add(Tagueamentos tag)
        {
            try
            {

                var parametro = new DynamicParameters();

               
                parametro.Add("screen", tag.screen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("model", tag.model, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("version", tag.version, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("btn_click", tag.btn_click, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("so", tag.so, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parametro.Add("experient_variantext", tag.experient_variantext, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                //experient_variantext
                parametro.Add("date_", tag.date, System.Data.DbType.String, System.Data.ParameterDirection.Input);

                var users = connection.Query<Tagueamentos>("RegisterTag", parametro, commandType: System.Data.CommandType.StoredProcedure);
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        
    }
}
