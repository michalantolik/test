using BBInvestigationTool.UnitTests.Data;
using BBInvestigationTool.UnitTests.Helpers;

namespace BBInvestigationTool.UnitTests.Views
{
    public class BBInvForm
    {
        private string viewPath = @"Views\Home\BBInvForm.cshtml";
        private string dataPath = @"Views\BBInvFormData.txt";

        [Fact]
        public void IsComplete()
        {
            // ARRANGE
            var fullPath = GitRepoHelper.FindGitRepoFile(viewPath);
            var sut = ViewLoader.LoadView(fullPath);

            // ACT
            var expectedTags = ViewDataLoader.LoadData(dataPath);
            var actualTags = sut.DocumentNode.SelectNodes("//*[@id]").Select(t => new ViewTag
            {
                TagID = t.GetAttributeValue("id", ""),
                TagName = t.Name
            }).ToArray();

            // ASSERT
            Assert.True(actualTags != null, $"Could not load actual HTML tags with IDs for \"{viewPath}\"");
            Assert.True(actualTags.Length != 0, $"Could not load actual HTML tags with IDs for \"{viewPath}\"");
            Assert.True(expectedTags != null, $"Could not load expected HTML tags with IDs for \"{viewPath}\"");
            Assert.True(expectedTags.Length != 0, $"Could not load expected HTML tags with IDs for \"{viewPath}\"");

            foreach (var singleExpectedTag in expectedTags)
            {
                var expectedIdName = singleExpectedTag.TagID;
                var foundIdName = actualTags.Any(t => t.TagID == expectedIdName);
                Assert.True(foundIdName, $"Expected ID \"{expectedIdName}\" was not found in \"{viewPath}\"");

                var expectedTagName = singleExpectedTag!.TagName;
                var foundTagName = actualTags.Any(t => t.TagID == expectedIdName && t.TagName == expectedTagName);
                Assert.True(foundTagName, $"Expected ID \"{expectedTagName}\" was not found in \"{viewPath}\"");
            }

            foreach (var singleActualTag in actualTags)
            {
                var actualIdName = singleActualTag.TagID;
                var foundIdName = expectedTags.Any(t => t.TagID == actualIdName);
                Assert.True(foundIdName, $"Unknown ID \"{actualIdName}\" was found in \"{viewPath}\"");

                var actualTagName = singleActualTag!.TagName;
                var foundTagName = expectedTags.Any(t => t.TagID == actualIdName && t.TagName == actualTagName);
                Assert.True(foundTagName, $"Unknown ID \"{actualTagName}\" was found in \"{viewPath}\"");
            }
        }
    }
}
