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
    class AnkouArieansEstate : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouAriensEstate.Entrance";
        public const string ROOM_ONE_KEY = "Ankou.AnkouAriensEstate.RoomOne";
        public const string ROOM_TWO_KEY = "Ankou.AnkouAriensEstate.RoomTwo";
        public const string ROOM_THREE_KEY = "Ankou.AnkouAriensEstate.RoomThree";
        public const string LARGE_COORIDOR_KEY = "Ankou.AnkouAriensEstate.LargeCooridor";
        public const string LONG_HALLWAY_KEY = "Ankou.AnkouAriensEstate.LongHallway";
        public const string BARRACKS_KEY = "Ankou.AnkouAriensEstate.Barracks";
        public const string GREAT_HALL_KEY = "Ankou.AnkouAriensEstate.GreatHall";
        public const string STAIRS_KEY = "Ankou.AnkouAriensEstate.Stairs";
        public const string LANDING_KEY = "Ankou.AnkouAriensEstate.Landing";
        public const string ROOM_FOUR_KEY = "Ankou.AnkouAriensEstate.RoomFour";
        public const string MEETING_ROOM_KEY = "Ankou.AnkouAriensEstate.MeetingRoom";
        public const string COORIDOR_KEY = "Ankou.AnkouAriensEstate.Cooridor";
        public const string ROOM_FIVE_KEY = "Ankou.AnkouAriensEstate.RoomFive";
        public const string ROOM_SIX_KEY = "Ankou.AnkouAriensEstate.RoomSix";
        public const string ARMORY_KEY = "Ankou.AnkouAriensEstate.Armory";
        public const string STORAGE_ROOM_KEY = "Ankou.AnkouAriensEstate.StorageRoom";
        public const string ARIENS_MASTER_BEDROOM = "Ankou.AnkouAriensEstate.AriensMasterBedroom";
        public const string DEFEATED_ROOM_ONE_GUARDS = "Ankou.AnkouAriensEstate.DefeatedRoomOneGuards";
        public const string DEFEATED_ROOM_TWO_GUARDS = "Ankou.AnkouAriensEstate.DefeatedRoomTwoGuards";
        public const string DEFEATED_ROOM_THREE_GUARDS = "Ankou.AnkouAriensEstate.DefeatedRoomThreeGuards";
        public const string DEFEATED_BARRACKS_GUARDS = "Ankou.AnkouAriensEstate.DefeatedBarracksGuards";
        public const string DEFEATED_GREATH_HALL_NOBLES = "Ankou.AnkouAriensEstate.DefeatedGreatHallNobles";
        public const string DEFEATED_LANDING_GUARDS = "Ankou.AnkouAriensEstate.DefeatedLandingGuards";
        public const string TOOK_ROOM_FOUR_TREASURE = "Ankou.AnkouAriensEstate.TookRoomFourTreasure";
        public const string DEFEATED_MEETING_ROOM_NOBLES = "Ankou.AnkouAriensEstate.DefeatedMeetingRoomNobles";
        public const string DEFEATED_ROOM_FIVE_GUARDS = "Ankou.AnkouAriensEstate.DefeatedRoomFiveGuards";
        public const string DEFEATED_ROOM_SIX_GUARDS = "Ankou.AnkouAriensEstate.DefeatedRoomSixGuards";
        public const string DEFEATED_ARMORY_GUARDS = "Ankou.AnkouAriensEstate.DefeatedArmoryGuards";
        public const string TOOK_STORAGE_ROOM_TREASURE = "Ankou.AnkouAriensEstate.TookStorageRoomTreasure";
        public const string TOOK_STORAGE_ROOM_GOLD = "Ankou.AnkouAriensEstate.TookStorageRoomGold";
        public const string KILLED_ARIEAN = "Ankou.AnkouAriensEstate.KilledAriean";
        public const string TOOK_ARIEAN_CHEST = "Ankou.AnkouAriensEstate.TookArieanTreasureChest";
        public const string TOOK_LETTERS = "Ankou.AnkouAriensEstate.TookNecroLettersToAriean";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region FLOOR ONE

        #region Entance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ariean's Estate";
            returnData.Description = "The estate's entrance is a large hall with two grand stair cases leading up to the second floor and a large door between them. The stairs are blocked and the door is bolted shut and cannot be opened. There is another door to the left.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

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
                returnData.Name = "Ariean's Estate";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room One

        public Location LoadRoomOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room One";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_ONE_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "A small room filled with four guards.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += RoomOneGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room filled with four dead guards.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomOneGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_ONE_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_ONE_KEY);

            }
        }

        public LocationDefinition GetRoomOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room One";
                returnData.DoLoadLocation = LoadRoomOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Two

        public Location LoadRoomTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Two";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_TWO_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "A medium sized room with three guards in it.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += RoomTwoGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A medium sized room with three dead guards in it.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_TWO_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_TWO_KEY);

            }
        }

        public LocationDefinition GetRoomTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Two";
                returnData.DoLoadLocation = LoadRoomTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Three

        public Location LoadRoomThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Three";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_THREE_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "The first room that actually looks inhabitable. It's a medium sized room with a couch agains the wall. Three guards are sitting on it, chatting.";
                
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += RoomThreeGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The first room that actually looks inhabitable. It's a medium sized room with a couch agains the wall. Three guards lay dead on the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetLargeCooridorDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomThreeGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_THREE_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_THREE_KEY);

            }
        }

        public LocationDefinition GetRoomThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Three";
                returnData.DoLoadLocation = LoadRoomThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Cooridor

        public Location LoadLargeCooridor()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Cooridor";
            returnData.Description = "A large cooridor filled with priceless art and statues.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLargeCooridorDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_COORIDOR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Cooridor";
                returnData.DoLoadLocation = LoadLargeCooridor;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Long Hallway

        public Location LoadLongHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Long Hallway";
            returnData.Description = "A long hallway with torches lining the walls and large paintings hanging above them.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLargeCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetBarracksDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetGreatHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetLongHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LONG_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Long Hallway";
                returnData.DoLoadLocation = LoadLongHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Barracks

        public Location LoadBarracks()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Barracks";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_BARRACKS_GUARDS));
            

            //Actions
            if (defeatedGuards)
            {
                returnData.Description = "A medium sized room full of armor and weapns. There are six guards sitting around inside.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += BarracksGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A medium sized room full of armor and weapns. There are six dead guards with their bodies strewn about the floor. The weapns and armor within are splattered with blood from the fight.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BarracksGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_BARRACKS_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BARRACKS_KEY);

            }
        }

        public LocationDefinition GetBarracksDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BARRACKS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Barracks";
                returnData.DoLoadLocation = LoadBarracks;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Great Hall

        public Location LoadGreatHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Great Hall";
            bool defeatedNobles = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_GREATH_HALL_NOBLES));

            //Actions
            if (!defeatedNobles)
            {
                returnData.Description = "A large great hall full of many nobles partaking in Ariean's party. They are non-aggressive and will let you pass without a fight.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> noble = new List<Mob>();
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                CombatAction combatAction = new CombatAction("Nobles", noble);
                combatAction.PostCombat += GreatHallNobles;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large great hall full of the dead bodies of a score of nobles. Mercilessly slaughtered without justice.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLongHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void GreatHallNobles(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_GREATH_HALL_NOBLES, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(GREAT_HALL_KEY);

            }
        }

        public LocationDefinition GetGreatHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = GREAT_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Great Hall";
                returnData.DoLoadLocation = LoadGreatHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region STAIRS       

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";
            returnData.Description = "A large marble stair case connecting the first and second floor of Ariean's Estate.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetGreatHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetStairsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STAIRS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Stairs";
                returnData.DoLoadLocation = LoadStairs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region FLOOR TWO

        #region Landing

        public Location LoadLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Landing";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_LANDING_GUARDS));
            
            //Actions
            if (defeatedGuards)
            {
                returnData.Description = "A large landing that overlooks the great hall beneath it. There are six guards blocking further access to the second floor.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += LandingGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large landing that overlooks the great hall beneath it. There are six dead bodies on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFourDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LandingGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_LANDING_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LANDING_KEY);

            }
        }

        public LocationDefinition GetLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LANDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Landing";
                returnData.DoLoadLocation = LoadLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Four

        public Location LoadRoomFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Four";
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_ROOM_FOUR_TREASURE));
            returnData.Description = "A small room that contains a treasure chest that's pushed up against the wall.";

            //Actions
            if (!tookTreasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(3);
                locationActions.Add(itemAction);
                itemAction.PostItem += RoomFourChest;
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFourChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_ROOM_FOUR_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_FOUR_KEY);

            }
        }

        public LocationDefinition GetRoomFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Four";
                returnData.DoLoadLocation = LoadRoomFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Meeting Room

        public Location LoadMeetingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Meeting Room";
            bool defeatedNobles = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_MEETING_ROOM_NOBLES));

            //Actions
            if (!defeatedNobles)
            {
                returnData.Description = "A medium sized room with a large table in the center. There are four nobles discussing current politics at the table. These nobles are non-aggressive and will not fight if they are not attacked first.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> noble = new List<Mob>();
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                noble.Add(new Noble());
                CombatAction combatAction = new CombatAction("Nobles", noble);
                combatAction.PostCombat += MeetingRoomNobles;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A medium sized room with a large table in the center. There are four slaughtered nobles at the table. This was a terrible crime.";
            

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void MeetingRoomNobles(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_MEETING_ROOM_NOBLES, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(MEETING_ROOM_KEY);

            }
        }

        public LocationDefinition GetMeetingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MEETING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Meeting Room";
                returnData.DoLoadLocation = LoadMeetingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cooridor

        public Location LoadCooridor()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cooridor";
            returnData.Description = "A narrow cooridor.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetMeetingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetCooridorDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COORIDOR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cooridor";
                returnData.DoLoadLocation = LoadCooridor;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Five

        public Location LoadRoomFive()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Five";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_FIVE_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "An empty room with four guards blocking further access to the second floor.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += RoomFiveGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "An empty room with four dead guards.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetCooridorDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomSixDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouArieansEstate.GetTownInstance().GetArmoryDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouArieansEstate.GetTownInstance().GetStorageRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFiveGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_FIVE_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_FIVE_KEY);

            }
        }

        public LocationDefinition GetRoomFiveDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_FIVE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Five";
                returnData.DoLoadLocation = LoadRoomFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Room Six

        public Location LoadRoomSix()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Room Six";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_SIX_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "A medium sized room with eight guards blocking access to Ariean's master bedroom. They all have the swords and shields drawn.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += RoomSixGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A medium sized room with eight dead guards laying strewn about. They have failed to protect their charge.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedGuards)
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetArieansMasterBedroomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomSixGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ROOM_SIX_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_SIX_KEY);

            }
        }

        public LocationDefinition GetRoomSixDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ROOM_SIX_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Room Six";
                returnData.DoLoadLocation = LoadRoomSix;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Armory

        public Location LoadArmory()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Armory";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ARMORY_GUARDS));

            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "A small armory holding a few more weapons and armor. Two guards are inspecting the equipment.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += ArmoryGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small armory holding a few more weapons and armor. Two guards are impaled by the equipment they were inspecting.";
            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ArmoryGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.DEFEATED_ARMORY_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ARMORY_KEY);

            }
        }

        public LocationDefinition GetArmoryDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARMORY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Armory";
                returnData.DoLoadLocation = LoadArmory;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage Room

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_STORAGE_ROOM_TREASURE));
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_STORAGE_ROOM_GOLD));
            returnData.Description = "A small storage room. There is a bag and a treasure chest within the room.";

            //Actions
            if (!tookTreasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(4);
                locationActions.Add(itemAction);
                itemAction.PostItem += StorageRoomTreasure;
                returnData.Actions = locationActions;
            }

            if (!tookGold)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(150);
                locationActions.Add(itemAction);
                itemAction.PostItem += StorageRoomGold;
                returnData.Actions = locationActions;
            }
            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void StorageRoomGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_STORAGE_ROOM_GOLD, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(STORAGE_ROOM_KEY);

            }
        }

        public void StorageRoomTreasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_STORAGE_ROOM_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(STORAGE_ROOM_KEY);

            }
        }

        public LocationDefinition GetStorageRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadStorageRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ariean's Master Bedroom

        public Location LoadArieansMasterBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ariean's Master Bedroom";
            bool defeatedAriean = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.KILLED_ARIEAN));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_ARIEAN_CHEST));
            bool takeLetters = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_LETTERS));
            string ArieanSpeechStart = "Welcome, " + GameState.Hero.Identifier + ", you've caused a lot of havoc and destruction here today. I don't think I'll be going in quietly with you. This is a severe breach of my rights and you and the city constable office has done me wrong tonight. No, I think I'll make you suffer for your crimes. Do you repent, " + GameState.Hero.Identifier + "? Or will you suffer?";
            string ArieanSpeechAfter = "Fine! You win! I'll go turn myself in. The evidence you're looking for is in a locked door on my nightsand. Here's the key.";

            //Actions
            if (!defeatedAriean)
            {
                returnData.Description = "A large room with very expensive furniture and decorations. There is a large master bed in the center of the room. Ariean is sitting on it, staring calmly at the door.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> ariean = new List<Mob>();
                ariean.Add(new Ariean());
                CombatAction combatAction = new CombatAction("Ariean", ariean, ArieanSpeechStart, ArieanSpeechAfter);
                combatAction.PostCombat += DefeatedAriean;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedAriean)
            {
                if (!openedChest)
                {
                    if (!takeLetters)
                        returnData.Description = "A large room with very expensive furniture and decorations. The letters Ariean referenced are in her nightstand. There is an unopened chest in the corner of the room.";
                    else
                        returnData.Description = "A large room with very expensive furniture and decorations. An unopened treasure chest sits in the corner of the room.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += ArieanChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeLetters)
                    returnData.Description = "A large room with very expensive furniture and decorations. An opened treasure chest sits in the corner of the room and Ariean's nightstand door lays open and empty.";
                if (!takeLetters && openedChest)
                {
                    returnData.Description = "A large room with very expensive furniture and decorations. An opened treasure chest sits in the corner of the room and the letter is still in Ariean's nighstand door.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Necromancer Letters to Ariean");
                    letterAction.PostItem += Letters;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouArieansEstate.GetTownInstance().GetRoomFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (takeLetters && defeatedAriean)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedAriean(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.KILLED_ARIEAN, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ARIENS_MASTER_BEDROOM);

            }
        }

        public void ArieanChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_ARIEAN_CHEST, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ARIENS_MASTER_BEDROOM);

            }
        }

        public void Letters(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouArieansEstate.TOOK_LETTERS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ARIENS_MASTER_BEDROOM);

            }
        }

        public LocationDefinition GetArieansMasterBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARIENS_MASTER_BEDROOM;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ariean's Master Bedroom";
                returnData.DoLoadLocation = LoadArieansMasterBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouArieansEstate _AnkouArieansEstate;

        public static AnkouArieansEstate GetTownInstance()
        {
            if (_AnkouArieansEstate == null)
            {
                _AnkouArieansEstate = new AnkouArieansEstate();
            }

            return _AnkouArieansEstate;
        }

        #endregion
    }
}