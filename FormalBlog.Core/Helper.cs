using FormalBlog.Infrastructure.EntityFramework;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace FormalBlog.Core
{
    public static class Helper
    {
        public static string Path = string.Empty;
        public static string CurrentEnvironment = string.Empty;
        public static string CurrentRootDomain = string.Empty;
        public static string WebRootPath = string.Empty;

        public static DatabaseContext db;

        /// <summary>
        /// App Settings
        /// </summary>
        public static Infrastructure.ViewModels.AppSettings AppSettings = null;

        public static string AppSettingsSecret = string.Empty;
        public static string ConnectionString = string.Empty;
        public static IConfiguration Configuration;

        public static void Error(Exception ex, string Other = "")
        {
            try
            {
                string FilePath = System.IO.Path.Combine(WebRootPath, "temp\\errors\\" + DateTime.UtcNow.ToString("yyyy-MM-dd") + ".txt");

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine("Date : " + DateTime.UtcNow.ToString());
                    writer.WriteLine();

                    if (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);
                        writer.WriteLine("InnerException : " + ex.InnerException);
                    }
                    writer.WriteLine("Other : " + Other);
                    writer.WriteLine("-----------------------------------------------------------------------------");
                }
            }
            catch (Exception)
            {

            }
        }

        public static void CreateFile(string Path)
        {
            if (!File.Exists(Path))
            {
                File.CreateText(Path).Dispose();
            }
        }

        public static void WriteInFile(string Path, string Text)
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(Text);
                fs.Write(info, 0, info.Length);
            }
        }
        public static string ToCamelCase(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
