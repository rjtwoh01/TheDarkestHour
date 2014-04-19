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
        public const string CENTER_WING_ROOM_KEY = "WatertownForestTower.CenterWingRoom";
        public const string BANDIT_STUDY_KEY = "WatertownForestTower.BanditStudy";
        public const string EAST_WING_ROOM_KEY = "WatertownForestTower.EastWingRoom";
        public const string CUSHIONED_ROOM_KEY = "WatertownForestTower.CushionedRoom";
        public const string INSPECTED_SKULLS_ROOM_ONE = "WatertownForestTower.InspectedSkulls";
        public const string DEFEATED_LARGE_HALL_BANDITS_ONE = "WatertownForestTower.DefeatedLargeHallBanditsOne";
        public const string DEFEATED_LARGE_HALL_BANDITS_TWO = "WatertownForestTower.DefeatedLargeHallBanditsTwo";
        public const string DEFEATED_WEST_WING_ROOM_SKELETONS = "WatertownForestTower.DefeatedWestWingRoomSkeletons";
        public const string DEFEATED_NECRO_ENVOY = "WatertownForestTower.DefeatedNecroEnvoy";
        public const string DEFEATED_CENTER_WING_BANDITS = "WatertownForestTower.DefeatedCenterWingBandits";
        public const string DEFEATED_BANDIT_SCHOLAR = "WatertownForestTower.DefeatedBanditScholar";
        public const string DEFEATED_EAST_WING_OUTLAWS = "WatertownForestTower.DefeatedEastWingCrazedOutlaws";
        public const string DEFEATED_CRAZED_OUTLAW_LEADER = "WatertownForestTower.DefeatedCrazedOutlawLeader";

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
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetLargeHallDefinition();
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

                Item armor = NecroEnvoyLoot();
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

        #region Center Wing

        #region Center Wing Room One

        public Location LoadCenterWingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Center Wing Room";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_CENTER_WING_BANDITS));

            if (!defeatedBandits)
            {
                returnData.Description = "A medium sized room with two bandits roaming about it";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += CenterWingBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A medium sized room with two dead bandit bodies strewn across the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Large Hall
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetLargeHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Bandit Study here
            if (defeatedBandits)
            {
                locationDefinition = WatertownForestTower.GetTownInstance().GetBanditStudyDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void CenterWingBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_CENTER_WING_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(CENTER_WING_ROOM_KEY);

            }
        }

        public LocationDefinition GetCenterWingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CENTER_WING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Center Wing Room";
                returnData.DoLoadLocation = LoadCenterWingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bandit Study

        public Location LoadBanditStudy()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Room";
            bool defeatedBanditScholar = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_BANDIT_SCHOLAR));

            if (!defeatedBanditScholar)
            {
                returnData.Description = "A small room lined with bookshelves and a desk overflowing with parchments. A scholar is sitting in a chair pouring over various documents.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> banditScholar = new List<Mob>();
                banditScholar.Add(new BanditScholar());
                CombatAction combatAction = new CombatAction("Bandit Scholar", banditScholar);
                combatAction.PostCombat += BanditScholar;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room lined with bookshelves and a desk overflowing with parchments.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetCenterWingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BanditScholar(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_BANDIT_SCHOLAR, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BANDIT_STUDY_KEY);

                Item helm = BanditScholarLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(helm);
                    Console.WriteLine("You loot \n{0}\n", helm);
                }
                else
                {
                    Console.WriteLine("Bandit Scholar drops \n{0}\nBut you don't have enough space to equip!\n", helm);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetBanditStudyDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BANDIT_STUDY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bandit Study";
                returnData.DoLoadLocation = LoadBanditStudy;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region East Wing

        #region East Wing Room One

        public Location LoadEastWingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "East Wing Room";
            bool defeatedOutlaws = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_EAST_WING_OUTLAWS));

            if (!defeatedOutlaws)
            {
                returnData.Description = "A small room with four crazed outlaws running around within";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> crazedOutlaws = new List<Mob>();
                crazedOutlaws.Add(new CrazedOutlaw());
                crazedOutlaws.Add(new CrazedOutlaw());
                CombatAction combatAction = new CombatAction("Crazed Outlaws", crazedOutlaws);
                combatAction.PostCombat += EastWingCrazedOutlaws;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room overcrowded by the dead outlaw bodies on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Large Hall
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetLargeHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Bandit Study here
            if (defeatedOutlaws)
            {
                locationDefinition = WatertownForestTower.GetTownInstance().GetCushionedRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void EastWingCrazedOutlaws(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_EAST_WING_OUTLAWS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(EAST_WING_ROOM_KEY);

            }
        }

        public LocationDefinition GetEastWingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = EAST_WING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "East Wing Room";
                returnData.DoLoadLocation = LoadEastWingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cushioned Room

        public Location LoadCushionedRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cushioned Room";
            bool defeatedCrazedOutlawLeader = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_CRAZED_OUTLAW_LEADER));

            if (!defeatedCrazedOutlawLeader)
            {
                returnData.Description = "A small room that's completely cushioned. There is a man jumping around laughing with a crazed look inside.";
                // Location Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> crazedOutlawLeasder = new List<Mob>();
                crazedOutlawLeasder.Add(new CrazedOutlawLeader());
                CombatAction combatAction = new CombatAction("Crazed Outlaw Leader", crazedOutlawLeasder);
                combatAction.PostCombat += CrazedOutlawLeader;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room that's completely cushioned.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // The Clearing on the outside of this tower.
            LocationDefinition locationDefinition = WatertownForestTower.GetTownInstance().GetEastWingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void CrazedOutlawLeader(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestTower.DEFEATED_CRAZED_OUTLAW_LEADER, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(CUSHIONED_ROOM_KEY);

                Item amulet = CrazedOutlawLoot();
                if (GameState.Hero.Inventory.Count < GameState.Hero.inventoryCap)
                {
                    GameState.Hero.Inventory.Add(amulet);
                    Console.WriteLine("You loot \n{0}\n", amulet);
                }
                else
                {
                    Console.WriteLine("Crazed Outlaw Leader drops \n{0}\nBut you don't have enough space to equip!\n", amulet);
                }
                GameState.ClearScreen();
            }
        }

        public LocationDefinition GetCushionedRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CUSHIONED_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cushioned Room";
                returnData.DoLoadLocation = LoadCushionedRoom;

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

        #region Boss Loot

        public Item NecroEnvoyLoot()
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

        public Item BanditScholarLoot()
        {
            Item returnData;

            int agility, strength, intelligence, armor, health, critChance, critDamage, requiredLevel, worth;
            agility = strength = intelligence = critChance = 0;
            armor = 28;
            health = 34;
            critDamage = 2;
            requiredLevel = GameState.Hero.level;
            worth = 100;
            string armorType = "";
            string name = "Helm of Wisdom";

            switch (GameState.Hero.Profession.Name)
            {
                case "Hunter":
                    agility = 32;
                    armorType = "Leather";
                    break;
                case "Rogue":
                    agility = 32;
                    armorType = "Leather";
                    break;
                case "Warrior":
                    strength = 32;
                    armorType = "Mail";
                    break;
                case "Guardian":
                    strength = 32;
                    armorType = "Mail";
                    break;
                case "Mage":
                    intelligence = 32;
                    armorType = "Cloth";
                    break;
                case "Cleric":
                    intelligence = 32;
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
            armor = 32;
            health = 40;
            critDamage = 5;
            critChance = 2;
            requiredLevel = GameState.Hero.level;
            worth = 100;
            string armorType = "";
            string name = "Amulet of the Damned";

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
