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
    class WatertownForestTowerFloorTwo : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownForestTowerFloorTwoFloorTwo.Entrance";
        public const string ROOM_ONE_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomOne";
        public const string ROOM_TWO_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomTwo";
        public const string ROOM_THREE_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomThree";
        public const string ROOM_FOUR_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomFour";
        public const string ROOM_FIVE_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomFive";
        public const string GRAND_ROOM_KEY = "WatertownForestTowerFloorTwoFloorTwo.RoomOne";
        public const string DEFEATED_ENTRANCE_SKELETONS = "WatertownForestTowerFloorTwoFloorTwo.DefeatedEntranceSkeletons";
        public const string DEFEATED_ROOM_ONE_BANDITS = "WatertownForestTowerFloorTwoFloorTwo.DefeatedRoomOneBandits";
        public const string DEFEATED_ROOM_TWO_GROUP = "WatertownForestTowerFloorTwoFloorTwo.DefeatedRoomTwoBandits";
        public const string DEFEATED_ROOM_FOUR_BANDITS = "WatertownForestTowerFloorTwoFloorTwo.DefeatedRoomFourGuards";
        public const string DEFEATED_ROOM_FIVE_NECRO = "WatertownForestTowerFloorTwoFloorTwo.DefeatedRoomFiveNecro";
        public const string DEFEATED_BANDIT_KING = "WatertownForestTowerFloorTwoFloorTwo.DefeatedBanditKing";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Tower Floor Two Entrance

        public Location LoadTowerFloorTwoEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Tower Floor Two Entrance";
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ENTRANCE_SKELETONS));

            //Actions
            if (!defeatedSkeletons)
            {
                returnData.Description = "A room with dead bodies strewn about the floor and skeletons wondering around";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += EntranceSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A room with dead bodies strewn about the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetLargeHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Room One
            locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EntranceSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ENTRANCE_SKELETONS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ENTRANCE_KEY);

            }
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
                returnData.Name = "Bandit Tower Floor Two Entrance";
                returnData.DoLoadLocation = LoadTowerFloorTwoEntrance;

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
            returnData.Name = "Small Room";
            bool defeatedSkeletons = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_ONE_BANDITS));

            //Actions
            if (!defeatedSkeletons)
            {
                returnData.Description = "A room with dead bodies strewn about the floor and skeletons wondering around";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> skeletons = new List<Mob>();
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                skeletons.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", skeletons);
                combatAction.PostCombat += EntranceSkeletons;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A room with dead bodies strewn about the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Room Two
            if (defeatedSkeletons)
            {
                locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomTwoDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomOneBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_ONE_BANDITS, true);

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
                returnData.Name = "Small Room";
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
            returnData.Name = "Eating Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_TWO_GROUP));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A room filled with tables for eating. There is a group of necromancers and bandits eating";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Bandits and Necromancers", mobs);
                combatAction.PostCombat += RoomTwoGroup;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A room with dead bodies strewn about the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomOneDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Room Two
            if (defeatedMobs)
            {
                locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomThreeDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomFourDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomFiveDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomTwoGroup(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_TWO_GROUP, true);

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
                returnData.Name = "Eating Room";
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
            returnData.Name = "Empty Room";
            returnData.Description = "A bare and empty room.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
                returnData.Name = "Empty Room";
                returnData.DoLoadLocation = LoadRoomThree;

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
            returnData.Name = "Guard Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_FOUR_BANDITS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A guard room. There is a door on the other signed guarded by four very grim men.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Guard());
                mobs.Add(new Guard());
                mobs.Add(new Guard());
                mobs.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", mobs);
                combatAction.PostCombat += RoomFourGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A guard room with four failures of guards laying dead on the ground";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Room Two
            if (defeatedMobs)
            {
                locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetGrandRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFourGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_FOUR_BANDITS, true);

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
                returnData.Name = "Guard Room";
                returnData.DoLoadLocation = LoadRoomFour;

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
            returnData.Name = "Necromancer Lounge";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_FIVE_NECRO));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A small lounge area for necromancers. There are two necromancers sitting on a couch relaxing.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Guards", mobs);
                combatAction.PostCombat += RoomFourGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small lounge area for necromancers.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomTwoDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RoomFiveNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_FIVE_NECRO, true);

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
                returnData.Name = "Necromancer Lounge";
                returnData.DoLoadLocation = LoadRoomFive;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region GrandRoom

        public Location LoadGrandRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Grand Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_ROOM_FIVE_NECRO));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A large grand room. The Bandit King is sitting on his throne.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new BanditKing());
                CombatAction combatAction = new CombatAction("Bandit King", mobs);
                combatAction.PostCombat += RoomFourGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large grand room. The Bandit King lays dead at the foot of his throne.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The floor below
            LocationDefinition locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            
            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BanditKing(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTowerFloorTwo.DEFEATED_BANDIT_KING, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(GRAND_ROOM_KEY);

                Item weapon = BanditKingLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(weapon);
                    Console.WriteLine("You loot \n{0}\n", weapon);
                }
                else
                {
                    Console.WriteLine("Bandit King drops \n{0}\nBut you don't have enough space to equip!\n", weapon);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetGrandRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = GRAND_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Grand Room";
                returnData.DoLoadLocation = LoadGrandRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static WatertownForestTowerFloorTwo _WaterForestCabin;

        public static WatertownForestTowerFloorTwo GetTownInstance()
        {
            if (_WaterForestCabin == null)
            {
                _WaterForestCabin = new WatertownForestTowerFloorTwo();
            }

            return _WaterForestCabin;
        }

        #endregion

        #region Boss Loot

        public Item BanditKingLoot()
        {
            Item returnData;

            int agility, strength, intelligence, damage, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = 0;
            damage = 32;
            health = 35;
            critDamage = 5;
            critChance = 2;
            requiredLevel = GameState.Hero.level;
            worth = 100;
            string armorType = "";
            string name = "";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 50;
                    armorType = "Bow";
                    name = "Royalty Killer";
                    break;
                case "Rogue":
                    agility = 50;
                    armorType = "Dagger";
                    name = "Sabotager";
                    break;
                case "Warrior":
                    strength = 50;
                    armorType = "Sword";
                    name = "King Slayer";
                    break;
                case "Guardian":
                    strength = 50;
                    armorType = "Sword";
                    name = "Protection";
                    break;
                case "Mage":
                    intelligence = 50;
                    armorType = "Staff";
                    name = "The Unmaker";
                    break;
                case "Cleric":
                    intelligence = 50;
                    armorType = "Staff";
                    name = "Holy Smiter";
                    break;
            }

            returnData = new Weapon(name, armorType, damage, strength, agility, intelligence, health, 0, 0, requiredLevel, critChance, critDamage, worth);

            return returnData;
        }

        #endregion
    }
}
