using System;
using Depra.Configuration.Runtime.SO;

namespace Depra.Configuration.Runtime.Factory
{
    public interface IConfigFactory
    {
        ObjectConfig CreateAndLoad(Type type);
    }
}