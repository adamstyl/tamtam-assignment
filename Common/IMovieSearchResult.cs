using System.Collections.Generic;

namespace Common
{
	public interface IMovieSearchResult<out T> where T : IMovie
	{
		int Page { get; }
		IEnumerable<T> Results { get; }
		int TotalPages { get; }
		int TotalResults { get; }
	}
}