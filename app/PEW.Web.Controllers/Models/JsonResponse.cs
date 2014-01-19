using System.Collections.Generic;
using PEW.Core.Domain;

namespace PEW.Web.Controllers.Models
{
	#region Jsonreponse classes

	/// <summary>
	/// A jsonresponse for ajax calls. Contains validation information or error information.
	/// </summary>
	public class JsonResponse
	{
		/// <summary>
		/// Creates a empty non error response.
		/// </summary>
		public JsonResponse()
		{
			IsValid = true;
		}

		/// <summary>
		/// Creates a validation error response.
		/// </summary>
		/// <param name="validationMessages"></param>
		public JsonResponse(IEnumerable<ValidationMessage> validationMessages)
		{
			IsValid = false;
			ValidationMessages = validationMessages;
		}

		/// <summary>
		/// Creates a error response.
		/// </summary>
		/// <param name="errorText"></param>
		public JsonResponse(string errorText)
		{
			IsValid = false;
			ValidationMessages = new List<ValidationMessage> { new ValidationMessage { ErrorMessage = errorText, PropertyName = "Exception" } };
		}

		/// <summary>
		/// Indicates if the response is valid for client processing
		/// </summary>
		public bool IsValid { get; set; }

		/// <summary>
		/// A list of messages for the client.
		/// </summary>
		public IEnumerable<ValidationMessage> ValidationMessages { get; set; }
	}

	/// <summary>
	/// A json response containing domain specific data for client handling.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonDataListResponse<T> : JsonResponse where T : class
	{
		/// <summary>
		/// A list of data for client handling.
		/// </summary>
		public IEnumerable<T> Data { get; set; }
	}

	/// <summary>
	/// A json response containing domain specific data for client handling.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonDataItemResponse<T> : JsonResponse where T : class
	{
		/// <summary>
		/// Data for client handling.
		/// </summary>
		public T Data { get; set; }
	}

	#endregion
}
