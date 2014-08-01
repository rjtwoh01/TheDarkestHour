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
    class AnkouSeedyInn : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouSeedyInn.Entrance";
        public const string LOUNGING_ROOM_KEY = "Ankou.AnkouSeedyInn.LoungingRoom";
        public const string KITCHEN_KEY = "Ankou.AnkouSeedyInn.Kitchen";
        public const string STAIRS_KEY = "Ankou.AnkouSeedyInn.Stairs";
        public const string BASEMENT_LANDING_KEY = "Ankou.AnkouSeedyInn.BasementLanding";
        public const string STORAGE_KEY = "Ankou.AnkouSeedyInn.Storage";
        public const string TORTURE_CHAMBER_KEY = "Ankou.AnkouSeedyInn.TortureChamber";
        public const string DEFEATED_LOUNGING_ROOM_PEASANTS = "Ankou.AnkouSeedyInn.DefeatedLoungingRoomPeasants";
        public const string DEFEATED_KITCHEN_PEASANTS = "Ankou.AnkouSeedyInn.DefeatedKitchenPeasants";
        public const string DEFEATED_BASEMENT_LANDING_BANDITS = "Ankou.AnkouSeedyInn.DefeatedBasmentLandingBadnits";
        public const string DEFEATED_STORAGE_BANDITS = "Ankou.AnkouSeedyInn.DefeatedStorageBandits";
        public const string KILLED_BANDIT_TORTURER = "Ankou.AnkouSeedyInn.KilledBanditTorturer";
        public const string TOOK_NOTES_OF_PAYMENT = "Ankou.AnkouSeedyInn.TortureChamber";
        public const string TOOK_TREASURE = "Ankou.AnkouSeedyInn.TookTreasure";

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
            returnData.Name = "Seedy Inn";
            returnData.Description = "A run down dirty inn used by the scum of society for black market trade and backdoor dealings. The place gives off a very bad vibe and is avoided by decent people. The entrance is falling apart and smells of old dried blood.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetLoungingRoomDefinition();
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
                returnData.Name = "Seedy Inn";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Lounging Room

        public Location LoadLoungingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Lounging Room";
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_LOUNGING_ROOM_PEASANTS));

            //Actions
            if (!defeatedPeasants)
            {
                returnData.Description = "A small lounging room with a torn couch and a broken fire place. There are two drunk peasants sitting on the couch arguing with each other. They are too absorbed in their own coversation to attack you without being provocked";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> peasant = new List<Mob>();
                peasant.Add(new Peasant());
                peasant.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", peasant);
                combatAction.PostCombat += LoungingRoomPeasants;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small lounging room with a torn couch and a broken fire place. There are two dead peasants slaughtered upon the couch, adding to to the depressing run down atmosphere.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LoungingRoomPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_LOUNGING_ROOM_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LOUNGING_ROOM_KEY);

            }
        }

        public LocationDefinition GetLoungingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LOUNGING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Lounging Room";
                returnData.DoLoadLocation = LoadLoungingRoom;

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
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_KITCHEN_PEASANTS));
            
            //Actions
            if (!defeatedPeasants)
            {
                returnData.Description = "A small kitchen with old rusty equipment. There are four peasants trying to cook old moldy food. The peasants are non-aggressive and will not engage in combat with you except in retaliation.";

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
                returnData.Description = "A small kitchen with old rusty equipment. There are four peasants slaughtered with their blood pouring into the food.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetLoungingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void KitchenPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_KITCHEN_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
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

        #region Stairs

        public Location LoadStairs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Stairs";
            returnData.Description = "A small narrow stair case. There are individual stairs that are either missing or that have holes in them.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouSeedyInn.GetTownInstance().GetBasementLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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

        #region BasementLanding

        public Location LoadBasementLanding()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Basement Landing";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_BASEMENT_LANDING_BANDITS));
            
            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A small landing at the stairs. There are several bandits waiting to greet you.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += BasementLandingBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small landing at the stairs. There are several dead bandits on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouSeedyInn.GetTownInstance().GetStorageDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BasementLandingBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_BASEMENT_LANDING_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BASEMENT_LANDING_KEY);

            }
        }

        public LocationDefinition GetBasementLandingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BASEMENT_LANDING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Basement Landing";
                returnData.DoLoadLocation = LoadBasementLanding;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage

        public Location LoadStorage()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_STORAGE_BANDITS));
            
            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A small room with shabby boxes. There are two bandits sorting through them.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandits = new List<Mob>();
                bandits.Add(new Bandit());
                bandits.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandits);
                combatAction.PostCombat += StorageBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room with shabby boxes. There are two decapitated bandits with their heads in the boxes they were looking through.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetBasementLandingDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouSeedyInn.GetTownInstance().GetTortureChamberDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void StorageBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.DEFEATED_STORAGE_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(STORAGE_KEY);

            }
        }

        public LocationDefinition GetStorageDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage";
                returnData.DoLoadLocation = LoadStorage;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Torture Chamber

        public Location LoadTortureChamber()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Torture Chamber";
            bool defeatedBanditTorturer = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.KILLED_BANDIT_TORTURER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.TOOK_TREASURE));
            bool takeLetters = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.TOOK_NOTES_OF_PAYMENT));
            string banditSpeechBefore = "Welcome, " + GameState.Hero.Identifier + ". You're the new guest of honor. I hope you like my work here, you'll be my new canvas after all. What do you say we get to know each other, you look a tad uncomfortable.";
            string banditSpeechAfter = "The Bandit Torturer's dead body falls to the ground and you feel a profound sense of relief knowing the world has been rid of this evil being.";
            
            //Actions
            if (!defeatedBanditTorturer)
            {
                returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is what can only be the Bandit Torturer.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> torturer = new List<Mob>();
                torturer.Add(new BanditTorturer());
                CombatAction combatAction = new CombatAction("Badnit Torturer", torturer, banditSpeechBefore, banditSpeechAfter);
                combatAction.PostCombat += DefeatedBanditTorturer;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedBanditTorturer)
            {
                if (!openedChest)
                {
                    if (!takeLetters)
                        returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is the dead body of the Bandit Torturer. There are notes signifying his payment for his work from a necromancer in his pocket. And there is an unopened chest in the corner of the room.";
                    else
                        returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is the dead body of the Bandit Torturer. There is an unopened chest in the corner of the room.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += TorturerChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeLetters)
                    returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is the dead body of the Bandit Torturer. There is an opened chest in the corner of the room.";
                if (!takeLetters && openedChest)
                {
                    returnData.Description = "A medium sized room painted red with blood. There is blood all over the floor and several dead bodies laying in the corner. There is a freshly dead of a young woman laying on a table in the center of the room. She is nude with several cuts and burns all over her body. Blood is still falling from her wounds. Next to her is the dead body of the Bandit Torturer. There are notes signifying his payment for his work from a necromancer in his pocket. And there is an opened chest in the corner of the room";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Necromancer notes of payment");
                    letterAction.PostItem += Letters;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }
            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouSeedyInn.GetTownInstance().GetStorageDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBanditTorturer && takeLetters)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedBanditTorturer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.KILLED_BANDIT_TORTURER, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(TORTURE_CHAMBER_KEY);

            }
        }

        public void TorturerChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.TOOK_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(TORTURE_CHAMBER_KEY);

            }
        }

        public void Letters(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouSeedyInn.TOOK_NOTES_OF_PAYMENT, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(TORTURE_CHAMBER_KEY);

            }
        }

        public LocationDefinition GetTortureChamberDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TORTURE_CHAMBER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Torture Chamber";
                returnData.DoLoadLocation = LoadTortureChamber;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouSeedyInn _AnkouSeedyInn;

        public static AnkouSeedyInn GetTownInstance()
        {
            if (_AnkouSeedyInn == null)
            {
                _AnkouSeedyInn = new AnkouSeedyInn();
            }

            return _AnkouSeedyInn;
        }

        #endregion
    }
}
