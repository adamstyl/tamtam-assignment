using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TMDB
{
	internal class Video
	{
		[JsonProperty("id")]
		public string Id { get; private set; }
		[JsonProperty("key")]
		public string Key { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("type")]
		public string Type { get; private set; }
		[JsonProperty("site")]
		public string Source{ get; private set; }
	}
}