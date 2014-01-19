using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PEW.Core.Domain
{
	#region Validation extensions

	/// <summary>
	/// A basic class for encapsulating a validation error message
	/// </summary>
	public class ValidationMessage
	{
		public string PropertyName { get; set; }
		public string ErrorMessage { get; set; }
	}

	public static class ExtensionMethods
	{
		/// <summary>
		/// Get all validation errors for the given instance
		/// </summary>
		public static IEnumerable<ValidationMessage> GetErrors(this object instance)
		{
			var metadataAttrib = instance.GetType().GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault();
			var typeObject = metadataAttrib != null ? metadataAttrib.MetadataClassType : instance.GetType();
			var typeProperties = TypeDescriptor.GetProperties(typeObject).Cast<PropertyDescriptor>();
			var classProperties = TypeDescriptor.GetProperties(instance.GetType()).Cast<PropertyDescriptor>();

			return from property in typeProperties
					 join modelProp in classProperties on property.Name equals modelProp.Name
					 from attribute in property.Attributes.OfType<ValidationAttribute>()
					 where !attribute.IsValid(modelProp.GetValue(instance))
					 select new ValidationMessage { PropertyName = property.Name, ErrorMessage = attribute.FormatErrorMessage(string.Empty) };
		}

		/// <summary>
		/// Are there any validation errors?
		/// </summary>
		public static bool IsValid(this Entity model)
		{
			return !model.GetErrors().Any();
		}
	}

	#endregion
}
