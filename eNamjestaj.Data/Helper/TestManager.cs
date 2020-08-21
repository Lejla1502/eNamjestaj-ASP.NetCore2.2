using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Helper
{
    public class TestManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public TestManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
    }
}
