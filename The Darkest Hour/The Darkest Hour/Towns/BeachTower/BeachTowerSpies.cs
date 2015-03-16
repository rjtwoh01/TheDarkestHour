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
using The_Darkest_Hour.Common;


namespace The_Darkest_Hour.Towns.Watertown
{
    class BeachTowerSpies : Town
    {
        #region Location Keys
        public const string ENTRANCE_KEY = "BeachTower.BeachTowerSpies.Entrace";
        public const string HALLWAY_KEY = "BeachTower.BeachTowerSpies.Hallway";
        public const string EAST_ROOM_KEY = "BeachTower.BeachTowerSpies.EastRoom";
        public const string WEST_ROOM_KEY = "BeachTower.BeachTowerSpies.WestRoom";
        public const string NORTH_ROOM_KEY = "BeachTower.BeachTowerSpies.NorthRoom";
        public const string TALKED_TO_GUARD = "BeachTower.BeachTowerSpies.TalkedToEntranceGuard";
        public const string EAST_ROOM_SPIES = "BeachTower.BeachTowerSpies.EastRoomSpies";
        public const string WEST_ROOM_SPIES = "BeachTower.BeachTowerSpies.WestRoomSpies";
        public const string SPY_MASTER = "BeachTower.BeachTowerSpies.SpyMaster";
        public const string SPY_MASTER_TREASURE = "BeachTower.BeachTowerSpies.SpyMasterTreasure";
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
            returnData.Name = "Beach Tower Underground Floor";
            bool talkedToGuard = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.TALKED_TO_GUARD));
            returnData.Description = "The air is thicker upon arriving at the underground tower floor. There is tower soldier standing guard at the entrance.";

            //Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            //Adding the guard report about the spies into the locationActions
            LocationAction GuardReportAction = new RumorAction("Aken - Lieutenant of the Guard", this.GuardReport);
            locationActions.Add(GuardReportAction);
            returnData.Actions = locationActions;


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment guard = BeachTowerSpies.GetBeachTowerSpiesAccomplishments().Find(x => x.Name.Contains("Guard Report"));
            if (GameState.Hero.Accomplishments.Contains(guard))
            {
                locationDefinition = BeachTowerSpies.GetTownInstance().GetHallwayDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        private List<Rumor>GuardReport
        {
            get
            {
                bool defeatedSpyMaster = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.SPY_MASTER));
                List<Rumor> returnData = new List<Rumor>();
                Rumor rumor;

                if (!defeatedSpyMaster)
                {
                    rumor = new Rumor("Spy Report", "So after our spies investigated, we have determined that the enemy spies are taking up residence down here. This whole floor is NOT friendly. You can feel free to eliminate anyone that you believe is a threat. Though I do ask that you try to find some info while you're down here. Talk to the captain once this mess is cleaned up, yeah?");
                    rumor.OnHeardRumor = this.HeardSpyReportRumor;
                    returnData.Add(rumor);
                }
                else
                {
                    rumor = new Rumor("After the Fact", "You did a good job ridding us of the spies. Who knows how long it would have taken to get a team together to raid this floor if you weren't here to do it. As it is, I don't know when we'll get a clean up crew down here anyway. Thanks again!");
                    returnData.Add(rumor);
                }
                return returnData;
            }
        }

        public void HeardSpyReportRumor()
        {
            Accomplishment accomplishment = BeachTowerSpies.GetBeachTowerSpiesAccomplishments().Find(x => x.Name.Contains("Guard Report"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the entrance so it will open up the hallway
            LocationHandler.ResetLocation(ENTRANCE_KEY);
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
                returnData.Name = "Beach Tower Underground Floor";
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
            returnData.Description = "The hallway is a wide one lined with scattered boxes, some of them with offical looking documents sitting on top of them.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerSpies.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerSpies.GetTownInstance().GetEastRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerSpies.GetTownInstance().GetWestRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerSpies.GetTownInstance().GetNorthRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
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

        #region East Room

        public Location LoadEastRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Barracks";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.EAST_ROOM_SPIES));

            if (!defeatedMobs)
            {
                returnData.Description = "The room is lined with beds and there are several enemies spies loitering about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                CombatAction combatAction = new CombatAction("Spies", mobs);
                combatAction.PostCombat += EastRoomSpies;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The room is lined with beds which have the dead bodies of enemy spies laying on them.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerSpies.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void EastRoomSpies(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.EAST_ROOM_SPIES, true);

                //Reload 
                LocationHandler.ResetLocation(EAST_ROOM_KEY);
            }
        }

        public LocationDefinition GetEastRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EAST_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Barracks";
                returnData.DoLoadLocation = LoadEastRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region West Room

        public Location LoadWestRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.WEST_ROOM_SPIES));

            if (!defeatedMobs)
            {
                returnData.Description = "A small storage room with two enemy spies sorting through documents.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Spies());
                mobs.Add(new Spies());
                CombatAction combatAction = new CombatAction("Spies", mobs);
                combatAction.PostCombat += WestRoomSpies;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A small storage room with two dead spies thrown across the boxes.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerSpies.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WestRoomSpies(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.WEST_ROOM_SPIES, true);

                //Reload 
                LocationHandler.ResetLocation(WEST_ROOM_KEY);
            }
        }

        public LocationDefinition GetWestRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WEST_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadWestRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Room

        public Location LoadNorthRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ornate Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.SPY_MASTER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.SPY_MASTER_TREASURE));
            string spyMasterSpeechBefore = "''So, " + GameState.Hero.Identifier + "... You have come at last. I must admit, I was curious how long it would take for my little operation here to become compromised. Though this was a little sooner than expected. No matter, I will deal with you and can make my escape then before those idiot guards realize anything has gone wrong. Yes, that should do it. Any last words?'' \nWithout waiting for a reply for a reply he swiftly draws two swords and lunges at you. You narrowly dodge the attack and brace yourself for a fight.";
            string spyMasterSpeechAfter = "You stand over the Spy Master as the life force leaves his body. He looks up at you and says, ''You'll... pay... you... bastard. This... is... not... the... end... My... masters... have... plans. A... darkness... rises... in... the... east.'' He gasp out the last word and then chokes on the air as he struggles to breathe. After a few seconds he succumbs to his wounds and departs this life.";

            if (!defeatedMobs)
            {
                returnData.Description = "A large ornate room furnished with the best that nobles could afford when they commissioned the building of the tower. A spy master is pacing back and forth in the middle of it, his forhead creased in concentration.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new SpyMaster());
                CombatAction combatAction = new CombatAction("Spy Master", mobs, spyMasterSpeechBefore, spyMasterSpeechAfter);
                combatAction.PostCombat += SpyMaster;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A large ornate room furnished with the best that nobles could afford when they commissioned the building of the tower. The spy master lies dead in the center of it.";
            }

            if (defeatedMobs && !openedChest)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += SpyMasterChest;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerSpies.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SpyMaster(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.SPY_MASTER, true);

                //Reload 
                LocationHandler.ResetLocation(NORTH_ROOM_KEY);
            }
        }

        public void SpyMasterChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerSpies.SPY_MASTER_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(NORTH_ROOM_KEY);
            }
        }

        public LocationDefinition GetNorthRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ornate Room";
                returnData.DoLoadLocation = LoadNorthRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance
        private static BeachTowerSpies _BeachHead;

        public static BeachTowerSpies GetTownInstance()
        {
            if (_BeachHead == null)
            {
                _BeachHead = new BeachTowerSpies();
            }

            return _BeachHead;
        }
        #endregion

        #region Accomplishments

        public static Accomplishments _BeachTowerSpiesAccomplishments;
        public static Accomplishments GetBeachTowerSpiesAccomplishments()
        {
            if (_BeachTowerSpiesAccomplishments == null)
            {
                _BeachTowerSpiesAccomplishments = new Accomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Underground Enemies";
                accomplishment.Name = "Has heard the rumor of Guard Report";
                accomplishment.Description = "Has heard the rumor of the spies under the beach tower from the Guard Report that was standing at the entrance to the floor.";
                _BeachTowerSpiesAccomplishments.Add(accomplishment);

            }

            return _BeachTowerSpiesAccomplishments;
        }

        #endregion

    }
}