using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTrailerService.Models
{
	public class SearchResults : IMovieSearchResult<TrailerInfo>
	{
		public int Page { get; private set; }

		public IEnumerable<TrailerInfo> Results { get; private set; }

		public int TotalPages { get; private set; }

		public int TotalResults { get; private set; }

		public static SearchResults AdaptFrom(IMovieSearchResult<IMovie> adaptee)
		{
			SearchResults adaptedResult = new SearchResults()
			{
				Page = adaptee.Page,
				Results = adaptee.Results.Select(m => TrailerInfo.AdaptFrom(m)),
				TotalPages = adaptee.TotalPages,
				TotalResults = adaptee.TotalResults
			};
			return adaptedResult;
		}
	}
}