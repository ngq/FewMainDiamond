using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.CommonModel
{
    public class Pager
    {
        private int _pageindex = 1;
        public int Page
        {
            get
            {
                if (_pageindex < 0)
                {
                    return 0;
                }
                return _pageindex;
            }
            set
            {
                _pageindex = value;
            }
        }
        private int _PageSize;
        public int PageSize
        {
            get
            {
                if (_PageSize == 0)
                {
                    _PageSize = 20;
                }
                if (_PageSize >= 200)
                {
                    _PageSize = 20;
                }
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

       
    }

}
