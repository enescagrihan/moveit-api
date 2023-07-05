using System;
namespace MoveIt.Models
{
	public class User
	{
		public long Id { get; set; }

		public string EMail { get; set; }

		public string PhoneNumber { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public string Password { get; set; }

		public bool isCarrier { get; set; }
	}
}

