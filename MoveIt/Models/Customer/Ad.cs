using System;
namespace MoveIt.Models.Customer
{
	public class Ad
	{
		// public object Photo { get; set; }

		public long Id { get; set; }

		public long UserId { get; set; }

		public string PhotoURL { get; set; }

		public string AdTitle { get; set; }

		public string TransportDate { get; set; }

		public string TransportHour { get; set; }

		public string FromWhere { get; set; }

		public string ToWhere { get; set; }

		public string DetailedAddress { get; set; }

		public string GoodsCategory { get; set; }

		public string GoodsName { get; set; }

		public string GoodsVolume { get; set; }

		public string GoodsLength { get; set; }

		public string GoodsWidth { get; set; }

		public string GoodsDepth { get; set; }

		public string GoodsWeight { get; set; }

		public string Details { get; set; }

		public bool isDone { get; set; }

	}
}

