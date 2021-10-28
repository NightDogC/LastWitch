using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;

namespace HG.Libs
{
    public class Excel
    {
        /// <summary>
        /// 解析为对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="hotRead">是否复制原文件 用于不关闭excel文件下进行热读取</param>
        /// <returns></returns>
        public static List<T> DeserializeList<T>( string path, bool hotRead = false ) where T : new() {
            string p = path;
            if ( hotRead ) {
                p += ".copy.xlsx";
                if ( File.Exists( p ) ) {
                    File.Delete( p );
                }
                File.Copy( path , p );
            }
            var e = new ExcelMapper( p ).Fetch<T>();
            return e.ToList();
        }
    }
}
