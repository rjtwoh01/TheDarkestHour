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
    class BankenInconspicousCave : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenInconspicousCave.Entrance";
        public const string PASSAGEWAY_KEY = "Banken.BankenInconspicousCave.Passageway";
        public const string GUARD_ROOM_KEY = "Banken.BankenInconspicousCave.GuardRoom";
        public const string STORAGE_ROOM_KEY = "Banken.BankenInconspicousCave.StorageRoom";
        public const string DIMLY_LIT_HALLWAY_KEY = "Banken.BankenInconspicousCave.DimlyLitHallway";
        public const string DINING_ROOM_KEY = "Banken.BankenInconspicousCave.DiningRoom";
        public const string DIMLY_LIT_HALLWAY_2_KEY = "Banken.BankenInconspicousCave.DimilyLitHallway2";
        public const string RITUAL_ROOM_KEY = "Banken.BankenInconspicousCave.RitualRoom";
        public const string SEARCH_ENTRANCE = "Banken.BankenInconspicousCave.SearchEntrace";
        public const string PASSAGE_WAY_MOBS = "Banken.BankenInconspicousCave.PassageWayMobs";
        public const string GUARD_ROOM_MOBS_ONE = "Banken.BankenInconspicousCave.GuardRoomMobsOne";
        public const string GUARD_ROOM_MOBS_TWO = "Banken.BankenInconspicousCave.GuardRoomMobsTwo";
        public const string DIMLY_LIT_HALLWAY_MOBS = "Banken.BankenInconspicousCave.DimlyLitHallwayMobs";
        public const string STORAGE_ROOM_TREASURE = "Banken.BankenInconspicousCave.StorageRoomTreasure";
        public const string STORAGE_ROOM_GOLD = "Banken.BankenInconspicousCave.StorageRoomGold";
        public const string DINING_ROOM_MOBS = "Banken.BankenInconspicousCave.DiningRoomMobs";
        public const string DIMLY_LIT_HALLWAY_TWO_MOBS = "Banken.BankenInconspicousCave.dimlyLitHallwayTwoMobs";
        public const string RITUAL_ROOM_GUARDS = "Banken.BankenInconspicousCave.RitualRoomGuards";
        public const string RITUAL_ROOM_NECRO = "Banken.BankenInconspicousCave.RitualRoomNecro";
        public const string ZULIEN = "Banken.BankenInconspicousCave.Zulien";
        public const string TREASURE = "Banken.BankenInconspicousCave.Treasure";

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
            returnData.Name = "Inconcspicous Cave";
            bool searchEntrance = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.SEARCH_ENTRANCE));
            
            //Only if on the quest (LATER)
            if (!searchEntrance)
            {
                returnData.Description = "A seemingly innocent cave with no signs of any suspicious activity.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Search", "Entrance", "You search the entrance, trying to find anything that may point toward more going on that meets the eye. Luckily, you stumble upon a trap door covered by a magical illusion. The illusion was dispelled as your hand feels the latch");
                locationActions.Add(itemAction);
                itemAction.PostItem += SearchEntrance;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A once seemingly innocent cave with an uncovered trap door on the floor.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetNorthernPathThreeDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (searchEntrance)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetPassageWayDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void SearchEntrance(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.SEARCH_ENTRANCE, true);

                //Reload
                LocationHandler.ResetLocation(ENTRANCE_KEY);
            }
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
                returnData.Name = "Inconspicuous Cave";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Passage Way

        public Location LoadPassageWay()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Passage Way";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.PASSAGE_WAY_MOBS));
            
            if (!defeatedMobs)
            {
                returnData.Description = "A small passage way located beneath the trap door. There are two Re-Animated Statues patrolling the passage way.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ReAnimatedStatue());
                mobs.Add(new ReAnimatedStatue());
                CombatAction combatAction = new CombatAction("Re-Animated Statues", mobs);
                combatAction.PostCombat += PassageWayMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small passage way located beneath the trap door. The stoney remains of the statues lay crumbling on the ground.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetGuardRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void PassageWayMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.PASSAGE_WAY_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(PASSAGEWAY_KEY);
            }
        }

        public LocationDefinition GetPassageWayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = PASSAGEWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Passage Way";
                returnData.DoLoadLocation = LoadPassageWay;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Guard Room

        public Location LoadGuardRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Guard Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.GUARD_ROOM_MOBS_ONE));
            bool defeatedMobs2 = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.GUARD_ROOM_MOBS_TWO));
            
            if (!defeatedMobs)
            {
                returnData.Description = "The guard room is rather cramped, but that doesn't seem to be much of a bother to the necromancers within.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                CombatAction combatAction = new CombatAction("Necromancer Elite Guards", mobs, "You move to engage the deadly Necromancer Elite Guards", "As you kill the last necromancer, two re-animated statues burst the door and charge at you head on");
                combatAction.PostCombat += GuardRoomMobsOne;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            if (defeatedMobs && !defeatedMobs2)
            {
                returnData.Description = "The guard room is rather cramped, the re-animated statues are barreling at you.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ReAnimatedStatue());
                mobs.Add(new ReAnimatedStatue());
                CombatAction combatAction = new CombatAction("Re-Animated Statues", mobs);
                combatAction.PostCombat += GuardRoomMobsTwo;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The guard room is rather cramped, now also full of dead bodies and crumbled stone.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetPassageWayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs && defeatedMobs2)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetStorageRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BankenInconspicousCave.GetTownInstance().GetDimilyLitHallwayDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void GuardRoomMobsOne(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.GUARD_ROOM_MOBS_ONE, true);

                //Reload 
                LocationHandler.ResetLocation(GUARD_ROOM_KEY);
            }
        }

        public void GuardRoomMobsTwo(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.GUARD_ROOM_MOBS_TWO, true);

                //Reload 
                LocationHandler.ResetLocation(GUARD_ROOM_KEY);
            }
        }

        public LocationDefinition GetGuardRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = GUARD_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Guard Room";
                returnData.DoLoadLocation = LoadGuardRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Storage Room

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            returnData.Description = "A rather small storage room filled to the brim with suplies.";
            bool tookGold = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.STORAGE_ROOM_GOLD));
            bool takeTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.STORAGE_ROOM_TREASURE));

            if (!tookGold)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                PickUpGoldAction itemAction = new PickUpGoldAction(250);
                locationActions.Add(itemAction);
                itemAction.PostItem += StorageRoomGold;
                returnData.Actions = locationActions;
            }
            if (!takeTreasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += StorageRoomTreasure;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetGuardRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void StorageRoomGold(object sender, PickUpGoldEventArgs goldEventArgs)
        {
            if (goldEventArgs.GoldResults == PickUpGoldResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.STORAGE_ROOM_GOLD, true);

                //Reload
                LocationHandler.ResetLocation(STORAGE_ROOM_KEY);
            }
        }

        public void StorageRoomTreasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.STORAGE_ROOM_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(STORAGE_ROOM_KEY);
            }
        }

        public LocationDefinition GetStorageRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STORAGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Storage Room";
                returnData.DoLoadLocation = LoadStorageRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dimly Lit Hallway

        public Location LoadDimlyLitHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dimly Lit Hallway";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DIMLY_LIT_HALLWAY_MOBS));
            
            if (!defeatedMobs)
            {
                returnData.Description = "A long hallway that is very dimly lit. It is being patrolled by two necromancer guards.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                CombatAction combatAction = new CombatAction("Necromancer Elite Guards", mobs);
                combatAction.PostCombat += DimlyLitHallwayMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A long hallway that is very dimly lit.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetGuardRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetDiningRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DimlyLitHallwayMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DIMLY_LIT_HALLWAY_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DIMLY_LIT_HALLWAY_KEY);
            }
        }

        public LocationDefinition GetDimilyLitHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DIMLY_LIT_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dimly Lit Hallway";
                returnData.DoLoadLocation = LoadDimlyLitHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dining Room

        public Location LoadDiningRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dining Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DINING_ROOM_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A nicely sized dining room (for the cave). It is full of necromancers ready to eat.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += DiningRoomMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A nicely sized dining room (for the cave). It is now serving dead necromancer.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetDimilyLitHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetDimilyLitHallway2Definition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DiningRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DINING_ROOM_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DINING_ROOM_KEY);
            }
        }

        public LocationDefinition GetDiningRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DINING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dining Room";
                returnData.DoLoadLocation = LoadDiningRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dimly Lit Hallway 2

        public Location LoadDimlyLitHallway2()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dimly Lit Hallway 2";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DIMLY_LIT_HALLWAY_TWO_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "Another dimly lit hallway. This one is far creepier than last. The walls are lined with skulls. Evil walks here";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new ReAnimatedStatue());
                mobs.Add(new ReAnimatedStatue());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers and Re-Animated Statues", mobs, "The necromancers have summoned re-animated statues to protect themselves", "As the last necromancer falls dead to the ground, you can hear chanting growing louder and louder from the ritual room just at the end of the hallway");
                combatAction.PostCombat += DimlyLitHallwayTwoMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "Another dimly lit hallway. This one is far creepier than last. The walls are lined with skulls";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetDiningRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenInconspicousCave.GetTownInstance().GetRitualRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DimlyLitHallwayTwoMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.DIMLY_LIT_HALLWAY_TWO_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(DIMLY_LIT_HALLWAY_2_KEY);
            }
        }

        public LocationDefinition GetDimilyLitHallway2Definition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DIMLY_LIT_HALLWAY_2_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dimly Lit Hallway 2";
                returnData.DoLoadLocation = LoadDimlyLitHallway2;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Ritual Room

        public Location LoadRitualRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Ritual Room";
            bool defeatedEliteGuards = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.RITUAL_ROOM_GUARDS));
            bool defeatedNormalNecros = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.RITUAL_ROOM_NECRO));
            bool defeatedZulien = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.ZULIEN));
            bool takeTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.TREASURE));
            string before = "Zulien stops his ritual and turns his head toward you. As he sees you, his eyes flash with fury. He turns his full attention toward you. " +
                "\nHe lets out a strong magical blast that leaves you kneeling on the ground, arm covering your head. He shouts, \"You dare interupt my ritual? Die, mortal!\"";
            string after = "Zulien collapses to the ground, dead. Bload trickling out of his mouth. The world is a slightly better place.";

            if (!defeatedEliteGuards)
            {
                returnData.Description = "A large room with magic symbols painted on the ground with blood. There are several necromancer guards along with the rank and file protecting a vile necromancer performing a blood ritual";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                mobs.Add(new NecromancerEliteGuard());
                CombatAction combatAction = new CombatAction("Necromancer Elite Guards", mobs);
                combatAction.PostCombat += RitualRoomEliteNecroGuard;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            if (defeatedEliteGuards && !defeatedNormalNecros)
            {
                returnData.Description = "A large room with magic symbols painted on the ground with blood. The elite necromancer guard is dead, leaving only normal necromancers to protect the vile necromancer performing a blood ritual";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += RitualRoomNecro;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            if (defeatedEliteGuards && defeatedNormalNecros && !defeatedZulien)
            {
                returnData.Description = "A large room with magic symbols painted on the ground with blood. There are several necromancer guards along with the rank and file protecting a vile necromancer performing a blood ritual";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Zulien());
                CombatAction combatAction = new CombatAction("Zulien", mobs, before, after);
                combatAction.PostCombat += RitualRoomZulien;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "Another dimly lit hallway. This one is far creepier than last. The walls are lined with skulls";

            if (defeatedZulien && !takeTreasure)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += Treasure;
                returnData.Actions = locationActions;
            }

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Will need a change
            LocationDefinition locationDefinition = BankenInconspicousCave.GetTownInstance().GetDimilyLitHallway2Definition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedZulien)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void RitualRoomEliteNecroGuard(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.RITUAL_ROOM_GUARDS, true);

                //Reload 
                LocationHandler.ResetLocation(RITUAL_ROOM_KEY);
            }
        }

        public void RitualRoomNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.RITUAL_ROOM_NECRO, true);

                //Reload 
                LocationHandler.ResetLocation(RITUAL_ROOM_KEY);
            }
        }

        public void RitualRoomZulien(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.ZULIEN, true);

                //Reload 
                LocationHandler.ResetLocation(RITUAL_ROOM_KEY);
            }
        }

        public void Treasure(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenInconspicousCave.TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(RITUAL_ROOM_KEY);
            }
        }

        public LocationDefinition GetRitualRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RITUAL_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Ritual Room";
                returnData.DoLoadLocation = LoadRitualRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenInconspicousCave _InconspicousCave;

        public static BankenInconspicousCave GetTownInstance()
        {
            if (_InconspicousCave == null)
            {
                _InconspicousCave = new BankenInconspicousCave();
            }

            return _InconspicousCave;
        }

        #endregion
    }
}
