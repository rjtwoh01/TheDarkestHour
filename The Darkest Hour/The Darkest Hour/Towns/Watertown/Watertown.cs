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
        #region Location Keys

        public const string ARENA_KEY = "Watertown.Arena";
        public const string TOWN_CENTER_KEY = "Watertown.TownCenter";
        public const string INN_KEY = "Watertown.Inn";

        public const string LOCATION_STATE_KEY = "Watertown";
        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetTownCenterDefinition();
        }

        public Location LoadArena()
        {
            Location returnData;
            LocationAction locationAction;

            returnData = new Location();
            returnData.Name = "Watertown Arena";
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
                returnData.Name = "Watertown Arena";
                returnData.DoLoadLocation = LoadArena;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        public Location LoadInn()
        {
            Location returnData;


            returnData = new Location();
            returnData.Name = "Prancing Pony";
            returnData.Description = "You belly up to the bar!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction = new RumorAction("Bartender", this.InnKeepersRumors);
            locationActions.Add(locationAction);

            //Adding rumors from guest in the inn
            LocationAction guestLocationAction = new RumorAction("Guest", this.InnGuestRumors);
            locationActions.Add(guestLocationAction);

            //Adding rumors from constable in the inn
            LocationAction constableLocationAction = new RumorAction("Town Constable", this.ConstableRumors);
            locationActions.Add(constableLocationAction);

            locationAction = new RestAction(5);
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
                returnData.Name = "Prancing Pony";
                returnData.DoLoadLocation = LoadInn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;


        }

        public Location LoadTownCenter()
        {
            Location returnData;
            LocationAction locationAction;


            returnData = new Location();
            returnData.Name = "Watertown Town Center";
            returnData.Description = "Welcome to the cozy Watertown Town Center.";

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

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;
                        
            Accomplishment sewerKingAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            if (GameState.Hero.Accomplishments.Contains(sewerKingAccomplishment))
            {
                locationDefinition = WatertownSewer.GetTownInstance().GetSewerEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            Accomplishment banditCaptainAccomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Captain"));
            if (GameState.Hero.Accomplishments.Contains(banditCaptainAccomplishment))
            {
                locationDefinition = WatertownForest.GetTownInstance().GetForestEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

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
                returnData.Name = "Watertown Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }      

        #endregion

        #region Rumors

        #region Inn Keeper's Rumors

        private List<Rumor> InnKeepersRumors
        {
            get
            {
                List<Rumor> returnData = new List<Rumor>();

                bool visitedSewers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewer.VISITED_SEWER_STATE));
                bool defeatedSewerKing = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewer.DEFEATED_SEWER_KING));
                bool exploredLeft = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerLeft.DEFEATED_OUTLAW_BOSS));
                bool exploredRight = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownSewerRight.DEFEATED_SKELETON_KING));
                bool defeatedNecro = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForestCabin.TOOK_LETTER));
                Rumor rumor;

                if (defeatedSewerKing && !exploredLeft && !exploredRight)
                {
                    rumor = new Rumor("Defeated Sewer King", "Congratulations on defeating that monster! Explore both the left and right hand parts of the sewer from his room. You may find some treasures or some nice piece of info. You can never know.");
                    rumor.OnHeardRumor = this.KilledSewerKingRumor;
                }
                else if (exploredLeft && exploredRight && !defeatedNecro)
                {
                    rumor = new Rumor("Explore the Forest", "A skeleton king you say? That's highly disturbing. Please go to the forest from the exit on the right hand side and investigate some more.");
                    rumor.OnHeardRumor = this.HeardForestSkeletonRumor;
                }
                else if (defeatedNecro)
                {
                    rumor = new Rumor("Killed Necro Leader", "Thanks for bringing me the letter. This is all highly disturbing stuff. We're legally not allowed to look in this letter and we need to send it to Anokki for investigation. So officially your involvement in this matter is over. However, I have a distinct feeling that this is not the case, and you'll be getting far deeper in this mess than anyone could every imagine.");
                    rumor.OnHeardRumor = this.HeardNecroLeaderRumor;
                }
                else if (visitedSewers & !defeatedSewerKing && !exploredLeft && !exploredRight)
                {
                    rumor = new Rumor("Visisted Sewers", "I've heard you've been down to the sewers.  Have you found the Sewer King yet?");
                }
                else if (!visitedSewers && !defeatedSewerKing)
                {
                    rumor = new Rumor("Sewer King", "There are tales of a Sewer King with hoards of riches and gold.  The entrance to the sewers can be found in the Town Center.");
                    rumor.OnHeardRumor = this.HeardSewerKingRumor;
                }
                else
                    rumor = new Rumor("How are you doing", "Hi, how are you doing?");
                
                returnData.Add(rumor);

                returnData.Add(new Rumor("Not Much", "Not much happening around here these days."));
                returnData.Add(new Rumor("Stay awhile", "Stay a while and listen to our bard play music and sing songs of great tales."));
                return returnData;
            }
        }


        public void HeardSewerKingRumor()
        {
            // TODO: need to keep duplicate accomplishments from happening.
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Sewer King"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the sewer
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardForestSkeletonRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Explore the Forest"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the hidden room
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void KilledSewerKingRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Defeated Sewer King"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the hidden room
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardNecroLeaderRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Killed Necro Leader"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the hidden room
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        #endregion

        #region Inn Guest's Rumors
        private List<Rumor> InnGuestRumors
        {
            get
            {
                bool defeatedCaptain = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownForest.DEFEATED_CAPTAIN_STATE));
                bool defeatedLieutenant = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCave.DEFEATED_LIEUTENANT_KEY));
                bool defeatedSupplyCaptain = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY));

                List<Rumor> returnData = new List<Rumor>();

                if (!defeatedCaptain)
                {
                    Rumor guestRumor = new Rumor("Bandit Captain", "I can't seem to get supplies out of Watertown here. My caravans keep being attacked by a group of bandits. If you're looking for work, you should find and slay their leader. It would do everyone here a great deal of good.");
                    guestRumor.OnHeardRumor = this.HeardBanditCaptainRumor;
                    returnData.Add(guestRumor);
                }
                else if (!defeatedLieutenant)
                {
                    Rumor guestRumor = new Rumor("Bandit Cave", "Good, thanks for defeating their captain. However, his right hand man is still out there. Find their cave and and slay the lieutenant.");
                    guestRumor.OnHeardRumor = this.HeardBanditCaveRumor;
                    returnData.Add(guestRumor);
                }
                else
                {
                    Rumor guestRumor = new Rumor("Deeper Cave", "It is such a relief that the bandits are no longer a threat! You know, I've heard rumors that the caves in that forest have many secret and hidden rooms. Maybe you could return to the cave and see if the bandits took advantage of any such room. You may find somethig interesting.");
                    guestRumor.OnHeardRumor = this.HeardHiddenRoomRumor;
                    returnData.Add(guestRumor);
                }
                returnData.Add(new Rumor("Life's Hard", "It's hard to make it as a traveling minstrel. Come to think of it, I think it's starting to get close to the time that I need to get moving away from here."));
                returnData.Add(new Rumor("Riches", "This town may not look it from the outside, but there is a great big market here. You can get plenty rich while here. Lot's of trade."));

                return returnData;
            }
            
        }

        private List<Rumor> ConstableRumors
        {
            get
            {
                bool defeatedSupplyCaptain = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Watertown.LOCATION_STATE_KEY, WatertownBanditCaveDeeper.DEFEATED_BANDIT_SUPPLY_CAPTAIN_KEY));

                List<Rumor> returnData = new List<Rumor>();

                if (defeatedSupplyCaptain)
                {
                    Rumor constablerRumor = new Rumor("Bandit Murder", "So you discovered a crime scene? This will take some serious investigating. Bandits don't usually turn on eachother, so if they did that's worrisome. And if it's a law abiding citizen we need to know. Come back to me later, I may have a plan of action then. THIS QUEST CHAIN IS NOT COMPLETE. WILL BE CONTINUED IN LATER ALPHA PATCHES.");
                    constablerRumor.OnHeardRumor = this.HeardBanditCaptainRumor;
                    returnData.Add(constablerRumor);
                }
                returnData.Add(new Rumor("Look Out", "If you see any crime, please report it to me."));
                returnData.Add(new Rumor("Need Anything", "If you need anything, just shout. I'll help however I can."));

                return returnData;
            }
            
        }

        public void HeardBanditCaptainRumor()
        {
            // TODO: Need to keep duplicate accomplishments from happening (SEE ABOVE METHOD)
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Captain"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the forest
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardBanditCaveRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Cave"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the cave
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardHiddenRoomRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Hidden Room"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the hidden room
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardMurderRumor()
        {
            Accomplishment accomplishment = Watertown.GetWatertownAccomplishments().Find(x => x.Name.Contains("Bandit Murder"));
            GameState.Hero.Accomplishments.Add(accomplishment);

            // Reload the TownCenter so it will open up the hidden room
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        #endregion

        #endregion

        #region Accomplishments
        private static Accomplishments _WatertownAccomplishments;

        public static Accomplishments GetWatertownAccomplishments()
        {
            if (_WatertownAccomplishments == null)
            {
                _WatertownAccomplishments = new Accomplishments();

                Accomplishment accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Sewer King Rumor";
                accomplishment.Description = "Has heard the rumor of the sewer king.   Tales of gold and rewards in the Watertown sewer.";
                _WatertownAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Bandit Captain Rumor";
                accomplishment.Description = "Has heard the rumor of the bandit cave.";
                _WatertownAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard the Hidden Room Rumor";
                accomplishment.Description = "Has heard the rumor of the bandit hidden room.";
                _WatertownAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has Heard Bandit Murder Rumor";
                accomplishment.Description = "Has heard the rumor of the bandit murder.";
                _WatertownAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has heard rumor of Explore the Forest";
                accomplishment.Description = "Has heard the rumor of exploring the forest off the sewer.";
                _WatertownAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Watertown";
                accomplishment.Name = "Has heard rumor Defeated Sewer King";
                accomplishment.Description = "Has heard the rumor of Defeated Sewer King.";
                _WatertownAccomplishments.Add(accomplishment);

                // TODO: Can add more accomplishments here;
            }

            return _WatertownAccomplishments;
        }

#endregion

        #region Get Town Instance

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
