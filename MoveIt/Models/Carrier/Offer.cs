using System;
namespace MoveIt.Models.Carrier
{
	public class Offer
	{
		public long Id { get; set; }

		public long CarrierId { get; set; }

		public long CustomerId { get; set; }

		public long AdId { get; set; }

		public string AdTitle { get; set; }

		public string TransportDay { get; set; }

		public string TransportHour { get; set; }

		public string From { get; set; }

		public string To { get; set; }

		public string OfferValue { get; set; }

		public bool isAccepted { get; set; }

		public bool isCarrierConfirmed { get; set; }

		public bool isCustomerConfirmed { get; set; }
	}
}

