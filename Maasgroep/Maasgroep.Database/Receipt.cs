using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maasgroep.Database
{
	public class Receipt
	{
		[Key]
		public long Id { get; set; }
		public DateTime Created { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Amount { get; set; }
		public Store Store { get; set; }
		public CostCentre CostCentre { get; set; }
		public DateTime? Approved { get; set; }
		public string? Location { get; set; }//TODO: Kevin; GPS zie ik nog even niet vliegen?

	}
}