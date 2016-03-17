using System;

namespace TMDB
{
	internal class MovieApiInfo
	{
		private string apiUrlBase;
		private string apiKey;

		public MovieApiInfo(string apiUrlBase, string apiKey)
		{
			this.apiUrlBase = apiUrlBase;
			this.apiKey = apiKey;
		}

		public string GetMovieSearchUrl(string searchTerm, int page)
		{
			return apiUrlBase + "search/movie?api_key=" + apiKey + "&query=" + searchTerm + "&page=" + page;
		}

		public string GetMovieTrailerServiceUrl(string movieId)
		{
			return apiUrlBase + "movie/" + movieId + "/videos?api_key=" + apiKey;
		}

	}
}