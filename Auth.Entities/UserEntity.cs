using SqlSugar;

namespace Auth.Entities
{
    [SugarTable("Sys_User")]
    public class UserEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}