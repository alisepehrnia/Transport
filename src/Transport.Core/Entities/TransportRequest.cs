using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities
{
	public class TransportRequest : Request
	{
		public TransportRequest()
		{
			Persons = new HashSet<User>();
		}

		[Required]
		public DateTime TravelDateTime { get; set; }

		[Required]
		public string Address { get; set; }

		public virtual ICollection<User> Persons { get; set; }
	}
}