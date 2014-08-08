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
    class AnkouUndergroundTunnel : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouUndergroundTunnel.Entrance";
        public const string MUDDY_ROOM_KEY = "Ankou.AnkouUndergroundTunnel.MuddyRoom";
        public const string SMALL_ROOM_KEY = "Ankou.AnkouUndergroundTunnel.SmallRoom";
        public const string RITUAL_ROOM_KEY = "Ankou.AnkouUndergroundTunnel.RitualRoom";
        public const string COORDINATION_ROOM_KEY = "Ankou.AnkouUndergroundTunnel.CoordinationRoom";
        public const string DEFEATED_LIVING_ROOM_BANDITS = "Ankou.AnkouUndergroundTunnel.CoordinationRoom";
        public const string DEFEATED_MUDDY_ROOM_BANDITS = "Ankou.AnkouUndergroundTunnel.DefeatedMuddyRoomBandits";
        public const string DEFEATED_SMALL_ROOM_MOBS = "Ankou.AnkouUndergroundTunnel.DefeatedSmallRoomMobs";
        public const string DEFEATED_BUFFER_ROOM_BANDITS = "Ankou.AnkouUndergroundTunnel.DefeatedRitualRoomMobs";
        public const string KILLED_ATTACK_COORDINATOR = "Ankou.AnkouUndergroundTunnel.KilledAttackCoordinator";
        public const string TOOK_ATTACK_PLANS = "Ankou.AnkouUndergroundTunnel.TookAttackPlans";
        public const string TOOK_TREASURE = "Ankou.AnkouUndergroundTunnel.TookTreasure";


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
            returnData.Name = "Underground Tunnel";
            returnData.Description = "A small trapdoor that leads to an underground tunnel, beneath the Ankou Town Center. The entrance is small without a lot of room, meant to obscure the purpose of the tunnel - making it appear smaller than it really is.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetMuddyRoomDefinition();
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
                returnData.Name = "Underground Tunnel";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Muddy Room

        public Location LoadMuddyRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Muddy Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_MUDDY_ROOM_BANDITS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A muddy room that has two mobs pacing it, guarding further access to the tunnel";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Bandit());
                mob.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", mob);
                combatAction.PostCombat += MuddyRoomBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A muddy room that has two dead mobs laying on the ground, their blood pulled on the cold ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetSmallRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void MuddyRoomBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_MUDDY_ROOM_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(MUDDY_ROOM_KEY);

            }
        }

        public LocationDefinition GetMuddyRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = MUDDY_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Muddy Room";
                returnData.DoLoadLocation = LoadMuddyRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Room

        public Location LoadSmallRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Room";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_SMALL_ROOM_MOBS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A small room that has two peasants and two nobles playing a game of cards amongst themselves, killing time.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Peasant());
                mob.Add(new Noble());
                mob.Add(new Peasant());
                mob.Add(new Noble());
                CombatAction combatAction = new CombatAction("Peasants and Nobles", mob);
                combatAction.PostCombat += SmallRoomMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A small room that has four dead bodies scattered about the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetMuddyRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetRitualRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void SmallRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_SMALL_ROOM_MOBS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(SMALL_ROOM_KEY);

            }
        }

        public LocationDefinition GetSmallRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Room";
                returnData.DoLoadLocation = LoadSmallRoom;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_BUFFER_ROOM_BANDITS));

            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A dark room, swirling with strong dark energy. There are six necromancers in a cirlce chanting together";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Necromancer());
                mob.Add(new Necromancer());
                mob.Add(new Necromancer());
                mob.Add(new Necromancer());
                mob.Add(new Necromancer());
                mob.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mob);
                combatAction.PostCombat += RitualRoomMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A dark room, swirling with strong dark energy. There are six dead necromancers on the ground, their bodies forming a circle.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetSmallRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetCoordinationRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void RitualRoomMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.DEFEATED_BUFFER_ROOM_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
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

        #region Coordination Room

        public Location LoadCoordinationRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Coordination Room";
            bool defeatedAttackCoordinator = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.KILLED_ATTACK_COORDINATOR));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.TOOK_TREASURE));
            bool takePlans = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.TOOK_ATTACK_PLANS));
            string mobSpeechBefore = "I heard you as you walked in, " + GameState.Hero.Identifier +". You cannot sneak up on me. No, I think you've seen too much here, and I can't let you leave.\n";
            string mobSpeechAfter = "The attack coordinator's body falls to ground dead, blood falling out of his mouth and onto the ground.\n";

            //Actions
            if (!defeatedAttackCoordinator)
            {
                returnData.Description = "A large room with maps of Ankou covering the walls. The maps are all anoted with circles and pins scattered about them. There is a small man observing the maps, his back turned to the wall.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> coordinator = new List<Mob>();
                coordinator.Add(new AttackCoordinator());
                CombatAction combatAction = new CombatAction("Attack Coordinator", coordinator, mobSpeechBefore, mobSpeechAfter);
                combatAction.PostCombat += DefeatedAttackCoordinator;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedAttackCoordinator)
            {
                if (!openedChest)
                {
                    if (!takePlans)
                        returnData.Description = "A large room with maps of Ankou covering the walls. The maps are all anoted with circles and pins scattered about them. There is a small man dead in the middle of the room, lying in his own blood. The attack plans are sitting on a table on the far edge of the room and there is an unopened chest beneath the table.";
                    else
                        returnData.Description = "A large room with maps of Ankou covering the walls. The maps are all anoted with circles and pins scattered about them. There is a small man dead in the middle of the room, lying in his own blood. There is an unopened chest beneath the table.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(5);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += CoordinatorChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takePlans)
                    returnData.Description = "A large room with maps of Ankou covering the walls. The maps are all anoted with circles and pins scattered about them. There is a small man dead in the middle of the room, lying in his own blood. There is an opened chest beneath the table.";
                if (!takePlans && openedChest)
                {
                    returnData.Description = "A large room with maps of Ankou covering the walls. The maps are all anoted with circles and pins scattered about them. There is a small man dead in the middle of the room, lying in his own blood. The attack plans are sitting on a table on the far edge of the room and there is an opened chest beneath the table.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction takePlansAction = new TakeItemAction("Attack Plans");
                    takePlansAction.PostItem += TakeAttackPlans;
                    locationActions.Add(takePlansAction);
                    returnData.Actions = locationActions;
                }
            }

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouUndergroundTunnel.GetTownInstance().GetRitualRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedAttackCoordinator && takePlans)
            {
                locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedAttackCoordinator(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.KILLED_ATTACK_COORDINATOR, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(COORDINATION_ROOM_KEY);

            }
        }

        public void CoordinatorChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.TOOK_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(COORDINATION_ROOM_KEY);

            }
        }

        public void TakeAttackPlans(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouUndergroundTunnel.TOOK_ATTACK_PLANS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(COORDINATION_ROOM_KEY);

            }
        }

        public LocationDefinition GetCoordinationRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = COORDINATION_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Coordination Room";
                returnData.DoLoadLocation = LoadCoordinationRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouUndergroundTunnel _AnkouUndergroundTunnel;

        public static AnkouUndergroundTunnel GetTownInstance()
        {
            if (_AnkouUndergroundTunnel == null)
            {
                _AnkouUndergroundTunnel = new AnkouUndergroundTunnel();
            }

            return _AnkouUndergroundTunnel;
        }

        #endregion
    }
}