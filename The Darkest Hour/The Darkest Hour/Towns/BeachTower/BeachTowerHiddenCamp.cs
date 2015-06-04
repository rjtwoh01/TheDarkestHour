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
    class BeachTowerHiddenCamp : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerHiddenCamp.Entrace";
        public const string BURNT_TENTS_KEY = "BeachTower.BeachTowerHiddenCamp.BurntTents";
        public const string COOKS_TENTS_KEY = "BeachTower.BeachTowerHiddenCamp.CooksTents";
        public const string NECRO_AREA_KEY = "BeachTower.BeachTowerHiddenCamp.NecromancerLivingArea";
        public const string LARGE_CLEARING_KEY = "BeachTower.BeachTowerHiddenCamp.LargeClearing";
        public const string NECRO_OFFICER_TENT_KEY = "BeachTower.BeachTowerHiddenCamp.NecroOfficerTent";
        public const string BURNT_TENTS_SKELETONS = "BeachTower.BeachTowerHiddenCamp.BurntTentsSkeletons";
        public const string COOKS_TENTS_MOBS = "BeachTower.BeachTowerHiddenCamp.CooksTentsMobs";
        public const string NECRO_AREA_MOBS = "BeachTower.BeachTowerHiddenCamp.NecroAreaMobs";
        public const string LARGE_CLEARING_MOBS = "BeachTower.BeachTowerHiddenCamp.LargeClearingMobs";
        public const string NECRO_OFFICER = "BeachTower.BeachTowerHiddenCamp.NecroOfficerFight";
        public const string NECRO_OFFICER_CHEST = "BeachTower.BeachTowerHiddenCamp.NecroOfficerChest";
        public const string DOCUMENT = "BeachTower.BeachTowerHiddenCamp.Document";

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
            returnData.Name = "Hidden Camp";
            returnData.Description = "A small camp hidden deep within the woods. The place reeks of dark magic.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerGloomyForest.GetTownInstance().GetForestPathFourDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetBurntTentsDefinition();
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
                returnData.Name = "Hidden Camp";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Burnt Tents

        public Location LoadBurntTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Burnt Tents";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.BURNT_TENTS_SKELETONS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small collection of burnt tents on the outer edge of the camp. The area is full of scattered skeletons armed with old but sharp swords.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += BurntTentsSkeletons;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A small collection of burnt tents on the outer edge of the camp. The area is full of skeletons bones strewn on the ground.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetCooksTentsDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void BurntTentsSkeletons(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.BURNT_TENTS_SKELETONS, true);

                //Reload 
                LocationHandler.ResetLocation(BURNT_TENTS_KEY);
            }
        }

        public LocationDefinition GetBurntTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BURNT_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Burnt Tents";
                returnData.DoLoadLocation = LoadBurntTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cooks Tents

        public Location LoadCooksTents()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cook's Tents";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.COOKS_TENTS_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "An open area with several fires and a few tents scattered about. It seems to have been put up haphazardly, but it serves its purpose. There are possesed villagers working on the food to sustain the necromancers hidden deeper within the camp.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new PossesedVillager());
                mobs.Add(new PossesedVillager());
                mobs.Add(new PossesedVillager());
                mobs.Add(new PossesedVillager());
                CombatAction combatAction = new CombatAction("Possesed Villagers", mobs);
                combatAction.PostCombat += CooksTentsMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "An open area with several fires and a few tents scattered about. It seems to have been put up haphazardly, but it serves its purpose. The possesed villagers have been freed and put out of their misery. May they rest in peace.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetBurntTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetNecroLivingAreaDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CooksTentsMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.COOKS_TENTS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(COOKS_TENTS_KEY);
            }
        }

        public LocationDefinition GetCooksTentsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COOKS_TENTS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cook's Tents";
                returnData.DoLoadLocation = LoadCooksTents;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Necromancer Living Area

        public Location LoadNecroLivingArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Necromancer Living Area";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_AREA_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "This part of the camp is densly populated with tents. There are necromancers wondering about, preparing for whatever nefarious activities they have planned.";

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
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancer", mobs);
                combatAction.PostCombat += NecroAreaMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "This part of the camp is densly populated with tents. The necromancers lay dead with their remains splattered against the tents they used to call home. You feel better knowing you rid the world of whatever evil they were planning to commit.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetCooksTentsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetLargeClearingDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void NecroAreaMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_AREA_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(NECRO_AREA_KEY);
            }
        }

        public LocationDefinition GetNecroLivingAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NECRO_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Necromancer Living Area";
                returnData.DoLoadLocation = LoadNecroLivingArea;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Clearing

        public Location LoadLargeClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Necromancer Living Area";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.LARGE_CLEARING_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A large clearing in the camp. On the otherside you can see a large tent that clearly belongs to whoever is in charge of the necromancers in this camp. Unfortunately, the clearing is full of a mob of angry skeletons intent on blood.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += LargeAreaMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A large clearing in the camp. On the otherside you can see a large tent that clearly belongs to whoever is in charge of the necromancers in this camp. Smoke rises from the bones of skeletons in the clearing as their spirits are freed from battle.";
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetNecroLivingAreaDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetNecroIntelligenceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LargeAreaMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.LARGE_CLEARING_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(LARGE_CLEARING_KEY);
            }
        }

        public LocationDefinition GetLargeClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Clearing";
                returnData.DoLoadLocation = LoadLargeClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Necro Intelligence Officer Tent

        public Location LoadNecroOfficerTent()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Necromancer Intelligence Officer's Tent";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_OFFICER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_OFFICER_CHEST));
            bool tookDocument = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.DOCUMENT));
            string NecroOfficerSpeachBefore = GameState.Hero.Identifier + ", welcome to my humble adobe. You came here for information? How unfortunate. I will never reveal anything.";
            string NecroOfficerSpeachAfter = "You kneel down over the Intelligence Officer's body and search him for any documents. You find a folded document that Mike might find interesting.";

            if (!defeatedMobs)
            {
                returnData.Description = "A large over the top tent. Inside of it there is a necromancer dressed in very expensive robes. The room is decorated with the most expensive pieces of furniture money can buy on this side of Ankou.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new NecroIntelligenceOfficer());

                CombatAction combatAction = new CombatAction("Necromancer Intelligence Officer", mobs);
                combatAction.PostCombat += NecroIntelligenceOfficer;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
            {
                returnData.Description = "A large over the top tent. Inside of it there is a necromancer dressed in very expensive robes laying dead on the ground. The room is decorated with the most expensive pieces of furniture money can buy on this side of Ankou.";
            }

            if (defeatedMobs && !openedChest)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += NecroIntelligenceOfficerChest;
                returnData.Actions = locationActions;
            }

            if (defeatedMobs && !tookDocument)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Document");
                locationActions.Add(itemAction);
                itemAction.PostItem += NecroIntelligenceOfficerDocument;
                returnData.Actions = locationActions;
            }


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerHiddenCamp.GetTownInstance().GetLargeClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if(defeatedMobs)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void NecroIntelligenceOfficer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_OFFICER, true);

                //Reload 
                LocationHandler.ResetLocation(NECRO_OFFICER_TENT_KEY);
            }
        }

        public void NecroIntelligenceOfficerChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.NECRO_OFFICER_CHEST, true);

                //Reload
                LocationHandler.ResetLocation(NECRO_OFFICER_TENT_KEY);
            }
        }

        public void NecroIntelligenceOfficerDocument(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerHiddenCamp.DOCUMENT, true);

                //Reload
                LocationHandler.ResetLocation(NECRO_OFFICER_TENT_KEY);
            }
        }

        public LocationDefinition GetNecroIntelligenceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = NECRO_OFFICER_TENT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Necromancer Intelligence Officer's Tent";
                returnData.DoLoadLocation = LoadNecroOfficerTent;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerHiddenCamp _BeachTowerHiddenCamp;

        public static BeachTowerHiddenCamp GetTownInstance()
        {
            if (_BeachTowerHiddenCamp == null)
            {
                _BeachTowerHiddenCamp = new BeachTowerHiddenCamp();
            }

            return _BeachTowerHiddenCamp;
        }

        #endregion
    }
}
