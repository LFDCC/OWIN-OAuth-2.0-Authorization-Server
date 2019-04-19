using SqlSugar;

namespace Auth.Entities
{
    [SugarTable("T_Client")]
    public class ClientEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientSecret { get; set; }

        public string ClientImage { get; set; }

        public string ClientDesc { get; set; }

        public string RedirectUrl { get; set; }

        public int Sort { get; set; }

        public string GrantType { get; set; }
    }
}