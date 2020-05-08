using System;
using System.IO;
using System.Threading;
using ICSharpCode.CodeConverter;
using ICSharpCode.CodeConverter.CommandLine;
using ICSharpCode.CodeConverter.Shared;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "C:\\Users\\Metju\\source\\repos\\WindowsApp1\\WindowsApp1";
            var slnPath = $"{file}.sln";
            var projPath = $"{file}.vbproj";

            var outputDirectoryPath = "C:\\temp\\conversie";
            DirectoryInfo outputDirectory = new DirectoryInfo(outputDirectoryPath);
            MSBuildWorkspaceConverter converter = new MSBuildWorkspaceConverter(projPath, false);
            var converterResultsEnumerable = converter.ConvertProjectsWhereAsync(x => true, Language.CS,
                new Progress<ConversionProgress>(), CancellationToken.None);
            ConversionResultWriter.WriteConvertedAsync(converterResultsEnumerable, slnPath, outputDirectory, true, false, new Progress<string>(), CancellationToken.None);
            Console.WriteLine("Conversie gelukt..");
            Console.ReadKey();
        }
    }
}
