using HtmlAgilityPack;

namespace BBInvestigationTool.UnitTests.Helpers
{
    internal static class ViewLoader
    {
        internal static HtmlDocument LoadView(string path)
        {
            var fullpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, path));
            var html = File.ReadAllText(fullpath);
            var sut = new HtmlDocument();
            sut.LoadHtml(html);

            return sut;
        }
    }
}
