namespace SLRFC.PlayerManager.ViewModels
{
    using System.Collections.Generic;

    using SLRFC.Model;

    public class PlayersViewModel
    {
        public Player Player { get; set; }

        public List<Player> Players { get; set; }

        public string SuccessMessage { get; set; }

        public string FailureMessage { get; set; }
    }
}