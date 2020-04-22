using System.Collections.Generic;

namespace LBHVerificationHubAPI.Boundary.V1
{
    public abstract class AbstractRequest
    {
        public Dictionary<string, string> GetQueryDict()
        {
            var dict = new Dictionary<string, string>();
            foreach (var prop in this.GetType().GetProperties())
                if (prop.GetValue(this, null) != null)
                    dict.Add(prop.Name, prop.GetValue(this, null).ToString());

            return dict;
        }
    }
}
