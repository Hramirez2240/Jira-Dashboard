using Jira_Dashboard.Bl.Dto;
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
        public dynamic Get(int id)
        {
            dynamic respond = _issueService.Get("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + id.ToString());

            return respond;
        }

        [HttpPost]
        public async Task<dynamic> Create(IssueDto dto)
        {
            dynamic respond = await _issueService.Post("https://hramirez2240.atlassian.net/rest/api/2/issue/", dto);

            return respond;
        }

        [HttpPut]
        public async Task<dynamic> Update(int id, IssueDto dto)
        {
            dynamic respond = await _issueService.Update("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + id.ToString(), dto);

            return respond;
        }

        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            dynamic respond = await _issueService.Delete("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + id.ToString());

            return respond;
        }

        [HttpPost("ChangeIssueStatus")]
        public async Task<string> IssueStatus(string id, string statusNumber)
        {
            dynamic respond = await _issueService.ChangeIssueStatus($"https://hramirez2240.atlassian.net/rest/api/2/issue/JD-{id}/transitions?expand=transitions.fields", statusNumber);

            return respond;
        }
    }
}
