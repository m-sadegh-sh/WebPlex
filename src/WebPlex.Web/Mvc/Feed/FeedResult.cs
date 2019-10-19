namespace WebPlex.Web.Mvc.Feed {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.ServiceModel.Syndication;
	using System.Text;
	using System.Web;
	using System.Web.Mvc;
	using System.Xml;

	using CuttingEdge.Conditions;

	public class FeedResult : ActionResult {
		private readonly string _title;
		private readonly IList<SyndicationItem> _items;
		private readonly string _language;

		public FeedResult(string title, IList<SyndicationItem> items, string language = "fa-IR") {
			_title = title;
			_items = items;
			_language = language;
		}

		public override void ExecuteResult(ControllerContext context) {
			Condition.Requires(context).IsNotNull();

			WriteToResponse(context.HttpContext);
		}

		private void WriteToResponse(HttpContextBase httpContext) {
			var feed = new SyndicationFeed {
					Title = new TextSyndicationContent(_title.CorrectRtl()),
					Language = _language,
					Items = _items
			};

			AddChannelLinks(httpContext.Request, feed);

			var feedData = FeedToString(feed);
			feedData = feedData.Replace("xmlns:a10", "xmlns:atom").Replace("a10:", "atom:");

			var response = httpContext.Response;
			response.ContentEncoding = Encoding.UTF8;
			response.ContentType = "application/rss+xml";
			response.Write(feedData);
			response.End();
		}

		private static void AddChannelLinks(HttpRequestBase request, SyndicationFeed feed) {
			var baseUrl = new UriBuilder(request.Url.Scheme, request.Url.Host).Uri;
			var link = new Uri(baseUrl, request.RawUrl);
			feed.Links.Add(SyndicationLink.CreateSelfLink(link));
			feed.Links.Add(new SyndicationLink {
					Uri = baseUrl,
					RelationshipType = "alternate"
			});
		}

		private static string FeedToString(SyndicationFeed feed) {
			using (var stream = new MemoryStream()) {
				using (var writer = XmlWriter.Create(stream, new XmlWriterSettings {
						Indent = true
				}))
					new Rss20FeedFormatter(feed).WriteTo(writer);

				return Encoding.UTF8.GetString(stream.ToArray());
			}
		}
	}
}