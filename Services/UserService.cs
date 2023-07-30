using CW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace CW.Services
{
	public class UserService : IUserService
	{
		private string _baseUrl = "https://c9de-105-163-156-122.ngrok-free.app";
        private readonly ILogger<UserService> _logger;

            public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }
		public async Task<List<UserResponseModel>> GetUsers()
		{ 
			var returnResponse = new List<UserResponseModel>();
			try
			{
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/v1/users";
                    var apiResponse = await client.GetAsync(url);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<List<UserResponseModel>>(response);
                       
                  
                    }
                }
            }catch (Exception ex)
            {
                string message = ex.Message;
            }
			 return returnResponse;
		}

   

        public async Task<bool> AddUser(AddUpdateUserRequest request)
        {

            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/v1/users";
                    var serializeContent = JsonConvert.SerializeObject(request);
                    var apiResponse = await client.PostAsync(url,new StringContent(serializeContent,Encoding.UTF8,"application/json" ));
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<bool>(response);
       

                        if (returnResponse)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        _logger.LogError($"Error response : {apiResponse.StatusCode} -{apiResponse.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        public async Task<bool> updateuser(int id, AddUpdateUserRequest addUpdateUserRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/v1/users/{id}";
                    var serializeContent = JsonConvert.SerializeObject(addUpdateUserRequest);
                    var apiResponse = await client.PutAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<bool>(response);


                        if (returnResponse)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        _logger.LogError($"Error response : {apiResponse.StatusCode} -{apiResponse.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        public async Task<bool> deleteuser(int id)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/v1/users/{id}";
                    client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "DELETE");
                    var apiResponse = await client.DeleteAsync(url);
                    if (apiResponse.StatusCode==HttpStatusCode.NoContent)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<bool>(response);

                        _logger.LogError($" response : {apiResponse.StatusCode}");
                        if (returnResponse)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        _logger.LogError($"Error response : {apiResponse.StatusCode} -{apiResponse.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        public async Task<UserResponseModel> getUserById(int id)
        {
            var returnResponse = new UserResponseModel();
            try
            {
                using (var client = new HttpClient())
                { 
                    string url = $"{_baseUrl}/api/v1/users/{id}";
                    var apiResponse = await client.GetAsync(url);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<UserResponseModel>(response);


                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return returnResponse;
        }
    }
}
