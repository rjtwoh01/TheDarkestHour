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
    class BeachHead : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachHead.Entrace";
        public const string NORTH_TENTS_KEY = "BeachTower.BeachHead.NorthTents";
        public const string CENTER_CAMP_KEY = "BeachTower.BeachHead.CenterCamp";
        public const string WEST_TENTS_KEY = "BeachTower.BeachHead.WestTents";
        public const string EAST_TENTS_KEY = "BeachTower.BeachHead.EastTents";
        public const string SOUTH_TENTS_KEY = "BeachTower.BeachHead.SouthTents";
        public const string SMALL_PATH_KEY = "BeachTower.BeachHead.SmallPath";
        public const string PIRATE_CAPTAINS_TENT_KEY = "BeachTower.BeachHead.PirateCaptainsTent";
        public const string NORTH_PIRATES = "BeachTower.BeachHead.NorthPirates";
        public const string CENTER_PIRATES = "BeachTower.BeachHead.CenterPirates";
        public const string WEST_PIRATES = "BeachTower.BeachHead.WestPirates";
        public const string WEST_CHEST = "BeachTower.BeachHead.WestChest";
        public const string EAST_PIRATES = "BeachTower.BeachHead.EastPirates";
        public const string EAST_GOLD = "BeachTower.BeachHead.EastGold";
        public const string SOUTH_PIRATES = "BeachTower.BeachHead.SouthPirates";
        public const string SMALL_PATH_PIRATES = "BeachTower.BeachHead.SmallPathPirates";
        public const string PIRATE_CAPTAIN = "BeachTower.BeachHead.PirateCaptain";
        public const string CAPTAIN_TREASURE = "BeachTower.BeachHead.CaptainTreasure";
        public const string CAPTAIN_ORDERS = "BeachTower.BeachHead.CaptainOrders";

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
            returnData.Name = "Beach Head";
            returnData.Description = "The beach head travels for as far as the eyes can see. Off in the distance you can spot the tents that the pirates pitched. You can see small blobs moving about around the tents which must be the pirates.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachHead.GetTownInstance().GetNorthTentsDefinition();
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
                returnData.Name = "Beach Head";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Tents

        public Location LoadNorthTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Tents";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.NORTH_PIRATES));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "The northern tents have four pirates roaming about, making every day small talk.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += NorthPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern tents are bloodied from battles fought previously with four dead pirates laying scattered about.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPirates)
            {
                locationDefinition = BeachHead.GetTownInstance().GetCenterCampDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void NorthPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.NORTH_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(NORTH_TENTS_KEY);
            }
        }

        public LocationDefinition GetNorthTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Tents";
                returnData.DoLoadLocation = LoadNorthTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Center Camp

        public Location LoadCenterCamp()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "The Camp's Center";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CENTER_PIRATES));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "In the center of the camp is a clearing with a stone circle in the middle with a fire running in it. There are sevearl pirates mingling about and eating.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += CenterPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "In the center of the camp is a clearing with a stone circle in the middle with a fire running in it. There are dead pirate bodies strewn across the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetNorthTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPirates)
            {
                locationDefinition = BeachHead.GetTownInstance().GetEastTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BeachHead.GetTownInstance().GetWestTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BeachHead.GetTownInstance().GetSouthTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CenterPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CENTER_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(CENTER_CAMP_KEY);
            }
        }

        public LocationDefinition GetCenterCampDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CENTER_CAMP_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "The Camp's Center";
                returnData.DoLoadLocation = LoadCenterCamp;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region West Tents

        public Location LoadWestTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "West Tents";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.WEST_PIRATES));
            bool tookChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.WEST_CHEST));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "A collection of tents in the west. There are two pirates mingling about and a treasure chest.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += WestPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
            {
                if (!tookChest)
                    returnData.Description = "A collection of tents in the west. There are two dead headless pirates treasure chest.";
                else
                    returnData.Description = "A collection of tents in the west. There are two dead headless pirates and an open treasure chest.";
            }

            if (defeatedPirates && !tookChest)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(2);
                locationActions.Add(itemAction);
                itemAction.PostItem += WestChest;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetCenterCampDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void WestPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.WEST_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(WEST_TENTS_KEY);
            }
        }

        public void WestChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.WEST_CHEST, true);

                //Reload
                LocationHandler.ResetLocation(WEST_TENTS_KEY);
            }
        }

        public LocationDefinition GetWestTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WEST_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "West Tents";
                returnData.DoLoadLocation = LoadWestTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region East Tents

        public Location LoadEastTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "East Tents";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.EAST_PIRATES));
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.EAST_GOLD));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "A collection of tents in the east. There are four pirates sitting around drinking. You spy a bag of gold tucked in a corner.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += EastPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
            {
                if (!tookGold)
                    returnData.Description = "A collection of tents in the east. There are four dead bodies bloodying up the otherwise nice tents. You spy a bag of gold tucked in a corner.";
                else
                    returnData.Description = "A collection of tents in the east. There are four dead bodies bloodying up the otherwise nice tents.";
            }

            if (defeatedPirates && !tookGold)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(250);
                locationActions.Add(itemAction);
                itemAction.PostItem += EastGold;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetCenterCampDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void EastPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.EAST_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(EAST_TENTS_KEY);
            }
        }

        public void EastGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.EAST_GOLD, true);

                //Reload
                LocationHandler.ResetLocation(EAST_TENTS_KEY);
            }
        }

        public LocationDefinition GetEastTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EAST_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "East Tents";
                returnData.DoLoadLocation = LoadEastTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region South Tents

        public Location LoadSouthTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "South Tents";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.SOUTH_PIRATES));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "The tents here are getting closer together. There are six pirates roaming the area, armed for battle. They seem to be guarding the path ahead.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += SouthPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The tents here are getting closer together. Dead pirates litter the ground and the path ahead is now clear.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetCenterCampDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPirates)
            {
                locationDefinition = BeachHead.GetTownInstance().GetSmallPathDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SouthPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.SOUTH_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(SOUTH_TENTS_KEY);
            }
        }

        public LocationDefinition GetSouthTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SOUTH_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "South Tents";
                returnData.DoLoadLocation = LoadSouthTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Path

        public Location LoadSmallPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Path";
            bool defeatedPirates = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.SMALL_PATH_PIRATES));

            //Actions
            if (!defeatedPirates)
            {
                returnData.Description = "The path is small and narrow. The are several empty rum bottles littering the ground. Two pirates are standing at the end of the path, guarding the tent just beyond it.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Pirate());
                mobs.Add(new Pirate());
                CombatAction combatAction = new CombatAction("Pirates", mobs);
                combatAction.PostCombat += SmallPathPirates;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The path is small and narrow. The are several empty rum bottles littering the ground. There are two dead pirates at the entrance of the tent at the end of the path.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetCenterCampDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPirates)
            {
                locationDefinition = BeachHead.GetTownInstance().GetCaptainTentDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SmallPathPirates(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.SMALL_PATH_PIRATES, true);

                //Reload 
                LocationHandler.ResetLocation(SMALL_PATH_KEY);
            }
        }

        public LocationDefinition GetSmallPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Path";
                returnData.DoLoadLocation = LoadSmallPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Captain Tent

        public Location LoadCaptainTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Captain's Tent";
            bool defeatedPirateCaptain = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.PIRATE_CAPTAIN));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CAPTAIN_TREASURE));
            bool tookOrders = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CAPTAIN_ORDERS));
            string parchmentText = "I don't want to hear any more excuses captain. You will lead on the beach head and you will wreck havoc. Kill as many innocents as you can. I don't give a rat's ass if there is a military tower close by. They will not pose a threat. You will decimate them and they won't be able to do anything about it. Victory is at hand!";

            //Actions
            if (!defeatedPirateCaptain)
            {
                returnData.Description = "The tent is large and decorated with foul substances collected through decades of pillaging. The pirate captain is sitting in his chair behind his desk, looking at you with a smirk on his face.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new PirateCaptain());
                CombatAction combatAction = new CombatAction("Pirate Captain", mobs);
                combatAction.PostCombat += PirateCaptain;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedPirateCaptain)
            {
                if (!openedChest)
                {
                    if (!tookOrders)
                    {
                        returnData.Description = "The tent is large and decorated with foul substances collected through decades of pillaging. The pirate captain lays dead in the center of the room. There is a piece of parchment on his desk and a treasure chest under it.";
                    }
                    else
                        returnData.Description = "The tent is large and decorated with foul substances collected through decades of pillaging. The pirate captain lays dead in the center of the room. There is a treasure chest under his desk.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += CaptainChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && tookOrders)
                    returnData.Description = "The tent is large and decorated with foul substances collected through decades of pillaging. The pirate captain lays dead in the center of the room. There is an opened treasure chest under his desk.";
                if (!tookOrders && openedChest)
                {
                    returnData.Description = "The tent is large and decorated with foul substances collected through decades of pillaging. The pirate captain lays dead in the center of the room. There is a piece of parchment on his desk and an opened treasure chest under it.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    ReadPapersAction parchmentAction = new ReadPapersAction(parchmentText);
                    parchmentAction.PostPaper += CaptainOrders;
                    locationActions.Add(parchmentAction);
                    returnData.Actions = locationActions;
                }
            }
                
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachHead.GetTownInstance().GetSmallPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPirateCaptain)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void PirateCaptain(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.PIRATE_CAPTAIN, true);

                //Reload 
                LocationHandler.ResetLocation(PIRATE_CAPTAINS_TENT_KEY);
            }
        }

        public void CaptainChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CAPTAIN_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(PIRATE_CAPTAINS_TENT_KEY);
            }
        }

        public void CaptainOrders(Object sender, PaperReadEventArgs paperReadEventArgs)
        {
            if (paperReadEventArgs.PaperResults == PaperReadResults.Read)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachHead.CAPTAIN_ORDERS, true);

                //Reload
                LocationHandler.ResetLocation(PIRATE_CAPTAINS_TENT_KEY);
            }
        }

        public LocationDefinition GetCaptainTentDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = PIRATE_CAPTAINS_TENT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Captain's Tent";
                returnData.DoLoadLocation = LoadCaptainTent;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachHead _BeachHead;

        public static BeachHead GetTownInstance()
        {
            if (_BeachHead == null)
            {
                _BeachHead = new BeachHead();
            }

            return _BeachHead;
        }

        #endregion
    }
}
