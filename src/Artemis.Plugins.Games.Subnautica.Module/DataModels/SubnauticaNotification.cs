using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.Subnautica.DataModels
{
    public class SubnauticaNotification
    {
        public int UndefinedNotificationCount { get; set; }
        public int InventoryNotificationCount { get; set; }
        public int BlueprintsNotificationCount { get; set; }
        public int BuilderNotificationCount { get; set; }
        public int CraftTreeNotificationCount { get; set; }
        public int LogNotificationCount { get; set; }
        public int GalleryNotificationCount { get; set; }
        public int EncyclopediaNotificationCount { get; set; }
    }
}
