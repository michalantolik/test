namespace BBInvestigationTool.UnitTests.Helpers
{
    internal static class GitRepoHelper
    {
        public static string FindGitRepoFile(string partialPath)
        {
            var root = GetRepoRoot();

            var fullPath = Directory
                .GetFiles(root, "*", SearchOption.AllDirectories)
                .FirstOrDefault(f => f.EndsWith(partialPath));

            return fullPath!;
        }

        private static string GetRepoRoot()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (!Directory.Exists(Path.Combine(dir!.FullName, ".git")))
            {
                dir = dir.Parent;
            }

            return dir.FullName;
        }
    }
}
