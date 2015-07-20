using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Towns.Watertown;

namespace The_Darkest_Hour.Towns.Watertown
{
    class Banken : Town
    {
        #region Location Keys

        public const string ARENA_KEY = "Banken.Arena";
        public const string TOWN_CENTER_KEY = "Banken.TownCenter";
        public const string INN_KEY = "Banken.Inn";
        public const string WAR_COUNCIL_KEY = "Banken.WarCouncil";
        public const string LOCATION_STATE_KEY = "Banken";

        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetTownCenterDefinition();
        }

        #region Arena
        public Location LoadArena()
        {
            Location returnData;
            LocationAction locationAction;

            returnData = new Location();
            returnData.Name = "Banken Arena";
            returnData.Description = "Prepare to Die!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            locationAction = new ArenaAction();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetArenaDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = ARENA_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Banken Arena";
                returnData.DoLoadLocation = LoadArena;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Inn
        public Location LoadInn()
        {
            Location returnData;


            returnData = new Location();
            returnData.Name = "Banken Inn";
            returnData.Description = "You belly up to the bar!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction;

            locationAction = new RestAction(100);
            locationActions.Add(locationAction);

            locationAction = new BuyTravelRation();
            locationActions.Add(locationAction);

            locationAction = new SaveAction();
            locationActions.Add(locationAction);

            locationAction = new MainMenuAction();
            locationActions.Add(locationAction);

            locationAction = new ExitGame();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetInnDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = INN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Banken Inn";
                returnData.DoLoadLocation = LoadInn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #region Town Center
        public Location LoadTownCenter()
        {
            Location returnData;
            LocationAction locationAction;


            returnData = new Location();
            returnData.Name = "Banken";
            returnData.Description = "The small town of Banken, located in the middle of the Ashen Forest. There are several wooden buildings throughout the town. The town is mainly populated by Forest Rangers, but there are some civilians living there as well.";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            locationAction = new DisplayStatsAction();
            locationActions.Add(locationAction);

            locationAction = new DisplayInventoryAction();
            locationActions.Add(locationAction);

            locationAction = new DisplayEquippedAction();
            locationActions.Add(locationAction);

            locationAction = new AffixSwapperAction();
            locationActions.Add(locationAction);

            locationAction = new StoreAction();
            locationActions.Add(locationAction);

            locationAction = new MainMenuAction();
            locationActions.Add(locationAction);

            locationAction = new ExitGame();
            locationActions.Add(locationAction);

            returnData.Actions = locationActions;



            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetArenaDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = GetInnDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = GetWarCouncilDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment investigateShrine = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Investigate Religious Shrine"));
            if (GameState.Hero.Accomplishments.Contains(investigateShrine))
            {
                locationDefinition = BankenAshenForest.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        // TODO: Probably should change the design of the GetTownCenter, etc..
        // to public Get properties as this is exactly how they are operating.
        public LocationDefinition GetTownCenterDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_CENTER_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Banken";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            if (GameState.Hero.startingLocation != "Banken")
            {
                GameState.Hero.startingLocation = "Banken";
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);
            }

            return returnData;
        }
        #endregion

        #region War Council
        public Location LoadWarCouncil()
        {
            Location returnData;


            returnData = new Location();
            returnData.Name = "Banken War Council";
            returnData.Description = "One of the largest buildings in the town, the War Council resides in a large room with a circular table residing in the center. On the table there are various maps and strategies scattered about it. Gildan sits at the head of the table. You take one of the few open seats.";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction GildanRumorAction = new RumorAction("Gildan - Head of the Ranger War Council", this.GildanRumors);
            locationActions.Add(GildanRumorAction);
            returnData.Actions = locationActions;

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetWarCouncilDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = WAR_COUNCIL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Banken War Council";
                returnData.DoLoadLocation = LoadWarCouncil;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }
        #endregion

        #endregion

        #region Rumors

        private List<Rumor> GildanRumors
        {
            get
            {
                List<Rumor> returnData = new List<Rumor>();
                Rumor rumor;

                //Bool's to check if the player has completed certain parts of the game
                bool quest = false;
                if (!quest)
                {
                    rumor = new Rumor("Investigate Religious Shrine", "Welcome to Banken, " + GameState.Hero.Identifier + ". It seems you have accomplished quite a lot in the recent months. Impressive. It seems as if darkness is plauging all of Asku at the moment, and it troubles me. The Ashen Forest wasn't named out of random. It is the job of my Rangers to keep the darkness at bay. However, its becoming more and more apparent that, that's something that we can't do by ourselves anymore. We need help. I have a task for you. There is a religious shrine about a mile outside of the town, in a small clearing in the forest. People regularly travel there to pay their worship to the Gods. However, as of late they have been coming back pale and shaken. Unwilling to speak of what happened. I feel as if something evil has taken root at or near the shrine. My Rangers are spread thin at the moment. Can you go investigate for me? Do what you have to do.");
                    rumor.OnHeardRumor = this.HeardInvestigateReligiousShrineRumor;
                }
                else
                    rumor = new Rumor("You want something?", "You want something?");

                returnData.Add(rumor);
                return returnData;
            }
        }

        public void HeardInvestigateReligiousShrineRumor()
        {
            Accomplishment accomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Investigate Religious Shrine"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the area to Complete the Task that the Task is in
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        #endregion

        #region Accomplishments

        public static Accomplishments _BankenAccomplishments;
        public static Accomplishments GetBankenAccomplishments()
        {
            if (_BankenAccomplishments == null)
            {
                _BankenAccomplishments = new Accomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Banken";
                accomplishment.Name = "Has heard the rumor of Investigate Religious Shrine";
                accomplishment.Description = "Has heard the rumor of traveling to the small forest clearing a mile out of Banken and Investigate Religious Shrine";
                _BankenAccomplishments.Add(accomplishment);
            }

            return _BankenAccomplishments;
        }

        #endregion

        #region Get Town Instance

        private static Banken _Banken;

        public static Banken GetTownInstance()
        {
            if (_Banken == null)
            {
                _Banken = new Banken();
            }

            return _Banken;
        }
        #endregion
    }
}
