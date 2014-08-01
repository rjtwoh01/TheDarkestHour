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
    class AnkouBanditAndNecroCave : Town
    {
        #region Location keys

        public const string ENTRANCE_KEY = "Ankou.AnkouBanditAndNecroCave.Entrance";
        public const string DIRTY_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.DirtyRoom";
        public const string SMALL_HOVEL_KEY = "Ankou.AnkouBanditAndNecroCave.SmallHovel";
        public const string LARGE_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.LargeRoom";
        public const string DARK_ROOM_KEY = "Ankou.AnkouBanditAndNecroCave.DarkRoom";
        public const string DEFEATED_DIRTY_ROOM_BANDITS = "Ankou.AnkouBanditAndNecroCave.DefeatedDirtyRoomBandits";
        public const string DEFEATED_SMALL_HOVEL_MOBS = "Ankou.AnkouBanditAndNecroCave.DefeatedSmallHovelMobs";
        public const string DEFEATED_LARGE_ROOM_NECROS = "Ankou.AnkouBanditAndNecroCave.DefeatedLargeRoomNecros";
        public const string KILLED_NECRO_CONTRACTOR = "Ankou.AnkouBanditAndNecroCave.KilledNecroContractor";
        public const string TOOK_JOURNAL = "Ankou.AnkouBanditAndNecroCave.TookJournal";
        public const string TOOK_TREASURE = "Ankou.AnkouBanditAndNecroCave.TookChest";

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
            returnData.Name = "Bandit and Necromancer Cave";
            returnData.Description = "A small cave entrance that is hidden from view but noticable if you know to look for it. On the inside is an empty space that makes it look like the cave is really small. However, you know that there is more to the cave and can notice the door that leads to the next room.";

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouForest.GetTownInstance().GetRightThreeDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDirtyRoomDefinition();
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
                returnData.Name = "Bandit and Necromancer Cave";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dirty Room

        public Location LoadDirtyRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dirty Room";
            bool defeatedBandits = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_DIRTY_ROOM_BANDITS));

            //Actions
            if (!defeatedBandits)
            {
                returnData.Description = "A dirty room with six bandits relaxing in it.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> bandit = new List<Mob>();
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                bandit.Add(new Bandit());
                CombatAction combatAction = new CombatAction("Bandits", bandit);
                combatAction.PostCombat += DirtyRoomBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A dirty room with six dead bandits in it.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedBandits)
            {
                locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetSmallHovelDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DirtyRoomBandits(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_DIRTY_ROOM_BANDITS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DIRTY_ROOM_KEY);

            }
        }

        public LocationDefinition GetDirtyRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DIRTY_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dirty Room";
                returnData.DoLoadLocation = LoadDirtyRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Hovel

        public Location LoadSmallHovel()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Hovel";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_SMALL_HOVEL_MOBS));
     
            //Actions
            if (!defeatedMobs)
            {
                returnData.Description = "A small hovel that has two bandits and two necromancers discussing future plans.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> mob = new List<Mob>();
                mob.Add(new Bandit());
                mob.Add(new Necromancer());
                mob.Add(new Bandit());
                mob.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Bandits and Necromancers", mob);
                combatAction.PostCombat += SmallHovelMobs;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;

            }
            else
                returnData.Description = "A small hovel with four dead boides lying mangled and bent on the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDirtyRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetLargeRoomDefinition();
                adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void SmallHovelMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_SMALL_HOVEL_MOBS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(SMALL_HOVEL_KEY);

            }
        }

        public LocationDefinition GetSmallHovelDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_HOVEL_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Hovel";
                returnData.DoLoadLocation = LoadSmallHovel;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Large Room

        public Location LoadLargeRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Large Room";
            bool defeatedNecro = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_LARGE_ROOM_NECROS));

            //Actions
            if (!defeatedNecro)
            {
                returnData.Description = "A large room that has ten necromancers mingling about and discussing various things.";

                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> necro = new List<Mob>();
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                necro.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", necro);
                combatAction.PostCombat += DirtyRoomBandits;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large room with ten necromancers slaughtered about the ground.";

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetSmallHovelDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetDarkRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void LargeRoomNecros(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.DEFEATED_LARGE_ROOM_NECROS, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(LARGE_ROOM_KEY);

            }
        }

        public LocationDefinition GetLargeRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LARGE_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Large Room";
                returnData.DoLoadLocation = LoadLargeRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Dark Room

        public Location LoadDarkRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dark Room";
            returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle stands a small man with a black hood covering his face. He has his hands outstreched and he's chanting something and the air grows heavier the more he chants.";
            bool defeatedBanditTorturer = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.KILLED_NECRO_CONTRACTOR));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.TOOK_TREASURE));
            bool takeLetters = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.TOOK_JOURNAL));
            string necroSpeechBefore = "Welcome to my humble adobe, " + GameState.Hero.Identifier + ". You won't make it out alive. Come, join me.";
            string necroSpeechAfter = "The necromancer's body vanishes from his robes and they collapse to the ground, blackened and charred from the dark magic he used during the fight.";

            //Actions
            if (!defeatedBanditTorturer)
            {
                returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle stands a small man with a black hood covering his face. He has his hands outstreched and he's chanting something and the air grows heavier the more he chants.";
                List<LocationAction> locationActions = new List<LocationAction>();

                List<Mob> contractor = new List<Mob>();
                contractor.Add(new NecroContractor());
                CombatAction combatAction = new CombatAction("Necromancer Contractor", contractor, necroSpeechBefore, necroSpeechAfter);
                combatAction.PostCombat += DefeatedContractor;

                locationActions.Add(combatAction);

                returnData.Actions = locationActions;
            }
            else if (defeatedBanditTorturer)
            {
                if (!openedChest)
                {
                    if (!takeLetters)
                        returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle lays the blackened robe of the necroamncer contractor. There is a journal on top of the robe and an unopened chest next to it.";
                    else
                        returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle lays the blackened robe of the necroamncer contractor. There is an unopened chest next to it.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TreasureChestAction itemAction = new TreasureChestAction(2);
                    locationActions.Add(itemAction);
                    itemAction.PostItem += ContractorChest;
                    returnData.Actions = locationActions;
                }
                if (openedChest && takeLetters)
                    returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle lays the blackened robe of the necroamncer contractor. There is an opened chest next to it.";
                if (!takeLetters && openedChest)
                {
                    returnData.Description = "A very dark room. The walls are black and glowing purple with some dark evil magic. There are skulls aligned in ritualistic patterns on the floor. There are drawings on the walls, painted with blood. In the middle lays the blackened robe of the necroamncer contractor. There is a journal on top of the robe and an opened chest next to it.";

                    List<LocationAction> locationActions = new List<LocationAction>();
                    TakeItemAction letterAction = new TakeItemAction("Journal of pay outs and economical dealings");
                    letterAction.PostItem += Journal;
                    locationActions.Add(letterAction);
                    returnData.Actions = locationActions;
                }
            }

            //Actions

            // Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefinitions = new Dictionary<string, LocationDefinition>();

            // Town Center
            LocationDefinition locationDefinition = AnkouBanditAndNecroCave.GetTownInstance().GetLargeRoomDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = Ankou.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefinitions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefinitions;

            return returnData;
        }

        public void DefeatedContractor(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.KILLED_NECRO_CONTRACTOR, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DARK_ROOM_KEY);

            }
        }

        public void ContractorChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.TOOK_TREASURE, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DARK_ROOM_KEY);

            }
        }

        public void Journal(object sender, TakeItemEventArgs inspectEventArgs)
        {
            if (inspectEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Ankou.LOCATION_STATE_KEY, AnkouBanditAndNecroCave.TOOK_JOURNAL, true);

                // Reload the Sewer Coordior so it will open up the sewer
                LocationHandler.ResetLocation(DARK_ROOM_KEY);

            }
        }

        public LocationDefinition GetDarkRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DARK_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dark Room";
                returnData.DoLoadLocation = LoadDarkRoom;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static AnkouBanditAndNecroCave _AnkouBanditAndNecroCave;

        public static AnkouBanditAndNecroCave GetTownInstance()
        {
            if (_AnkouBanditAndNecroCave == null)
            {
                _AnkouBanditAndNecroCave = new AnkouBanditAndNecroCave();
            }

            return _AnkouBanditAndNecroCave;
        }

        #endregion
    }
}
