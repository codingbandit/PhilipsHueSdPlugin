using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;
using Q42.HueApi.Interfaces;
using StreamDeckLib;
using StreamDeckLib.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhilipsHueSdPlugin
{
    [ActionUuid(Uuid = "com.trilliuminnovations.philipshue.green")]
    public class PhilipsHueGreenAction : BaseStreamDeckActionWithSettingsModel<Models.GreenSettingsModel>
    {
        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            if (SettingsModel.IsValid())
            {
                ILocalHueClient client = new LocalHueClient(SettingsModel.hueHubIp);
                client.Initialize(SettingsModel.appUserId);
                var cmd = new LightCommand();
                cmd.TurnOn().SetColor(new RGBColor("00FF00"));
                await client.SendCommandAsync(cmd, new List<string> { SettingsModel.lightIndex.ToString() });
            }
        }
    }
}
