namespace EFCoreBulkInsert
{
    public static class AppConfig
    {
        public static string ConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
    }
}
