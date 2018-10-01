using Petrostat.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Petrostat.Domain
{
    public class VictoryEvents
    {
        #region Convenience References
        readonly Game game;
        Nation nation => game.Nation;
        #endregion

        public VictoryEvents (Game game)
        {
            this.game = game;
            ClassChanges = new HashSet<ClassChange>();
            Genocides = new HashSet<Genocide>();
        }

        #region common
        public int RepressionSuccessCount { get; set; }
        public int RepressionFailureCount { get; set; }
        public HashSet<ClassChange> ClassChanges { get; set; }
        public IEnumerable<ClassChange> EnrichedToWealthy =>            ClassChanges.Where(cc => !cc.Impoverished && cc.SubsequentClass == EconomicClass.Wealthy);
        public IEnumerable<ClassChange> EnrichedToMiddleClass =>        ClassChanges.Where(cc => !cc.Impoverished && cc.SubsequentClass == EconomicClass.MiddleClass);
        public IEnumerable<ClassChange> EnrichedToWorkingClass =>       ClassChanges.Where(cc => !cc.Impoverished && cc.SubsequentClass == EconomicClass.WorkingClass);
        public IEnumerable<ClassChange> ImpoverishedToMiddleClass =>    ClassChanges.Where(cc =>  cc.Impoverished && cc.SubsequentClass == EconomicClass.MiddleClass);
        public IEnumerable<ClassChange> ImpoverishedToWorkingClass =>   ClassChanges.Where(cc =>  cc.Impoverished && cc.SubsequentClass == EconomicClass.WorkingClass);
        public IEnumerable<ClassChange> ImpoverishedToPoor =>           ClassChanges.Where(cc =>  cc.Impoverished && cc.SubsequentClass == EconomicClass.Poor);
        public HashSet<Genocide> Genocides { get; set; }
        public int GlobalizationCount => GlobalizationsAddedCount - GlobalizationsRemovedCount;
        #endregion

        #region Liberal
        public int GenocideCount                => Genocides.Count();
        public int ElectionCount                { get; set; }
        public int CoupCount                    { get; set; }
        public int GlobalizationsAddedCount     { get; set; }
        public int GlobalizationsRemovedCount   { get; set; }
        public int UnwantedFundamentalistCount => nation.Population.Where(p => p.UnderReligiousLaw && p.Alignment != IdeologyName.Fundamentalist).Count();

        public int TurnEndingWithoutElectionCount { get; set; }
        #endregion

        #region Authoritarian
        public int WarCount                     { get; set; }
        public int NonGoverningGenocideCount    => Genocides.Where(g => !g.ByGovernment).Count();

        public int TurnEndingsWithoutWarCount   { get; set; }
        public int TurnEndingsProtestCount      { get; set; }
        #endregion

        #region Socialist
        public int AnyEnrichedToMiddleClassCount =>      EnrichedToMiddleClass.Count();
        public int AnyEnrichedToWorkingClassCount =>     EnrichedToWorkingClass.Count();
        public int AnyImpoverishedToWorkingClassCount => ImpoverishedToWorkingClass.Count();
        public int AnyImpoverishedToPoorCount =>         ImpoverishedToPoor.Count();

        public int TurnEndingWithRichAndPoorCount                { get; set; } 
        public int TurnEndingWithBadMiddleWorkingRatioCount      { get; set; }
        public int TurnEndingWithGoodMiddleToWorkingRatioCount   { get; set; }
        #endregion

        #region MajoritySectarian
        public int MajorityEnrichedToWealthyCount           => EnrichedToWealthy            .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityEnrichedToMiddleClassCount       => EnrichedToMiddleClass        .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityEnrichedToWorkingClassCount      => EnrichedToWorkingClass       .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityImpoverishedToMiddleClassCount   => ImpoverishedToMiddleClass    .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityImpoverishedToWorkingClassCount  => ImpoverishedToWorkingClass   .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityImpoverishedToPoorCount          => ImpoverishedToPoor           .Where(cc => cc.Population.IsMajority).Count();
        public int MajorityGenocidesCount                   => Genocides.Where(g => g.Population.IsMajority).Count();
        #endregion

        #region MinoritySectarian
        public int MinorityEnrichedToWealthyCount           => EnrichedToWealthy            .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityEnrichedToMiddleClassCount       => EnrichedToMiddleClass        .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityEnrichedToWorkingClassCount      => EnrichedToWorkingClass       .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityImpoverishedToMiddleClassCount   => ImpoverishedToMiddleClass    .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityImpoverishedToWorkingClassCount  => ImpoverishedToWorkingClass   .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityImpoverishedToPoorCount          => ImpoverishedToPoor           .Where(cc => !cc.Population.IsMajority).Count();
        public int MinorityGenocidesCount                   => Genocides.Where(g => !g.Population.IsMajority).Count();
        #endregion

        #region Nationalist
        public int ImperialismLevel
        {
            get
            {
                return (int)nation.Empire.Level;
            }
            set
            {
                if (value > TurnEndingBonusCount - ForeignPCPenaltyCount)
                {
                    ForeignPCPenaltyCount = 0;
                    TurnEndingBonusCount = 0;
                }
                ImperialismLevel = value;
            }
        }
        public int ForeignPCPenaltyCount
        {
            get
            {
                return ForeignPCPenaltyCount;
            }
            set
            {
                if ((TurnEndingBonusCount * 5) - value < (int)nation.Empire.Level)
                    ForeignPCPenaltyCount = TurnEndingBonusCount * 5;
                else
                    ForeignPCPenaltyCount = value;
            }
        }
        public int TurnEndingBonusCount { get; set; }
        #endregion

        #region Fundamentalist
        public int ReligiousLawCount => nation.Population.Where(p => p.UnderReligiousLaw).Count();
        #endregion

    }
}