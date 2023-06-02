using DataRestApplication.DTO;
using DataRestApplication.Repositories.Abstraction;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DomainApplication.Models;
using Microsoft.VisualBasic.FileIO;
using RestSharp;
using System.Runtime.ConstrainedExecution;

namespace DataRestApplication.Repositories
{
    public class IMDBRepository : IIMDBRepository
    {
        private readonly IRestClient _client;
        private readonly IOptions<ConfigOption> _options;

        public IMDBRepository(HttpClient httpClient, IOptions<ConfigOption> options)
        {
            _client = new RestClient("https://imdb-api.com/en/API/");
            _options = options;

        }
        public async Task<IMDBMovieDTO> GetMoviesDetails(string movieId)
        {
            try
            {
                var request = new RestRequest($"Title/{_options.Value.ImdbApyKey}/{movieId}");

                var response = await _client.ExecuteAsync<IMDBMovieDTO>(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error returning data from IMDB");
                }
                return response.Data;
            }catch(Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
