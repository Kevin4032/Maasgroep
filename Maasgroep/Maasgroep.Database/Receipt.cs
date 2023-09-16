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
		public Store? Store { get; set; }
		//[ForeignKey("Store")]
		//public long StoreId { get; set; } // Helaas nodig voor Foreign key Relationship
		public CostCentre? CostCentre { get; set; }
		//[ForeignKey("CostCentre")]
		//public long CostCentreId { get; set; } // Helaas nodig voor Foreign key Relationship
		public DateTime? Approved { get; set; }
		public string? Location { get; set; }//TODO: Kevin; GPS zie ik nog even niet vliegen?

	}
}