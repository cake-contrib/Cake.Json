namespace Cake.Json
{
    /// <summary>
    /// Controls how the serialized json will be formatted
    /// </summary>
    /// <remarks>This enum maps 1-to-1 to <code>Newtonsoft.Json.Formatting</code></remarks>
    public enum Formatting
    {
        /// <summary>
        /// Create as compact JSON as possible
        /// </summary>
        None,
        /// <summary>
        /// Pretty-print JSON for human readability
        /// </summary>
        Indented
    }
}
