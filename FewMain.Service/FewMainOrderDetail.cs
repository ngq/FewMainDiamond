//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FewMain.Service
{
    using System;
    using System.Collections.Generic;
    
    using FewMain.IRepository;
    using FewMain.IService;
    using Model;
    public partial class  FewMainOrderDetailServices:BaseServices<FewMainOrderDetail>,IFewMainOrderDetailServices
    {
      IFewMainOrderDetailRepository _rep;
    
       public FewMainOrderDetailServices(IFewMainOrderDetailRepository _rep)
       {
        this._rep = _rep;
    	base._dal = _rep;
       }
    }
}
