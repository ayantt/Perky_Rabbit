using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF
{
    public static class SessionManager
    {
        private static Dictionary<string, object> _session = new Dictionary<string, object>();

        public static void SetValue(string key, object value)
        {
            if (_session.ContainsKey(key))
            {
                _session[key] = value;
            }
            else
            {
                _session.Add(key, value);
            }
        }

        public static T GetValue<T>(string key)
        {
            if (_session.ContainsKey(key))
            {
                return (T)_session[key];
            }
            else
            {
                return default(T);
            }
        }

        public static void ClearSession()
        {
            _session.Clear();
        }
    }

}
