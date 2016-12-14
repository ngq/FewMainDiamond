using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model
{
    public class ResultModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 传回的值
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 传回的消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
