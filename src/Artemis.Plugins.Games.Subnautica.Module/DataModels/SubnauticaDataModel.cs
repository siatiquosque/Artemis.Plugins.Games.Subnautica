using Artemis.Core.Modules;

namespace Artemis.Plugins.Games.Subnautica.DataModels;

public class SubnauticaDataModel : DataModel
{
    public SubnauticaGameState GameState { get; set; }
    public SubnauticaPlayer Player { get; set; }
    public SubnauticaNotification Notification { get; set; }
    public SubnauticaWorld World { get; set; }

}