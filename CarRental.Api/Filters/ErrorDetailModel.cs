using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Api.Filters
{
    /// <summary>
    /// Detalle de error model
    /// </summary>
    [JsonObject(Title = "error_detail_model")]
    public class ErrorDetailModel
    {
        /// <summary>
        /// ErrorDetailModel
        /// </summary>
        public ErrorDetailModel()
        {
            Errors = new List<Error>();
        }
        /// <summary>
        /// Descripción del código de error Http
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Codigo HTTP
        /// </summary>
        [JsonProperty(PropertyName = "status_code")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Detalle del error
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Lista de errores
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public List<Error> Errors { get; set; }
    }

    /// <summary>
    /// Error
    /// </summary>
    [JsonObject(Title = "error")]
    public class Error
    {
        /// <summary>
        /// Titulo
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Detalle
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }
    }

}
