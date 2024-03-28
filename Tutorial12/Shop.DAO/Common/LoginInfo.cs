using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Common
{
    public class LoginInfo
    {
        public int id { get; set; }

        public void logout()
        {
            id = 0;
        }
    }
}
