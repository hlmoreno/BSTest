using BSTest.Data;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Model
{
    public class BDInstance
    {
        public static IPersistencia BD = new BaseDatos(DependencyService.Get<IFileHelper>().GetLocalFilePath("BSTest.db3"));
    }
}
