using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using Newtonsoft.Json;

namespace TMDB
{
	internal class MovieSearchResult : IMovieSearchResult<Movie>
	{
		[JsonProperty("results")]
		public IEnumerable<Movie> Results { get; set; }
		[JsonProperty("page")]
		public int Page { get; private set; }
		[JsonProperty("total_results")]
		public int TotalResults { get; private set; }
		[JsonProperty("total_pages")]
		public int TotalPages { get; private set; }
	}
}