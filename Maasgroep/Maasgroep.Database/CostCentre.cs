using System.ComponentModel.DataAnnotations;

namespace Maasgroep.Database
{
	public class CostCentre
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; } //Unique constraint in Builder.
		public Receipt? Receipt { get; set; }
	}
}
