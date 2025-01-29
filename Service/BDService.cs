namespace WebAPIEcommerceCoreMVC.Service
{
    public static  class BDService
    {
        public static String conection() {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            // Lê o valor da chave 
            var conectionString = config.GetSection("ConnectionStrings:connection").Value;
            return conectionString;

        }

    }
}
