using BSTest.Droid.Helpers;
using BSTest.Data;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace BSTest.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(path, filename);
        }
    }
}