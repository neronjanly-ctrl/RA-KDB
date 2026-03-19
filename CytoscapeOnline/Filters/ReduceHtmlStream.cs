using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CytoscapeOnline
{
    public class ReduceHtmlStream : MemoryStream
    {
        private readonly Stream _outputStream;
        private readonly Encoding _encoding;

        public ReduceHtmlStream(Stream stream, Encoding encoding)
        {
            _outputStream = stream;
            _encoding = encoding;
        }

        public static string Compress(string text)
        {
            var reg1 = new Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|\r|(?=[\n])\s{2,}|(?=[\r])\s{2,}");
            var reg2 = new Regex(@"(?<=[\s])\s+");

            text = reg1.Replace(text, string.Empty);
            text = reg2.Replace(text, string.Empty);

            return text;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var buf = _encoding.GetString(buffer, offset, count);
            buf = Compress(buf);

            var data = _encoding.GetBytes(buf);
            _outputStream.Write(data, 0, data.Length);
            _outputStream.Flush();
        }
    }
}
