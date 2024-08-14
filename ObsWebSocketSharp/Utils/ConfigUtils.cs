using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObsWebSocketSharp.Objs;

namespace ObsWebSocketSharp.Utils;

public static class ConfigUtils
{
    private const string FileName = "wsconfig.json";

    public static ConfigObj Config { get; private set; }

    public static void Init()
    {
        if (File.Exists(FileName))
        {
            ReadConfig();
        }
        if (Config == null)
        {
            Config = MakeDefault();
            SaveConfig();
        }
    }

    private static void ReadConfig()
    {
        var data = File.ReadAllText(FileName);
        var config = JsonConvert.DeserializeObject<ConfigObj>(data);
        if (config != null)
        {
            Config = config;
        }
    }

    private static void SaveConfig()
    {
        File.WriteAllText(FileName, JsonConvert.SerializeObject(Config));
    }

    private static ConfigObj MakeDefault()
    {
        return new()
        {
            Url = "ws://localhost:4455"
        };
    }
}
