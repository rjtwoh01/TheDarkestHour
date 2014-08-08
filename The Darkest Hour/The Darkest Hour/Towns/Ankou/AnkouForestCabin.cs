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
    class AnkouForestCabin : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouForestCabin.Entrance";
        public const string LIVING_ROOM_KEY = "Ankou.AnkouForestCabin.LivingRoom";
        public const string KITCHEN_KEY = "Ankou.AnkouForestCabin.Kitchen";
        public const string BEDROOM_KEY = "Ankou.AnkouForestCabin.Bedroom";
        public const string DEFEATED_LIVING_ROOM_PEASANTS = "Ankou.AnkouForestCabin.DefeatedLivingRoomPeasants";
        public const string DEFEATED_KITCHEN_PEASANTS = "Ankou.AnkouForestCabin.DefeatedKitchenPeasants";
        public const string KILLED_PEASANT_LEADER = "Ankou.AnkouForestCabin.KilledPeasantLeader";
        public const string RESCUED_PEASANTS = "Ankou.AnkouForestCabin.RescudedPeasants";
        public const string TOOK_TREASURE = "Ankou.AnkouForestCabin.TookTreasure";


        #endregion

        #region Locations

        public override LocationDefinition GetStartingLocationDefinition()
        {
            return GetEntranceDefinition();
        }

        #region Entance

        public Location LoadEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Shabby Cabin";
            returnData.Description = "A cabin that was clumsily put together with really cheap wood. It looks as if it's falling apart.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetStraightFourDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouForestCabin.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

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
                returnData.Name = "Shabby Cabin";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Living Room

        public Location LoadLivingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Living Room";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_LIVING_ROOM_PEASANTS));

            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A shabby living room with beat up chairs. There are six bandits mingling about, eating and talking about nothing in particular.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandit = new List<Mob>();
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandit);
                combatAction.PostCombat += LivingRoomBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A shabby living room with beat up chairs. There are six dead bandits scattered about the room.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouForestCabin.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LivingRoomBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_LIVING_ROOM_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LIVING_ROOM_KEY);

            }
        }

        public LocationDefinition GetLivingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LIVING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Living Room";
                returnData.DoLoadLocation = LoadLivingRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Kitchen

        public Location LoadKitchen()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Kitchen";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_KITCHEN_PEASANTS));

            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A small kitchen. Most of the appliances don't work but never-the-less there are bandits working on the next meal for everyone.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandit = new List<Mob>();
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandit);
                combatAction.PostCombat += KitchenBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small kitchen. Most of the appliances don't work. There are several severed bandit heads laying in the soup they were making.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouForestCabin.GetTownInstance().GetBedroomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void KitchenBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.DEFEATED_KITCHEN_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(KITCHEN_KEY);

            }
        }

        public LocationDefinition GetKitchenDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = KITCHEN_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Kitchen";
                returnData.DoLoadLocation = LoadKitchen;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Bedroom

        public Location LoadBedroom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Bedroom";
            bool defeatedBanditWarden = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.KILLED_PEASANT_LEADER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_TREASURE));
            bool freePrisoners = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.RESCUED_PEASANTS));
            string banditSpeechBefore = "So you did come after all, " + GameState.Hero.Identifier + ". I guess I was wrong about you. I thought you weren't this stupid. No matter, this is better for us after all. You see, what's going to happen is I'm going to kill you. Slowly, and painfully. But before you take your last breath, you'll have to watch all of these people die a horrific death. Kind of a sad story. A 'hero' such as to come so far only to falter when it really matters. Die now, " + GameState.Hero.Identifier + ".";
            string banditSpeechAfter = "''How... How could you have bested me?'' Gasp out the Bandit Warden. He is hunched over, his sword laying next to him. You walk over to him and kick him down on the floor and pick up his sword. You stare at his eyes and watch as they widden in horror as he realizes the end is here. You swiftly behead and turn your attention to the suffering prisoners. Despite what they've been through, there is a visible look of relief on their faces as they realize that their captor has been slain and they are safe now.";

            //Actions
            if (!defeatedBanditWarden)
            {
                returnData.Description = "The largest room in the shack is dedicated to holding prisoners. There are ten peasants chained to the wall. All of them are nude, including the women and childern. All of them have whip lashes covering their bodies. A young teenaged woman on the right hand corner has fresh blood running down her chest from an cut between her breast.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> wardnen = new List<Mob>();
                wardnen.Add(new BanditWarden());
                CombatAction combatAction = new CombatAction("Bandit Warden", wardnen, banditSpeechBefore, banditSpeechAfter);
                combatAction.PostCombat += DefeatedBanditWarden;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedBanditWarden)
            {
                if (!openedChest)
                {
                    if (!freePrisoners)
                        returnData.Description = "The largest room in the shack is dedicated to holding prisoners. There are ten peasants chained to the wall. All of them are nude, including the women and childern. All of them have whip lashes covering their bodies. A young teenaged woman on the right hand corner has fresh blood running down her chest from an cut between her breast. There is an unopened chest where the warden used to stand.";
                    else
                        returnData.Description = "The largest room in the shack is dedicated to holding prisoners. The chains that used to hold the prisoners are missing but the bodily imprints of the prisoners remains on the wall, and their blood remains behind standing as testimony to the horrors experienced here.There is an unopened chest where the warden use to stand.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += WardenChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && freePrisoners)
                    returnData.Description = "The largest room in the shack is dedicated to holding prisoners. The chains that used to hold the prisoners are missing but the bodily imprints of the prisoners remains on the wall, and their blood remains behind standing as testimony to the horrors experienced here.There is an opened chest where the warden use to stand.";
                if (!freePrisoners && openedChest)
                {
                    returnData.Description = "The largest room in the shack is dedicated to holding prisoners. There are ten peasants chained to the wall. All of them are nude, including the women and childern. All of them have whip lashes covering their bodies. A young teenaged woman on the right hand corner has fresh blood running down her chest from an cut between her breast. There is an unopened chest where the warden used to stand.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction freePrisonerAction = new TakeItemAction("Free", "Prisoners", "You hastily cut down the chains holding the prisoners. You make sure all of them are able to walk and you usher them out of the house and to safety. You urge the more injured ones to seek medical help and promise them that that the town constable office will pay for all expenses.");
                    freePrisonerAction.PostItem += FreePrisoners;
                    locationActions.Add(freePrisonerAction);
                    returnData.Actions = locationActions;
                }
            }

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForestCabin.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBanditWarden && freePrisoners)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedBanditWarden(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.KILLED_PEASANT_LEADER, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public void WardenChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.TOOK_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public void FreePrisoners(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouForestCabin.RESCUED_PEASANTS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(BEDROOM_KEY);

            }
        }

        public LocationDefinition GetBedroomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = BEDROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Bedroom";
                returnData.DoLoadLocation = LoadBedroom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouForestCabin _AnkouForestCabin;

        public static AnkouForestCabin GetTownInstance()
        {
            if (_AnkouForestCabin == null)
            {
                _AnkouForestCabin = new AnkouForestCabin();
            }

            return _AnkouForestCabin;
        }

        #endregion
    }
}
