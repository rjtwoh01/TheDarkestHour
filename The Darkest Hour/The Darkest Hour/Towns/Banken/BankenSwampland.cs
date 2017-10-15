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
    class BankenSwampland : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenSwampland.Entrance";
        public const string SWAMPY_AREA_ONE_KEY = "Banken.BankenSwampland.SwampyAreaOne";
        public const string CRUMBLED_BUILDING_KEY = "Banken.BankenSwampland.CrumbledBuilding";
        public const string SMALL_GRAVEYARD_KEY = "Banken.BankenSwampland.SmallGraveyard";
        public const string FISHERMANS_DOCK_KEY = "Banken.BankenSwampland.FishermansDock";
        public const string SWAMPY_AREA_TWO_KEY = "Banken.BankenSwampland.SwampyAreaTwo";
        public const string SWAMPY_AREA_THREE_KEY = "Banken.BankenSwampland.SwampyAreaThree";
        public const string RUINED_CASTLE_KEY = "Banken.BankenSwampland.RuinedCastle";
        public const string SWAMPY_AREA_ONE_MOBS = "Banken.BankenSwampland.SwampyAreaOneMobs";
        public const string CRUMBLED_BUILDING_MOBS = "Banken.BankenSwampland.CrumbledBuildingMobs";
        public const string SMALL_GRAVEYARD_MOBS = "Banken.BankenSwampland.SmallGraveyardMobs";
        public const string FISHERMANS_DOCK_MOBS = "Banken.BankenSwampland.FishermansDockMobs";
        public const string SWAMPY_AREA_TWO_MOBS = "Banken.BankenSwampland.SwampyAreaTwoMobs";
        public const string SWAMPY_AREA_ACTIVATE_RUINS = "Banken.BankenSwampland.SwampyAreaThreeActivateRuins";
        public const string SWAMPY_AREA_THREE_MOBS = "Banken.BankenSwampland.SwampyAreaThreeMobs";
        public const string RUINED_CASTLE_SHADES = "Banken.BankenSwampland.RuinedCastleShades";
        public const string RUINED_CASTLE_NECROS = "Banken.BankenSwampland.RuinedCastleNecros";
        public const string MARZEN = "Banken.BankenSwampland.Marzen";
        public const string TREASURE = "Banken.BankenSwampland.Treasure";

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
            returnData.Name = "Swampland";            
            returnData.Description = "The swampland is hot and mucky out. It's not a pleasant place to be.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernForestEdgeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaOneDefinition();
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
                returnData.Name = "Swampland";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Swampy Area One
        public Location LoadSwampyAreaOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area One";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_ONE_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The swamp begins with deep murky water. Water Spirits float about above the ponds";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                CombatAction combatAction = new CombatAction("Water Spirits", mobs);
                combatAction.PostCombat += SwampyAreaOneMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The swamp begins with deep murky water.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetCrumbledBuildingDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SwampyAreaOneMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_ONE_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(SWAMPY_AREA_ONE_KEY);
            }
        }

        public LocationDefinition GetSwampyAreaOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area One";
                returnData.DoLoadLocation = LoadSwampyAreaOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Crumbled Building
        public Location LoadCrumbledBuilding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Crumbled Building";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.CRUMBLED_BUILDING_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A medium sized building lies in ruins in the middle of the swamp. Moss covers the stones of the former building. Shades roam the area.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += CrumbledBuildingMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A medium sized building lies in ruins in the middle of the swamp. Moss covers the stones of the former building.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaOneDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetSmallGraveyardDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CrumbledBuildingMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.CRUMBLED_BUILDING_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CRUMBLED_BUILDING_KEY);
            }
        }

        public LocationDefinition GetCrumbledBuildingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CRUMBLED_BUILDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Crumbled Building";
                returnData.DoLoadLocation = LoadCrumbledBuilding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Small Graveyard
        public Location LoadSmallGraveyard()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Graveyard";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SMALL_GRAVEYARD_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small graveyard in the middle of the swamplands for the small population of people that live here. There are a couple tombstones scattered about. Skeletons have risen from the grave and they are accompanied by shades.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Shade());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Skeletons and Shades", mobs);
                combatAction.PostCombat += SmallGraveyardMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            returnData.Description = "A small graveyard in the middle of the swamplands for the small population of people that live here. There are a couple tombstones scattered about";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetCrumbledBuildingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetFishermansDockDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SmallGraveyardMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SMALL_GRAVEYARD_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(SMALL_GRAVEYARD_KEY);
            }
        }

        public LocationDefinition GetSmallGraveyardDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_GRAVEYARD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Graveyard";
                returnData.DoLoadLocation = LoadSmallGraveyard;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Fishermans Dock
        public Location LoadFishermansDock()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Fisherman's Dock";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.FISHERMANS_DOCK_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small dock into a large pond. There is a boat loosely tied to a post. Water Spirits defend the pond.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                CombatAction combatAction = new CombatAction("Water Spirits", mobs);
                combatAction.PostCombat += FishermansDockMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A small dock into a large pond. There is a boat loosely tied to a post.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSmallGraveyardDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaTwoDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void FishermansDockMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.FISHERMANS_DOCK_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(FISHERMANS_DOCK_KEY);
            }
        }

        public LocationDefinition GetFishermansDockDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = FISHERMANS_DOCK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Fisherman's Dock";
                returnData.DoLoadLocation = LoadFishermansDock;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Swampy Area Two
        public Location LoadSwampyAreaTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area Two";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_TWO_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The pure swampland continues on. The air is thicker and it is harder to breathe. Water Spirits roam the area.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                mobs.Add(new WaterSpirit());
                CombatAction combatAction = new CombatAction("Water Spirits", mobs);
                combatAction.PostCombat += SwampyAreaTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The pure swampland continues on. The air is thicker and it is harder to breathe.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetFishermansDockDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaThreeDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SwampyAreaTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(SWAMPY_AREA_TWO_KEY);
            }
        }

        public LocationDefinition GetSwampyAreaTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area Two";
                returnData.DoLoadLocation = LoadSwampyAreaTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Swampy Area Three
        public Location LoadSwampyAreaThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Swampy Area Three";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_THREE_MOBS));
            bool activateRuins = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_ACTIVATE_RUINS));

            if (!activateRuins)
            {
                returnData.Description = "The edge of the swampland. There are giant stones buzzing with dark energy sitting in the middle of a small creek.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Activate", "Ruins on Stones", "You activate the ruins on the stones. They light up and then fade to black. A dark whirl forms then spreads, covering the area in darkness. Slowly the darkness fades, leaving behind several shades");
                locationActions.Add(itemAction);
                itemAction.PostItem += ActivateRuins;
                returnData.Actions = locationActions;
            }
            if (activateRuins && !defeatedMobs)
            {
                returnData.Description = "The edge of the swampland. There are giant stones sitting in the middle of a small creek. Shades float above the stones.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs);
                combatAction.PostCombat += SwampyAreaThreeMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "The edge of the swampland. There are giant stones sitting in the middle of a small creek.";
            }
            //returnData.Description = "The edge of the swampland. Shades float menacingly above the ruins";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaTwoDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenSwampland.GetTownInstance().GetRuinedCastleDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void ActivateRuins(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_ACTIVATE_RUINS, true);

                //Reload
                LocationHandler.ResetLocation(SWAMPY_AREA_THREE_KEY);
            }
        }
        public void SwampyAreaThreeMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.SWAMPY_AREA_THREE_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(SWAMPY_AREA_THREE_KEY);
            }
        }
                
        public LocationDefinition GetSwampyAreaThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SWAMPY_AREA_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Swampy Area Three";
                returnData.DoLoadLocation = LoadSwampyAreaThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Load Ruined Castle
        public Location LoadRuinedCastle()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ruined Castle";
            bool defeatedShades = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.RUINED_CASTLE_SHADES));
            bool defeatedNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.RUINED_CASTLE_NECROS));
            bool defeatedMarzen = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.MARZEN));
            bool treasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.TREASURE));
            string beforeShades = "The shades take notice of you and descend, ready to end your existence.";
            string afterShades = "The last of the shades has vanished, sending forth a burst of dark energy vaporizing the first section of the ruins.";
            string beforeMarzen = "As you move toward the inside of the ruins, the chanting suddenly stops. The world grows cold. Slowly, a necromancer in elaborate robes calmly walks out of the ruins. He draws a sword and slings a bolt of dark energy toward you. You leap to the side, dodging it and then draw your weapon.";
            string afterMarzen = "As Marzen falls to the ground dead, the darkness fades away and warmth once again floods your body.";

            if (!defeatedShades)
            {
                returnData.Description = "The ruins of a once great castle. Shades stand protecting the ruins. You can hear chanting just behind the stones.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                mobs.Add(new Shade());
                CombatAction combatAction = new CombatAction("Shades", mobs, beforeShades, afterShades);
                combatAction.PostCombat += RuinedCastleShades;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!defeatedNecros)
            {
                returnData.Description = "The ruins of a once great castle. The necromancers now stand exposed, vulnerable to attack as they frantically continue their ritual";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs, beforeShades, afterShades);
                combatAction.PostCombat += RuinedCastleNecros;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!defeatedMarzen)
            {
                returnData.Description = "The ruins of a once great castle. One necromancer remains, just out of sight. You can feel the darkness swirl as his ritual nears completion";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Marzen());
                CombatAction combatAction = new CombatAction("Marzen, High Necromancer", mobs, beforeMarzen, afterMarzen);
                combatAction.PostCombat += Marzen;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {

                returnData.Description = "The ruins of a once great castle.";
            }

            if (defeatedMarzen && !treasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += Treasure;
                returnData.Actions = locationActions;
            }


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenSwampland.GetTownInstance().GetSwampyAreaThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMarzen)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void RuinedCastleShades(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.RUINED_CASTLE_SHADES, true);

                //Reload 
                LocationHandler.ResetLocation(RUINED_CASTLE_KEY);
            }
        }

        public void RuinedCastleNecros(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.RUINED_CASTLE_NECROS, true);

                //Reload 
                LocationHandler.ResetLocation(RUINED_CASTLE_KEY);
            }
        }

        public void Marzen(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.MARZEN, true);

                //Reload 
                LocationHandler.ResetLocation(RUINED_CASTLE_KEY);
            }
        }

        public void Treasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenSwampland.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(RUINED_CASTLE_KEY);
            }
        }

        public LocationDefinition GetRuinedCastleDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RUINED_CASTLE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Rruined Castle";
                returnData.DoLoadLocation = LoadRuinedCastle;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion
                
        #endregion

        #region Get Town Instance

        private static BankenSwampland _Swampland;

        public static BankenSwampland GetTownInstance()
        {
            if (_Swampland == null)
            {
                _Swampland = new BankenSwampland();
            }

            return _Swampland;
        }

        #endregion
    }
}