using System;

using SqlSugar;

namespace Auth.Entities
{
    [SugarTable("T_User")]
    public class UserEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserId { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public int RoleId { get; set; }

        public bool Sex { get; set; }

        public string CardNo { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int UserState { get; set; }

        public int UserFrom { get; set; }

        public int UserAudit { get; set; }

        public int SchoolId { get; set; }

        public int GradeId { get; set; }

        public int ClassId { get; set; }

        public decimal ScorePlus { get; set; }

        public decimal ScoreSub { get; set; }

        public decimal ScoreCur { get; set; }

        public string QrCode { get; set; }

        public int BlocId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}