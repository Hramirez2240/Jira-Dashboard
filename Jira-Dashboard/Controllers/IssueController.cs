using Jira_Dashboard.Bl.Dto;
using Jira_Dashboard.Model.Enum;
using Jira_Dashboard.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jira_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("GetAllIssues")]
        public dynamic Get()
        {
            dynamic respond = _issueService.Get("https://hramirez2240.atlassian.net/rest/api/2/search");

            return respond;
        }

        [HttpGet("GetOneIssue")]
        public dynamic Get(string JD)
        {
            dynamic respond = _issueService.Get("https://hramirez2240.atlassian.net/rest/api/latest/issue/" + JD);

            return respond;
        }

        [HttpPost]
        public async Task<dynamic> Create(IssueDto dto)
        {
            dynamic respond = await _issueService.Post("https://hramirez2240.atlassian.net/rest/api/2/issue/", dto);

            return respond;
        }

        [HttpPut]
        public async Task<dynamic> Update(string JD, IssueDto dto)
        {
            dynamic respond = await _issueService.Update("https://hramirez2240.atlassian.net/rest/api/latest/issue/" + JD, dto);

            return respond;
        }

        [HttpDelete]
        public async Task<string> Delete(string JD)
        {
            dynamic respond = await _issueService.Delete("https://hramirez2240.atlassian.net/rest/api/latest/issue/" + JD);

            return respond;
        }

        [HttpPost("ChangeIssueStatus")]
        public async Task<string> IssueStatus(string JD, IssueState issueState)
        {
            var state = (int)issueState;

            dynamic respond = await _issueService.ChangeIssueStatus($"https://hramirez2240.atlassian.net/rest/api/2/issue/{JD}/transitions?expand=transitions.fields", state.ToString());

            return respond;
        }
    }
}
