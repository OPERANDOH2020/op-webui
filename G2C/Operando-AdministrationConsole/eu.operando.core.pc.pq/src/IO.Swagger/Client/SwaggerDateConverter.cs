/* 
 * Privacy Questionairre API
 *
 * A set of methods to manage privacy quesions.   Privacy questions are generated to form a questionairre that can be displayed to the user. The answers to these questions form a privacy sensitivity index.  For an individual service (OSP) a set of questions can be generated  
 *
 * OpenAPI spec version: 1.0.0
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json.Converters;

namespace eu.operando.core.pc.pq.Client
{
    /// <summary>
    /// Formatter for 'date' swagger formats ss defined by full-date - RFC3339
    /// see https://github.com/OAI/OpenAPI-Specification/blob/master/versions/2.0.md#data-types
    /// </summary>
    public class SwaggerDateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerDateConverter" /> class.
        /// </summary>
        public SwaggerDateConverter()
        {
            // full-date   = date-fullyear "-" date-month "-" date-mday
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
