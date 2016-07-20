using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model.JsonResponse.ResponseDestinyCharacters
{
    public class ResponseDestinyCharacters
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public Messagedata MessageData { get; set; }
    }

    public class Response
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public Character[] characters { get; set; }
        public string clanName { get; set; }
        public string clanTag { get; set; }
        public Inventory inventory { get; set; }
        public int grimoireScore { get; set; }
        public object[] vendorReceipts { get; set; }
        public int versions { get; set; }
        public int accountState { get; set; }
    }

    public class Inventory
    {
        public Buckets buckets { get; set; }
        public Currency1[] currencies { get; set; }
    }

    public class Buckets
    {
        public Invisible[] Invisible { get; set; }
        public Item[] Item { get; set; }
        public Currency[] Currency { get; set; }
    }

    public class Invisible
    {
        public object[] items { get; set; }
        public int bucketHash { get; set; }
    }

    public class Item
    {
        public object[] items { get; set; }
        public long bucketHash { get; set; }
    }

    public class Currency
    {
        public object[] items { get; set; }
        public long bucketHash { get; set; }
    }

    public class Currency1
    {
        public long itemHash { get; set; }
        public int value { get; set; }
    }

    public class Character
    {
        public Characterbase characterBase { get; set; }
        public Levelprogression levelProgression { get; set; }
        public string emblemPath { get; set; }
        public string backgroundPath { get; set; }
        public int emblemHash { get; set; }
        public int characterLevel { get; set; }
        public int baseCharacterLevel { get; set; }
        public bool isPrestigeLevel { get; set; }
        public float percentToNextLevel { get; set; }
    }

    public class Characterbase
    {
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public string characterId { get; set; }
        public DateTime dateLastPlayed { get; set; }
        public string minutesPlayedThisSession { get; set; }
        public string minutesPlayedTotal { get; set; }
        public int powerLevel { get; set; }
        public long raceHash { get; set; }
        public long genderHash { get; set; }
        public long classHash { get; set; }
        public int currentActivityHash { get; set; }
        public int lastCompletedStoryHash { get; set; }
        public Stats stats { get; set; }
        public Customization customization { get; set; }
        public int grimoireScore { get; set; }
        public Peerview peerView { get; set; }
        public int genderType { get; set; }
        public int classType { get; set; }
        public long buildStatGroupHash { get; set; }
    }

    public class Stats
    {
        public STAT_DEFENSE STAT_DEFENSE { get; set; }
        public STAT_INTELLECT STAT_INTELLECT { get; set; }
        public STAT_DISCIPLINE STAT_DISCIPLINE { get; set; }
        public STAT_STRENGTH STAT_STRENGTH { get; set; }
        public STAT_LIGHT STAT_LIGHT { get; set; }
        public STAT_ARMOR STAT_ARMOR { get; set; }
        public STAT_AGILITY STAT_AGILITY { get; set; }
        public STAT_RECOVERY STAT_RECOVERY { get; set; }
        public STAT_OPTICS STAT_OPTICS { get; set; }
    }

    public class STAT_DEFENSE
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_INTELLECT
    {
        public int statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_DISCIPLINE
    {
        public int statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_STRENGTH
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_LIGHT
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_ARMOR
    {
        public int statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_AGILITY
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_RECOVERY
    {
        public int statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class STAT_OPTICS
    {
        public long statHash { get; set; }
        public int value { get; set; }
        public int maximumValue { get; set; }
    }

    public class Customization
    {
        public long personality { get; set; }
        public long face { get; set; }
        public long skinColor { get; set; }
        public long lipColor { get; set; }
        public long eyeColor { get; set; }
        public long hairColor { get; set; }
        public long featureColor { get; set; }
        public long decalColor { get; set; }
        public bool wearHelmet { get; set; }
        public int hairIndex { get; set; }
        public int featureIndex { get; set; }
        public int decalIndex { get; set; }
    }

    public class Peerview
    {
        public Equipment[] equipment { get; set; }
    }

    public class Equipment
    {
        public long itemHash { get; set; }
        public Dye[] dyes { get; set; }
    }

    public class Dye
    {
        public long channelHash { get; set; }
        public long dyeHash { get; set; }
    }

    public class Levelprogression
    {
        public int dailyProgress { get; set; }
        public int weeklyProgress { get; set; }
        public int currentProgress { get; set; }
        public int level { get; set; }
        public int step { get; set; }
        public int progressToNextLevel { get; set; }
        public int nextLevelAt { get; set; }
        public int progressionHash { get; set; }
    }

    public class Messagedata
    {
    }


}
