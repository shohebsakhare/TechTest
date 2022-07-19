using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTestCore.Model;
using TechTestApiHandler.IRepositories;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace TechTestApiHandler.Repositories
{
    public class DataRetriverAPIService : IDataRetriverAPIService
    {
        private IOptions<AppSetting> ConfigSettings;

        public DataRetriverAPIService(IOptions<AppSetting> settings)
        {
            ConfigSettings = settings;
        }
        public async Task<List<albumData>> getAllData()
        {
            try
            {
                List<albumData> rtnData = new List<albumData>(); // Object used to return list of data

                albumData apiData = new albumData();//Object used to hold data received from URL

                string albumDataEndpoint = ConfigSettings.Value.endpoint + "albums"; // common url coming from app.config
                string photoDataEndpoint = ConfigSettings.Value.endpoint + "photos";
                using (HttpClient client = new HttpClient())
                {
                    //Fetching all album data
                    var albumResponse = await client.GetAsync(albumDataEndpoint);
                    var album_data = JsonConvert.DeserializeObject<List<albumData>>(albumResponse.Content.ReadAsStringAsync().Result);

                    //looping on album data and getting photo data respective to the albumId in list
                    foreach (var item in album_data)
                    {
                        apiData = item;
                        var response = await client.GetAsync(QueryHelpers.AddQueryString(photoDataEndpoint, "albumId", item.id.ToString()));
                        apiData.photo_data = JsonConvert.DeserializeObject<List<photoData>>(response.Content.ReadAsStringAsync().Result);
                        rtnData.Add(apiData);
                    }

                    return rtnData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<albumData>> getUserIdData(int UserId)
        {
            try
            {
                List<albumData> rtnUserIdData = new List<albumData>();// Object used to return list of data
                albumData apiUserIdData = new albumData();//Object used to hold data received from URL

                string albumUserIdDataEndpoint = ConfigSettings.Value.endpoint + "albums";// common endpoint url coming from app.config
                string photoUserIdDataEndpoint = ConfigSettings.Value.endpoint + "photos";
                using (HttpClient client = new HttpClient())
                {
                    //Fetching album data for UserId received in parameter
                    var albumResponse = await client.GetAsync(QueryHelpers.AddQueryString(albumUserIdDataEndpoint, "userId", UserId.ToString()));
                    var album_data = JsonConvert.DeserializeObject<List<albumData>>(albumResponse.Content.ReadAsStringAsync().Result);

                    //looping on album data and getting photo data respective to the albumId in list
                    foreach (var item in album_data)
                    {
                        apiUserIdData = item;
                        var response = await client.GetAsync(QueryHelpers.AddQueryString(photoUserIdDataEndpoint, "albumId", item.id.ToString()));
                        apiUserIdData.photo_data = JsonConvert.DeserializeObject<List<photoData>>(response.Content.ReadAsStringAsync().Result);
                        rtnUserIdData.Add(apiUserIdData);
                    }

                    return rtnUserIdData;
                }
                return rtnUserIdData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
