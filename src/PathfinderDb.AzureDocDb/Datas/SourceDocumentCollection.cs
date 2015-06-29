using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderDb.Datas
{
	public sealed class SourceDocumentCollection
	{
		private readonly DocumentClient client;

		internal SourceDocumentCollection(DocumentClient client)
		{
			this.client = client;
            //this.client.ReadDocumentCollectionAsync();
		}
	}
}
