using BBInvestigationTool.UnitTests.Data;

namespace BBInvestigationTool.UnitTests.Helpers
{
    internal static class ViewDataLoader
    {
        internal static ViewTag[] LoadData(string partialPath)
        {
            var fullPath = GitRepoHelper.FindGitRepoFile(partialPath);

            var lines = File.ReadAllLines(fullPath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .Where(l => l.Contains(","))
                            .ToArray();

            var results = new List<ViewTag>();

            foreach (var singleLine in lines)
            {
                var parts = singleLine.Split(',').ToArray();

                if (parts.Length == 2)
                {
                    results.Add(new ViewTag
                    {
                        TagID = parts[0].Trim(),
                        TagName = parts[1].Trim(),
                    });
                }
            }

            return results.ToArray();
        }
    }
}
