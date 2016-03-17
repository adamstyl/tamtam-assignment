using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MovieTrailerService.Models;
using TMDB;
using Common;

namespace MovieTrailerService.Controllers
{
	public class SearchController : ApiController
	{
		private static MongoClient client;
		private static SearchResultProvider tmdbProvider = new SearchResultProvider();

		static SearchController()
		{
			BsonClassMap.RegisterClassMap<SearchCache>();
			//BsonClassMap.RegisterClassMap<MovieSearchResult>();
			//BsonClassMap.RegisterClassMap<Movie>();
			//BsonClassMap.RegisterClassMap<Video>();
			client = new MongoClient("mongodb://localhost:27017");
		}

		[HttpGet]
		public IMovieSearchResult<IMovie> Search([FromUri] string query)
		{
			query = query.ToLower();
			IMovieSearchResult<IMovie> result = FetchCached(query);
			if (result == null)
			{
				result = SearchResults.AdaptFrom(tmdbProvider.GetMoviesWithTrailer(query));
				AppendCache(result, query);
			}
			return result;
		}

		private IMovieSearchResult<IMovie> FetchCached(string search)
		{
			return client.GetDatabase("TrailerSearch")
				.GetCollection<SearchCache>("SearchCache")
				.Find(sc => sc.Keyword == search)
				.FirstOrDefault()
				?.SearchResult;
		}

		private void AppendCache(IMovieSearchResult<IMovie> result, string query)
		{
			SearchCache cache = SearchCache.Create(result, query);
			WaitCallback cb = (context) => client.GetDatabase("TrailerSearch")
				 .GetCollection<SearchCache>("SearchCache")
				 .InsertOne(cache);
			ThreadPool.QueueUserWorkItem(cb);
		}
	}
}
