using System;

using SqlSugar;

namespace Auth.Entities
{
    [SugarTable("Sys_User")]
    public class UserEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }
        
        public DateTime? CreateTime { get; set; }
    }
}