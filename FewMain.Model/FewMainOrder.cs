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
    
    public partial class FewMainOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FewMainOrder()
        {
            this.FewMainOrderDetail = new HashSet<FewMainOrderDetail>();
        }
    
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatus { get; set; }
        public string StatusName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Consignee { get; set; }
        public string Address { get; set; }
        public decimal TotalMoney { get; set; }
        public string Remark { get; set; }
        public System.DateTime AddTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
    
        public virtual FewMainOrderType FewMainOrderType { get; set; }
        public virtual FewMainUsers FewMainUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FewMainOrderDetail> FewMainOrderDetail { get; set; }
    }
}
