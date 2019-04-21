using System;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Core;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cake.Json
{
#pragma warning disable CS1570
    /// <summary>
    /// <para>JSON related cake aliases.</para>
    /// <para>
    ///  In order to use aliases from this addin, you will need to also reference Newtonsoft.Json as an addin.
    ///  Here is what including Cake.Json in your script should look like:
    /// <code>
    /// #addin package:?Cake.Json
    /// #addin package:?Newtonsoft.Json&mp;version=11.0.2
    /// </code>
    /// </para>
    /// </summary>
#pragma warning restore CS1570
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
        /// Serializes an object to a pretty JSON file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="filename">The filename to serialize to.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static void SerializeJsonToPrettyFile<T> (this ICakeContext context, FilePath filename, T instance)
        {
            File.WriteAllText (filename.MakeAbsolute (context.Environment).FullPath,
                Newtonsoft.Json.JsonConvert.SerializeObject (instance, Newtonsoft.Json.Formatting.Indented));
        }

        /// <summary>
        /// Serializes an object to a JSON file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="filename">The filename to serialize to.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static void SerializeJsonToFile<T> (this ICakeContext context, FilePath filename, T instance)
        {
            File.WriteAllText (filename.MakeAbsolute (context.Environment).FullPath,
                Newtonsoft.Json.JsonConvert.SerializeObject (instance));
        }

        /// <summary>
        /// Serializes an object to a JSON string.
        /// </summary>
        /// <returns>The JSON string.</returns>
        /// <param name="context">The context.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static string SerializeJson<T> (this ICakeContext context, T instance)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject (instance);
        }

        /// <summary>
        /// Serializes an object to a pretty JSON string.
        /// </summary>
        /// <returns>The JSON string.</returns>
        /// <param name="context">The context.</param>
        /// <param name="instance">The object to serialize.</param>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        [CakeMethodAlias]
        public static string SerializeJsonPretty<T> (this ICakeContext context, T instance)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject (instance, Newtonsoft.Json.Formatting.Indented);
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

        /// <summary>
        /// Parses the file contents into a JObject.
        /// </summary>
        /// <returns>The JObject.</returns>
        /// <param name="context">The context.</param>
        /// <param name="filename">The filename to serialize from.</param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Newtonsoft.Json.Linq")]
        public static JObject ParseJsonFromFile(this ICakeContext context, FilePath filename)
        {
            return JObject.Parse (File.ReadAllText (filename.MakeAbsolute (context.Environment).FullPath));
        }
    }
}

