using Depra.Configuration.Editor;
using Depra.Configuration.Runtime.Assets;
using NUnit.Framework;

namespace Depra.Configuration.Tests
{
    public class ConfigurationTests
    {
        [Test]
        public void Can_Get_AssetConfig_By_Type()
        {
            Assert.IsNotNull(ConfigObject.GetConfig(typeof(EditorConfig)));
        }

        [Test]
        public void CanGet_AssetConfig_By_Generic_Type()
        {
            Assert.IsNotNull(ConfigObject<EditorConfig>.Instance);
        }
        
        [Test]
        public void Editor_Config_Existed()
        {
            Assert.IsNotNull(EditorConfig.Instance);
        }
    }
}