using System;
using Depra.Configuration.Runtime.SO;

namespace Depra.Configuration.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SubConfigAttribute : ConfigAttribute
    {
        public ObjectConfig Parent { get; }
        
        public SubConfigAttribute(ObjectConfig parent, string name, int order = -1) : base(name, order)
        {
            Parent = parent;
        }
    }
}