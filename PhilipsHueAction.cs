﻿using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;
using Q42.HueApi.Interfaces;
using StreamDeckLib;
using StreamDeckLib.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhilipsHueSdPlugin
{
  [ActionUuid(Uuid="com.trilliuminnovations.philipshue.custom")]
  public class PhilipsHueAction : BaseStreamDeckActionWithSettingsModel<Models.CustomColorSettingsModel>
  {
        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            if (SettingsModel.IsValid())
            {
                ILocalHueClient client = new LocalHueClient(SettingsModel.hueHubIp);
                client.Initialize(SettingsModel.appUserId);
                var cmd = new LightCommand();
                cmd.TurnOn().SetColor(new RGBColor(SettingsModel.colorHex));
                await client.SendCommandAsync(cmd, new List<string> { SettingsModel.lightIndex.ToString() });
            }
        }
    }
}
