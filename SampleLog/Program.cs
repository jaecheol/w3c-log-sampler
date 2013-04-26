using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SampleLog
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int sampleRate = int.Parse(args[0]);
            string fileName = args[1];

            Trace.WriteLine(sampleRate);
            Trace.WriteLine(fileName);

            foreach (var matchedLine in File.ReadLines(fileName)
                                            .Select((line, lineNo) => new {Line = line, LineNo = lineNo})
                                            .Where(lineInfo =>
                                                   lineInfo.Line.StartsWith("#") || lineInfo.LineNo%sampleRate == 0))
            {
                Console.WriteLine(matchedLine.Line);
            }
        }
    }
}