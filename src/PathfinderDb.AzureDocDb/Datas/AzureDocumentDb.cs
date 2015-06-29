using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace PathfinderDb.Datas
{
	public class AzureDocumentDb
	{
		private const string EndpointUrl = "<your endpoint URI>";
		private const string AuthorizationKey = "<your key>";

		private readonly DocumentClient client;

		private SourceDocumentCollection sources;

		public AzureDocumentDb()
		{
			this.client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
		}

		public SourceDocumentCollection Sources
		{
			get { return this.sources ?? (this.sources = new SourceDocumentCollection(this.client)); }
		}
	}
}
