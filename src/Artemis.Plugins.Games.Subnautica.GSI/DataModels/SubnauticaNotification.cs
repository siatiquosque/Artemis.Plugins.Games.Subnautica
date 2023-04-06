using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.Subnautica.GSI.DataModels
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

        public SubnauticaNotification() {
            UndefinedNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Undefined);
            InventoryNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Inventory);
            BlueprintsNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Blueprints);
            BuilderNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Builder);
            CraftTreeNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.CraftTree);
            LogNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Log);
            GalleryNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Gallery);
            EncyclopediaNotificationCount = NotificationManager.main.GetCount(NotificationManager.Group.Encyclopedia);

        }
    }
}
