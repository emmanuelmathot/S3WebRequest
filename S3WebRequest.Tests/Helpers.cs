using System;
using System.IO;
using System.Net.S3;
using System.Threading.Tasks;

namespace S3WebRequest.Tests
{
    internal class Helpers
    {
        internal static Stream RunContentStreamGenerator(int sizeInMB, Stream stream)
        {
            byte[] data = new byte[8192];
            Random rng = new Random();
            Task.Run(() =>
            {
                for (int i = 0; i < sizeInMB * 128; i++)
                {
                    rng.NextBytes(data);
                    stream.Write(data, 0, data.Length);
                }
                stream.Close();
            });
            return stream;
        }
    }
}