using Jira_Dashboard.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jira_Dashboard.Tests
{
    public class BaseTestService
    {
        protected readonly IssueService _issueService;

        public BaseTestService()
        {
            HttpClient httpClient = new();

            _issueService = new IssueService(httpClient);
        }
    }
}
