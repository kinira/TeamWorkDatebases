using System;
using System.IO;
using System.IO.Compression;

namespace LoadExcelReportsFromZipFile
{
    public class ExtractZipFiles
    {
        public void ExtractFile()
        {           
            string zipPath = @"..\..\..\Sample-Sales-Reports.zip";
            string extractPath = @"..\..\..\ExtractedZip\";

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
