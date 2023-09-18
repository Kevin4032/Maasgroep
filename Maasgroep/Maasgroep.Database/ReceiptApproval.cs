using System.ComponentModel.DataAnnotations;

namespace Maasgroep.Database
{
	public record ReceiptApproval
	{
		[Key]
		public Receipt Receipt { get; set; }
		public DateTime Approved { get; set; }
		public MaasgroepMember ApprovedBy { get; set; }
	}
}
