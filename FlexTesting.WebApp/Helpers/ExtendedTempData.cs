using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlexTesting.WebApp.Helpers
{
    public static class ExtendedTempData
    {
        public static void Add<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            if (tempData.ContainsKey(key))
                tempData.Remove(key);
            tempData[key] = JsonSerializer.Serialize(value);
        }

        public static T Get<T> (this ITempDataDictionary tempData, string key) where T : class
        {
            if (tempData.TryGetValue(key, out object value) && value!=null)
            {
                tempData.Keep();
                var obj = JsonSerializer.Deserialize<T>(value.ToString());
                return obj;
            }
            return null;
        }
    }
}
