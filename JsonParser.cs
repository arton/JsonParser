//
// Most part of this program was taken from DynamicJson (https://dynamicjson.codeplex.com/)
// 
// Copyright(c) arton 2016
//
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Art.On
{
    public static class JsonParser
    {
        private enum JsonType
        {
            @string, number, boolean, @object, array, @null
        }

        // public static methods

        /// <summary>from JsonSring to DynamicJson</summary>
        public static dynamic Parse(string json)
        {
            return Parse(json, Encoding.Unicode);
        }
        public static dynamic Parse(string json, Encoding encoding)
        {
            using (var reader = JsonReaderWriterFactory.CreateJsonReader(encoding.GetBytes(json), XmlDictionaryReaderQuotas.Max))
            {
                return ToValue(XElement.Load(reader));
            }
        }
        internal static dynamic ToValue(XElement element)
        {
            var type = (JsonType)Enum.Parse(typeof(JsonType), element.Attribute("type").Value);
            switch (type)
            {
                case JsonType.boolean:
                    return (bool)element;
                case JsonType.number:
                    return (double)element;
                case JsonType.@string:
                    return (string)element;
                case JsonType.@object:
                    var obj = new ExpandoObject();
                    foreach (var e in element.Descendants())
                    {
                        ((IDictionary<string, object>)obj).Add(e.Name.LocalName, ToValue(e));
                    }
                    return obj;
                case JsonType.array:
                    var list = new List<dynamic>();
                    foreach (var e in element.Descendants())
                    {
                        list.Add(ToValue(e));
                    }
                    return list.ToArray();
                case JsonType.@null:
                default:
                    return null;
            }
        }
    }
}
