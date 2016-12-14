using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ParamModel
{
    /// <summary>
    /// 用户注册
    /// </summary>
    public class RegisterParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string  Mobile { get; set; }
        public string  Weixin { get; set; }
        public string ValidateCode { get; set; }
    }
}
