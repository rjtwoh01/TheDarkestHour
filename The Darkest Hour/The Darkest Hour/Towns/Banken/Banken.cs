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

            locationAction = new DisplayPotionBagAction();
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
                bool investigateReligiousShrine = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.JOURNAL));
                bool rescueRangers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestRangerPaths.GIANT_SHADOW_DEMON));
                bool ancientBurialGrounds = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAncientBurialGrounds.ACKHAN));
                bool shadeLordDefeated = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenForestWilderness.SHADE_LORD));
                bool recruitMage = false;
                if (!investigateReligiousShrine)
                {
                    rumor = new Rumor("Investigate Religious Shrine", "Welcome to Banken, " + GameState.Hero.Identifier + ". It seems you have accomplished quite a lot in the recent months. Impressive. It seems as if darkness is plauging all of Asku at the moment, and it troubles me. The Ashen Forest wasn't named out of random. It is the job of my Rangers to keep the darkness at bay. However, its becoming more and more apparent that, that's something that we can't do by ourselves anymore. We need help. I have a task for you. There is a religious shrine about a mile outside of the town, in a small clearing in the forest. People regularly travel there to pay their worship to the Gods. However, as of late they have been coming back pale and shaken. Unwilling to speak of what happened. I feel as if something evil has taken root at or near the shrine. My Rangers are spread thin at the moment. Can you go investigate for me? Do what you have to do.");
                    rumor.OnHeardRumor = this.HeardInvestigateReligiousShrineRumor;
                }
                else if (!rescueRangers)
                {
                    rumor = new Rumor("Rescue Rangers", "Thank you for what you did in the worship region. Your tale sounds absolutely awful. I can't believe something like that took root so close to us. Unfortunately we are running very short on rangers. In fact, a large group of our finest went missing while you were in the worship region. We'll study this journal here at the council while you go aide in the search of our missing. You'll find one of our rangers in the wilderness near the beginning of the Ashen Forest. Good luck, " + GameState.Hero.Identifier + ".");
                    rumor.OnHeardRumor = this.HeardRescueRangersRumor;
                }
                else if (!ancientBurialGrounds)
                {
                    rumor = new Rumor("Ancient Burial Grounds", " So you weren't able to find out any more about the missing rangers? I'm not a fan of how this is turning out. There is something dark at work here. Some unseen force of evil... I'll tell you what. There is an ancient burial ground somewhere up to the north. We don't venture near it because of the dark forces that inhabit the area. We just keep it contained. But if that's spreading, the answers to our questions may be found there. Go investigate. Good luck, " + GameState.Hero.Identifier + ".");
                    rumor.OnHeardRumor = this.HeardAncientBurialGroundsRumor;
                }
                else if (!shadeLordDefeated)
                {
                    rumor = new Rumor("Shade Lord", "I have no idea what these tombs are that Ackhan spoke about. I really don't know where to continue looking for these rangers. Go scout the wilderness and see if you can stumble upon anything. Doubtful because of how much nothing there is but one can hope.");
                    rumor.OnHeardRumor = this.HearShadeLordRumor;
                }
                else if (!recruitMage)
                {
                    rumor = new Rumor("Recruit Mage", "So you say the gate is sealed by dark magic? The only thing I can think of is talking to a mage that lives in the forest from time to time. He has a retreat house off the worship region of the forest. If memory servers correctly, its just off the clearing where the shrine is kept. Go there and see if she has any thoughts on how to deal with this.");
                    rumor.OnHeardRumor = this.HeardRecruitMageRumor;
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

        public void HeardRescueRangersRumor()
        {
            Accomplishment accomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Rescue Rangers"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the area to Complete the Task that the Task is in
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardAncientBurialGroundsRumor()
        {
            Accomplishment accomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Ancient Burial Grounds"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the area to Complete the Task that the Task is in
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HearShadeLordRumor()
        {
            Accomplishment accomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Shade Lord"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the area to Complete the Task that the Task is in
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardRecruitMageRumor()
        {
            Accomplishment accomplishment = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Recruit Mage"));
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

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Banken";
                accomplishment.Name = "Has heard the rumor of Rescue Rangers";
                accomplishment.Description = "Has heard the rumor of traveling into the Ashen Forest and Rescue Rangers";
                _BankenAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Banken";
                accomplishment.Name = "Has heard the rumor of Ancient Burial Grounds";
                accomplishment.Description = "Has heard the rumor of traveling into the Ashen Forest and investigating the Ancient Burial grounds which are located someplace in the north.";
                _BankenAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Banken";
                accomplishment.Name = "Has heard the rumor of Shade Lord";
                accomplishment.Description = "Has heard the rumor of traveling into the Ashen Forest going into the wilderness where you will eventually encounter a Shade Lord.";
                _BankenAccomplishments.Add(accomplishment);

                accomplishment = new Accomplishment();
                accomplishment.NameSpace = "Banken";
                accomplishment.Name = "Has heard the rumor of Recruit Mage";
                accomplishment.Description = "Has heard the rumor of traveling into the Ashen forest and finding the mage's retreat house to Recruit Mage.";
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