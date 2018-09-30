namespace Petrostat.Domain
{
    public class VictoryEvents
    {

        #region common
        public int RepressionSuccessCount { get; set; }
        public int RepressionFailureCount { get; set; }
        #endregion

        #region Liberal
        public int GenocideCount { get; set; }
        public int ElectionCount { get; set; }
        public int CoupCount { get; set; }
        public int GlobalizationsAddedCount { get; set; }
        public int GlobalizationsRemovedCount { get; set; }
        public int UnwantedFundamentalistCount { get; set; }

        public int TurnEndingWithoutElectionCount { get; set; }
        #endregion

        #region Authoritarian
        public int WarCount { get; set; }
        public int NonGoverningGenocideCount { get; set; }

        public int TurnEndingsWithoutWarCount { get; set; }
        public int TurnEndingsProtestCount { get; set; }
        #endregion
    }
}