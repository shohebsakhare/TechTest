using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTestApiHandler.IRepositories;
using TechTestCore.Model;

namespace TechTest.Controllers
{
    public class DataRetriverController : Controller
    {
        private readonly IDataRetriverAPIService _DataretriverAPI;
        public DataRetriverController(IDataRetriverAPIService _DataretriverAPI)
        {
            this._DataretriverAPI = _DataretriverAPI;
        }

        //API to get all album data with photos
        [Route("api/DataRetriverController/getAllData/")]
        [HttpGet]
        public async Task<List<albumData>> getAllData()
        {
            List<albumData> retrnData = new List<albumData>();
            try
            {
               retrnData = await _DataretriverAPI.getAllData();
               return retrnData;
            }
            catch (Exception ex)
            {
            }
            return retrnData;
        }

        //API to get data of specific user
        [Route("api/DataRetriverController/getUserIdData/")]
        [HttpGet]
        public async Task<List<albumData>> getUserIdData(int UserId)
        {
            List<albumData> retrnData = new List<albumData>();
            try
            {
                retrnData = await _DataretriverAPI.getUserIdData(UserId);
                return retrnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retrnData;
        }
    }
}
