using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDividerr;

namespace TextDivider.Tests
{
    public class SettingsSetTests
    {
        [Fact]
        public void SettingsSet_JsonSerialization_RoundTripWorks()
        {
            // Arrange
            var originalSettings = new SettingsSet();
            originalSettings.SetSeperator("||");
            originalSettings.SetClipboard(true);
            originalSettings.SetPartHeaderText("Part {numerator}");

            // Act
            string json = originalSettings.ToJson();
            var deserializedSettings = SettingsSet.FromJson(json);

            // Assert
            Assert.Equal(originalSettings.GetSeperator(), deserializedSettings.GetSeperator());
            Assert.Equal(originalSettings.clibboardstatus(), deserializedSettings.clibboardstatus());
        }

        [Fact]
        public void SettingsSet_InvalidJson_ThrowsException()
        {
            // Arrange
            string invalidJson = "{ invalid json }";

            // Act & Assert
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => SettingsSet.FromJson(invalidJson));
        }
    }
}
