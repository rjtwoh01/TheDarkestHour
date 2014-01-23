using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters.Mobs;
using The_Darkest_Hour.Characters.Mobs.Bosses;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class WatertownBanditCaveDeeper : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "WatertownBanditCaveDeeper.Entrance";
        public const string READ_PAPER_KEY = "ReadPapers";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetCaveDeeperEntrance();
        }

        #region Entrance

        public Location LoadCaveDeeperEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bandit Cave Hidden Room";
            returnData.Description = "A study lined with bookshelves with a desk in the middle of the room. There are papers scattered about the desk.";
            string paperText = "To whomever it may concern, \nWe were supposed to get a shipment of supplies a week ago! Find out what went wrong! I'll be in \ncontact again if this isn't sorted out...\n";
            bool readPaper = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.READ_PAPER_KEY));

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            ReadPapersAction paperReadAction = new ReadPapersAction(paperText);
            locationActions.Add(paperReadAction);
            paperReadAction.PostPaper += PaperResults;
            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = WatertownBanditCave.GetTownInstance().GetLairDefinition();
            if (readPaper)
            {
                //Add trapdoor
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;

        }

        public void PaperResults(object sender, PaperReadEventArgs paperEventArgs)
        {
            if (paperEventArgs.PaperResults == PaperReadResults.Read)
            {
                LocationHandler.SetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.READ_PAPER_KEY, true);

                // Reload the forest straight path
                LocationHandler.ResetLocation(READ_PAPER_KEY);
            }
        }

        public LocationDefinition GetCaveDeeperEntrance()
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
                returnData.Name = "Bandit Cave Hidden Room";
                returnData.DoLoadLocation = LoadCaveDeeperEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Entrance

        private static WatertownBanditCaveDeeper _WatertownBanditCaveDeeper;

        public static WatertownBanditCaveDeeper GetTownInstance()
        {
            if (_WatertownBanditCaveDeeper == null)
            {
                _WatertownBanditCaveDeeper = new WatertownBanditCaveDeeper();
            }

            return _WatertownBanditCaveDeeper;
        }

        #endregion
    }
}
