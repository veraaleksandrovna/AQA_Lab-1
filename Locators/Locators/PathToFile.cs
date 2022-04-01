using System.IO;
using System.Reflection;

namespace Locators;

public class PathToFile
{
    private static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static readonly string FilePath =
        $"file:{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}index.html";
}