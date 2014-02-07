using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownBanditCaveDeeper : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownBanditCaveDeeper.Entrance";
        public const string JAIL_KEY = "WaterTownBanditCaveDeeper.JailCell";
        public const string STORAGE_KEY = "WaterTownBanditCaveDeeper.Storage";
        public const string HIDEOUT_KEY = "WaterTownBanditCaveDeeper.Hideout";
        public const string HALLWAY_KEY = "WaterTownBanditCaveDeeper.Hallway";
        public const string FOODROOM_KEY = "WaterTownBanditCaveDeeper.FoodRoom";
        public const string READ_PAPER_KEY = "ReadPapers";
        public const string TAKE_ROPE_KEY = "TakeRope";
        public const string TAKE_WOOD_KEY = "TakeWood";
        public const string TAKE_SAW_KEY = "TakeSaw";
        public const string BUILD_LADDER_KEY = "BuildLadder";
        public const string DEFEATED_HIDEOUT_BANDITS_KEY = "DefeatedHideoutBandits";
        public const string DEFEATED_HALLWAY_BANDITS_KEY = "DefeatedDeeperHallwayBandits";
        public const string DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY = "DefatedBanditSupplyCaptain";
        private bool _takeRope = false;
        private bool _takeWood = false;
        private bool _takeSaw = false;

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetCaveDeeperEntrance();
        }

        #region Entrance

        public Location LoadCaveDeeperEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Cave Hidden Room";
            string paperText = "To whomever it may concern, \nWe were supposed to get a shipment of supplies a week ago! Find out what went wrong! I'll be in \ncontact again if this isn't sorted out...\n";
            bool readPaper = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.READ_PAPER_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!readPaper)
            {
                returnData.Description = "A study lined with bookshelves with a desk in the middle of the room. There are papers scattered about the desk.";

                ReadPapersAction paperReadAction = new ReadPapersAction(paperText);
                locationActions.Add(paperReadAction);
                paperReadAction.PostPaper += PaperResults;
                returnData.Actions = locationActions;
            }

            if (_takeSaw && _takeRope && _takeWood)
            {
                returnData.Description = "A study lined with bookshelves. A desk was pushed up against the wall with paper scattered across the floor. There is a pool of blood where the desk used to be.";
            }
            else
                returnData.Description = "A study lined with bookshelves with a desk in the middle of the room. There are papers scattered about the desk.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCave.GetTownInstance().GetLairDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            if (readPaper)
            {
                locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetJailCellDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            if (_takeWood && _takeRope && _takeSaw)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY, true);
                LocationHandler.ResetLocation(Watertown.INN_KEY); // Need to reload Inn so that new conversation can be set.
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void PaperResults(object sender, PaperReadEventArgs paperEventArgs)
        {
            if (paperEventArgs.PaperResults == PaperReadResults.Read)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.READ_PAPER_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(READ_PAPER_KEY);
            }
        }

        public LocationDefinition GetCaveDeeperEntrance()
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
                returnData.Name = "Bandit Cave Hidden Room";
                returnData.DoLoadLocation = LoadCaveDeeperEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region JailCell

        public Location LoadJailCell()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Jail Cell";
            returnData.Description = "A small and dirty jail cell. It stinks of decaying flesh. And something horrid and rotten.";
            bool ladder = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.BUILD_LADDER_KEY));


            if (_takeRope && _takeSaw && _takeWood && !ladder)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Build Ladder");
                locationActions.Add(itemAction);
                itemAction.PostItem += LadderResult;
                returnData.Actions = locationActions;
    
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetStorageRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetHideoutDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (ladder)
            {
                locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetStartingLocationDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void LadderResult(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.BUILD_LADDER_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(BUILD_LADDER_KEY);
            }
        }

        public LocationDefinition GetJailCellDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = JAIL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Jail Cell";
                returnData.DoLoadLocation = LoadJailCell;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region StorageRoom

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            returnData.Description = "A small room full of boxes and loose supplies.";
            string itemName = "Rope";
            _takeRope = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_ROPE_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!_takeRope)
            {
                TakeItemAction itemAction = new TakeItemAction(itemName);
                locationActions.Add(itemAction);
                itemAction.PostItem += RopeResults;
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetJailCellDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void RopeResults(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_ROPE_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(TAKE_ROPE_KEY);
            }
        }

        public LocationDefinition GetStorageRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_KEY;

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

        #region BanditHideOut

        public Location LoadBanditHideOut()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hideout";
            string itemName = "Wood";
            _takeWood = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_WOOD_KEY));
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_HIDEOUT_BANDITS_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedBandits)
            {
                returnData.Description = "A small room with four bandits sitting at a table.";

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());

                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += HideoutBanditResults;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            if (defeatedBandits)
            {
                returnData.Description = "A small room with a empty table. Bandits lay dead on the ground.";

                if (!_takeWood)
                {
                    TakeItemAction itemAction = new TakeItemAction(itemName);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += WoodResult;
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetJailCellDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetHallwayDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void WoodResult(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_WOOD_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(TAKE_WOOD_KEY);
            }
        }

        public void HideoutBanditResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_HIDEOUT_BANDITS_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DEFEATED_HIDEOUT_BANDITS_KEY);

            }
        }

        public LocationDefinition GetHideoutDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HIDEOUT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hideout";
                returnData.DoLoadLocation = LoadBanditHideOut;

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
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_HALLWAY_BANDITS_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedBandits)
            {
                returnData.Description = "A narrow hallway with bandits walking down from the supply room";

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());

                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += HallwayBanditResults;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            if (defeatedBandits)
            {
                returnData.Description = "A narrow hallway. Two bandits lay slaughtered on the ground.";
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetHideoutDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetFoodRoomDefiniton();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void HallwayBanditResults(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_HALLWAY_BANDITS_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DEFEATED_HALLWAY_BANDITS_KEY);

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

        #region FoodRoom

        public Location LoadFoodRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Food Room";
            string itemName = "Saw";
            _takeSaw = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_SAW_KEY));
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            if (!defeatedBandits)
            {
                returnData.Description = "A large room filled with boxes of food. A bandit in elaborate clothes is inspecting the boxes.";

                List<Mob> supplyCaptain = new List<Mob>();
                supplyCaptain.Add(new BanditSupplyCaptain());


                CombatAction combatAction = new CombatAction("Bandit Supply Captain", supplyCaptain);
                combatAction.PostCombat += SupplyCaptainResult;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            if (defeatedBandits)
            {
                returnData.Description = "A large room filled with boxes of food. The bandit supply captain's body lays pushed against a corner of the room.";

                if (!_takeSaw)
                {
                    TakeItemAction itemAction = new TakeItemAction(itemName);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += SawResult;
                    returnData.Actions = locationActions;
                }
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCaveDeeper.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void SawResult(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.TAKE_SAW_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(TAKE_SAW_KEY);
            }
        }

        public void SupplyCaptainResult(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY);

            }
        }

        public LocationDefinition GetFoodRoomDefiniton()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FOODROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Food Room";
                returnData.DoLoadLocation = LoadFoodRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Entrance

        private static WatertownBanditCaveDeeper _WatertownBanditCaveDeeper;

        public static WatertownBanditCaveDeeper GetTownInstance()
        {
            if (_WatertownBanditCaveDeeper == null)
            {
                _WatertownBanditCaveDeeper = new WatertownBanditCaveDeeper();
            }

            return _WatertownBanditCaveDeeper;
        }

        #endregion
    }
}