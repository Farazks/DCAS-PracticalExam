using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace DCAS_PracticalExam.Services
{
    public static class SmsService
    {
        public static bool Send(IConfiguration _config, SmsDto sms)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var DataInJson = JsonConvert.SerializeObject(sms);
                    var stringContent = new StringContent(DataInJson, Encoding.UTF8, "application/json");

                    httpClient.BaseAddress = new Uri(_config.GetValue<string>("SmsApiUrl"));
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    httpClient.DefaultRequestHeaders.Add("x-Gateway-APIKey", "00855e09-7c02-4b37-897f-5g2h5d6s5u8f");

                    var response = httpClient.PostAsync("Home/sendMessage", stringContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //string resultByApi = response.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
    public class SmsDto
    {
        public string _mobileNo { get; set; }
        public string _message { get; set; }
    }
}

