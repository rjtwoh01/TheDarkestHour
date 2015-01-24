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
using The_Darkest_Hour.Items;

namespace The_Darkest_Hour.Towns.Watertown
{
    class AnkouBattle : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Ankou.AnkouBattle.Entrance";
        public const string TOWN_CENTER_KEY = "Ankou.AnkouBattle.TownCenter";
        public const string WEST_ROAD_KEY = "Ankou.AnkouBattle.WestRoad";
        public const string WEST_CLEARING_KEY = "Ankou.AnkouBattle.WestClearing";
        public const string SOUTH_ROAD_KEY = "Ankou.AnkouBattle.SouthRoad";
        public const string SOUTH_CLEARING_KEY = "Ankou.AnkouBattle.SouthClearing";
        public const string EAST_ROAD_KEY = "Ankou.AnkouBattle.EastRoad";
        public const string EAST_CLEARING_KEY = "Ankou.AnkouBattle.EastClearing";
        public const string DEFEATED_TOWN_HALL_MOBS = "Ankou.AnkouBattle.DefeatedTownCenterMobs";
        public const string DEFEATED_WEST_ROAD_BANDITS = "Ankou.AnkouBattle.DefeatedWestRoadBandits";
        public const string DEFEATED_BANDIT_ASSAULT_LEADER = "Ankou.AnkouBattle.DefeatedBanditAssaultLeader";
        public const string DEFEATED_SOUTH_ROAD_PEASANTS = "Ankou.AnkouBattle.DefeatedSouthRoadPeasants";
        public const string DEFEATED_PEASANT_ASSAULT_LEADER = "Ankou.AnkouBattle.DefeatedPeasantAssaultLeader";
        public const string DEFEATED_EAST_ROAD_NOBLES = "Ankou.AnkouBattle.DefeatedEastRoadNobles";
        public const string DEFEATED_NOBLE_ASSAULT_LEADER = "Ankou.AnkouBattle.DefeatedNobleAssaultLeader";
        public const string NORTH_ONE_KEY = "Ankou.AnkouBattle.NorthOne";
        public const string NORTH_TWO_KEY = "Ankou.AnkouBattle.NorthTwo";
        public const string NORTH_THREE_KEY = "Ankou.AnkouBattle.NorthThree";
        public const string NORTH_FOUR_KEY = "Ankou.AnkouBattle.NorthFour";
        public const string NORTH_FIVE_KEY = "Ankou.AnkouBattle.NorthFive";
        public const string NORTH_CLEARING_KEY = "Ankou.AnkouBattle.NorthClearing";
        public const string DEFEATED_ROAD_ONE_MOBS = "Ankou.AnkouBattle.DefeatedRoadOneMobs";
        public const string DEFEATED_ROAD_TWO_MOBS = "Ankou.AnkouBattle.DefeatedRoadTwoMobs";
        public const string DEFEATED_ROAD_THREE_MOBS = "Ankou.AnkouBattle.DefeatedRoadThreeMobs";
        public const string DEFEATED_ROAD_FOUR_MOBS = "Ankou.AnkouBattle.DefeatedRoadFourMobs";
        public const string DEFEATED_ROAD_FIVE_MOBS = "Ankou.AnkouBattle.DefeatedRoadFiveMobs";
        public const string DEFEATED_LORD_ARGUS = "Ankou.AnkouBattle.DefeatedLordArgus";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Battle Entrance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Battle for Ankou";
            returnData.Description = "Ankou us under siege from many forces. Smoke and fire rise into the night. The moon is red and dark energy fills the streets. Screams echo throughout the city and the cries of the damned are heard for centuries more.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetStartingLocationDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Ankou Town Center Under Siege
            locationDefinition = AnkouBattle.GetTownInstance().GetTownCenterDefinition();
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
                returnData.Name = "Battle for Ankou";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region First Half

        #region Ankou Town Center Under Siege

