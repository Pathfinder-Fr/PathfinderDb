using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PathfinderDb.Models
{
	public class Source
	{
		[Key]
		[DisplayName("Identifiant")]
		[StringLength(10)]
		public string Id { get; set; }

		[DisplayName("Nom")]
		[StringLength(80)]
		public string Name { get; set; }

		[DisplayName("Nom anglais")]
		[StringLength(80)]
		public string AltName { get; set; }
	}
}
