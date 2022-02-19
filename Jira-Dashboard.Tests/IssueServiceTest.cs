using Jira_Dashboard.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jira_Dashboard.Tests
{
    public class IssueServiceTest : BaseTestService
    {
        [Fact]
        public void ShouldGetIssues()
        {
            var result = _issueService.Get("https://hramirez2240.atlassian.net/rest/api/2/search");

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldGetOneIssue()
        {
            var issue = 3;

            var result = _issueService.Get("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + issue.ToString());

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldCreateIssue()
        {
            var dto = new IssueDto
            {
                Key = "JD",
                Summary = "Summary example",
                Description = "Description example"
            };

            var result = _issueService.Post("https://hramirez2240.atlassian.net/rest/api/2/issue/", dto);

            Assert.False(result.IsFaulted);
        }

        [Fact]
        public void ShouldUpdateIssue()
        {
            var dto = new IssueDto
            {
                Key = "JD",
                Summary = "Summary example",
                Description = "Description example"
            };

            var issueCreated = _issueService.Post("https://hramirez2240.atlassian.net/rest/api/2/issue/", dto);

            var id = 5;

            var dto2 = new IssueDto
            {
                Key = "JD",
                Summary = "Summary completed",
                Description = "Description completed"
            };

            var issueUpdated = _issueService.Update("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + id.ToString(), dto2);

            Assert.NotSame(issueCreated, issueUpdated);
        }

        [Fact]
        public void ShouldDeleteIssue()
        {
            var id = 10;

            var issueDeleted = _issueService.Delete("https://hramirez2240.atlassian.net/rest/api/latest/issue/JD-" + id.ToString());

            Assert.False(issueDeleted.IsFaulted);
        }
    }
}
