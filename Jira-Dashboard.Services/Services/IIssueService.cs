using Jira_Dashboard.Bl.Dto;
using System.Threading.Tasks;

namespace Jira_Dashboard.Services.Services
{
    public interface IIssueService
    {
        dynamic Get(string url);

        Task<dynamic> Post(string url, IssueDto dto);

        Task<dynamic> Update(string url, IssueDto dto);

        Task<dynamic> Delete(string url);

        Task<dynamic> ChangeIssueStatus(string url, string statusNumber);
    }
}