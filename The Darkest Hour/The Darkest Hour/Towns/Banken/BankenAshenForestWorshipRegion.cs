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
    class BankenAshenForestWorshipRegion : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAshenForestWorshipRegion.Entrace";
        public const string STATUE_CLEARING_KEY = "Banken.BankenAshenForestWorshipRegion.SatueClearingKey";
        public const string FLEEING_LOCAL = "Banken.BankenAshenForestWorshipRegion.FleeingLocal";

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
            returnData.Name = "Ashen Forest Path - Worship Region";
            returnData.Description = "You enter the worship region of the Ashen Forest. Many people travel here to pay homage in some kind to whatever Gods they believe in. This is ancient ground, that some believe used to be holy. But now, a dark presence is defiling it. Faint, but there none-the-less.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetStatueClearingDefinition();
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
                returnData.Name = "Ashen Forest Path - Worship Region";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Satue Clearing

        public Location LoadStatueClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Holy Statue Clearing";
            bool fleeingLocal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.FLEEING_LOCAL));

            if (!fleeingLocal)
            {
                returnData.Description = "You enter into a small clearing that has a giant statue placed at the back of it. It is adorned with flowers and personal trinkets from the locals that come here to worship and pray. As you enter, several locals push past you as they rush to flee the area.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Talk to", "fleeing local", "You stop one of the locals as he tries to push past you and demand to know what's going on. He looks at you wide eyed and lets out a strangled, gurgling noise. You put a calming hand on his should and tell him to take a moment and try again.\n\nThe local takes a deep breath then says, ''Dark... darkness... It's all that's left. The dead... Awful... Run. Run now. Run while you still can.''\n\nWith that the local pushes past you and continues his retreat out of the forest. You steal yourself for whatever horrors are beyond this clearing.");
                locationActions.Add(itemAction);
                itemAction.PostItem += TalkToFleeingLocal;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "You enter into a small clearing that has a giant statue placed at the back of it. It is adorned with flowers and personal trinkets from the locals that come here to worship and pray. You can feel darkness emanating from beyond the clearing. Evil awaits.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TalkToFleeingLocal(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.FLEEING_LOCAL, true);

                //Reload
                LocationHandler.ResetLocation(STATUE_CLEARING_KEY);
            }
        }

        public LocationDefinition GetStatueClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STATUE_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Holy Statue Clearing";
                returnData.DoLoadLocation = LoadStatueClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAshenForestWorshipRegion _BankenAshenForestWorshipRegion;

        public static BankenAshenForestWorshipRegion GetTownInstance()
        {
            if (_BankenAshenForestWorshipRegion == null)
            {
                _BankenAshenForestWorshipRegion = new BankenAshenForestWorshipRegion();
            }

            return _BankenAshenForestWorshipRegion;
        }

        #endregion
    }
}
