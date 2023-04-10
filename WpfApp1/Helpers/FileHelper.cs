using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfApp1.Models;

namespace WpfApp1.Helpers
{
    internal class FileHelper
    {
        public static void WriteBooks(Human human) 
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{human.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, human);
                }
            }
        }

        //public static List<Human> ReadStudents()
        //{
        //    List<Human> students = null;
        //    var serializer = new JsonSerializer();
        //    using (var sr = new StreamReader("students.json"))
        //    {
        //        using (var jr = new JsonTextReader(sr))
        //        {
        //            students = serializer.Deserialize<List<Human>>(jr);
        //        }
        //    }
        //    return students;
        //}
    }
}
