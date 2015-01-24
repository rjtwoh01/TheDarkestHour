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
    class AnkouForestCabin : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouForestCabin.Entrance";
        public const string LIVING_ROOM_KEY = "Ankou.AnkouForestCabin.LivingRoom";
        public const string KITCHEN_KEY = "Ankou.AnkouForestCabin.Kitchen";
        public const string BEDROOM_KEY = "Ankou.AnkouForestCabin.Bedroom";
        public const string DEFEATED_LIVING_ROOM_PEASANTS = "Ankou.AnkouForestCabin.DefeatedLivingRoomPeasants";
        public const string DEFEATED_KITCHEN_PEASANTS = "Ankou.AnkouForestCabin.DefeatedKitchenPeasants";
        public const string KILLED_PEASANT_LEADER = "Ankou.AnkouForestCabin.KilledPeasantLeader";
        public const string TOOK_MAP = "Ankou.AnkouForestCabin.TookMap";
        public const string TOOK_TREASURE = "Ankou.AnkouForestCabin.TookTreasure";


        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Shabby Cabin";
            returnData.Description = "A cabin that was clumsily put together with really cheap wood. It looks as if it's falling apart.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForestCabin.GetTownInstance().GetLivingRoomDefinition();
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
                returnData.Name = "Shabby Cabin";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Living Room

        public Location LoadLivingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Living Room";
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_LIVING_ROOM_PEASANTS));

            //Actions
            if (!defeatedPeasants)
            {
                returnData.Description = "A small living devoid of any and all furniture except for a wooden bench across the back wall. There are two peasants in the room. One is sitting on the bench and the other is pacing around nervously, something obviously on her mind.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> peasant = new List<Mob>();
                peasant.Add(new Peasant());
                peasant.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", peasant);
                combatAction.PostCombat += LivingRoomPeasants;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small living devoid of any and all furniture except for a wooden bench across the back wall. There are two dead peasants laying on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPeasants)
            {
                locationDefinition = AnkouForestCabin.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LivingRoomPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_LIVING_ROOM_PEASANTS, true);

                // Reload
                LocationHandler.ResetLocation(LIVING_ROOM_KEY);

            }
        }

        public LocationDefinition GetLivingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LIVING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Living Room";
                returnData.DoLoadLocation = LoadLivingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_KITCHEN_PEASANTS));

            //Actions
            if (!defeatedPeasants)
            {
                returnData.Description = "A tiny kitchen with barely any materials to cook with. Despite this, there are four peasants working tirelessly to produce food for their leader.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> peasant = new List<Mob>();
                peasant.Add(new Peasant());
                peasant.Add(new Peasant());
                peasant.Add(new Peasant());
                peasant.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", peasant);
                combatAction.PostCombat += KitchenPeasants;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A tiny kitchen with barely any materials to cook with. There are four dead peasants whose blood now coats the walls.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPeasants)
            {
                locationDefinition = AnkouForestCabin.GetTownInstance().GetBedroomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void KitchenPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_KITCHEN_PEASANTS, true);

                // Reload
                LocationHandler.ResetLocation(KITCHEN_KEY);

            }
        }

        public LocationDefinition GetKitchenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = KITCHEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadKitchen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bedroom

        public Location LoadBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bedroom";
            bool defeatedPeasantWarden = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.KILLED_PEASANT_LEADER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_TREASURE));
            bool freePrisoners = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_MAP));
            string peasantSpeechBefore = "Ah, I see you found me. You've been causing a lot of problems for my enemies, and some problems for me. I'm willing to forgive all the crimes you've comitted against me if you agree to focus solely on eradicating every noble in Ankou.\n\nNo? Fine then. Die. Now.\n";
            string peasantSpeechAfter = "The peasant leader gasp out, ''You won't survive what's to come " + GameState.Hero.Identifier + ". Your world will burn, and this town will be nuthing but dust by the time we're done with you!'' \n\nHe collapses to the ground, his body cold and lifeless.\n";

            //Actions
            if (!defeatedPeasantWarden)
            {
                returnData.Description = "A small bedroom with a wooden bed and a torn sheet laying on it. The peasant leader is sitting on it, staring out the window.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> leader = new List<Mob>();
                leader.Add(new PeasantLeader());
                CombatAction combatAction = new CombatAction("Peasant Leader", leader, peasantSpeechBefore, peasantSpeechAfter);
                combatAction.PostCombat += DefeatedPeasantWarden;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedPeasantWarden)
            {
                if (!openedChest)
                {
                    if (!freePrisoners)
                        returnData.Description = "A small bedroom with a wooden bed and a torn sheet laying on it. The peasant leader lays dead at the foot of his bed. There is a map that's halfway fallen out of his pocket and a small shabby chest beneath the bed that's unopened.";
                    else
                        returnData.Description = "A small bedroom with a wooden bed and a torn sheet laying on it. The peasant leader lays dead at the foot of his bed. There is a small shabby chest beneath the bed that's unopened.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += LeaderChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && freePrisoners)
                    returnData.Description = "A small bedroom with a wooden bed and a torn sheet laying on it. The peasant leader lays dead at the foot of his bed. There is a small shabby chest beneath the bed that's opened.";
                if (!freePrisoners && openedChest)
                {
                    returnData.Description = "A small bedroom with a wooden bed and a torn sheet laying on it. The peasant leader lays dead at the foot of his bed. There is a map that's halfway fallen out of his pocket and a small shabby chest beneath the bed that's opened.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction freePrisonerAction = new TakeItemAction("Map");
                    freePrisonerAction.PostItem += TakeMap;
                    locationActions.Add(freePrisonerAction);
                    returnData.Actions = locationActions;
                }
            }

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPeasantWarden && freePrisoners)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedPeasantWarden(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.KILLED_PEASANT_LEADER, true);

                // Reload
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public void LeaderChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_TREASURE, true);

                // Reload
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public void TakeMap(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_MAP, true);

                // Reload
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public LocationDefinition GetBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouForestCabin _AnkouForestCabin;

        public static AnkouForestCabin GetTownInstance()
        {
            if (_AnkouForestCabin == null)
            {
                _AnkouForestCabin = new AnkouForestCabin();
            }

            return _AnkouForestCabin;
        }

        #endregion
    }
}
