using Common;
using Newtonsoft.Json;

namespace TMDB
{
    internal class Movie : IMovie
	{
		[JsonProperty("id")]
		public string Id { get; private set; }
		[JsonProperty("title")]
		public string Title { get; private set; }
		[JsonProperty("poster_path")]
		public string PosterLocation { get; private set; }
		[JsonProperty("overview")]
		public string Description { get; private set; }
		[JsonIgnore]
		public string TrailerUrl { get; set; }
	}
}