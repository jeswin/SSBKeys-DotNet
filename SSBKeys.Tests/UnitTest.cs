using System;
using SSBKeys;
using Xunit;
using Xunit.Abstractions;

namespace SSBKeys.Tests {
    public class SSBKeysTest {
        private readonly ITestOutputHelper output;

        public SSBKeysTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void LoadOrCreateSyncTest() {
            var keys = SSBKeys.LoadOrCreateSync();
            Console.WriteLine("Output was... " + keys.FileName); 
        }
    }
}