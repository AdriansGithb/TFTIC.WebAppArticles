using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public byte[] ByteArray
        {
            get { return _session.Get(nameof(ByteArray)); }
            set { _session.Set(nameof(ByteArray), value); }
        }
        public string MyString
        {
            get { return _session.GetString(nameof(MyString)); }
            set { _session.SetString(nameof(MyString), value); }
        }
        public int? MyInt32
        {
            get { return _session.GetInt32(nameof(MyInt32)); }
            set { _session.SetInt32(nameof(MyInt32), value.Value); }
        }

    }
}
