using System;
using Auth.Entities;
using Auth.Infrastructure.Tools.Encrypt;

namespace Auth.DbRepository
{
    public class DbData
    {
        public static void Initial()
        {
            var context = new DbContext();
            if (!context.UserDb.IsAny(t => t.UserName == "admin") )
            {
                context.UserDb.Insert(new UserEntity
                {
                    UserName = "admin",
                    Password = MD5.Encrypt("000000"),
                    CreateTime = DateTime.Now
                });
            }
            if (!context.ClientDb.IsAny(t => t.ClientId == "000000"))
            {
                context.ClientDb.Insert(new ClientEntity
                {
                    ClientId = "000000",
                    ClientSecret = "111111",
                    RedirectUrl = "http://localhost:38500/Home/Index"
                });
            }
        }
    }
}