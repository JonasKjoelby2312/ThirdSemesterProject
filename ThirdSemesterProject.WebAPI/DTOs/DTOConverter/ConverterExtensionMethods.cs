using System.Reflection;

namespace ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

/// <summary>
/// Provides extension methods for copying properties between objects.
/// </summary>
public static class ConverterExtensionMethods
{
    /// <summary>
    /// Copies properties from the source object to the destination object if the property names and types match.
    /// </summary>
    /// <typeparam name="T">The type of the destination object.</typeparam>
    /// <param name="sourceObject">The source object from which properties are copied.</param>
    /// <param name="destinationObject">The destination object to which properties are copied.</param>
    /// <returns>The destination object with updated property values.</returns>
    /// <remarks>
    /// - Only properties with matching names and types between the source and destination objects are copied.
    /// - Properties in the destination object that are not writable are ignored.
    /// </remarks>
    public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
    {
        foreach (PropertyInfo destinationProperty in destinationObject.GetType().GetProperties().Where(p => p.CanWrite))
        {
            if (!sourceObject.GetType().GetProperties().Any(sourceProp => sourceProp.Name == destinationProperty.Name && sourceProp.PropertyType == destinationProperty.PropertyType)) continue;
            var sourceProp = sourceObject.GetType().GetProperty(destinationProperty.Name);
            destinationProperty.SetValue(destinationObject, sourceProp.GetValue(sourceObject, null), null);
        }
        return destinationObject;
    }
}
