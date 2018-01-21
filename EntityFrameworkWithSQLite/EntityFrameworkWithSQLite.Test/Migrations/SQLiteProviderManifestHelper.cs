using System;

namespace EntityFrameworkWithSQLite.Test.Migrations
{
    static class SQLiteProviderManifestHelper
    {
        public const int MaxObjectNameLength = 255;

        /// <summary>
        /// Quotes an identifier
        /// </summary>
        /// <param name="name">Identifier name</param>
        /// <returns>The quoted identifier</returns>
        internal static string QuoteIdentifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            return "\"" + name.Replace("\"", "\"\"") + "\"";
        }
    }
}
