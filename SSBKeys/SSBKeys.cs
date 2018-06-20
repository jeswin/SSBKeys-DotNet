using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace SSBKeys
{
  public struct Keys
  {
    public string FileName { get; set; }
    public string Curve { get; set; }
    public string Public { get; set; }
    public string Private { get; set; }
    public string Id { get; set; }
  }

  public static class SSBKeys
  {
    public static Keys LoadOrCreateSync(string filePath = null)
    {
      string homeDir = (
        Environment.OSVersion.Platform == PlatformID.Unix ||
        Environment.OSVersion.Platform == PlatformID.MacOSX
      )
        ? Environment.GetEnvironmentVariable("HOME")
        : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

      var ssbSecretPath = filePath != null ? filePath : Path.Combine(homeDir, ".ssb", "secret");

      // .ssb/secret is not strictly JSON. It can contain commented lines, starting with a #
      var jsonContents = string.Join("\r\n", File.ReadAllLines(ssbSecretPath).Where(x => !x.Trim().StartsWith("#")));
      var serialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContents);
      var keys = new Keys
      {
        FileName = ssbSecretPath,
        Curve = serialized["curve"],
        Public = serialized["public"],
        Private = serialized["private"],
        Id = serialized["id"]
      };
      return keys;
    }
  }
}