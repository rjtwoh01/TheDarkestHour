using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Combat;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Characters.Mobs.Bosses.Banken;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class BankenAncientBurialGrounds : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAncientBurialGrounds.Entrance";
        public const string DESECRATED_TOMB_STONES = "Banken.BankenAncientBurialGrounds.DesecratedTombStones";
        public const string SMALL_POND = "Banken.BankenAncientBurialGrounds.SmallPond";
        public const string WIDE_PATH = "Banken.BankenAncientBurialGrounds.WidePath";
        public const string DENSE_FOG = "Banken.BankenAncientBurialGrounds.DenseFog";
        public const string DESERTED_RITUAL_GROUNDS = "Banken.BankenAncientBurialGrounds.DesertedRitualGrounds";
        public const string DESECRATED_TOMB_STONES_SKELETONS = "Banken.BankenAncientBurialGrounds.DesecratedTombStonesSkeletons";
        public const string SMALL_POND_WATER_SPIRITS = "Banken.BankenAncientBurialGrounds.SmallPondWaterSpirits";
        public const string WIDE_PATH_SKELETONS = "Banken.BankenAncientBurialGrounds.WidePathSkeletons";
        public const string DENSE_FOG_SPIRITS = "Banken.BankenAncientBurialGrounds.DenseFogSpirits";
        public const string ACKHAN = "Banken.BankenAncientBurialGrounds.Ackhan";
        public const string TREASURE = "Banken.BankenAncientBurialGrounds.Treasure";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entrance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ancient Burial Grounds";
            returnData.Description = "The Ancient Burial Grounds reek of evil. A dark presence encloses your heart and you feel hope drain from your body. Proceed with caution.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesecratedTombStonesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEntranceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENTRANCE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ancient Burial Grounds";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Desecrated Tomb Stones

        public Location LoadDesecratedTombStones()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Desecrated Tomb Stones";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.DESECRATED_TOMB_STONES_SKELETONS));
            
            if (!defeatedMobs)
            {
                returnData.Description = "A small area of with several desecrated tomb stones scattered about. The ground is disturbed as if something has risen from it. There are skeletons wandering about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += DesecratedTombStonesSkeletons;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small area of with several desecrated tomb stones scattered about. The ground is disturbed as if something has risen from it. There are skeletons wandering about.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetSmallPondDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DesecratedTombStonesSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.DESECRATED_TOMB_STONES_SKELETONS, true);

                //Reload 
                LocationHandler.ResetLocation(DESECRATED_TOMB_STONES);
            }
        }

        public LocationDefinition GetDesecratedTombStonesDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DESECRATED_TOMB_STONES;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Desecrated Tomb Stones";
                returnData.DoLoadLocation = LoadDesecratedTombStones;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Pond

        public Location LoadSmallPond()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Pond";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.SMALL_POND_WATER_SPIRITS));
            
            if (!defeatedMobs)
            {
                returnData.Description = "A small pond is on the edge of the burial grounds. Several water spirits are pouring out of the pond, intent on attack.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                CombatAction combatAction = new CombatAction("Water Spirits", mobs);
                combatAction.PostCombat += SmallPondWaterSpirits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small pond is on the edge of the burial grounds. Several water spirits are pouring out of the pond, intent on attack.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesecratedTombStonesDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetWidePathDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SmallPondWaterSpirits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.SMALL_POND_WATER_SPIRITS, true);

                //Reload 
                LocationHandler.ResetLocation(SMALL_POND);
            }
        }

        public LocationDefinition GetSmallPondDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_POND;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Pond";
                returnData.DoLoadLocation = LoadSmallPond;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Wide Path

        public Location LoadWidePath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Wide Path";           
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.WIDE_PATH_SKELETONS));

            if (!defeatedMobs)
            {
                returnData.Description = "A wide path loops from the small pond deep into the heart of the ancient burial grounds. The path is patrolled by several strongly armed skeletons";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += WidePathSkeletons;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A wide path loops from the small pond deep into the heart of the ancient burial grounds.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetSmallPondDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDenseFogDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WidePathSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.WIDE_PATH_SKELETONS, true);

                //Reload 
                LocationHandler.ResetLocation(WIDE_PATH);
            }
        }

        public LocationDefinition GetWidePathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WIDE_PATH;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Wide Path";
                returnData.DoLoadLocation = LoadWidePath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dense Fog

        public Location LoadDenseFog()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dense Fog";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.DENSE_FOG_SPIRITS));

            if (!defeatedMobs)
            {
                returnData.Description = "At the end of the path lays a dense fog, clouding the air. The sacraficial ground lays on the other side but is blocked from sight. Evil Spirits are pouring out of the fog.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                CombatAction combatAction = new CombatAction("Evil Spirits", mobs);
                combatAction.PostCombat += DenseFogSpirits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "At the end of the path lays a dense fog, clouding the air. The sacraficial ground lays on the other side but is blocked from sight. Evil Spirits are pouring out of the fog.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetWidePathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDesertedRitualGroundsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DenseFogSpirits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.DENSE_FOG_SPIRITS, true);

                //Reload 
                LocationHandler.ResetLocation(DENSE_FOG);
            }
        }

        public LocationDefinition GetDenseFogDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DENSE_FOG;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dense Fog";
                returnData.DoLoadLocation = LoadDenseFog;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Deserted Ritual Grounds

        public Location LoadDesertedRitualGrounds()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Deserted Ritual Grounds";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.ACKHAN));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.TREASURE));
            string before = "You walk into the circular and Ackhan's eyes darken as he fixates on you. He raises his right and and sends a blast of shadow energy straight at you. You dodge and draw your weapon. Prepare to fight!";
            string after = "Ackhan gasp out, blood splurtting out of his mouth. You draw a hidden dagger and put it up to his throught. You growl down at him, 'Tell me what I want to know and I'll end this quickly for you. Tell me what happened to those rangers?' \nAckhan coughs on his blood and says, 'Gone... tombs... You'll never find them.' \nIn frustration you slice his throat and his dead body crumbles to the ground. There is an explosion of dark energy from the center of his body, sending you flying backwards. You slowly stand up to find his dead body missing and a giant black scorch mark where it used to lay.";

            if (!defeatedMobs)
            {
                returnData.Description = "On the other side of the dense fog is a circular arrea that used to be used as ritual grounds. The grounds have long since been abandoned. However, a new resident has taken up home here and is spewing dark magic into the lands. An evil necromancer, Ackhan, whom is part of the Necromancer Council stands in the middle of the circle chanting in some unknown tongue. Dark wisps leave his body and fly into the forest.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Ackhan());
                CombatAction combatAction = new CombatAction("Ackhan", mobs, before, after);
                combatAction.PostCombat += Ackhan;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookTreasure)
            {
                returnData.Description = "On the other side of the dense fog is a circular arrea that used to be used as ritual grounds. The grounds have long since been abandoned. However, a new resident has taken up home here and is spewing dark magic into the lands. There is a black scorch mark where Ackhan used to be. There is an unopened treasure chest on the edge of the circle.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "On the other side of the dense fog is a circular arrea that used to be used as ritual grounds. The grounds have long since been abandoned. There is a black scorch mark where Ackhan used to be.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAncientBurialGrounds.GetTownInstance().GetDenseFogDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void Ackhan(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.ACKHAN, true);

                //Reload 
                LocationHandler.ResetLocation(DESERTED_RITUAL_GROUNDS);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(DESERTED_RITUAL_GROUNDS);
            }
        }

        public LocationDefinition GetDesertedRitualGroundsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DESERTED_RITUAL_GROUNDS;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Deserted Ritual Grounds";
                returnData.DoLoadLocation = LoadDesertedRitualGrounds;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAncientBurialGrounds _BankenAncientBurialGrounds;

        public static BankenAncientBurialGrounds GetTownInstance()
        {
            if (_BankenAncientBurialGrounds == null)
            {
                _BankenAncientBurialGrounds = new BankenAncientBurialGrounds();
            }

            return _BankenAncientBurialGrounds;
        }

        #endregion
    }
}
