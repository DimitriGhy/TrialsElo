using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model.Converters
{
    public class CharacterConverter
    {
        public static Character ToCharacter(TestElo.Model.JsonResponse.ResponseDestinyCharacters.Character dc)
        {
            Character c = new Character();
            c.CharacterId = dc.characterBase.characterId;
            c.DateLastPlayed = dc.characterBase.dateLastPlayed;
            c.MembershipId = dc.characterBase.membershipId;
            c.ModifiedOn = DateTime.Now;
            c.TimePlayed = int.Parse(dc.characterBase.minutesPlayedTotal);
            c.classType = (Enums.Enums.Classes)dc.characterBase.classType;
            return c;
        }
    }
}
