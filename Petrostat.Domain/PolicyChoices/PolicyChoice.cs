using Petrostat.Domain.Enums;
using Petrostat.Domain.Ideologies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Petrostat.Domain.Utilities.StaticUtilities;
using Petrostat.Domain.Interfaces;

namespace Petrostat.Domain
{
    internal abstract class PolicyChoice : IId
    {
        protected readonly Nation _nation;

        public PolicyChoice() {}
        public PolicyChoice(Nation nation) {
            _nation = nation;
            Id = PetroLuck.Next();
        }

        public int Id { get; set; }
        internal Ideology Ideology 
            { 
                get { return Ideology; } 
                set 
                { 
                    if (this.Ideology == null) 
                    {
                        Ideology = value;
                    } else {
                        throw new FieldAccessException("PolicyChoice.Ideology cannot be set once it has a value");
                    }
                }
            }
        public abstract PolicyName Name { get; }
        public abstract string Description { get; }
        public bool CanBePlayed(Ideology ideology)
        {   
            var qualifications = GetCurrentQualifications(ideology);
            var qualificationsMeetRequirements = MinimumRequirementCombinations.Any(r => 
                (r & qualifications) == r);
            return qualificationsMeetRequirements;
        }
        protected abstract List<PolicyChoiceRequirement> MinimumRequirementCombinations { get; }
        protected abstract PolicyChoiceRequirement GetCurrentQualifications(Ideology ideology);
        public abstract void Play();        
        protected abstract bool IsSuccess();
        protected abstract void OnSuccess();
        protected abstract void OnFailure();
    }
}
