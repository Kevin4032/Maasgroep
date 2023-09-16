using System.ComponentModel.DataAnnotations;

namespace Maasgroep.Database
{
	public class Photo
	{
		[Key]
		public long Id { get; set; }
		public Receipt Receipt { get; set; }

		public DateTime Created { get; set; }

		[MaxLength]
		public byte[] Bytes { get; set; }

		public string? Location { get; set; }//TODO: Kevin; GPS zie ik nog even niet vliegen?

	}
}
