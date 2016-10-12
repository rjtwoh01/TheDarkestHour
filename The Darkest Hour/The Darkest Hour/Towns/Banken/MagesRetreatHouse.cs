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
    class MagesRetreatHouse : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.MagesRetreatHouse.Entrance";
        public const string HALLWAY_KEY = "Banken.MagesRetreatHouse.Hallway";
        public const string DININING_ROOM_KEY = "Banken.MagesRetreatHouse.DiningRoom";
        public const string KITCHEN_KEY = "Banken.MagesRetreatHouse.Kitchen";
        public const string LIVING_ROOM_KEY = "Banken.MagesRetreatHouse.LivingRoom";
        public const string BEDROOM_KEY = "Banken.MagesRetreatHouse.Bedroom";
        public const string HALLWAY_MOBS = "Banken.MagesRetreatHouse.HallwayMobs";
        public const string DINING_ROOM_MOBS = "Banken.MagesRetreatHouse.DiningRoomMobs";
        public const string KITCHEN_MOBS = "Banken.MagesRetreatHouse.KitchenMobs";
        public const string LIVING_ROOM_MOBS = "Banken.MagesRetreatHouse.LivingRoomMobs";
        public const string PSYCHOTIC_BANDIT = "Banken.MagesRetreatHouse.PsychoticBandit";
        public const string TREASURE = "Banken.MagesRetreatHouse.Treasure";


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
            returnData.Name = "Mage's Retreat House";
            returnData.Description = "A small house built just off the Worship Region of Banken's forest.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetReligiousShrineClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
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
                returnData.Name = "Mage's Retreat Shack";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Hallway

        public Location LoadHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hallway";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.HALLWAY_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A hallway lays just inside the front door of the house. There are summoned spirits left over from some recent battle.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                mobs.Add(new EvilSpirit());
                CombatAction combatAction = new CombatAction("Evil Spirits", mobs);
                combatAction.PostCombat += HallwaySpirits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A hallway lays just inside the front door of the house.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = MagesRetreatHouse.GetTownInstance().GetDiningRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = MagesRetreatHouse.GetTownInstance().GetLivingRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void HallwaySpirits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.HALLWAY_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(HALLWAY_KEY);
            }
        }

        public LocationDefinition GetHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hallway";
                returnData.DoLoadLocation = LoadHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dining Room

        public Location LoadDiningRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dining Room";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.DINING_ROOM_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A dining room, made to fit a small family or group of friends. There are several bandits sitting at the table laughing as they drink beer, most likely stolen from the mage who lives here.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += DiningRoomBandits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A dining room, made to fit a small family or group of friends.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = MagesRetreatHouse.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DiningRoomBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.DINING_ROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DININING_ROOM_KEY);
            }
        }

        public LocationDefinition GetDiningRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DININING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dining Room";
                returnData.DoLoadLocation = LoadDiningRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.KITCHEN_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small kitchen. There are cabnits thrown open and boxes of food strewn across the floor. There are two bandits rummaging through the different food stores.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += KitchenBandits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small kitchen. There are cabnits thrown open and boxes of food strewn across the floor.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetDiningRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void KitchenBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.KITCHEN_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(KITCHEN_KEY);
            }
        }

        public LocationDefinition GetKitchenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = KITCHEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadKitchen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Living Room

        public Location LoadLivingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Living Room";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.LIVING_ROOM_MOBS));            

            if (!defeatedMobs)
            {
                returnData.Description = "The living room has a couch and a couple chairs. There is a fireplace in the corner. There are four bandits sitting about, talking about their various adventures.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += LivingRoomBandits;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The living room has a couch and a couple chairs. There is a fireplace in the corner.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = MagesRetreatHouse.GetTownInstance().GetBedroomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LivingRoomBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.LIVING_ROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(LIVING_ROOM_KEY);
            }
        }



        public LocationDefinition GetLivingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LIVING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Living Room";
                returnData.DoLoadLocation = LoadLivingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bedroom

        public Location LoadBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bedroom";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.PSYCHOTIC_BANDIT));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.TREASURE));
            string before = "The Psychotic Bandit hears your foot steps and spins around, a crazed look gleaming in his eyes. \nHe laughs hysterically and says, ''Hah! You're too late! We've already captured that puny mage. She fought  but she could not withstand us!''";
            string after = "You put a knife up to the Psychotic Bandit's throat and growl out, ''Where is the mage? Where is she?''\nHe laughs and coughs up blood. He looks you in the eyes and replies, ''In hell.'' \nThe Psychotic Bandit coughs up blood one last time and then goes limp on the floor";

            List<LocationAction> locationActions = new List<LocationAction>();
            if (!defeatedMobs)
            {
                returnData.Description = "A small bedroom with a bed against the back wall and a desk against a side wall. A Pyschotic Bandit is going through the mage's desk and is throwing papers about everywhere.";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new PsychoticBandit());
                CombatAction combatAction = new CombatAction("Pyschotic Bandit", mobs, before, after);
                combatAction.PostCombat += PsychoticBandit;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookTreasure)
            {
                returnData.Description = "A small bedroom with a bed against the back wall and a desk against a side wall. A treasue chest is sitting under the mage's desk.";
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small bedroom with a bed against the back wall and a desk against a side wall.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MagesRetreatHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void PsychoticBandit(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.PSYCHOTIC_BANDIT, true);

                //Reload 
                LocationHandler.ResetLocation(BEDROOM_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, MagesRetreatHouse.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(BEDROOM_KEY);
            }
        }

        public LocationDefinition GetBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static MagesRetreatHouse _MagesRetreatHouse;

        public static MagesRetreatHouse GetTownInstance()
        {
            if (_MagesRetreatHouse == null)
            {
                _MagesRetreatHouse = new MagesRetreatHouse();
            }

            return _MagesRetreatHouse;
        }

        #endregion
    }
}