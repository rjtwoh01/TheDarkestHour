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
    class BeachTowerBattleForTheSeas : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerBattleForTheSeas.Entrace";
        public const string BLOODIED_BEACH_PATH_KEY = "BeachTower.BeachTowerBattleForTheSeas.BloodiedBeachPath";
        public const string HIGH_BEACH_CLIFF_KEY = "BeachTower.BeachTowerBattleForTheSeas.HighBeachCliff";
        public const string DOCKS_KEY = "BeachTower.BeachTowerBattleForTheSeas.Docks";
        public const string SEA_OVERWATCH_KEY = "BeachTower.BeachTowerBattleForTheSeas.SeaOverwatch";
        public const string ENEMY_BOAT_KEY = "BeachTower.BeachTowerBattleForTheSeas.EnemyBoat";
        public const string CAPTAIN_DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.CaptainDeck";
        public const string HOLE_IN_SHIP_KEY = "BeachTower.BeachTowerBattleForTheSeas.HoleInShip";
        public const string CREW_DINING_AREA_KEY = "BeachTower.BeachTowerBattleForTheSeas.CrewDiningArea";
        public const string STAIRS_KEY = "BeachTower.BeachTowerBattleForTheSeas.Stairs";
        public const string DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.Deck";
        public const string ADMIRAL_DECK_KEY = "BeachTower.BeachTowerBattleForTheSeas.AdmiralDeck";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region First Wing

        #region Entrance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Beach Head";
            returnData.Description = "The air is thick with the scents and sounds of battle. Up ahead the guards of the Beach Tower and invading soldiers clash upon the beach. War has arrived to Asku. It is up to you to stop the invasion before true war begins.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetBloodiedBeachpathDefinition();
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
                returnData.Name = "Beach Head";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bloodied Beach Path

        public Location LoadBloodiedBeachPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bloodied Beach Path";
            returnData.Description = "The beach path is bloodied with war. Soldiers from both sides lay dead or dying on the ground. The air is full of the sounds of war. The clash of metal on metal, the screams of soldiers, the cries of the wounded, and force of magic. Several enemy soldiers block your path forward.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHighBeachCliffDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetBloodiedBeachpathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BLOODIED_BEACH_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bloodied Beach Path";
                returnData.DoLoadLocation = LoadBloodiedBeachPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region High Beach Cliff

        public Location LoadHighBeachCliff()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "High Beach Cliff";
            returnData.Description = "A high cliff on the beach that overlooks the battle raging on. The Land Assault Leader stand ontop of the cliff, watching the battle beneathe him.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetBloodiedBeachpathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDocksDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetHighBeachCliffDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HIGH_BEACH_CLIFF_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "High Beach Cliff";
                returnData.DoLoadLocation = LoadHighBeachCliff;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Docks

        public Location LoadDocks()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Docks";
            returnData.Description = "The docks are just beyond the High Beach Cliff. They extend to the end of the shallow waters. They are currently overrun with enemy soldiers.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHighBeachCliffDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetSeaOverwatchDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDocksDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DOCKS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Docks";
                returnData.DoLoadLocation = LoadDocks;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Sea Overwatch

        public Location LoadSeaOverwatch()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Sea Overwatch";
            returnData.Description = "There is a platform at the end of the docks that is raised high into the air to overlook the seas. The Landing Officer is standing up there, surveying the landing of the enemy for their assault.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDocksDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEnemyBoatDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSeaOverwatchDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SEA_OVERWATCH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Sea Overwatch";
                returnData.DoLoadLocation = LoadSeaOverwatch;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Enemy Boat

        public Location LoadEnemyBoat()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Enemy Boat";
            returnData.Description = "The enemy boat currently docked is a mid sized one. Not all of its crew have left the boat yet to aid in the invasion.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCaptainDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetEnemyBoatDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ENEMY_BOAT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Enemy Boat";
                returnData.DoLoadLocation = LoadEnemyBoat;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Captain's Deck

        public Location LoadCaptainDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Captain's Deck";
            returnData.Description = "The Captain's Deck rest at the right end of the boat. The Captain is currently standing up there.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetEnemyBoatDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHoleInShipDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCaptainDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CAPTAIN_DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Captain's Deck";
                returnData.DoLoadLocation = LoadCaptainDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Second Wing

        #region Hole in Ship

        public Location LoadHoleInShip()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Hole in Lead Assault Ship";
            returnData.Description = "There is a hole in the side of the Lead Assault Ship. Standing gaurd at the newly formed hole is two soldiers.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCaptainDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCrewDiningAreaDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetHoleInShipDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HOLE_IN_SHIP_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Hole in Lead Assault Ship";
                returnData.DoLoadLocation = LoadHoleInShip;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Crew Dinning Area

        public Location LoadCrewDiningArea()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Crew Dinning Area";
            returnData.Description = "Just off of the hole that was blown into the ship is the dinning area of the crew. There are several soldiers and sailors mingling about.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetHoleInShipDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetCrewDiningAreaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CREW_DINING_AREA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Crew Dinning Area";
                returnData.DoLoadLocation = LoadCrewDiningArea;

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
            returnData.Description = "Stairs leading up to the top of the ship. There are several soldiers moving up and down them.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetCrewDiningAreaDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

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

        #region Deck

        public Location LoadDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Deck";
            returnData.Description = "The Deck of the ship is large, with many soldiers and sailors running around on it, doing various things to help the invasion. There are cannons every few feet. This is not a ship to be messed with.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetStairsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetAdmiralDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Deck";
                returnData.DoLoadLocation = LoadDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Admiral's Deck

        public Location LoadAdmiralDeck()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Admiral's Deck";
            returnData.Description = "The Admiral's Deck is on the right side of the ship. The Admiral is standing on the top of it, sailing the ship.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerBattleForTheSeas.GetTownInstance().GetDeckDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetAdmiralDeckDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ADMIRAL_DECK_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Admiral's Deck";
                returnData.DoLoadLocation = LoadAdmiralDeck;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerBattleForTheSeas _BeachTowerBattleForTheSeas;

        public static BeachTowerBattleForTheSeas GetTownInstance()
        {
            if (_BeachTowerBattleForTheSeas == null)
            {
                _BeachTowerBattleForTheSeas = new BeachTowerBattleForTheSeas();
            }

            return _BeachTowerBattleForTheSeas;
        }

        #endregion
    }
}
