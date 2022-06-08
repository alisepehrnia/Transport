using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities
{
	public class TransportRequest : Request
	{
		public TransportRequest()
		{
			Persons = new HashSet<UserInfo>();
		}

		[Required]
		public DateTime TravelDateTime { get; set; }

		[Required]
		public string Address { get; set; }

		public virtual ICollection<UserInfo> Persons { get; set; }
	}
}