using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTrailerService.Models
{
	public class TrailerInfo : IMovie
	{
		public string Id { get; private set; }
		public string Title { get; private set; }
		public string PosterLocation { get; private set; }
		public string Description { get; private set; }
		public string TrailerUrl { get; private set; }

		public static TrailerInfo AdaptFrom(IMovie adaptee)
		{
			TrailerInfo adaptedMovie = new TrailerInfo()
			{
				Id = adaptee.Id,
				Title = adaptee.Title,
				PosterLocation = adaptee.PosterLocation,
				Description = adaptee.Description,
				TrailerUrl = adaptee.TrailerUrl
			};
			return adaptedMovie;
		}
	}
}