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
    class BeachTowerCapturedVillage : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerCapturedVillage.Entrace";
        public const string TOWN_CENTER_KEY = "BeachTower.BeachTowerCapturedVillage.TownCenter";
        public const string MARKET_STREET_KEY = "BeachTower.BeachTowerCapturedVillage.MarketStreet";
        public const string PRISON_KEY = "BeachTower.BeachTowerCapturedVillage.Prison";
        public const string TOWN_HALL_KEY = "BeachTower.BeachTowerCapturedVillage.TownHall";
        public const string HOUSE_DISTRICT_KEY = "BeachTower.BeachTowerCapturedVillage.HouseDistrict";
        public const string MAYORS_HOUSE_KEY = "BeachTower.BeachTowerCapturedVillage.MayorsHouse";
        public const string TOWN_CENTER_MOBS = "BeachTower.BeachTowerCapturedVillage.TownCenterMobs";
        public const string MARKET_STREET_MOBS = "BeachTower.BeachTowerCapturedVillage.MarketStreetMobs";
        public const string PRISON_MOBS = "BeachTower.BeachTowerCapturedVillage.PrisonMobs";
        public const string PRISON_GUARDS = "BeachTower.BeachTowerCapturedVillage.PrisonGuards";
        public const string TOWN_HALL_MOBS = "BeachTower.BeachTowerCapturedVillage.TownHallMobs";
        public const string HOUSE_DISTRICT_MOBS = "BeachTower.BeachTowerCapturedVillage.HouseDistrictMobs";
        public const string HOUSE_DISTRICT_VILLAGERS = "BeachTower.BeachTowerCapturedVillage.HouseDistrictVillagers";
        public const string MASKED_BANDIT = "BeachTower.BeachTowerCapturedVillage.MaskedBandit";
        public const string MAYOR_HOUSE_DOOR = "BeachTower.BeachTowerCapturedVillage.OpenMayorHouseDoor";
        public const string MASKED_BANDIT_TREASURE = "BeachTower.BeachTowerCapturedVillage.MaskedBanditTreasure";

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
            returnData.Name = "Beach Side Village";
            returnData.Description = "A small village located a few miles to the south of the Beach Tower. The village is overrun with bandits who have set several of the buildings ablaze. The smoke rises into the air and can be seen for miles off.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            Accomplishment trackBandit = BeachTower.GetBeachTowerAccomplishments().Find(x => x.Name.Contains("Tracked Down Masked Bandit"));
            if (GameState.Hero.Accomplishments.Contains(trackBandit))
            {
                locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

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
                returnData.Name = "Beach Side Village";
                returnData.DoLoadLocation = LoadEntrance;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.TOWN_CENTER_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The center of the small village. What used to be a tall monument that represented the pride of the locals now lays shattered on the ground, stained with the blood of unknown victims. Bandits are scattered about.";

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
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += TownCenterMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The center of the small village. What used to be a tall monument that represented the pride of the locals now lays shattered on the ground, stained with the blood of unknown victims.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetMarketStreetDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetPrisonDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownHallDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetHouseDistrictDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void TownCenterMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.TOWN_CENTER_MOBS, true);

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

        #region Market Street

        public Location LoadMarketStreet()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Market Street";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MARKET_STREET_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The market street is barely recognizable to those who would have frequented it before. Several of the carts lay broken on the ground and even more are just piles of ash. Several bandits are inspecting the goods that survived the flames.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += MarketStreetMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The market street is barely recognizable to those who would have frequented it before. Several of the carts lay broken on the ground and even more are just piles of ash. The remaining goods have been saved from the bandits.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void MarketStreetMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MARKET_STREET_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(MARKET_STREET_KEY);
            }
        }

        public LocationDefinition GetMarketStreetDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MARKET_STREET_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Market Street";
                returnData.DoLoadLocation = LoadMarketStreet;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Prison

        public Location LoadPrison()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Prison";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.PRISON_MOBS));
            bool freedGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.PRISON_GUARDS));

            if (!defeatedMobs)
            {
                returnData.Description = "A small prison with all of the jail cells broken open. A group of bandits are taunting the guards of the prison who are tied up in the corner and beaten severely.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += PrisonMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (defeatedMobs && !freedGuards)
            {
                returnData.Description = "A small prison with all of the jail cells broken open. A group of prison guards are tied up in the corner.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Free", "Guards", "You free the prison guards from their bounds. You tell them to head to the Beach Tower for medical treatment. They thank you and rush off.");
                itemAction.PostItem += PrisonGuards;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small prison with all of the jail cells broken open.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void PrisonMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.PRISON_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(PRISON_KEY);
            }
        }

        public void PrisonGuards(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.PRISON_GUARDS, true);

                //Reload 
                LocationHandler.ResetLocation(PRISON_KEY);
            }
        }

        public LocationDefinition GetPrisonDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = PRISON_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Prison";
                returnData.DoLoadLocation = LoadPrison;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.TOWN_HALL_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A collection of buildings that were the former government buildings of the village are set ablaze, no longer the pillars of society. A group of bandits are feeding the flames, laughing manically.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += TownHallMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A collection of buildings that were the former government buildings of the village are set ablaze, no longer the pillars of society.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void TownHallMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.TOWN_HALL_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(TOWN_HALL_KEY);
            }
        }

        public LocationDefinition GetTownHallDefinition()
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

        #region House District

        public Location LoadHouseDistrict()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "House District";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_MOBS));
            bool freedVillagers = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_VILLAGERS));

            if (!defeatedMobs)
            {
                returnData.Description = "The house district showcases the true nature of the locals. The houses are all large but simple, reflecting their life style philosophy. Bandits are rounding up some of the villagers and tying them to a wooden post to burn alive.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                mobs.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mobs);
                combatAction.PostCombat += HouseDistrictMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (defeatedMobs && !freedVillagers)
            {
                returnData.Description = "The house district showcases the true nature of the locals. The houses are all large but simple, reflecting their life style philosophy. There are a lot of villagers tied up to a post.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Free", "Villagers", "You free the villagers, and inform them to head to the Beach Tower so they can seek medical attention. They thank you and run off in the distance.");
                itemAction.PostItem += HouseDistrictVillagers;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The house district showcases the true nature of the locals. The houses are all large but simple, reflecting their life style philosophy.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //Player must defeat bandits and free villagers to advance
            locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetMayorsHouseDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void HouseDistrictMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(HOUSE_DISTRICT_KEY);
            }
        }

        public void HouseDistrictVillagers(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_VILLAGERS, true);

                //Reload 
                LocationHandler.ResetLocation(HOUSE_DISTRICT_KEY);
            }
        }

        public LocationDefinition GetHouseDistrictDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = HOUSE_DISTRICT_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "House District";
                returnData.DoLoadLocation = LoadHouseDistrict;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Mayor's House

        public Location LoadMayorsHouse()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "The Mayor's House";            
            //Add a confront masked bandit action
            //There will be a conversation with the bandit, followed by a brief fight
            //After the fight the bandit will throw out an insult and flee
            //The player will then have to try to get into the house but realize its impossible.
            //There is some type of spell on the house preventing access.
            //The player will have to chase down the masked bandit to figure out how to get in.
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_MOBS));
            bool openDoor = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.HOUSE_DISTRICT_VILLAGERS));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MASKED_BANDIT_TREASURE));

            if (!defeatedMobs)
            {
                returnData.Description = "At the center of the House District is the Mayor's House. A large house, at least twice as large as the houses that surround it. It looks to be untouched by the bandits, but you can hear screaming from within - as if people are being tortured inside. There is a masked bandit standing calmly at the front of the house preventing access inside.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new MaskedBandit());
                CombatAction combatAction = new CombatAction("Masked Bandit", mobs);
                combatAction.PostCombat += MaskedBandit;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (defeatedMobs && !openDoor)
            {
                returnData.Description = "At the center of the House District is the Mayor's House. A large house, at least twice as large as the houses that surround it. It looks to be untouched by the bandits, but you can hear screaming from within - as if people are being tortured inside.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Open", "Door", "You try to open the door but are repelled by a magical force. You realize you cannot break into the house. You have to somehow track down the Masked Bandit and force him to reveal how to get into the house and save the people trapped inside.");
                itemAction.PostItem += OpenMayorHouseDoor;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }
            if (openDoor && !openedChest)
            {
                returnData.Description = "At the center of the House District is the Mayor's House. A large house, at least twice as large as the houses that surround it. It looks to be untouched by the bandits, but you can hear screaming from within - as if people are being tortured inside.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += MaskedBanditChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "At the center of the House District is the Mayor's House. A large house, at least twice as large as the houses that surround it. It looks to be untouched by the bandits, but you can hear screaming from within - as if people are being tortured inside.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetHouseDistrictDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            //This is just a temporary port back to Beach Tower TownHall for in development testing (since next quest isn't in yet)
            if (openedChest)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void MaskedBandit(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MASKED_BANDIT, true);

                //Reload 
                LocationHandler.ResetLocation(MAYORS_HOUSE_KEY);
            }
        }

        public void OpenMayorHouseDoor(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MAYOR_HOUSE_DOOR, true);

                //Reload 
                LocationHandler.ResetLocation(MAYORS_HOUSE_KEY);
            }
        }

        public void MaskedBanditChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCapturedVillage.MASKED_BANDIT_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(MAYORS_HOUSE_KEY);
            }
        }

        public LocationDefinition GetMayorsHouseDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MAYORS_HOUSE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Mayor's House";
                returnData.DoLoadLocation = LoadMayorsHouse;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerCapturedVillage _BeachTowerCapturedVillage;

        public static BeachTowerCapturedVillage GetTownInstance()
        {
            if (_BeachTowerCapturedVillage == null)
            {
                _BeachTowerCapturedVillage = new BeachTowerCapturedVillage();
            }

            return _BeachTowerCapturedVillage;
        }

        #endregion
    }
}