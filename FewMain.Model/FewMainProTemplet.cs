//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FewMain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FewMainProTemplet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProTypeId { get; set; }
        public string ProTypeName { get; set; }
        public int ProSeriesId { get; set; }
        public string ProSeriesName { get; set; }
        public string ImgSrcList { get; set; }
        public string ProImgDetail { get; set; }
        public string WebTitle { get; set; }
        public string WebKeyword { get; set; }
        public string WebDescription { get; set; }
        public int IsShow { get; set; }
        public System.DateTime AddTime { get; set; }
    
        public virtual FewMainComment FewMainComment { get; set; }
    }
}
