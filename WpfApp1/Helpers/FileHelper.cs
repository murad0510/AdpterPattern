using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Serialization;
using WpfApp1.Models;
using WpfApp1.ViewModel.MainWindowViewModel;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace WpfApp1.Helpers
{
    interface IAdapter
    {
        void ReadInformation(string filename);
        void WriterInformation(Human human);
    }

    class JsonAdapter : IAdapter
    {
        private Json _json;

        public JsonAdapter(Json json)
        {
            this._json = json;
        }
        public void ReadInformation(string filename)
        {
            _json.ReadFileJson(filename);
        }

        public void WriterInformation(Human human)
        {
            _json.WriteFileJson(human);
        }
    }

    class XmlAdapter : IAdapter
    {
        private Xml _xml;

        public XmlAdapter(Xml xml)
        {
            this._xml = xml;
        }

        public void ReadInformation(string filename)
        {
            _xml.ReadFileXml(filename);
        }

        public void WriterInformation(Human human)
        {
            _xml.WriteFileXml(human);
        }
    }

    public class Json
    {
        public void WriteFileJson(Human human)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{human.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, human);
                }
            }
        }

        public Human ReadFileJson(string filename)
        {
            Human users = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{filename}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<Human>(jr);
                }
            }
            return users;
        }
    }

    public class Xml
    {
        public void WriteFileXml(Human human)
        {
            //List<Human> humans = new List<Human>();
            using (var writer = new XmlTextWriter($"{human.Name}.xml", Encoding.UTF8))
            {
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Humans");

                //foreach (var human in humans)
                //{
                writer.WriteStartElement("Human");
                writer.WriteElementString(nameof(human.Name), human.Name);
                writer.WriteElementString(nameof(human.Surname), human.Surname);
                writer.WriteElementString(nameof(human.Age), human.Age.ToString());
                writer.WriteElementString(nameof(human.Speciality), human.Speciality);

                writer.WriteEndElement();
                //}
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public List<Human> ReadFileXml(string filename)
        {
            List<Human> users = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (TextReader reader = new StreamReader($"{filename}.xml"))
            {
                users = (List<Human>)serializer.Deserialize(reader);
            }
            return users;
        }
    }

    class Converter
    {
        private readonly IAdapter _adapter;

        public Converter(IAdapter adapter)
        {
            this._adapter = adapter;
        }

        public void Writer(Human human)
        {
            _adapter.WriterInformation(human);
        }

        public void Read(string filename)
        {
            _adapter.ReadInformation(filename);
        }
    }

    class Application
    {
        private Converter _converter;

        public Application(IAdapter adapter)
        {
            _converter = new Converter(adapter);
        }

        public void Write(Human human)
        {
            _converter.Writer(human);
        }

        public void Read(string filename)
        {
            _converter.Read(filename);
        }
    }

    class Aplication
    {
        public void Start(string tex, Human human)
        {
            IAdapter adapter;
            if (tex == "j")
            {
                Json json = new Json();
                adapter = new JsonAdapter(json);
            }
            else
            {
                Xml xml = new Xml();
                adapter = new XmlAdapter(xml);
            }
            Application application = new Application(adapter);

            application.Write(human);

        }

        public void ReadMethod(string filename)
        {
            if (App.JsonPeople.Contains(filename))
            {
                Json json = new Json();
                IAdapter adapter;

                adapter = new JsonAdapter(json);
                Application application = new Application(adapter);

                application.Read(filename);
            }
            else
            {
                Xml json = new Xml();
                IAdapter adapter;

                adapter = new XmlAdapter(json);
                Application application = new Application(adapter);

                application.Read(filename);
            }

        }
    }
}
