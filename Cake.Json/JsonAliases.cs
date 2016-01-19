using System;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Core;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cake.Json
{
    /// <summary>
    /// JSON related cake aliases.
    /// </summary>
    [CakeAliasCategory ("Json")]
    public static class JsonAliases
    {
        /// <summary>
        /// Deserializes the JSON from a file.
        /// </summary>
        /// <returns>The Deserialized Object.</returns>
        /// <param name="context">The context.</param>
        /// <param name="filename">The JSON filename.</param>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        [CakeMethodAlias]
        public static T DeserializeJsonFromFile<T> (this ICakeContext context, FilePath filename)
        {
            var json = File.ReadAllText (filename.MakeAbsolute (context.Environment).FullPath);

            return DeserializeJson<T> (context, json);
        }

        /// <summary>
        /// Deserializes the JSON from a string.
        /// </summary>
        /// <returns>The Deserialized Object.</returns>
        /// <param name="context">The context.</param>
        /// <param name="json">The JSON string.</param>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        [CakeMethodAlias]
        public static T DeserializeJson<T> (this ICakeContext context, string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T> (json);   
        }

        /// <summary>
        /// Serializes an object to a JSON file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="filename">The filename to serialize to.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <param name="formatting">Whether to pretty-print the JSON output.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static void SerializeJsonToFile<T> (this ICakeContext context, FilePath filename, T instance, Formatting formatting = Formatting.None)
        {
            File.WriteAllText (filename.MakeAbsolute (context.Environment).FullPath,
                Newtonsoft.Json.JsonConvert.SerializeObject (instance, new JsonSerializerSettings
                {
                    Formatting = formatting == Formatting.Indented
                    ? Newtonsoft.Json.Formatting.Indented
                    : Newtonsoft.Json.Formatting.None
                }));
        }

        /// <summary>
        /// Serializes an object to a JSON string.
        /// </summary>
        /// <returns>The JSON string.</returns>
        /// <param name="context">The context.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <param name="formatting">Whether to pretty-print the JSON output.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static string SerializeJson<T> (this ICakeContext context, T instance, Formatting formatting = Formatting.None)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject (instance, new JsonSerializerSettings
            {
                Formatting = formatting == Formatting.Indented
                    ? Newtonsoft.Json.Formatting.Indented
                    : Newtonsoft.Json.Formatting.None
            });
        }

        /// <summary>
        /// Parses the JSON into a JObject.
        /// </summary>
        /// <returns>The JObject.</returns>
        /// <param name="context">The context.</param>
        /// <param name="json">The JSON to parse.</param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Newtonsoft.Json.Linq")]
        public static JObject ParseJson (this ICakeContext context, string json)
        {
            return JObject.Parse (json);
        }
    }
}

