using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Model.ParamModel;
using FewMain.Model.ViewModel;

namespace FewMain.IService
{
    partial interface IFewMainProductServices
    {
        ProductListViewModel GetProduct(ProSearchParam command);
    }
}
