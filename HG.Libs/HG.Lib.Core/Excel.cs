using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;

namespace HG.Libs
{
    public class Excel
    {
        public static List<T> DeserializeList<T>( string path ) where T : new() { 
            var e = new ExcelMapper( path ).Fetch<T>();
            return e.ToList();
        }
    }
}
