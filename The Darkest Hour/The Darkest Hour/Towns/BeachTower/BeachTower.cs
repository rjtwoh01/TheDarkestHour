using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters;

namespace The_Darkest_Hour.Towns.Watertown
{
    class BeachTower : Town
    {
        #region Location Keys

        public const string ARENA_KEY = "BeachTower.Arena";
        public const string TOWN_CENTER_KEY = "BeachTower.TownCenter";
        public const string INN_KEY = "BeachTower.Inn";
        public const string CAPTAIN_OFFICE_KEY = "BeachTower.Captainoffice";

        public const string LOCATION_STATE_KEY = "Beach Tower";
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
            returnData.Name = "Beach Tower Arena";
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
                returnData.Name = "Beach Tower Arena";
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
            returnData.Name = "Beach Tower Inn";
            returnData.Description = "You belly up to the bar!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction;

            locationAction = new RestAction(5);
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
                returnData.Name = "Beach Tower Inn";
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
            returnData.Name = "Beach Tower Main Floor";
            returnData.Description = "Welcome to the main floor of the Beach Tower.";

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

            locationDefinition = GetCaptainOfficeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment beachHeadPirates = BeachTower.GetBeachTowerAccomplishments().Find(x => x.Name.Contains("Beach Head Pirates"));
            if (GameState.Hero.Accomplishments.Contains(beachHeadPirates))
            {
                locationDefinition = BeachHead.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
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
                returnData.Name = "Beach Tower Main Floor";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            if (GameState.Hero.startingLocation != "Beach Tower")
            {
                GameState.Hero.startingLocation = "Beach Tower";
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);
            }

            return returnData;
        }
        #endregion

        #region Captain Office
        
        public Location LoadCaptainOffice()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Captain's Office";
            returnData.Description = "A small cramped office on the top floor of the tower. The walls are lined with maps that have several markings on them and what looks like troop movements documented. Several areas surrounding the tower are circled in different colors.";

            //Locatio Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            //Adding rumors from Captain in teh Captain Office
            LocationAction CaptainRumorAction = new RumorAction("Mike - Captain of the Guard", this.CaptainRumors);
            locationActions.Add(CaptainRumorAction);
            returnData.Actions = locationActions;

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();
            LocationDefinition locationDefinition = GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetCaptainOfficeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CAPTAIN_OFFICE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Captain's Office";
                returnData.DoLoadLocation = LoadCaptainOffice;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Rumors

        private List<Rumor> CaptainRumors
        {
            get
            {
                List<Rumor> returnData = new List<Rumor>();
                Rumor rumor;

                //Bool's to check if the player has completed certain parts of the game
                bool killedBeachHeadPirates = false; //Need to change this bool's name. This is just a placeholder

                if (!killedBeachHeadPirates)
                {
                    rumor = new Rumor("Beach Head Pirates", "Hey, welcome to our humble little tower here. There's a lot of bad stuff that comes in from the sea and we're the first line of defence against the madness. Unfortunately due to everything that's been going on all over Ankou, we've been short staffed. There's a group of pirates that have been terrorizing people who leave Ankou waters for years, but now they've taken landing on the beach head and assualt anyone that tries to go out there and just enjoy a nice day. This is something that has to stop. People are losing faith in our forces and not without reason. I don't have the men power to put a stop to this. It's hard enough to protect the village up ahead, let alone the whole coastal area like I'm supposed to. Why don't you go out and clean up the pirate mess, and then we can see where to go from there.");
                    rumor.OnHeardRumor = this.HeardBeachHeadPiratesRumor;
                }
                else
                    rumor = new Rumor("You want something?", "You want something?");

                returnData.Add(rumor);
                return returnData;
            }
        }

        public void HeardBeachHeadPiratesRumor()
        {
            Accomplishment accomplishment = BeachTower.GetBeachTowerAccomplishments().Find(x => x.Name.Contains("Beach Head Pirates"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the area to Complete the Task that the Task is in
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        #endregion

        #region Accomplishments

        public static Accomplishments _BeachTowerAccomplishments;
        public static Accomplishments GetBeachTowerAccomplishments()
        {
            if (_BeachTowerAccomplishments == null)
            {
                _BeachTowerAccomplishments = new Accomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Beach Tower";
                accomplishment.Name = "Has heard the rumor of Beach Head Pirates";
                accomplishment.Description = "Has heard the rumor of the Beach Head Pirates that took up refuge on the beach head and terrorize anyone that visits the area.";
                _BeachTowerAccomplishments.Add(accomplishment);
            }

            return _BeachTowerAccomplishments;
        }

        #endregion

        #region Get Town Instance

        private static BeachTower _BeachTower;

        public static BeachTower GetTownInstance()
        {
            if (_BeachTower == null)
            {
                _BeachTower = new BeachTower();
            }

            return _BeachTower;
        }
        #endregion
    }
}