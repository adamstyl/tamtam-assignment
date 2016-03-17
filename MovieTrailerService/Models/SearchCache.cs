using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using Common;

namespace MovieTrailerService.Models
{
	internal class SearchCache
	{
		[BsonId]
		public string Keyword { get; private set; }
		public SearchResults SearchResult { get; private set; }
		public DateTime TimePerformed { get; private set; }

		public static SearchCache Create (IMovieSearchResult<IMovie> result, string keyword)
		{
			return new SearchCache()
			{
				Keyword = keyword,
				SearchResult = SearchResults.AdaptFrom(result),
				TimePerformed = DateTime.Now
			};
		}
	}
}