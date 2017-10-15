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
using The_Darkest_Hour.Characters.Mobs.Bosses.Banken;
using The_Darkest_Hour.Common;

namespace The_Darkest_Hour.Towns.Watertown
{
    class BankenOldForestRuins : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.OldForestRuins.Entrance";
        public const string MAIN_ROAD_KEY = "Banken.OldForestRuins.MainRoad";
        public const string TOWN_CENTER_KEY = "Banken.OldForestRuins.TownCenter";
        public const string INN_KEY = "Banken.OldForestRuins.Inn";
        public const string LOCKED_HOUSE_KEY = "Banken.OldForestRuins.LockedHouse";
        public const string TOWN_HALL_KEY = "Banken.OldForestRuins.TownHall";
        public const string MAIN_ROAD_MOBS = "Banken.OldForestRuins.MainRoadMobs";
        public const string CLEAR_ROAD_BLOCK = "Banken.OldForestRuins.ClearRoadBlock";
        public const string TOWN_CENTER_MOBS = "Banken.OldForestRuins.TownCenterMobs";
        public const string FREE_PRISONERS = "Banken.OldForestRuins.FreePrisoners";
        public const string INN_MOBS = "Banken.OldForestRuins.InnMobs";
        public const string SEARCH_INN = "Banken.OldForestRuins.SearchInn";
        public const string TAKE_KEY = "Banken.OldForestRuins.TakeKey";
        public const string UNLOCK_HOUSE = "Banken.OldForestRuins.UnlockHouse";
        public const string ESCORT_FAMILY = "Banken.OldForestRuins.EscortFamily";
        public const string DEFEAT_BANDIT_LEADERS = "Banken.OldForestRuins.DefeatBanditLeaders";
        public const string TAKE_ORDERS = "Banken.OldForestRuins.TakeOrders";
        public const string TREASURE = "Banken.OldForestRuins.Treasure";

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
            returnData.Name = "Old Forest Ruins";
            returnData.Description = "Ruins of an old town, overcome by the forest. Vines are growing on buildings that have long since crumpled to the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenOldForestRuins.GetTownInstance().GetMainRoadDefinition();
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
                returnData.Name = "Old Forest Ruins";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Main Road

