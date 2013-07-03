using System.Collections.Generic;
using Newtonsoft.Json;

namespace Restafari
{
    public class Parameters : Dictionary<string, object>
    {
        internal string GetSerialized(string key)
        {
            if (this[key] is string)
            {
                return (string)this[key];
            }

            return JsonConvert.SerializeObject(this[key]);
        }
    }
}