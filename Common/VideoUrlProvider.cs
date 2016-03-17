using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
	public class VideoUrlProvider
	{
		private string providerName;
		private string baseUrl;
		public VideoUrlProvider(string providerName, string baseUrl)
		{
			this.providerName = providerName;
			this.baseUrl = baseUrl;
		}

		public string ProviderName
		{
			get { return providerName; }
		}

		public string GetVideoUrl(string videoKey)
		{
			return baseUrl + videoKey;
		}
	}
}