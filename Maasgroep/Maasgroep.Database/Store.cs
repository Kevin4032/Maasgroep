using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maasgroep.Database
{
	public class Store
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; } //Unique constraint in Builder.
	}
}
