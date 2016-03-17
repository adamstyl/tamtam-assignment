using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TMDB
{
	internal class VideoResults
	{
		[JsonProperty("results")]
		public IEnumerable<Video> Results { get; private set; }
	}
}