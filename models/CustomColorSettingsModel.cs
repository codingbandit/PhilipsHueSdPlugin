using System;
using System.Collections.Generic;
using System.Text;

namespace PhilipsHueSdPlugin.Models
{
    public class CustomColorSettingsModel : BaseSettingsModel
    {
        public string colorHex { get; set; } = string.Empty;
        public int lightIndex { get; set; } = 1;

        public override bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrWhiteSpace(colorHex);
        }
    }
}
