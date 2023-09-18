﻿using System.ComponentModel.DataAnnotations;

namespace Maasgroep.Database
{
	public record Store
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; } //Unique constraint in Builder.
	}
}
