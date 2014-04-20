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
        public const string DEFEATED_ENTRANCE_SKELETONS = "WatertownForestTowerFloorTwoFloorTwo.DefeatedEntranceSkeletons";

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
            //locationDefinition = WatertownForestTowerFloorTwo.GetTownInstance().GetRoomOneDefinition();
            //adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


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
