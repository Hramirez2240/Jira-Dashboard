using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using RestSharp;
using Jira_Dashboard.Bl.Dto;

namespace Jira_Dashboard.Services.Services
{
    public class IssueService : IIssueService
    {
        private readonly HttpClient _httpClient;

        public IssueService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            string encoded = AuthenticateApi.Authentication();

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encoded);
        }

        public dynamic Get(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "GET";
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";

            string encoded = AuthenticateApi.Authentication();

            myWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new(myStream);

            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

            dynamic data = JsonConvert.DeserializeObject(Datos).ToString();

            return data;
        }

        public async Task<dynamic> Post(string url, IssueDto issueDto)
        {

            string json = JsonConvert.SerializeObject(
                    new
                    {
                        fields = new
                        {
                            project = new
                            {
                                key = issueDto.Key
                            },
                            summary = issueDto.Summary,
                            description = issueDto.Description,
                            issuetype = new { name = "Task" }
                        }
                    },

                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        public async Task<dynamic> Update(string url, IssueDto issueDto)
        {
            string json = JsonConvert.SerializeObject(
                    new
                    {
                        fields = new
                        {
                            project = new
                            {
                                key = issueDto.Key
                            },
                            summary = issueDto.Summary,
                            description = issueDto.Description,
                            issuetype = new { name = "Task" }
                        }
                    },

                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        public async Task<dynamic> Delete(string url)
        {
            var result = await _httpClient.DeleteAsync(url);

            return result.ToString();
        }

        public async Task<dynamic> ChangeIssueStatus(string url, string statusNumber)
        {
            string json = JsonConvert.SerializeObject(
                    new
                    {
                        update = new
                        {
                            
                        },
                        transition = new
                        {
                            id = statusNumber
                        }
                    },

                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }
    }
}
