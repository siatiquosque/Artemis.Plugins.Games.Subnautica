using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Artemis.Plugins.Games.Subnautica.GSI
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

        public SubnauticaPlayer()
        {
            Biom = Player.main.GetBiomeString();

            var SubRoot = Player.main.GetCurrentSub();
            var Vehicle = Player.main.GetVehicle();

            if (SubRoot)
                Type = SubRoot.GetType().Equals(typeof(BaseRoot)) ? PlayerType.Base : PlayerType.Cyclops;
            else if (Vehicle)
                Type = Vehicle.GetType().Equals(typeof(SeaMoth)) ? PlayerType.Seamoth : PlayerType.Prawn;
            else
                Type = PlayerType.Unknown;

            DepthLevel = Mathf.RoundToInt(Player.main.depthLevel)*-1;

            Health = Mathf.RoundToInt(Player.main.liveMixin.health);
            Food = Mathf.RoundToInt(Player.main.gameObject.GetComponent<Survival>().food);
            Water = Mathf.RoundToInt(Player.main.gameObject.GetComponent<Survival>().water);

            CanBreathe = Player.main.CanBreathe();
            OxygenCapacity = Mathf.RoundToInt(Player.main.GetOxygenCapacity());
            OxygenAvailable = Mathf.RoundToInt(Player.main.GetOxygenAvailable());

            PDAState = (PlayerPDAState)Player.main.GetPDA().state;

            IsSwimming = Player.main.IsSwimming();

            MotorMode = (PlayerMotorMode)Player.main.motorMode;
            Mode = (PlayerMode)Player.main.GetMode();
        }
    }
}
