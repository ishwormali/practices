using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Core
{
    public class ComponentLocator
    {

        public IDictionary<string, IList<object>> components;
 
        public ComponentLocator()
        {
            components=new Dictionary<string, IList<object>>();
        }

        public void Register(string key,object component)
        {
            IList<object> lst = new List<object>();
            components.TryGetValue(key, out lst);
            lst.Add(component);

            //components.Add(key,component);
        }

        public T Locate<T>(string key)
        {
            if (components.ContainsKey(key))
            {
                return (T)components[key];
            }

            return default(T);
        }

        private static ComponentLocator _componentLocator;

        public static ComponentLocator Instance
        {
            get
            {
                if (_componentLocator==null)
                {
                    _componentLocator=new ComponentLocator();
                }

                return _componentLocator;
            }
        }
    }
}
