using Depra.Configuration.Editor;
using Depra.Configuration.Runtime.SO;
using NUnit.Framework;

namespace Depra.Configuration.Tests
{
    public class ConfigurationTests
    {
        [Test]
        public void Can_Get_Config_By_Type()
        {
            Assert.IsNotNull(ObjectConfig.GetConfig(typeof(EditorConfig)));
        }

        [Test]
        public void CanGet_Config_By_Generic_Type()
        {
            Assert.IsNotNull(ObjectConfig<EditorConfig>.GetConfig());
        }
        
        [Test]
        public void Editor_Config_Existed()
        {
            Assert.IsNotNull(EditorConfig.Instance);
        }
    }
}