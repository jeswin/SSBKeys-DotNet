using System;
using System.IO;

namespace SSBKeys {
    public struct Keys {
        public string FileName { get; set; }
    }

    public static class SSBKeys {
        public static Keys LoadOrCreateSync(string filePath = null) {
            string homeDir = (
                Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX
            ) 
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var fileName = filePath != null ? filePath : Path.Combine(homeDir, ".ssb", "secret");
            var keys = new Keys { FileName = fileName };
            return keys;
        }

    }
}