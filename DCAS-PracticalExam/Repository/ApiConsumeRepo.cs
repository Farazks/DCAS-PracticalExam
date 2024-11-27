using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DCAS_PracticalExam.Repository
{
    public class ApiConsumeRepo : IApiConsume
    {
        private readonly IConfiguration _config;

        public ApiConsumeRepo(IConfiguration config)
        {
            _config = config;
        }

        private async Task<Responder> ValidateUser(LoginDto t, string apiName, string token = null)
        {
            try
            {
                //serialize data in json
                var DataInJson = JsonConvert.SerializeObject(t);
                //now set above serialized data in application/json format
                var stringContent = new StringContent(DataInJson, Encoding.UTF8, "application/json");

                //http client instance
                using (HttpClient httpClient = new HttpClient())
                {
                    //get url
                    string UrlFromAppseting = _config.GetValue<string>("AD:VerificationUrl");
                    //passign url to httpclient
                    httpClient.BaseAddress = new Uri(UrlFromAppseting);

                    if (!String.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    using (var response = await httpClient.PostAsync(apiName, stringContent))
                    {
                        if (!response.IsSuccessStatusCode)
                            return null;
                        if (String.IsNullOrEmpty(token))
                            return new() { res = response.Content.ReadAsStringAsync().Result };

                        var resultByApi = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Responder>(resultByApi);
                    }//response using 
                }//httpclinet using
            }
            catch (Exception ex)
            {
                return null;
            }
        }//validate user

        //active directory login
        public async Task<bool> VerifyUserAsync(string email, string password)
        {
            try
            {
                string adEmail = _config.GetValue<string>("AD:Email"), adPswd = _config.GetValue<string>("AD:Pswd");
                //verify api 
                var response = await ValidateUser(new() { Email = adEmail, Password = adPswd }, "TokenGet");
                if (String.IsNullOrEmpty(response.res))
                    return false;

                //varify user 
                var result = await ValidateUser(new() { UserName = email.Split('@')[0], Password = password }, "verify", response.res);
                if (result.res == "success")
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }//class


    public class LoginDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Responder
    {
        public string res { get; set; }
    }
}
