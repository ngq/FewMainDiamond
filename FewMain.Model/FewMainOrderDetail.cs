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
    
    public partial class FewMainOrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProImg { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Material { get; set; }
        public string HandSize { get; set; }
        public string ProInfo { get; set; }
    
        public virtual FewMainOrder FewMainOrder { get; set; }
    }
}
