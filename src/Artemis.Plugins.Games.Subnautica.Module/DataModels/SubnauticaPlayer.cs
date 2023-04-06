using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.Subnautica.DataModels
{
    public enum PlayerType
    {
        Unknown = -1,
        Base = 0,
        Cyclops = 1,
        Seamoth = 2,
        Prawn = 3
    }

    public enum PlayerPDAState
    {
        Opened = 0,
        Closed = 1,
        Opening = 2,
        Closing = 3
    }

    public enum PlayerMotorMode
    {
        Walk = 0,
        Dive = 1,
        Seaglide = 2,
        Vehicle = 3,
        Mech = 4,
        Run = 5
    }

    public enum PlayerMode
    {
        Normal = 0,
        Piloting = 1,
        LockedPiloting = 2,
        Sitting = 3
    }

    public class SubnauticaPlayer
    {
        public string Biom { get; set; }
        public bool InLifePod { get; set; }

        public PlayerType Type { get; set; }

        public int DepthLevel { get; set; }

        public int Health { get; set; }
        public int Food { get; set; }
        public int Water { get; set; }

        public bool CanBreathe { get; set; }
        public int OxygenCapacity { get; set; }
        public int OxygenAvailable { get; set; }

        public PlayerPDAState PDAState { get; set; }
        public bool PDAopened { get; set; }
        public bool PDAclosed { get; set; }
        public bool PDAopening { get; set; }
        public bool PDAclosing { get; set; }

        public bool IsSwimming { get; set; }

        public PlayerMotorMode MotorMode { get; set; }
        public bool IsSeagliding { get; set; }

        public PlayerMode Mode { get; set; }
        public bool IsPiloting { get; set; }
    }
}
