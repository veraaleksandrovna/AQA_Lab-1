using System.Reflection;
using Newtonsoft.Json;
using SimpleLogger;

namespace JsonSerialization;

public static class JsonHandler
{
    private static readonly string Path;

    static JsonHandler()
    {
        Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    public static object Deserialzation<T>(string fileName)
    {
        var fullPath =
            $"{Path}{System.IO.Path.DirectorySeparatorChar}Data{System.IO.Path.DirectorySeparatorChar}{fileName}";
        string jsonString;

        try
        {
            jsonString = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(jsonString)!;
        }
        catch (JsonSerializationException ex)
        {
            Logger.Log(ex);
            return null;
        }
        catch (FileNotFoundException ex)
        {
            Logger.Log(ex);
            return null;
        }
        catch (IOException ex)
        {
            Logger.Log(ex);
            return null;
        }
    }

    public static void Serialization<T>(string fileName, T rewriteString)
    {
        var fullPath =
            $"{Path}{System.IO.Path.DirectorySeparatorChar}Data{System.IO.Path.DirectorySeparatorChar}{fileName}";
        string jsonString;
        try
        {
            jsonString = JsonConvert.SerializeObject(rewriteString, Formatting.Indented);
            File.WriteAllText(fullPath, jsonString);
        }
        catch (JsonSerializationException ex)
        {
            Logger.Log(ex);
        }
        catch (FileNotFoundException ex)
        {
            Logger.Log(ex);
        }
        catch (IOException ex)
        {
            Logger.Log(ex);
        }
    }
}
