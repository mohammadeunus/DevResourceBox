using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using WafiCommerce.Imports;

namespace WafiCommerce.Common;

public class StreamFileProcessor : ITransientDependency
{

    /// <summary>
    /// Retrieves data from an Excel file and maps it to a list of objects of type T.
    /// </summary>
    /// <typeparam name="T">The type of objects to create and populate from Excel data. Must implement <see cref="IExcelValidatorDto"/>.</typeparam>
    /// <param name="file">The Excel file content to read from.</param>
    /// <param name="expectedHeaders">The expected headers in the Excel file corresponding to properties of type T.</param>
    /// <returns>A list of objects of type T populated with data from the Excel file.</returns>
    /// <remarks>
    /// If any data for the expected headers is missing, the row will not be added to the output list.
    /// Additionally, properties in T must be of type string, double, or int; otherwise, the row will not be added to the output list.
    /// </remarks>
    public List<T> GetObjectFromExcelData<T>(IRemoteStreamContent file, string[] expectedHeaders) where T : IExcelValidatorDto
    {
        var output = new List<T>();
        #region validations 
        var extension = Path.GetExtension(file.FileName);
        if (extension != ".xlsx" && extension != ".xls")
            throw new UserFriendlyException("Invalid file type!");

        var properties = typeof(T).GetProperties();

        // check if the expectedHeaders are available or not in the T object.
        for (int col = 0; col < expectedHeaders.Length; col++)
        {
            var header = expectedHeaders[col];
            var property = properties.FirstOrDefault(p => p.Name == header);
            if (property is null) throw new Exception("Invalid file format, no expectedHeaders found in T.");
        }

        #endregion


        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(file.GetStream()))
        {
            var worksheet = package.Workbook.Worksheets[0];

            for (int i = 1; i <= expectedHeaders.Length; i++)
            {
                if (worksheet.Cells[1, i].Value?.ToString().Trim() != expectedHeaders[i - 1])
                    throw new UserFriendlyException("Invalid file format!");
            }

            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                T newObject = Activator.CreateInstance<T>();

                int validColumnsCount = 0;
                int expectedHeadersLength = expectedHeaders.Length;

                for (int col = 0; col < expectedHeadersLength; col++)
                {
                    var header = expectedHeaders[col];
                    var cellValue = Convert.ToString(worksheet.Cells[row, col + 1].Value);

                    var property = properties.FirstOrDefault(p => p.Name == header);

                    if (SetValueInNewObject(property, newObject, cellValue))
                        validColumnsCount++;
                }

                if (validColumnsCount == expectedHeadersLength) output.Add(newObject);
            }
        }

        return output;
    }


    /// <summary>
    /// Sets the value of a property in a new object based on the provided value, converting types if necessary.
    /// </summary>
    /// <param name="propertyInfo">The PropertyInfo object representing the property to set.</param>
    /// <param name="newObject">The object instance on which to set the property value.</param>
    /// <param name="value">The string value to set on the property.</param>
    /// <returns>True if the value was successfully set on the property; false if the value was null, empty, or whitespace.</returns>
    private bool SetValueInNewObject(PropertyInfo propertyInfo, object newObject, string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        if (propertyInfo.PropertyType == typeof(string))
        {
            propertyInfo.SetValue(newObject, value);
        }
        else if (propertyInfo.PropertyType == typeof(double))
        {
            propertyInfo.SetValue(newObject, Convert.ToSingle(value));
        }
        else if (propertyInfo.PropertyType == typeof(int))
        {
            propertyInfo.SetValue(newObject, Convert.ToInt64(value));
        }
        else
        {
            return false;
        }

        return true;
    }

}