        public Location LoadTownCenter()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ankou Town Center Under Siege";
            bool defeatedMobsOne = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_TOWN_HALL_MOBS));
            bool defeatedBanditAssaultLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_BANDIT_ASSAULT_LEADER));
            bool defeatedPeasantAssaultLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_PEASANT_ASSAULT_LEADER));
            bool defeatedNobleAssaultLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_NOBLE_ASSAULT_LEADER));

            if (!defeatedMobsOne)
            {
                returnData.Description = "The town center is burning with several enemies roaming about and killing any innocent they can find";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Peasant());
                mobs.Add(new Noble());
                mobs.Add(new Noble());
                mobs.Add(new Bandit());
                mobs.Add(new Peasant());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Noble());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Enemies of the State", mobs);
                combatAction.PostCombat += TownCenterMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Different wings here
            if (defeatedMobsOne)
            {
                //West Road
                locationDefinition = AnkouBattle.GetTownInstance().GetWestRoadDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                //South Road
                locationDefinition = AnkouBattle.GetTownInstance().GetCenterRoadRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                //East Road
                locationDefinition = AnkouBattle.GetTownInstance().GetEastRoadRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            if (defeatedBanditAssaultLeader && defeatedNobleAssaultLeader && defeatedPeasantAssaultLeader)
            {
                //North Road
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthOneDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            //Floor Two Entrance here.... Need to also check to make sure the player has all of the keys


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void TownCenterMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_TOWN_HALL_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);

            }
        }

        public LocationDefinition GetTownCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_CENTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ankou Town Center Under Siege";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region West Road

        #region West Road

        public Location LoadWestRoad()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "West Road";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_WEST_ROAD_BANDITS));

            if (!defeatedMobs)
            {
                returnData.Description = "The road stretches on with smoke making it hard to see far ahead. There are several bandits looting shops along the road.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += WestRoadSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The road stretches on with smoke making it hard to see far ahead. There are several dead bandits with the items they were looting laying long forgotten on the streets.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //West Clearing here
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetWestClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void WestRoadSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_WEST_ROAD_BANDITS, true);

                // Reload
                LocationHandler.ResetLocation(WEST_ROAD_KEY);

            }
        }

        public LocationDefinition GetWestRoadDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WEST_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "West Road";
                returnData.DoLoadLocation = LoadWestRoad;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region West Clearing

        public Location LoadWestClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "West Clearing";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_BANDIT_ASSAULT_LEADER));

            if (!defeatedMobs)
            {
                returnData.Description = "A large circular clearing with the Bandit Assault Leader admiring the work he's done on the city.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new BanditAssaultLeader());
                CombatAction combatAction = new CombatAction("Bandit Assault Leader", mobs);
                combatAction.PostCombat += BanditAssaultLeader;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The clearing lays charred from the fires that took place here during the battle. The Bandit Assault Leader lays dead in the middle of the clearing.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetWestRoadDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BanditAssaultLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_BANDIT_ASSAULT_LEADER, true);

                // Reload
                LocationHandler.ResetLocation(WEST_CLEARING_KEY);

                Item armor = BanditAssaultLeaderLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(armor);
                    Console.WriteLine("You loot \n{0}\n", armor);
                }
                else
                {
                    Console.WriteLine("Bandit Assault Leader drops \n{0}\nBut you don't have enough space to equip!\n", armor);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetWestClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WEST_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "West Clearing";
                returnData.DoLoadLocation = LoadWestClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region South Road

        #region South Road North Road One

        public Location LoadCenterRoadRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "South Road";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_SOUTH_ROAD_PEASANTS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small narrow road that is lined with many burning shabby houses. There are a dozen peasants slaughtering any who did not join them in the attack and razing the hell they called home to the ground.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", mobs);
                combatAction.PostCombat += CenterRoadBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small narrow road that is lined with many burning shabby houses. The roads are littered with many a dead body.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Ankou Town Center Under Siege
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //South Clearing here
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetSouthClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void CenterRoadBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_SOUTH_ROAD_PEASANTS, true);

                // Reload
                LocationHandler.ResetLocation(SOUTH_ROAD_KEY);

            }
        }

        public LocationDefinition GetCenterRoadRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SOUTH_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "South Road";
                returnData.DoLoadLocation = LoadCenterRoadRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region South Clearing

        public Location LoadSouthClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "West Clearing";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_PEASANT_ASSAULT_LEADER));

            if (!defeatedMobs)
            {
                returnData.Description = "A tiny clearing with a small crazed man laughing hysterically in the middle of it. The Peasant Assault Leader. He has a crazed look in his eyes as the event he's been planning for some time now has finally comed to pass.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new PeasantAssaultLeader());
                CombatAction combatAction = new CombatAction("Peasant Assault Leader", mobs);
                combatAction.PostCombat += PeasantAssaultLeader;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A tiny clearing with a small man dead on the edge of it. His life was miserable and now he has finally found peace in death. A tragic ending.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetCenterRoadRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void PeasantAssaultLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_PEASANT_ASSAULT_LEADER, true);

                // Reload
                LocationHandler.ResetLocation(SOUTH_CLEARING_KEY);

                Item helm = PeasantAssaultLeaderLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(helm);
                    Console.WriteLine("You loot \n{0}\n", helm);
                }
                else
                {
                    Console.WriteLine("Peasant Assault Leader drops \n{0}\nBut you don't have enough space to equip!\n", helm);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetSouthClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SOUTH_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "South Clearing";
                returnData.DoLoadLocation = LoadSouthClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region East Road

        #region East Road North Road One

        public Location LoadEastRoadRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "East Road";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_EAST_ROAD_NOBLES));

            if (!defeatedMobs)
            {
                returnData.Description = "A large road lined with the most elegent and expensive houses that Ankou has to offer. There is a group of nobles setting fire to the houses of their enemies on the road. There are piles of dead bodies, the victims of this sick attack.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Noble());
                mobs.Add(new Noble());
                mobs.Add(new Noble());
                mobs.Add(new Noble());
                CombatAction combatAction = new CombatAction("Nobles", mobs);
                combatAction.PostCombat += EastRoadNobles;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A larege road line with the most elegent and expensive houses that Ankou has to offer. There is a pile of dead traitor nobles who set fire to several of the houses. Separated from there traitors is several piles of dead bodies, the victims of this sick attack.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Ankou Town Center Under Siege
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //South Clearing here
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetEastClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EastRoadNobles(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_EAST_ROAD_NOBLES, true);

                // Reload
                LocationHandler.ResetLocation(EAST_ROAD_KEY);

            }
        }

        public LocationDefinition GetEastRoadRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EAST_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "East Road";
                returnData.DoLoadLocation = LoadEastRoadRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region East Clearing

        public Location LoadEastClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "East Clearing";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_NOBLE_ASSAULT_LEADER));

            if (!defeatedMobs)
            {
                returnData.Description = "A large clearing that has a huge expensive fountain in the center. The fountain is of a general long dead who fought in the Asku civil war. The Noble Assault Leader is sitting on the edge of the fountain, flipping a coin repeatedly.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new NobleAssaultLeader());
                CombatAction combatAction = new CombatAction("Noble Assault Leader", mobs);
                combatAction.PostCombat += NobleAssaultLeader;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large clearing that has a huge expensive fountain in the center. The fountain is of a general long dead who fought in the Asku civil war. The Noble Assault Leader lays dead in the fountain, the water turned red with his blood.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetEastRoadRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NobleAssaultLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_NOBLE_ASSAULT_LEADER, true);

                // Reload
                LocationHandler.ResetLocation(EAST_CLEARING_KEY);

                Item amulet = CrazedOutlawLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(amulet);
                    Console.WriteLine("You loot \n{0}\n", amulet);
                }
                else
                {
                    Console.WriteLine("Noble Assault Leader drops \n{0}\nBut you don't have enough space to equip!\n", amulet);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetEastClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EAST_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "East Clearing";
                returnData.DoLoadLocation = LoadEastClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Second Half

        #region North Road One

        public Location LoadNorthOne()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Road One";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_ONE_MOBS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The northern road is a very long one that will go all the way up to City Hall. The first part of the road feels heavy with dark magic. There are several necromancers hurling dark bolts of energy at innocent civilians and laughing with glee with each person they strike down.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += NorthOneMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern road is a very long one that will go all the way up to City Hall. The first part of the road feels heavy with dark magic. There are several dead necromancers, their bodies laying amongst those of their victims.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //North Road Two
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NorthOneMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_ONE_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_ONE_KEY);

            }
        }

        public LocationDefinition GetNorthOneDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_ONE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Road One";
                returnData.DoLoadLocation = LoadNorthOne;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Road Two

        public Location LoadNorthTwo()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Road Two";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_TWO_MOBS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The northern road continues with fires blowing high into the sky. There are half a dozen necromancers rounding up civilians to take as slaves.";
                string before = "One of the new slaves looks up at you and shouts out, ''Come! Help us! Don't let them take us away!'' \n\nOne of the necromancers twirls around firing a bolt of dark magic at you while another one stabs the man who cried out in the gut. You draw your weapon and prepare yourself to save these people from a very nasty fate.\n";
                string after = "As the last necromancers falls dead to the ground you turn your attention to the slaves. You cut them loose from their ropes and bid them to hury and find saftey. They run off into the distance, all looking for parts of the city that have been reclaimed by the army and constables.\n";

                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs, before, after);
                combatAction.PostCombat += NorthTwoMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern road continues with fires blowing high into the sky. There are half a dozen dead necromancer bodies on the ground, their newly aquired slaves long gone.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetNorthOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //North Road Two
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NorthTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_TWO_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_TWO_KEY);

            }
        }

        public LocationDefinition GetNorthTwoDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_TWO_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Road Two";
                returnData.DoLoadLocation = LoadNorthTwo;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Road Three

        public Location LoadNorthThree()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Road Three";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_THREE_MOBS));
            
            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The northern road continues on. There are two necromancers sitting in the ruins of a burned building, taking a break from their killings.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += NorthThreeMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern road continues. There are two dead necromancers in the wreckage of one of the burnt buildings.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetNorthTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthFourDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NorthThreeMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_THREE_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_THREE_KEY);

            }
        }

        public LocationDefinition GetNorthThreeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_THREE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Road Three";
                returnData.DoLoadLocation = LoadNorthThree;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Road Four

        public Location LoadNorthFour()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Road Four";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_FOUR_MOBS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The northern road continues on. There is a group of four necromancers raping a young woman.";
                string before = "As you see the necromancers engaging in such revolting activity with the woman, you draw your weapon and shout a horrible battle cry, one that sends chills to the bones of everyone within the city. The necromancers turn on you and one of them slices the woman's throat. While you feel bad for what happen to the woman and regret over not being able to save her, you take consilation in the fact that she is now at peace and doesn't have to worry about anything anymore.\n";
                string after = "You feel an immense surge of satisfaction as the last necromancer falls dead to the ground. They deserved everything they got and then more. You strip one of the necromancers robes off him and gingerly place them on the dead woman, determined you will at least give her dignity in death even if the necromancers robbed her of it in life.\n";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs, before, after);
                combatAction.PostCombat += NorthFourMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern road continues on. There are four dead necromancers, one of them without robes which are on the dead woman lying several feet away from the necromancers.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetNorthThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //North Road Two
            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthFiveDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NorthFourMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_ROAD_FOUR_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_FOUR_KEY);

            }
        }

        public LocationDefinition GetNorthFourDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_FOUR_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Road Four";
                returnData.DoLoadLocation = LoadNorthFour;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region North Road Five

        public Location LoadNorthFive()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "North Road Five";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.NORTH_FIVE_KEY));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The northern road nears its end as it approaches City Hall. There is a large group of necromancers blocking the way to City Hall, preventing any relief forces from reclaiming the vital part of Ankou.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += NorthFiveNecro;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern road nears its end as it approaches City Hall. The dead bodies of eight necromancers lay on the ground. There is now nothing stopping the army from reclaiming the vital part of the city.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetNorthFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouBattle.GetTownInstance().GetNorthClearingDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            
            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NorthFiveNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.NORTH_FIVE_KEY, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_FIVE_KEY);

            }
        }

        public LocationDefinition GetNorthFiveDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_FIVE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "North Road Five";
                returnData.DoLoadLocation = LoadNorthFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region City Hall

        public Location LoadNorthClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "City Hall";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_LORD_ARGUS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "The clearing around city hall is full of fighting necromancers and soldiers of Ankou's army. The constables are off trying to restore peace in other parts of the city. Lord Argus stands at the top of the steps to City Hall, observing the fight with a smirk on his face.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();
                string before = "Lord Argus walks down the steps saying in a loud booming voice, ''Well, well, well. If it isn't the great hero, " + GameState.Hero.Identifier + ". Here to save the city are we? Well you're too late. Tonight has been in the making for several months. Ankou will burn to the ground. Die fool.''\n";
                string after = "Lord Argus's body falls to the ground at the bottom of the steps to City Hall. The once proud noble turned dark by the necromancers can no longer spread his corruption. As the necromancers see their leader's body fall to the ground, they make a retreat. The army storms city hall and raises Ankou's flag over the building once more. The city has been saved.\n";

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new LordArgus());
                CombatAction combatAction = new CombatAction("Lord Argus", mobs, before, after);
                combatAction.PostCombat += LordArgus;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The clearing before City Hall is littered with dead bodies from both sides of the conflict. The are is full of cheering soldiers, relieved that they have reclaimed the city.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = AnkouBattle.GetTownInstance().GetNorthFiveDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LordArgus(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, AnkouBattle.DEFEATED_LORD_ARGUS, true);

                // Reload
                LocationHandler.ResetLocation(NORTH_CLEARING_KEY);

                Item weapon = LordArgusLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(weapon);
                    Console.WriteLine("You loot \n{0}\n", weapon);
                }
                else
                {
                    Console.WriteLine("Lord Argus drops \n{0}\nBut you don't have enough space to equip!\n", weapon);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetNorthClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NORTH_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "City Hall";
                returnData.DoLoadLocation = LoadNorthClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouBattle _WaterForestCabin;

        public static AnkouBattle GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new AnkouBattle();
            }

            return _WaterForestCabin;
        }

        #endregion

        #region Boss Loot

        public Item BanditAssaultLeaderLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = critDamage = 0;
            armor = 40;
            health = 40;
            critChance = 4;
            requiredLevel = GameState.Hero.level;
            worth = 400;
            string armorType = "";
            string name = "Mysterious Chest";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 50;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 50;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 50;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 50;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 50;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 50;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Armor(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item PeasantAssaultLeaderLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = critChance = 0;
            armor = 38;
            health = 44;
            critDamage = 4;
            requiredLevel = GameState.Hero.level;
            worth = 400;
            string armorType = "";
            string name = "Ancient King's Helm";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 48;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 48;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 48;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 48;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 48;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 48;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Helmet(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item CrazedOutlawLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = 0;
            armor = 48;
            health = 40;
            critDamage = 5;
            critChance = 2;
            requiredLevel = GameState.Hero.level;
            worth = 400;
            string armorType = "";
            string name = "Blackened Amulet";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 40;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 40;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 40;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 40;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 40;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 40;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Amulet(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item LordArgusLoot()
        {
            Item returnData;

            int agility, strength, intelligence, damage, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = 0;
            damage = 50;
            health = 50;
            critDamage = 10;
            critChance = 6;
            requiredLevel = GameState.Hero.level;
            worth = 400;
            string armorType = "";
            string name = "";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 50;
                    armorType = "Bow";
                    name = "Bone Bow";
                    break;
                case "Rogue":
                    agility = 50;
                    armorType = "Dagger";
                    name = "Twisted Killer";
                    break;
                case "Warrior":
                    strength = 50;
                    armorType = "Sword";
                    name = "Sword of the Ancients";
                    break;
                case "Guardian":
                    strength = 50;
                    armorType = "Sword";
                    name = "The Lost Blade";
                    break;
                case "Mage":
                    intelligence = 50;
                    armorType = "Staff";
                    name = "Death's Staff";
                    break;
                case "Cleric":
                    intelligence = 50;
                    armorType = "Staff";
                    name = "Staff of the Grand Mother";
                    break;
            }

            returnData = new Weapon(name, armorType, damage, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        #endregion
    }
}