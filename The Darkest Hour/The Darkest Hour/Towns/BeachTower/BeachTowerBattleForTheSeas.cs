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
    class BeachTowerBattleForTheSeas : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerBattleForTheSeas.Entrace";
        public const string BLOODIED_BEACH_PATH_KEY = "BeachTower.BeachTowerBattleForTheSeas.BloodiedBeachPath";
        public const string HIGH_BEACH_CLIFF_KEY = "BeachTower.BeachTowerBattleForTheSeas.HighBeachCliff";
        public const string DOCKS_KEY = "BeachTower.BeachTowerBattleForTheSeas.Docks";
        public const string SEA_OVERWATCH_KEY = "BeachTower.BeachTowerBattleForTheSeas.SeaOverwatch";
        public const string ENEMY_BOAT_KEY = "BeachTower.BeachTowerBattleForTheSeas.EnemyBoat";
        public const string CAPTAIN_DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.CaptainDeck";
        public const string HOLE_IN_SHIP_KEY = "BeachTower.BeachTowerBattleForTheSeas.HoleInShip";
        public const string CREW_DINING_AREA_KEY = "BeachTower.BeachTowerBattleForTheSeas.CrewDiningArea";
        public const string STAIRS_KEY = "BeachTower.BeachTowerBattleForTheSeas.Stairs";
        public const string DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.Deck";
        public const string ADMIRAL_DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.AdmiralDeck";
        public const string BLOODIED_PATH_MOBS = "BeachTower.BeachTowerBattleForTheSeas.BloodiedPathMobs";
        public const string LAND_ASSAULT_LEADER = "BeachTower.BeachTowerBattleForTheSeas.LandAssaultLeader";
        public const string DOCKS_MOBS = "BeachTower.BeachTowerBattleForTheSeas.DocksMobs";
        public const string LANDING_OFFICER = "BeachTower.BeachTowerBattleForTheSeas.LandingOfficer";
        public const string ENEMY_BOAT_MOBS = "BeachTower.BeachTowerBattleForTheSeas.EnemyBoatMobs";
        public const string SAILOR_CAPTAIN = "BeachTower.BeachTowerBattleForTheSeas.SailorCaptain";
        public const string SAIL = "BeachTower.BeachTowerBattleForTheSeas.Sail";
        public const string SINK_ENEMY_SHIP = "BeachTower.BeachTowerBattleForTheSeas.SinkEnemyShip";
        public const string FIRE_ON_ENEMY = "BeachTower.BeachTowerBattleForTheSeas.FireOnEnemy";
        public const string BOARD_SHIP = "BeachTower.BeachTowerBattleForTheSeas.BoardShip";
        public const string HOLE_MOBS = "BeachTower.BeachTowerBattleForTheSeas.HoleMobs";
        public const string DINNING_AREA_MOBS = "BeachTower.BeachTowerBattleForTheSeas.DinningAreaMobs";
        public const string STAIRS_MOBS = "BeachTower.BeachTowerBattleForTheSeas.StairsMobs";
        public const string DECK_MOBS = "BeachTower.BeachTowerBattleForTheSeas.DeckMobs";
        public const string ASSAULT_ADMIRAL = "BeachTower.BeachTowerBattleForTheSeas.AssaultAdmiral";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region First Wing

        #region Entrance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Beach Head";
            returnData.Description = "The air is thick with the scents and sounds of battle. Up ahead the guards of the Beach Tower and invading soldiers clash upon the beach. War has arrived to Asku. It is up to you to stop the invasion before true war begins.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetBloodiedBeachpathDefinition();
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

        #region Bloodied Beach Path

        public Location LoadBloodiedBeachPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bloodied Beach Path";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.BLOODIED_PATH_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The beach path is bloodied with war. Soldiers from both sides lay dead or dying on the ground. The air is full of the sounds of war. The clash of metal on metal, the screams of soldiers, the cries of the wounded, and force of magic. Several enemy soldiers block your path forward.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                CombatAction combatAction = new CombatAction("Soldiers", mobs);
                combatAction.PostCombat += BloodiedPathMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The beach path is bloodied with war. Soldiers from both sides lay dead or dying on the ground. The air is full of the sounds of war. The clash of metal on metal, the screams of soldiers, the cries of the wounded, and force of magic.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHighBeachCliffDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BloodiedPathMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.BLOODIED_PATH_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(BLOODIED_BEACH_PATH_KEY);
            }
        }

        public LocationDefinition GetBloodiedBeachpathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BLOODIED_BEACH_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bloodied Beach Path";
                returnData.DoLoadLocation = LoadBloodiedBeachPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region High Beach Cliff

        public Location LoadHighBeachCliff()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "High Beach Cliff";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.LAND_ASSAULT_LEADER));

            if (!defeatedMobs)
            {
                returnData.Description = "A high cliff on the beach that overlooks the battle raging on. The Land Assault Leader stand ontop of the cliff, watching the battle beneathe him.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new LandAssaultLeader());
                CombatAction combatAction = new CombatAction("Land Assault Leader", mobs);
                combatAction.PostCombat += LandAssaultLeader;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A high cliff on the beach that overlooks the battle raging on.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetBloodiedBeachpathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDocksDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LandAssaultLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.LAND_ASSAULT_LEADER, true);

                //Reload 
                LocationHandler.ResetLocation(HIGH_BEACH_CLIFF_KEY);

                //Loot
                Item item = LandAssaultLeaderLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(item);
                    Console.WriteLine("You loot \n{0}\n", item);
                }
                else
                    Console.WriteLine("Land Assault Leader drops \n{0}\nBut you don't have enough space to equip it!\n", item);
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetHighBeachCliffDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HIGH_BEACH_CLIFF_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "High Beach Cliff";
                returnData.DoLoadLocation = LoadHighBeachCliff;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Docks

        public Location LoadDocks()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Docks";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DOCKS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The docks are just beyond the High Beach Cliff. They extend to the end of the shallow waters. They are currently overrun with enemy soldiers.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                CombatAction combatAction = new CombatAction("Soldiers", mobs);
                combatAction.PostCombat += DocksMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The docks are just beyond the High Beach Cliff. They extend to the end of the shallow waters. They are littered with the bloody bodies of enemy soldiers.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHighBeachCliffDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetSeaOverwatchDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DocksMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DOCKS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DOCKS_KEY);
            }
        }

        public LocationDefinition GetDocksDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DOCKS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Docks";
                returnData.DoLoadLocation = LoadDocks;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Sea Overwatch

        public Location LoadSeaOverwatch()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Sea Overwatch";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.LANDING_OFFICER));

            if (!defeatedMobs)
            {
                returnData.Description = "There is a platform at the end of the docks that is raised high into the air to overlook the seas. The Landing Officer is standing up there, surveying the landing of the enemy for their assault.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new LandingOfficer());
                CombatAction combatAction = new CombatAction("Landing Officer", mobs);
                combatAction.PostCombat += LandingOfficer;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "There is a platform at the end of the docks that is raised high into the air to overlook the seas.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDocksDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEnemyBoatDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LandingOfficer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.LANDING_OFFICER, true);

                //Reload 
                LocationHandler.ResetLocation(SEA_OVERWATCH_KEY);

                //Loot
                Item item = LandingOfficerLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(item);
                    Console.WriteLine("You loot \n{0}\n", item);
                }
                else
                    Console.WriteLine("Landing Officer drops \n{0}\nBut you don't have enough space to equip it!\n", item);
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetSeaOverwatchDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SEA_OVERWATCH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Sea Overwatch";
                returnData.DoLoadLocation = LoadSeaOverwatch;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Enemy Boat

        public Location LoadEnemyBoat()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Enemy Boat";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.ENEMY_BOAT_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The enemy boat currently docked is a mid sized one. Not all of its crew have left the boat yet to aid in the invasion.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                CombatAction combatAction = new CombatAction("Soldiers and Sailors", mobs);
                combatAction.PostCombat += BoatMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The enemy boat currently docked is a mid sized one. It's crew lays dead about its deck.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCaptainDeckDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BoatMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.ENEMY_BOAT_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(ENEMY_BOAT_KEY);
            }
        }

        public LocationDefinition GetEnemyBoatDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENEMY_BOAT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Enemy Boat";
                returnData.DoLoadLocation = LoadEnemyBoat;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Captain's Deck

        public Location LoadCaptainDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Captain's Deck";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SAILOR_CAPTAIN));
            bool sailed = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SAIL));
            bool sinkShip = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SINK_ENEMY_SHIP));
            bool fireOnAssaultShip = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.FIRE_ON_ENEMY));
            bool boardEnemy = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.BOARD_SHIP)); 

            if (!defeatedMobs)
            {
                returnData.Description = "The Captain's Deck rest at the right end of the boat. The Captain is currently standing up there.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new SailorCaptain());
                CombatAction combatAction = new CombatAction("Sailor Captain", mobs);
                combatAction.PostCombat += SailorCaptain;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!sailed)
            {
                returnData.Description = "The Captain's Deck rest at the right end of the boat. The captain is dead with his body pushed off to the side, soon to be forgotten.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Sail", "Ship", "You sail the ship away from the docks into the battle raging on the seas.");
                itemAction.PostItem += Sail;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else if (!sinkShip)
            {
                returnData.Description = "The Captain's Deck rest at the right end of the boat. You are sailing the ship. As you sail, an enemy ship comes within range and fires upon you.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Sink", "Enemy Ship", "You fire upon the enemy ship, scoring a direct hit with one of their mages. The mage was in the middle of casting a fire spell, and as the cannon ball tears his body apart the control over the spell is lost, and the fire he was controlling rapidly engulfs the whole ship. The ship burns brightly.");
                itemAction.PostItem += SinkShip;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else if (!fireOnAssaultShip)
            {
                returnData.Description = "The Captain's Deck rest at the right end of the boat. You are sailing the ship. After sinking the enemy ship, you continue to sail into the heart of the battle. You come upon the enemies' lead assault ship.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Fire Upon", "Enemy Lead Assault Ship", "You fire upon the lead assault ship. It's a miss. After a brief round of crossfire between your ship and the lead assault ship, you blow a hole into the side of the enemy ship.");
                itemAction.PostItem += FireOnEnemy;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else if (!boardEnemy)
            {
                returnData.Description = "The Captain's Deck rest at the right end of the boat. You are sailing the ship. You have drawn near the enemy's lead assault ship. The enemy ship has a large gaping hole in the side of it from the firefight between the two ships.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Board", "Enemy Lead Assault Ship", "You get in a small boat and sail it over to the enemy's lead assault ship. As you get below the hole you blew in it, you climb up the ship and get ready to go into the hole.");
                itemAction.PostItem += BoardEnemy;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            returnData.Description = "The Captain's Deck rest at the right end of the boat. You are sailing the ship. The ship is pulled up next to the enemy's lead assault ship. There is a small boat in the water below the hole blown in the enemy's ship during a brief firefight.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEnemyBoatDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (boardEnemy)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHoleInShipDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SailorCaptain(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SAILOR_CAPTAIN, true);

                //Reload 
                LocationHandler.ResetLocation(CAPTAIN_DECK_KEY);
            }

            //Loot
            Item item = SailorCaptainLoot();
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
            {
                GameState.Hero.Inventory.Add(item);
                Console.WriteLine("You loot \n{0}\n", item);
            }
            else
                Console.WriteLine("Sailor Captain drops \n{0}\nBut you don't have enough space to equip it!\n", item);
            GameState.ClearScreen();
        }

        public void Sail(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SAIL, true);

                //Reload 
                LocationHandler.ResetLocation(CAPTAIN_DECK_KEY);
            }
        }

        public void SinkShip(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.SINK_ENEMY_SHIP, true);

                //Reload 
                LocationHandler.ResetLocation(CAPTAIN_DECK_KEY);
            }
        }

        public void FireOnEnemy(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.FIRE_ON_ENEMY, true);

                //Reload 
                LocationHandler.ResetLocation(CAPTAIN_DECK_KEY);
            }
        }

        public void BoardEnemy(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.BOARD_SHIP, true);

                //Reload 
                LocationHandler.ResetLocation(CAPTAIN_DECK_KEY);
            }
        }

        public LocationDefinition GetCaptainDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CAPTAIN_DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Captain's Deck";
                returnData.DoLoadLocation = LoadCaptainDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Second Wing

        #region Hole in Ship

        public Location LoadHoleInShip()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hole in Lead Assault Ship";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.HOLE_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "There is a hole in the side of the Lead Assault Ship. Standing gaurd at the newly formed hole is two soldiers.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                CombatAction combatAction = new CombatAction("Soldiers", mobs);
                combatAction.PostCombat += HoleSoldiers;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "There is a hole in the side of the Lead Assault Ship.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCaptainDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCrewDiningAreaDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void HoleSoldiers(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.HOLE_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(HOLE_IN_SHIP_KEY);
            }
        }

        public LocationDefinition GetHoleInShipDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HOLE_IN_SHIP_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hole in Lead Assault Ship";
                returnData.DoLoadLocation = LoadHoleInShip;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Crew Dinning Area

        public Location LoadCrewDiningArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Crew Dinning Area";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DINNING_AREA_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "Just off of the hole that was blown into the ship is the dinning area of the crew. There are several soldiers and sailors mingling about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                CombatAction combatAction = new CombatAction("Soldiers and Sailors", mobs);
                combatAction.PostCombat += DinningHallMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "Just off of the hole that was blown into the ship is the dinning area of the crew.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHoleInShipDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DinningHallMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DINNING_AREA_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CREW_DINING_AREA_KEY);
            }
        }

        public LocationDefinition GetCrewDiningAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CREW_DINING_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Crew Dinning Area";
                returnData.DoLoadLocation = LoadCrewDiningArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Stairs

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.STAIRS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "Stairs leading up to the top of the ship. There are several soldiers moving up and down them.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                CombatAction combatAction = new CombatAction("Soldiers", mobs);
                combatAction.PostCombat += StairsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "Stairs leading up to the top of the ship. There are several dead bodies laying on the stairs.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCrewDiningAreaDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDeckDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void StairsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.STAIRS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(STAIRS_KEY);
            }
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

        #region Deck

        public Location LoadDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Deck";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DECK_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The Deck of the ship is large, with many soldiers and sailors running around on it, doing various things to help the invasion. There are cannons every few feet. This is not a ship to be messed with.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Soldier());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                mobs.Add(new Sailor());
                CombatAction combatAction = new CombatAction("Soldiers and Sailors", mobs);
                combatAction.PostCombat += DeckMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The Deck of the ship is large, with many dead bodies from soldiers and sailors. There are cannons every few feet. This is not a ship to be messed with, yet you did it anyway.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetAdmiralDeckDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DeckMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.DECK_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DECK_KEY);
            }
        }

        public LocationDefinition GetDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Deck";
                returnData.DoLoadLocation = LoadDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Admiral's Deck

        public Location LoadAdmiralDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Admiral's Deck";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.ASSAULT_ADMIRAL));

            string before = "So, you've made it this far. No matter, this war will continue. You will die here today, " + GameState.Hero.Identifier + ".";
            string after = "''You think this changes things? This changes nothing. Asku will burn.'' You don't want to hear anymore so you pick a sword up off the ground and slice the Admiral's head off. His words unsettle you. You've heard enemies declare something similar. Everything here was just a precusor for something much, much worse to come.";

            if (!defeatedMobs)
            {
                returnData.Description = "The Admiral's Deck is on the right side of the ship. The Admiral is standing on the top of it, sailing the ship.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new AssaultAdmiral());
                CombatAction combatAction = new CombatAction("Assault Admiral", mobs, before, after);
                combatAction.PostCombat += AssaultAdmiral;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The Admiral's Deck is on the right side of the ship. The Admiral lays dead before his wheel. Ships are on fire throughout the whole sea. The battle was fierce and bloody. But it is over now.";
            
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void AssaultAdmiral(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerBattleForTheSeas.ASSAULT_ADMIRAL, true);

                //Reload 
                LocationHandler.ResetLocation(ADMIRAL_DECK_KEY);
            }

            //Loot
            Item item = AssaultAdmiralLoot();
            if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
            {
                GameState.Hero.Inventory.Add(item);
                Console.WriteLine("You loot \n{0}\n", item);
            }
            else
                Console.WriteLine("Assault Admiral drops \n{0}\nBut you don't have enough space to equip it!\n", item);
            GameState.ClearScreen();
        }

        public LocationDefinition GetAdmiralDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ADMIRAL_DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Admiral's Deck";
                returnData.DoLoadLocation = LoadAdmiralDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Loot

        public Item LandAssaultLeaderLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;

            agility = strength = intelligence = critDamage = 0;
            armor = 80;
            health = 80;
            critChance = 5;
            requiredLevel = GameState.Hero.level;
            worth = 500;
            string armorType = "";
            string name = "War Helm";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Helmet(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item LandingOfficerLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;

            agility = strength = intelligence = critDamage = 0;
            armor = 80;
            health = 80;
            critChance = 5;
            requiredLevel = GameState.Hero.level;
            worth = 500;
            string armorType = "";
            string name = "War Chest";

            switch(GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Armor(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item SailorCaptainLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;

            agility = strength = intelligence = critDamage = 0;
            armor = 80;
            health = 80;
            critChance = 5;
            critDamage = 10;
            requiredLevel = GameState.Hero.level;
            worth = 500;
            string armorType = "";
            string name = "War Amulet";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 90;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 90;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 90;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Amulet(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        public Item AssaultAdmiralLoot()
        {
            Item returnData;

            int agility, strength, intelligence, damage, health, critChance, critDamage, requiredLevel, worth;

            agility = strength = intelligence = critDamage = 0;
            damage = 110;
            health = 80;
            critChance = 10;
            critDamage = 20;
            requiredLevel = GameState.Hero.level;
            worth = 500;
            string weaponType = "";
            string name = "";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 100;
                    weaponType = "Bow";
                    name = "Whale Hunter";
                    break;
                case "Rogue":
                    agility = 100;
                    weaponType = "Dagger";
                    name = "Serpent Sting";
                    break;
                case "Warrior":
                    strength = 100;
                    weaponType = "Sword";
                    name = "Throat Slasher";
                    break;
                case "Guardian":
                    strength = 100;
                    weaponType = "Sword";
                    name = "High Defender";
                    break;
                case "Mage":
                    intelligence = 100;
                    weaponType = "Staff";
                    name = "Storm Wager";
                    break;
                case "Cleric":
                    intelligence = 100;
                    weaponType = "Staff";
                    name = "Posidon's Bane";
                    break;
            }

            returnData = new Weapon(name, weaponType, damage, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        #endregion

        #region Get Town Instance

        private static BeachTowerBattleForTheSeas _BeachTowerBattleForTheSeas;

        public static BeachTowerBattleForTheSeas GetTownInstance()
        {
            if (_BeachTowerBattleForTheSeas == null)
            {
                _BeachTowerBattleForTheSeas = new BeachTowerBattleForTheSeas();
            }

            return _BeachTowerBattleForTheSeas;
        }

        #endregion
    }
}
