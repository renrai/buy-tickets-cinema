using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataRestApplication.DTO
{
    public class IMDBMovieDTO
    {

            [JsonPropertyName("id")]
            public string ImdbId { get; set; }
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("stars")]
            public string Stars { get; set; }
            [JsonPropertyName("releaseDate")]
            public DateTime ReleaseDate { get; set; }

    }
}