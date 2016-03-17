using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Common;
using Newtonsoft.Json;

namespace TMDB
{
	public class SearchResultProvider
	{
		private static readonly Dictionary<string, VideoUrlProvider> videoProviders = new Dictionary<string, VideoUrlProvider>();
		private static readonly MovieApiInfo api = new MovieApiInfo("http://api.themoviedb.org/3/", "63032c025acb0afa5d16fb547e5df0d1");
		private static readonly JsonSerializer serializer = JsonSerializer.CreateDefault();

		static SearchResultProvider()
		{
			var youtube = new VideoUrlProvider("YouTube", "https://www.youtube.com/watch?v=");
			videoProviders.Add(youtube.ProviderName.ToLower(), youtube);
		}

		public IMovieSearchResult<IMovie> GetMoviesWithTrailer(string searchTerm, int page = 1, bool removeEmpty = true)
		{
			WebRequest request = WebRequest.Create(api.GetMovieSearchUrl(searchTerm ?? "", page));
			WebResponse response = request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			
			MovieSearchResult movieSearchResult = serializer.Deserialize<MovieSearchResult>(new JsonTextReader(reader));
			AddTrailerInfo(movieSearchResult);
			if (removeEmpty)
			{
				movieSearchResult.Results = movieSearchResult.Results.Where(m => m.TrailerUrl != null); 
			}
			return movieSearchResult;
		}

		private void AddTrailerInfo(MovieSearchResult movieSearchResult)
		{
			foreach (Movie item in movieSearchResult.Results)
			{
				WebRequest request = WebRequest.Create(api.GetMovieTrailerServiceUrl(item.Id));
				WebResponse response = request.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				
				Video trailer = serializer.Deserialize<VideoResults>(new JsonTextReader(reader))
					.Results
					.Where(v => v.Type == "Trailer")
					.FirstOrDefault();
				if (trailer == null) continue;

				string providerKey = trailer.Source.ToLower();
				if (videoProviders.ContainsKey(providerKey))
				{
					item.TrailerUrl = videoProviders[providerKey].GetVideoUrl(trailer.Key);
				}
			}
		}
	}
}