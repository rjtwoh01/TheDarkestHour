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
    class Watertown : Town
    {

        #region Instance Properties and Methods
        private Location _Arena;
        private Location _TownCenter;
        private Location _Inn;
        private List<Rumor> _InnKeepersRumors;
        private List<Rumor> _InnGuestRomors;

        private List<Rumor> InnKeepersRumors
        {
            get
            {
                if (_InnKeepersRumors == null)
                {
                    _InnKeepersRumors = new List<Rumor>();

                    Rumor rumor = new Rumor("Sewer King", "There are tales of a Sewer King with hoards of riches and gold.  The entrance to the sewers can be found in the Town Center.");
                    rumor.Accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
                    rumor.OnHeardRumor += this.HeardSewerKingRumor;
                    _InnKeepersRumors.Add(rumor);
                    _InnKeepersRumors.Add(new Rumor("Not Much", "Not much happening around here these days."));
                    _InnKeepersRumors.Add(new Rumor("Stay awhile", "Stay a while and listen to our bard play music and sing songs of great tales."));
                }

                return _InnKeepersRumors;
            }
        }

        private List<Rumor> InnGuestRumors
        {
            get
            {
                if (_InnGuestRomors == null)
                {
                    _InnGuestRomors = new List<Rumor>();

                    Rumor guestRumor = new Rumor("Bandit Captain", "I can't seem to get supplies out of Watertown here. My caravans keep being attacked by a group of bandits. If you're looking for work, you should find and slay their leader. It would do everyone here a great deal of good.");
                    guestRumor.Accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("SBandit Captain"));
                    guestRumor.OnHeardRumor += this.HeardBanditCaptainRumor;
                    _InnGuestRomors.Add(guestRumor);
                    _InnGuestRomors.Add(new Rumor("Life's Hard", "It's hard to make it as a traveling minstrel. Come to think of it, I think it's starting to get close to the time that I need to get moving away from here."));
                    _InnGuestRomors.Add(new Rumor("Riches", "This town may not look it from the outside, but there is a great big market here. You can get plenty rich while here. Lot's of trade."));

                }

                return _InnGuestRomors;
            }
            
        }

        public override Location GetStartingLocation()
        {
            return GetTownCenter();
        }

        public void HeardSewerKingRumor()
        {
            // TODO: need to keep duplicate accomplishments from happening.
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the sewer
            // TODO: this is not working.  Currently, you need to save your character and reload the game for this to work
            // So, just need to handle the memory management a little better so I can easily flush out a cached location.
            _TownCenter = null;
            _TownCenter = GetTownCenter();
        }

        public void HeardBanditCaptainRumor()
        {
            // TODO: Need to keep duplicate accomplishments from happening (SEE ABOVE METHOD)
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Captain"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            //Reload the TownCenter so it will open up the forest
            // TODO: this is not working.  Currently, you need to save your character and reload the game for this to work
            // So, just need to handle the memory management a little better so I can easily flush out a cached location. (COPIED FROM SEWER KING)
            _TownCenter = null;
            _TownCenter = GetTownCenter();
        }

        public Location GetArena()
        {
            Location returnData;

            if (_Arena == null)
            {

                returnData = new Location();
                returnData.Name = "Watertown Arena";
                returnData.Description = "Prepare to Die!";

                _Arena = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                LocationAction locationAction = new ArenaAction();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;


                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _Arena;
            }

            return returnData;
        }

        public Location GetInn()
        {
            Location returnData;

            if (_Inn == null)
            {

                returnData = new Location();
                returnData.Name = "Prancing Pony";
                returnData.Description = "You belly up to the bar!";

                _Inn = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();


                LocationAction locationAction = new RumorAction("Bartender",this.InnKeepersRumors);
                locationActions.Add(locationAction);

                //Adding rumors from guest in the inn
                LocationAction guestLocationAction = new RumorAction("Guest", this.InnGuestRumors);
                locationActions.Add(guestLocationAction);

                locationAction = new SaveAction();
                locationActions.Add(locationAction);

                locationAction = new MainMenuAction();
                locationActions.Add(locationAction);

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetTownCenter());

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _Arena;
            }

            return returnData;
        }

        // TODO: Probably should change the design of the GetTownCenter, etc..
        // to public Get properties as this is exactly how they are operating.
        public Location GetTownCenter()
        {
            Location returnData;
            LocationAction locationAction;

            if (_TownCenter == null)
            {

                returnData = new Location();
                returnData.Name = "Watertown Town Center";
                returnData.Description = "Welcome to the cozy Watertown Town Center.";

                _TownCenter = returnData;

                List<LocationAction> locationActions = new List<LocationAction>();

                locationAction = new DisplayStatsAction();
                locationActions.Add(locationAction);

                locationAction = new DisplayInventoryAction();
                locationActions.Add(locationAction);

                locationAction = new SellItemsAction();
                locationActions.Add(locationAction);

                locationAction = new MainMenuAction();
                locationActions.Add(locationAction);

                locationAction = new ExitGame();
                locationActions.Add(locationAction);

                returnData.Actions = locationActions;

                List<Location> adjacentLocations = new List<Location>();

                adjacentLocations.Add(GetArena());
                adjacentLocations.Add(GetInn());

                Accomplishment sewerKingAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
                if (GameState.Hero.Accomplishments.Contains(sewerKingAccomplishment))
                {
                    adjacentLocations.Add(WatertownSewer.GetTownInstance().GetStartingLocation());
                }
                Accomplishment banditCaptainAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Captain"));
                if (GameState.Hero.Accomplishments.Contains(banditCaptainAccomplishment))
                {
                    adjacentLocations.Add(WaterTownForest.GetTownInstance().GetStartingLocation());
                }

                returnData.AdjacentLocations = adjacentLocations;


            }
            else
            {
                returnData = _TownCenter;
            }


            return returnData;
        }      

        #endregion

        #region Static Properties and Methods
        private static WatertownAccomplishments _WatertownAccomplishments;

        public static WatertownAccomplishments GetWatertownAccomplishments()
        {
            if (_WatertownAccomplishments == null)
            {
                _WatertownAccomplishments = new WatertownAccomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Sewer King Rumor";
                accomplishment.Description = "Has heard the rumor of the sewer king.   Tales of gold and rewards in the Watertown sewer.";
                _WatertownAccomplishments.Add(accomplishment);

                // TODO: Can add more accomplishments here;
            }

            return _WatertownAccomplishments;
        }

        private static Watertown _Watertown;

        public static Watertown GetTownInstance()
        {
            if (_Watertown == null)
            {
                _Watertown = new Watertown();
            }

            return _Watertown;
        }
        #endregion
    }
}
