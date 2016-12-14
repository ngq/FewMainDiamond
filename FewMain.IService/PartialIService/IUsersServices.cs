using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Model;

namespace FewMain.IService
{
    public partial interface IUsersServices
    {
        bool  Login(UsersLoginParam userModel);
    }
}
