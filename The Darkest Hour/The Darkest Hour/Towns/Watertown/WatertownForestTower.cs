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
    class WatertownForestTower : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForestTower.Entrance";
        public const string LARGE_HALL_KEY = "WatertownForestTower.LargeHall";
        public const string WEST_WING_ROOM_KEY = "WatertownForestTower.WestWingRoom";
        public const string LARGE_ROOM_KEY = "WatertownForestTower.LargeRoom";
        public const string INSPECTED_SKULLS_ROOM_ONE = "WatertownForestTower.InspectedSkulls";
        public const string DEFEATED_LARGE_HALL_BANDITS_ONE = "WatertownForestTower.DefeatedLargeHallBanditsOne";
        public const string DEFEATED_LARGE_HALL_BANDITS_TWO = "WatertownForestTower.DefeatedLargeHallBanditsTwo";
        public const string DEFEATED_WEST_WING_ROOM_SKELETONS = "WatertownForestTower.DefeatedWestWingRoomSkeletons";
        public const string DEFEATED_NECRO_ENVOY = "WatertownForestTower.DefeatedNecroEnvoy";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Tower Entrance

        public Location LoadTowerEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Tower Entrance";
            returnData.Description = "A room lined with skulls along the wall.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestClearingBeforeTower.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Large Hall
            locationDefinition = WatertownForestTower.GetTownInstance().GetLargeHallDefinition();
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
                returnData.Name = "Bandit Tower Entrance";
                returnData.DoLoadLocation = LoadTowerEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Hall

        public Location LoadLargeHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Hall";
            bool defeatedBanditsOne = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_LARGE_HALL_BANDITS_ONE));
            bool defeatedBanditsTwo = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_LARGE_HALL_BANDITS_TWO));

            if (!defeatedBanditsOne)
            {
                returnData.Description = "A large hall with two groups of bandits wondering about.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += LargeHallBanditsOne;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (!defeatedBanditsTwo && defeatedBanditsOne)
            {
                returnData.Description = "A large hall with one group of bandits wondering about.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += LargeHallBanditsTwo;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedBanditsTwo && defeatedBanditsOne)
                returnData.Description = "The hall is now empty except for the bandit bodies strewn across it.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Different wings here
            if (defeatedBanditsOne && defeatedBanditsTwo)
            {
                //West Wing
                locationDefinition = WatertownForestTower.GetTownInstance().GetWestWingRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            }

            //Floor Two Entrance here.... Need to also check to make sure the player has all of the keys


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LargeHallBanditsOne(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_LARGE_HALL_BANDITS_ONE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LARGE_HALL_KEY);

            }
        }

        public void LargeHallBanditsTwo(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_LARGE_HALL_BANDITS_TWO, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LARGE_HALL_KEY);

            }
        }

        public LocationDefinition GetLargeHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Hall";
                returnData.DoLoadLocation = LoadLargeHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region West Wing

        #region West Wing Room One

        public Location LoadWestWingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "West Wing Room";
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_WEST_WING_ROOM_SKELETONS));

            if (!defeatedSkeletons)
            {
                returnData.Description = "A medium sized room with three skeletons wondering about it.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += WestWingSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The hall is now empty except for the bandit bodies strewn across it.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Large Room here
            if (defeatedSkeletons)
            {
                locationDefinition = WatertownForestTower.GetTownInstance().GetLargeRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void WestWingSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_WEST_WING_ROOM_SKELETONS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(WEST_WING_ROOM_KEY);

            }
        }

        public LocationDefinition GetWestWingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WEST_WING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "West Wing Room";
                returnData.DoLoadLocation = LoadWestWingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Room

        public Location LoadLargeRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Room";
            bool defeatedNecroEnvoy = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_NECRO_ENVOY));

            if (!defeatedNecroEnvoy)
            {
                returnData.Description = "A large room with the necromancer's envoy standing in the middle of it.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necroEnvoy = new List<Mob>();
                necroEnvoy.Add(new NecroEnvoy());
                CombatAction combatAction = new CombatAction("Necromancer Envoy", necroEnvoy);
                combatAction.PostCombat += NecroEnvoy;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The room is blackened with dark magic from some great struggle.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetWestWingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void NecroEnvoy(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_NECRO_ENVOY, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LARGE_ROOM_KEY);

                Item armor = NecroEnvoy();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(armor);
                    Console.WriteLine("You loot \n{0}\n", armor);
                }
                else
                {
                    Console.WriteLine("Necromancer Envoy drops \n{0}\nBut you don't have enough space to equip!\n", armor);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetLargeRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Room";
                returnData.DoLoadLocation = LoadLargeRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownForestTower _WaterForestCabin;

        public static WatertownForestTower GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new WatertownForestTower();
            }

            return _WaterForestCabin;
        }

        #endregion

        #region Boos Loot

        public Item NecroEnvoy()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = critDamage = 0;
            armor = 30;
            health = 30;
            critChance = 1;
            requiredLevel = GameState.Hero.level;
            worth = 100;
            string armorType = "";
            string name = "Cursed Chest";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 35;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 35;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 35;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 35;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 35;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 35;
                    armorType = "Cloth";
                    break;
            }

            returnData = new Armor(name, armorType, armor, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        #endregion
    }
}
