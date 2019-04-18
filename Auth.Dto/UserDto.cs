using System;

namespace Auth.Dto
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int UserState { get; set; }

        /// <summary>
        /// 用户来源
        /// </summary>
        public int UserFrom { get; set; }

        /// <summary>
        /// 审核状态 1通过 2待审 3不通过
        /// </summary>
        public int UserAudit { get; set; }

        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// 年级ID
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 加分累计
        /// </summary>
        public decimal ScorePlus { get; set; }

        /// <summary>
        /// 减分累计
        /// </summary>
        public decimal ScoreSub { get; set; }

        /// <summary>
        /// 当前积分
        /// </summary>
        public decimal ScoreCur { get; set; }

        /// <summary>
        /// 二维码路径
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// 集团ID
        /// </summary>
        public int BlocId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}