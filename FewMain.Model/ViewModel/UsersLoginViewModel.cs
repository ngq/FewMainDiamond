using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model
{
    // <summary>
    /// 登录成功返回的登录人信息
    /// </summary>
    public class UsersLoginViewModel
    {

        public UsersLoginViewModel()
        {
            ResultModelInfo = new ResultModel();
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin { get; set; }
        /// <summary>
        /// 登录用户id(在服务端已加密)
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 登录人帐号
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 用户迷你登录密码
        /// </summary>

        public string Password { get; set; }

        /// <summary>
        /// 普通登录密码
        /// </summary>
        public string Passwd { get; set; }

        /// <summary>
        /// 自动登录
        /// </summary>
        public bool AutoLogin { get; set; }

        /// <summary>
        /// 是否记忆密码
        /// </summary>
        public bool MemeryPassword { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 登录人昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 登录成功或者失败信息
        /// </summary>
        public ResultModel ResultModelInfo { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// 页面标识
        /// </summary>
        public string UIMark { get; set; }

        /// <summary>
        /// 登录成功跳转页面
        /// </summary>
        public string ReturnUrl { get; set; }


    }
}
