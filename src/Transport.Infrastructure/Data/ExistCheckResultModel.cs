using System.Net;
using System.Web.Mvc;
using Transport.Core.Entities.Transport;

namespace Transport.Infrastructure.Data
{
	/// <summary>
	/// Containts TransportRequest And HttpStatusCode
	/// </summary>
	public class ExistCheckResultModel
	{
		public ExistCheckResultModel() { }
		public ExistCheckResultModel(TransportRequest request, HttpStatusCode httpStatusCode)
		{
			Request = request;
			HttpStatusCode = httpStatusCode;
		}

		public TransportRequest Request { get; set; }
		public HttpStatusCode HttpStatusCode { get; set; }

		public bool IsSucceed => Request != null;

		public HttpStatusCodeResult GetStatusCode()
		{
			return new HttpStatusCodeResult(HttpStatusCode);
		}

		public bool Is(HttpStatusCode statusCode) => HttpStatusCode == statusCode;
		public bool IsNotFound => Is(HttpStatusCode.NotFound);
	}
}
