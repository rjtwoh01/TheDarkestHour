using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Locations;
using The_Darkest_Hour.Locations.Actions;
using The_Darkest_Hour.Characters;
//using The_Darkest_Hour.Towns.Watertown;

namespace The_Darkest_Hour.Towns.Watertown
{
    class Ankou : Town
    {
        #region Location Keys

        public const string ARENA_KEY = "Ankou.Arena";
        public const string TOWN_CENTER_KEY = "Ankou.TownCenter";
        public const string INN_KEY = "Ankou.Inn";
        public const string CONSTABLE_OFFICE_KEY = "Ankou.ConstableOffice";

        public const string LOCATION_STATE_KEY = "Ankou";
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
            returnData.Name = "Ankou Arena";
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
                returnData.Name = "Ankou Arena";
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
            returnData.Name = "Darkened Inn";
            returnData.Description = "You belly up to the bar!";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            LocationAction locationAction = new RumorAction("Bartender", this.InnKeepersRumors);

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
                returnData.Name = "Darkened Inn";
                returnData.DoLoadLocation = LoadInn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;


        }
        #endregion

        #region Constable Office
        public Location LoadConstableOffice()
        {
            Location returnData;


            returnData = new Location();
            returnData.Name = "Constable Office";
            returnData.Description = "A stuffed and busy office of the town's finest.";

            // Location Actions
            List<LocationAction> locationActions = new List<LocationAction>();

            //Adding rumors from constable in the Constable Office
            LocationAction constableLocationAction = new RumorAction("Krea - Head Investigator", this.ConstableRumors);
            locationActions.Add(constableLocationAction);

            returnData.Actions = locationActions;

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = GetTownCenterDefinition();

            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public LocationDefinition GetConstableOfficeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CONSTABLE_OFFICE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Constable Office";
                returnData.DoLoadLocation = LoadConstableOffice;

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
            returnData.Name = "Ankou Town Center";
            returnData.Description = "Welcome to the cozy Ankou Town Center.";

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

            locationDefinition = GetConstableOfficeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment scummyMurdererMission = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Scummy Murderer"));
            if (GameState.Hero.Accomplishments.Contains(scummyMurdererMission))
            {
                locationDefinition = AnkouMurderShack.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            Accomplishment locateNecroMission = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Locate Necromancers"));
            if (GameState.Hero.Accomplishments.Contains(locateNecroMission))
            {
                locationDefinition = AnkouForest.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            Accomplishment silenceAriean = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Silence Ariean"));
            if (GameState.Hero.Accomplishments.Contains(silenceAriean))
            {
                locationDefinition = AnkouArieansEstate.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            locationDefinition = Watertown.GetTownInstance().GetTownCenterDefinition();
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
                returnData.Name = "Ankou Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

                LocationHandler.AddLocation(returnData);
            }

            if (GameState.Hero.startingLocation != "Ankou")
            {
                GameState.Hero.startingLocation = "Ankou";
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);
            }

            return returnData;
        }
        #endregion

        #endregion

        #region Rumors

        private List<Rumor> InnKeepersRumors
        {
            get
            {
                List<Rumor> returnData = new List<Rumor>();
                Rumor rumor;
                rumor = new Rumor("Hello", "Hey there friend! Fancy a drink? Or some food perhaps? Best place to come for such things on this side of Anokii.");
                returnData.Add(rumor);
                return returnData;
            }
        }

        private List<Rumor> ConstableRumors
        {
            get
            {
                //I'm creating a string for locate necros so I can inset the player's name into the quest text (can't do that within creating the actual rumor).
                string locateNecros = "Thank you so much for ridding us of that problem. That peasant has caused way too many issues. I guess a promise is a promise. Our preliminary intel has indicated that the necromancers have a camp a few miles into the forest surrounding the east side of Ankou. If you can locate them, find out what you can about their group and their plans. Come back once you've got that done and maybe we'll have enough intel to actually make a move on them. It's really unfortnate I can't take care of this right now. Having necromancers this close to my city makes me highly uncomfortable. Oh, and " + GameState.Hero.Identifier + ", try not to get killed. We could use someone like you around here. The longer you decide to stick around the better";

                bool killedMurderer = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouMurderShack.DEFEATED_SCUMMY_MURDERER));
                bool locatedNecromancers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouNecromancerCamp.TOOK_JOURNAL));
                bool silencedAriean = false;
                List<Rumor> returnData = new List<Rumor>();
                Rumor rumor;
                if (!killedMurderer)
                {
                    rumor = new Rumor("Scummy Murderer", "So I see you come in with high regards from the constable office in Watertown. We've caught wind of some necormancer type activities in the area, however, we're too tied up keeping the peasants from starting a revolt against the nobles. But I can't just send you out to hunt them down, you'll need to prove yourself to the others here. Earn some sort of rank and respect before you're able to commander any men or resources we have avaliable. I'll tell you what, there's one mission that could earn you a lot of allies in this place. There was a peasant that murdered an entire noble family, seeking revenge for the way his family was treated. We tried to arrest him, but he's holed up tight in some shack on the edge of town. We think he has armed allies in the shack with him, and that's why we've been apprehensive to approach. But the nobles are breathing down our necks about this issue and we need something done before this confilct escalates anymore. If you can either bring this guy in or kill him, you'll earn a lot of gratitude and favors from those that work here. Then we can talk about getting to the bottom of this necromancer activity.");
                    rumor.OnHeardRumor = this.HeardScummyMurdererRomor;
                }
                else if (killedMurderer && !locatedNecromancers)
                {
                    rumor = new Rumor("Locate Necromancers", locateNecros);
                    rumor.OnHeardRumor = this.HeardLocateNecrosRumor;
                }
                else if (locatedNecromancers && !silencedAriean)
                {
                    rumor = new Rumor("Silence Ariean", "Krae flips through the journal, studying the last few pages intensiley. Finally, she looks up at you and says \"This is highly troubling. Apparently the necromancers are planning to bring a full scale army and raise Ankou to the ground. One of their points of contact in the city is a noblewoman named Ariean. She's always seeemed cold to me, but to turn on us like this...\" She pauses for a second before continuing, \"This combined with the mini war between the peasants and nobles, I fear this city may turn to dust before our very eyes. Please, go find out what you can about Ariean. And if you have to, end her. I'd rather have her alive for questioning, but if she fights back, don't hesitate to kill her. An inside contact with the necromancers is too risky to be left free. Go now, and good luck.\" She turns back to the journal, a clear dismissal.");
                    rumor.OnHeardRumor = this.HeardArieanRumor;
                }
                else
                    rumor = new Rumor("How can I help you?", "You have any crimes to report?");
                returnData.Add(rumor);

                return returnData;
            }
        }

        public void HeardScummyMurdererRomor()
        {
            Accomplishment accomplishment = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Scummy Murderer"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the Shack that the murderer is in.
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardLocateNecrosRumor()
        {
            Accomplishment accomplishment = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Locate Necromancers"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the Forest to go hunt down the necromancer camp
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        public void HeardArieanRumor()
        {
            Accomplishment accomplishment = Ankou.GetAnkouAccomplishments().Find(x => x.Name.Contains("Silence Ariean"));
            GameState.Hero.Accomplishments.Add(accomplishment);
            //Reload the TownCenter so it will open up the Ariean's Estate
            LocationHandler.ResetLocation(TOWN_CENTER_KEY);
        }

        //Add the on heard action for the scummy murderer

        #endregion

        #region Accomplishments

        public static Accomplishments _AnkouAccomplishments;
        public static Accomplishments GetAnkouAccomplishments()
        {
            if (_AnkouAccomplishments == null)
            {
                _AnkouAccomplishments = new Accomplishments();

                Accomplishment accomplishent = new Accomplishment();
                accomplishent.NameSpace = "Ankou";
                accomplishent.Name = "Has heard rumor of the Scummy Murderer";
                accomplishent.Description = "Has heard the rumor of the Scummy Murderer who is causing much political conflict within Ankou between the nobility and peasants.";
                _AnkouAccomplishments.Add(accomplishent);

                accomplishent = new Accomplishment();
                accomplishent.NameSpace = "Ankou";
                accomplishent.Name = "Has heard rumor of the Locate Necromancers";
                accomplishent.Description = "Has heard the rumor of searching the forest to Locate Necromancers and their camp, and then uncover whatever evidence their is as to what their intentions are.";
                _AnkouAccomplishments.Add(accomplishent);

                accomplishent = new Accomplishment();
                accomplishent.NameSpace = "Ankou";
                accomplishent.Name = "Has heard rumor of the Silence Ariean";
                accomplishent.Description = "Has heard the rumor of hunting down Ariean and silencing her. She's too dangerous to be left free.";
                _AnkouAccomplishments.Add(accomplishent);
            }

            return _AnkouAccomplishments;
        }

        #endregion

        #region Get Town Instance

        private static Ankou _Ankou;

        public static Ankou GetTownInstance()
        {
            if (_Ankou == null)
            {
                _Ankou = new Ankou();
            }

            return _Ankou;
        }
        #endregion
    }
}