        public Location LoadMainRoad()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Main Road";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.MAIN_ROAD_MOBS));
            bool clearBlockade = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.CLEAR_ROAD_BLOCK));


            if (!defeatedMobs)
            {
                returnData.Description = "This is the main run that used to connect the city to the outside world. Now the stones are covered in overgrown moss and several are broken. Bandits walk this road. They have set up a blockade preventing further access to the ruins. Probably to enforce a tarrif on traveling through the ruins.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += MainRoadMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!clearBlockade)
            {
                returnData.Description = "This is the main run that used to connect the city to the outside world. Now the stones are covered in overgrown moss and several are broken. The road is littered with bandit corpses. They have set up a blockade preventing further access to the ruins. Probably to enforce a tarrif on traveling through the ruins.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Clear", "Blockade", "You painstacking clear the blockade that the bandits. Hopefully no one else will fall victim to their evil ways");
                locationActions.Add(itemAction);
                itemAction.PostItem += ClearBlockade;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "This is the main run that used to connect the city to the outside world. Now the stones are covered in overgrown moss and several are broken. The road is littered with bandit corpses. The rocks that blocked the road have been pushed to the side.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenOldForestRuins.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && clearBlockade)
            {
                locationDefinition = BankenOldForestRuins.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MainRoadMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.MAIN_ROAD_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MAIN_ROAD_KEY);
            }
        }

        public void ClearBlockade(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.CLEAR_ROAD_BLOCK, true);

                //Reload
                LocationHandler.ResetLocation(MAIN_ROAD_KEY);
            }
        }

        public LocationDefinition GetMainRoadDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MAIN_ROAD_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Main Road";
                returnData.DoLoadLocation = LoadMainRoad;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Center

        public Location LoadTownCenter()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Center";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TOWN_CENTER_MOBS));
            bool freePrisoners = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.FREE_PRISONERS));

            if (!defeatedMobs)
            {
                returnData.Description = "What used to be the town center now lays in ruins. It appears to have once been a nice, charming place. Now the air that circles it reeks of death and decay. There are several bandits that are holding prisoners by the fountain.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += TownCenterMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!freePrisoners)
            {
                returnData.Description = "What used to be the town center now lays in ruins. It appears to have once been a nice, charming place. Now the air that circles it reeks of death and decay. There are several prisoners tied up to the fountain. Their bandit jailors are now dead.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Free", "Prisoners", "You free the prisoners from their binds, taking sorrowful note of their wounds. They thank you enthusiastically before you send them on their way to Banken to recieve aid from the Rangers.");
                locationActions.Add(itemAction);
                itemAction.PostItem += FreePrisoners;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "What used to be the town center now lays in ruins. It appears to have once been a nice, charming place. Now the air that circles it reeks of death and decay. The fountain remains bloodstained from the prisoners chained and tortured there.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenOldForestRuins.GetTownInstance().GetMainRoadDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && freePrisoners)
            {
                locationDefinition = BankenOldForestRuins.GetTownInstance().GetInnDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenOldForestRuins.GetTownInstance().GetLockedHouseDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenOldForestRuins.GetTownInstance().GetTownHallDefiniton();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TownCenterMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TOWN_CENTER_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);
            }
        }

        public void FreePrisoners(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.FREE_PRISONERS, true);

                //Reload
                LocationHandler.ResetLocation(TOWN_CENTER_KEY);
            }
        }

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
                returnData.Name = "Town Center";
                returnData.DoLoadLocation = LoadTownCenter;

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
            returnData.Name = "Inn";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.INN_MOBS));
            bool searchInn = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.SEARCH_INN));
            bool takeKey = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TAKE_KEY));

            if (!defeatedMobs)
            {
                returnData.Description = "This inn used to be nice and cozy. Now the wood is crumbling. Four bandits are searching it to see if anything of value remains";
                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += InnMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!searchInn)
            {
                returnData.Description = "This inn used to be nice and cozy. Now the wood is crumbling. There may still be something to find within the crumbled building.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Search", "Inn", "You search the inn to see if you can find anything helpful to your task here. You pull up a floorboard and notice an old key that appears to be in good condition. It must be to another building within the ruins.");
                locationActions.Add(itemAction);
                itemAction.PostItem += SearchInn;
                returnData.Actions = locationActions;
            }
            else if (!takeKey)
            {
                returnData.Description = "This inn used to be nice and cozy. Now the wood is crumbling. You have found a key to what appears to be another building.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Key");
                locationActions.Add(itemAction);
                itemAction.PostItem += TakeKey;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "This inn used to be nice and cozy. Now the wood is crumbling.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenOldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void InnMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.INN_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(INN_KEY);
            }
        }

        public void SearchInn(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.SEARCH_INN, true);

                //Reload
                LocationHandler.ResetLocation(INN_KEY);
            }
        }

        public void TakeKey(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TAKE_KEY, true);

                //Reload
                LocationHandler.ResetLocation(INN_KEY);
            }
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
                returnData.Name = "Inn";
                returnData.DoLoadLocation = LoadInn;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Locked House

        public Location LoadLockedHouse()
        {
            Location returnData;
            returnData = new Location();
            bool unlockHouse = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.UNLOCK_HOUSE));
            bool escortFamily = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.ESCORT_FAMILY));
            bool haveKey = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TAKE_KEY));

            if (haveKey)
            {
                if (!unlockHouse)
                {
                    returnData.Name = "Locked House";
                    returnData.Description = "This battered house appears locked with no way in. Try searching for a key somewhere within the ruins.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction itemAction = new TakeItemAction("Unlock", "House", "You unlock the house");
                    locationActions.Add(itemAction);
                    itemAction.PostItem += UnlockHouse;
                    returnData.Actions = locationActions;
                }
                else if (!escortFamily)
                {
                    returnData.Name = "Unlocked House";
                    returnData.Description = "The house has been unlocked. There is a family hiding inside from the bandits. It seems as if they locked themselves in earlier for protection.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction itemAction = new TakeItemAction("Escort", "Family", "You escort the family out of the house and inform them to head to Banken, so the Rangers can take care of them.");
                    locationActions.Add(itemAction);
                    itemAction.PostItem += EscortFamily;
                    returnData.Actions = locationActions;
                }
                else
                {
                    returnData.Name = "Unlocked House";
                    returnData.Description = "This battered house lays barren in the ruins.";
                }
            }
            else
            {
                returnData.Name = "Locked House";
                returnData.Description = "This battered house appears locked with no way in. Try searching for a key somewhere within the ruins.";
            }

            //ACTIONS:
            // 1) Unlock with key the player recieved from the inn
            // 2) Escort family too safety

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenOldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void UnlockHouse(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.UNLOCK_HOUSE, true);

                //Reload
                LocationHandler.ResetLocation(LOCKED_HOUSE_KEY);
            }
        }

        public void EscortFamily(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.ESCORT_FAMILY, true);

                //Reload
                LocationHandler.ResetLocation(LOCKED_HOUSE_KEY);
            }
        }

        public LocationDefinition GetLockedHouseDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LOCKED_HOUSE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Locked House";
                returnData.DoLoadLocation = LoadLockedHouse;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Town Hall

        public Location LoadTownHall()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Town Hall";
            bool defeatedLeaders = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.DEFEAT_BANDIT_LEADERS));
            bool takeOrders = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TAKE_ORDERS));
            bool takeTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TREASURE));
            string before = "The three bandits are fighting with eachother, not noticing you as you approach. \n\nOne yells out \"I deserve to be leader!\" and takes a swing at the other two. They both slam their bodies into his, knocking him to the ground. \n\nYou give a slight cough, alerting them to your presence";
            string after = "The last bandit falls to the ground. At least the ruins can return to a peaceful state now.";
            string orders = "You three may just be the largest buffons I have ever had the misfortune of knowing. Unfortunately for me, I'm running out of talent so it appears my task have to fall to the untalented such as yourselves. Anyway, I need you all to capture the ruins of an old town in the Ashen Forest. I've marked its location on the map included with this letter. \n\nYou must setup a blockade with the appearance of collecting tolls to continue through the town. In reality, you'll be collecting prisoners for me. I have a little experiment to try and seize control of the mind's of my victims. I can raise an army this way, and then we can finally proceed onto the final plan. Asku will fall.";

            if (!defeatedLeaders)
            {
                returnData.Description = "The town hall for what must have been a once proud people. Now it's nothing but ruins. There are three bandits that appear to be fighting with each other.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Arth());
                mobs.Add(new Sedhem());
                mobs.Add(new Bothnul());
                CombatAction combatAction = new CombatAction("Bandit Leaders", mobs, before, after);
                combatAction.PostCombat += DefeatBanditLeaders;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!takeOrders)
            {
                returnData.Description = "The town hall for what must have been a once proud people. Now it's nothing but ruins. A piece of paper lays on the ground, lightly stained with blood.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Take", "Orders", orders);
                locationActions.Add(itemAction);
                itemAction.PostItem += TakeOrders;
                returnData.Actions = locationActions;
            }
            else if (!takeTreasure)
            {
                returnData.Description = "The town hall for what must have been a once proud people. Now it's nothing but ruins. There is a treasure chest on the edge of the room.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The town hall for what must have been a once proud people. Now it's nothing but ruins. Three crumpled bandit bodies lay in the middle of the once impressive hall.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenOldForestRuins.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedLeaders && takeOrders)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DefeatBanditLeaders(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.DEFEAT_BANDIT_LEADERS, true);

                //Reload 
                LocationHandler.ResetLocation(TOWN_HALL_KEY);
            }
        }

        public void TakeOrders(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TAKE_ORDERS, true);

                //Reload
                LocationHandler.ResetLocation(TOWN_HALL_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenOldForestRuins.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(TOWN_HALL_KEY);
            }
        }

        public LocationDefinition GetTownHallDefiniton()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TOWN_HALL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Town Hall";
                returnData.DoLoadLocation = LoadTownHall;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenOldForestRuins _OldForestRuins;

        public static BankenOldForestRuins GetTownInstance()
        {
            if (_OldForestRuins == null)
            {
                _OldForestRuins = new BankenOldForestRuins();
            }

            return _OldForestRuins;
        }

        #endregion
    }
}