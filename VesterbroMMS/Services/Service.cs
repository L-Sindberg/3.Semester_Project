using DataLibrary;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesterbroMMS.Services
{
    public abstract class Service
    {
        protected readonly IConfiguration _config;
        protected readonly IDataAccess _dataAccess;
        public Service(IConfiguration config)
        {
            _config = config;
            _dataAccess = new DataAccess();
        }
    }
}
