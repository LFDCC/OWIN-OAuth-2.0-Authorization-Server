using SqlSugar;

namespace Auth.Entities
{
    [SugarTable("Sys_Client")]
    public class ClientEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        public string Secret { get; set; }
        public string RedirectUrl { get; set; }
    }
}