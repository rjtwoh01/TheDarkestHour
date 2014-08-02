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
            returnData.Description = "A small passageway. The hideout is no longer made of dirty like the entrance was, it is now made of wood and brick. Two bandits stand guard to further access within the hideout.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A nicely sized kitchen. There are two bandits and two peasants they captured and enslaved working on meals for the rest of the people in the hideout.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetSmallPassageWayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A large conference room with a large round table in the middle of the room. There are several bandits and nobles sitting around it, discussing their strategy for moving forward.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetSmallPassageWayDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetStorageDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A small room used for storage. There is a treasure chest in against the back wall of the room.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "A large dinning hall meant to feed large groups of people. There are sevearl tables throughout the room. There's a dozen people eating, an even mix of bandits and nobles.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetConferenceRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetBarracksDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetOverseersQuartersDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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
            returnData.Description = "There are several pieces of weapons and armor hanging from the walls. There are four guards the nobles brought with them sitting down on at one of the tables playing a card game to pass time.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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

        #region Dinning Hall

        public Location LoadOverseersQuarters()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Overseer's Quarters";
            returnData.Description = "A nice large room meant to house the necromancer who was assigned to oversee the operations going on in Ankou. He is sitting at his desk scribbling away in his journal, his back turned away from the door.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundHideOut.GetTownInstance().GetDinningHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
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