using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestCore.Model;

namespace TechTestApiHandler.IRepositories
{
    public interface IDataRetriverAPIService
    {
        public Task<List<albumData>> getAllData();
        public Task<List<albumData>> getUserIdData(int UserId);
    }
}
