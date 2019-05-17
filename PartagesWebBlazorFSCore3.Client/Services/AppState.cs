using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services
{
    public class AppState
    {
        private string _jwt;
        public void setJwt(string jwt)
        {
            _jwt = jwt;
        }
        public string getJwt()
        {
            return this._jwt;
        }
    }
}
