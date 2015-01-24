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
    class AnkouUndergroundHideOut : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouUndergroundHideOut.Entrance";
        public const string SMALL_PASSAGEWAY_KEY = "Ankou.AnkouUndergroundHideOut.SmallPassageWay";
        public const string KITCHEN_KEY = "Ankou.AnkouUndergroundHideOut.Kitchen";
        public const string CONFERENCE_ROOM_KEY = "Ankou.AnkouUndergroundHideOut.ConferenceRoom";
        public const string STORAGE_KEY = "Ankou.AnkouUndergroundHideOut.Storage";
        public const string DINNING_HALL_KEY = "Ankou.AnkouUndergroundHideOut.DinningHall";
        public const string BARRACKS_KEY = "Ankou.AnkouUndergroundHideOut.Barracks";
        public const string OVERSEER_QUARTERS_KEY = "Ankou.AnkouUndergroundHideOut.OverseerQuarters";
        public const string DEFEATED_SMALL_PASSAGEWAY_BANDITS = "Ankou.AnkouUndergroundHideOut.DefeateSmallPassagewayBandits";
        public const string DEFEATED_KITCHEN_MOBS = "Ankou.AnkouUndergroundHideOut.DeefeatedKitchenMobs";
        public const string DEFEATED_CONFERENCE_ROOM_MOBS = "Ankou.AnkouUndergroundHideOut.DefeatedConferenceRoomMobs";
        public const string TOOK_STORAGE_TREASURE = "Ankou.AnkouUndergroundHideOut.TookStorageTreasure";
        public const string DEFEATED_DINNING_HALL_MOBS = "Ankou.AnkouUndergroundHideOut.DefeatedDinningHallMobs";
        public const string DEFEATED_BARRACKS_GUARDS = "Ankou.AnkouUndergroundHideOut.DefeatedBarracksGuards";
        public const string KILLED_NECRO_OVERSEER = "Ankou.AnkouUndergroundHideOut.KilledNecroOverseer";
        public const string TOOK_NECRO_OVERSEER_TREASURE = "Ankou.AnkouUndergroundHideOut.TookNecroOverseerTreasure";
        public const string TOOK_JOURNAL = "Ankou.AnkouUndergroundHideOut.TookJournal";

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
            returnData.Name = "Underground Hideout";
            returnData.Description = "A small trap door opens to an underground hideout. The entrance to the hideout feels like an underground cave, with everything dirt. There are torches lining the walls to give light to the entrance.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditShack.GetTownInstance().GetBufferRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetSmallPassageWayDefinition();
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
                returnData.Name = "Underground Hideout";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Pasageway

        public Location LoadSmallPassageway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Passageway";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_SMALL_PASSAGEWAY_BANDITS));
            
            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A small passageway. The hideout is no longer made of dirty like the entrance was, it is now made of wood and brick. Two bandits stand guard to further access within the hideout.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandit = new List<Mob>();
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandit);
                combatAction.PostCombat += PassageWayBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small passageway. The hideout is no longer made of dirty like the entrance was, it is now made of wood and brick. Two bandits lay dead on the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void PassageWayBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_SMALL_PASSAGEWAY_BANDITS, true);

                // Reload
                LocationHandler.ResetLocation(SMALL_PASSAGEWAY_KEY);

            }
        }

        public LocationDefinition GetSmallPassageWayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_PASSAGEWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Passageway";
                returnData.DoLoadLocation = LoadSmallPassageway;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_KITCHEN_MOBS));
            
            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A nicely sized kitchen. There are two bandits and two peasants they captured and enslaved working on meals for the rest of the people in the hideout.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Peasant());
                mobs.Add(new Peasant());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits and Peasants", mobs);
                combatAction.PostCombat += KitchenMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A nicely sized kitchen. There are four dead people with their bload acting as sausce for the food they were cooking.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetSmallPassageWayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void KitchenMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_KITCHEN_MOBS, true);

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

        #region Confernce Room

        public Location LoadConferenceRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Conference Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_CONFERENCE_ROOM_MOBS));
            
            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A large conference room with a large round table in the middle of the room. There are several bandits and nobles sitting around it, discussing their strategy for moving forward.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Bandit());
                mob.Add(new Noble());
                mob.Add(new Noble());
                mob.Add(new Bandit());
                mob.Add(new Noble());
                mob.Add(new Noble());
                mob.Add(new Bandit());
                mob.Add(new Bandit());
                mob.Add(new Bandit());
                mob.Add(new Noble());
                CombatAction combatAction = new CombatAction("Bandits and Nobles", mob);
                combatAction.PostCombat += ConferenceRoomMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large conference room with a large round table in the middle of the room. There are several bandits and nobles slaughtered upon the table, whatever strategy they were discussing now worthless.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetSmallPassageWayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetStorageDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ConferenceRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_CONFERENCE_ROOM_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(CONFERENCE_ROOM_KEY);

            }
        }

        public LocationDefinition GetConferenceRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CONFERENCE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Conference Room";
                returnData.DoLoadLocation = LoadConferenceRoom;

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
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_STORAGE_TREASURE));
            returnData.Description = "A small room used for storage. There is a treasure chest in against the back wall of the room.";

            //Actions
            if (!openedChest)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(2);
                locationActions.Add(itemAction);
                itemAction.PostItem += StorageChest;
                returnData.Actions = locationActions;
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void StorageChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_STORAGE_TREASURE, true);

                // Reload
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

        #region Dinning Hall

        public Location LoadDinningHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dinning Hall";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_DINNING_HALL_MOBS));
            
            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A large dinning hall meant to feed large groups of people. There are sevearl tables throughout the room. There's a dozen people eating, an even mix of bandits and nobles.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Bandit());
                mob.Add(new Noble());
                mob.Add(new Noble());
                mob.Add(new Bandit());
                mob.Add(new Noble());
                mob.Add(new Bandit());
                mob.Add(new Noble());
                mob.Add(new Noble());
                mob.Add(new Bandit());
                mob.Add(new Bandit());
                mob.Add(new Bandit());
                mob.Add(new Noble());
                CombatAction combatAction = new CombatAction("Bandits and Nobles", mob);
                combatAction.PostCombat += DinningHallMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large dinning hall meant to feed large groups of people. There are sevearl tables throughout the room. There's a dozen dead people laying with their blood coating their food.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetBarracksDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetOverseersQuartersDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DinningHallMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_DINNING_HALL_MOBS, true);

                // Reload
                LocationHandler.ResetLocation(DINNING_HALL_KEY);

            }
        }

        public LocationDefinition GetDinningHallDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DINNING_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dinning Hall";
                returnData.DoLoadLocation = LoadDinningHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Barracks

        public Location LoadBarracks()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Barracks";
            bool defeatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_BARRACKS_GUARDS));
            
            //Actions
            if (!defeatedGuards)
            {
                returnData.Description = "There are several pieces of weapons and armor hanging from the walls. There are four guards the nobles brought with them sitting down on at one of the tables playing a card game to pass time.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guard = new List<Mob>();
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                guard.Add(new Guard());
                CombatAction combatAction = new CombatAction("Guards", guard);
                combatAction.PostCombat += BarracksGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "There are several pieces of weapons and armor hanging from the walls. There are four dead guards slaughtered, there card game long forever forgotten.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void BarracksGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.DEFEATED_BARRACKS_GUARDS, true);

                // Reload
                LocationHandler.ResetLocation(BARRACKS_KEY);

            }
        }

        public LocationDefinition GetBarracksDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BARRACKS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Barracks";
                returnData.DoLoadLocation = LoadBarracks;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Overseer's Quarters

        public Location LoadOverseersQuarters()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Overseer's Quarters";
            bool defeatedOverseer = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.KILLED_NECRO_OVERSEER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_NECRO_OVERSEER_TREASURE));
            bool tookJournal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_JOURNAL));
            string overseerSpeechBefore = "Don't try to sneak up on me, I heard you come in. Tell me," + GameState.Hero.Identifier + ", how did you find this place? You know what, it doesn't really matter now does it. Your life ends here anyway.";
            string overseerSpeechAfter = "The Necromancer Overseer stumbles, his face drained of all color after his fight with you. You jump forward and grab his sword and impale him with it. He gasp once then collapse to the ground.";

            //Actions
            if (!defeatedOverseer)
            {
                returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He is sitting at his desk scribbling away in his journal, his back turned away from the door.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> overseer = new List<Mob>();
                overseer.Add(new NecroOverseer());
                CombatAction combatAction = new CombatAction("Necromancer Overseer", overseer, overseerSpeechBefore, overseerSpeechAfter);
                combatAction.PostCombat += DefeatedOverseer;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedOverseer)
            {
                if (!openedChest)
                {
                    if (!tookJournal)
                        returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He lays dead in the center of the floor. The journal he was writing in lays on the desk. There is an unopened chest beneath the desk.";
                    else
                        returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He lays dead in the center of the floor. There is an unopened chest beneath the desk.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(4);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += OverseerChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && tookJournal)
                    returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He lays dead in the center of the floor. There is an opened chest beneath the desk.";
                if (!tookJournal && openedChest)
                {
                    returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He lays dead in the center of the floor. The journal he was writing in lays on the desk. There is an opened chest beneath the desk.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction takeJournalAction = new TakeItemAction("Journal");
                    takeJournalAction.PostItem += TookJournal;
                    locationActions.Add(takeJournalAction);
                    returnData.Actions = locationActions;
                }
            }

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedOverseer && tookJournal)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedOverseer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.KILLED_NECRO_OVERSEER, true);

                // Reload
                LocationHandler.ResetLocation(OVERSEER_QUARTERS_KEY);

            }
        }

        public void OverseerChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_NECRO_OVERSEER_TREASURE, true);

                // Reload
                LocationHandler.ResetLocation(OVERSEER_QUARTERS_KEY);

            }
        }

        public void TookJournal(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundHideOut.TOOK_JOURNAL, true);

                // Reload
                LocationHandler.ResetLocation(OVERSEER_QUARTERS_KEY);

            }
        }

        public LocationDefinition GetOverseersQuartersDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = OVERSEER_QUARTERS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Overseer's Quarters";
                returnData.DoLoadLocation = LoadOverseersQuarters;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouUndergroundHideOut _AnkouUndergroundHideOut;

        public static AnkouUndergroundHideOut GetTownInstance()
        {
            if (_AnkouUndergroundHideOut == null)
            {
                _AnkouUndergroundHideOut = new AnkouUndergroundHideOut();
            }

            return _AnkouUndergroundHideOut;
        }

        #endregion
    }
}