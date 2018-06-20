using System;
using Xunit;
using SSBKeys;

namespace SSBKeys.Tests
{
	public class SSBKeysTest
	{
		[Fact]
		public void LoadOrCreateSyncTest()
		{
			var keys = SSBKeys.LoadOrCreateSync();
			Console.WriteLine("Output was... " + keys.FileName);
		}
	}
}