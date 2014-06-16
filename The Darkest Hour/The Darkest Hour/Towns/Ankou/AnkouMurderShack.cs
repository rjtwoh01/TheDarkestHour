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
    class AnkouMurderShack : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouMurderShack.Entrance";
        public const string ROOM_TWO_KEY = "Ankou.AnkouMurderShack.RoomTwo";
        public const string HALLWAY_KEY = "Ankou.AnkouMurderShack.Hallway";
        public const string DINNING_ROOM_KEY = "Ankou.AnkouMurderShack.DinningRoom";
        public const string MASTER_ROOM_KEY = "Ankou.AnkouMurderShack.MasterRoom";
        public const string DEFEATED_STORAGE_ROOM_PEASANTS = "Ankou.AnkouMurderShack.DefeatedStorageRoomPeasants";
        public const string DEFEATED_HALLWAY_PEASANTS = "Ankou.AnkouMurderShack.DefeatedHallwayPeasants";
        public const string DEFEATED_DINNING_ROOM_GUARDS = "Ankou.AnkouMurderShack.DefeatedDinningRoomGuards";
        public const string DEFEATED_SCUMMY_MURDERER = "Ankou.AnkouMurderShack.DefeatedScummyMurderer";
        public const string OPENED_CHEST = "Ankou.AnkouMurderShack.OpenedChest";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadMurderShackEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Murderer's Shack";
            returnData.Description = "The room appears as if it is falling aprt. The walls are coming undone and there are giant holes in the ceiling.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouMurderShack.GetTownInstance().GetStorageRoomDefinition();
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
                returnData.Name = "Murderer's Shack";
                returnData.DoLoadLocation = LoadMurderShackEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage Room

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_STORAGE_ROOM_PEASANTS));

            if (!defeatedPeasants)
            {
                returnData.Description = "The room is full of large stacks of boxes. There are several of the town's peasants armed with shabby swords working inventory.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> peasants = new List<Mob>();
                peasants.Add(new Peasant());
                peasants.Add(new Peasant());
                peasants.Add(new Peasant());
                peasants.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", peasants);
                combatAction.PostCombat += StorageRoomPeasants;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedPeasants)
                returnData.Description = "The room is full of large stacks of boxes. The peasant's bodies are strewn across several of the boxes.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouMurderShack.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPeasants)
            {
                locationDefinition = AnkouMurderShack.GetTownInstance().GetHallwayDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void StorageRoomPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_STORAGE_ROOM_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(ROOM_TWO_KEY);

            }
        }

        public LocationDefinition GetStorageRoomDefinition()
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
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadStorageRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Hallway

        public Location LoadHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hallway";
            bool defeatedPeasants = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_HALLWAY_PEASANTS));

            if (!defeatedPeasants)
            {
                returnData.Description = "A rather wide but short hallway with two poorly armed peasants patrolling it.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> peasants = new List<Mob>();
                peasants.Add(new Peasant());
                peasants.Add(new Peasant());
                CombatAction combatAction = new CombatAction("Peasants", peasants);
                combatAction.PostCombat += HallwayPeasants;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedPeasants)
                returnData.Description = "A rather wide but short hallway. Two bloodied bodies lay crumpled on the floor.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouMurderShack.GetTownInstance().GetStorageRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedPeasants)
            {
                locationDefinition = AnkouMurderShack.GetTownInstance().GetDinningRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void HallwayPeasants(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_HALLWAY_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(HALLWAY_KEY);

            }
        }

        public LocationDefinition GetHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dinning Room

        public Location LoadDinningRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dinning Room";
            bool defatedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_DINNING_ROOM_GUARDS));

            if (!defatedGuards)
            {
                returnData.Description = "A medium sized room with several tables and plates scattered about. There is food laying about, ready to be cooked. There are both peasants and bandits guarding the room.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> guards = new List<Mob>();
                guards.Add(new Peasant());
                guards.Add(new Peasant());
                guards.Add(new Peasant());
                guards.Add(new Peasant());
                guards.Add(new Bandit());
                guards.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Guards", guards);
                combatAction.PostCombat += DinningRoomGuards;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defatedGuards)
                returnData.Description = "A medium sized room with several tables and plates scattered about. There is food laying about, ready to be cooked. The goblets are full of the blood of the dead gaurds.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouMurderShack.GetTownInstance().GetHallwayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defatedGuards)
            {
                locationDefinition = AnkouMurderShack.GetTownInstance().GetMasterRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DinningRoomGuards(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_DINNING_ROOM_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DINNING_ROOM_KEY);

            }
        }

        public LocationDefinition GetDinningRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DINNING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dinning Room";
                returnData.DoLoadLocation = LoadDinningRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Master Room

        public Location LoadMasterRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Master Room";
            bool defeatedScummyMurderer = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_SCUMMY_MURDERER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.OPENED_CHEST));

            if (!defeatedScummyMurderer)
            {
                returnData.Description = "A large room with a torn up bed in the corner. The Scummy Murderer is sitting on the bed, staring at the door.";

                //Actions
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> scummyMurderer = new List<Mob>();
                scummyMurderer.Add(new ScummyMurderer());
                CombatAction combatAction = new CombatAction("Scummy Murderer", scummyMurderer);
                combatAction.PostCombat += ScummyMurderer;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            if (defeatedScummyMurderer)
            {
                if (!openedChest)
                {
                    returnData.Description = "A large room with a torn up bed in the corner. There is a chest at the front of the bed waiting to be opened. The Scummy Murderer's body lays mangled and strewn across his bed.";
                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(3);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += Chest;
                    returnData.Actions = locationActions;
                }
                else
                    returnData.Description = "A medium sized room with several tables and plates scattered about. There is an open chest at the front of the bed. The Scummy Murderer's body lays mangled and strewn across his bed.";
            }

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouMurderShack.GetTownInstance().GetDinningRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedScummyMurderer)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void ScummyMurderer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_DINNING_ROOM_GUARDS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(MASTER_ROOM_KEY);

            }
        }

        public void Chest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.OPENED_CHEST, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(MASTER_ROOM_KEY);

            }
        }

        public LocationDefinition GetMasterRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MASTER_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Master Room";
                returnData.DoLoadLocation = LoadDinningRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouMurderShack _AnkouMurderShack;

        public static AnkouMurderShack GetTownInstance()
        {
            if (_AnkouMurderShack == null)
            {
                _AnkouMurderShack = new AnkouMurderShack();
            }

            return _AnkouMurderShack;
        }

        #endregion
    }
}
