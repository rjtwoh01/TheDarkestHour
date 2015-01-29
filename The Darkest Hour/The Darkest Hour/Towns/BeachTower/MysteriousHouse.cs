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
    class MysteriousHouse : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.MysteriousHouse.Entrace";
        public const string LANDING_ROOM_KEY = "BeachTower.MysteriousHouse.LandingRoom";
        public const string LIVING_ROOM_KEY = "BeachTower.MysteriousHouse.LivingRoom";
        public const string LIVING_ROOM_NECRO = "BeachTower.MysteriousHouse.LivingRoomNecro";
        public const string KITCHEN_KEY = "BeachTower.MysteriousHouse.Kitchen";
        public const string KITCHEN_NECRO = "BeachTower.MysteriouseHouse.KitchenNecro";
        public const string STORAGE_ROOM_KEY = "BeachTower.MysteriousHouse.StorageRoom";
        public const string STORAGE_ROOM_JOURNAL = "BeachTower.MysteriousHouse.StorageRoomJournal";
        public const string DARK_MASTERS_OFFICE = "BeachTower.MysteriousHouse.DarkMastersOffice";
        public const string DARK_MASTER = "BeachTower.MysteriousHouse.DarkMaster";
        public const string DARK_MASTER_TREASURE = "BeachTower.MysteriousHouse.DarkMasterTreasure";

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
            returnData.Name = "Mysterious House";
            returnData.Description = "A dark mysterious house sitting on the the far edge of the woods that border the beach. The house looks run down and has a sinister quality about it. You can feel the chill in the air as you approach closer to it. Be on your guard. Evil awaits.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MysteriousHouse.GetTownInstance().GetLandingRoomDefinition();
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
                returnData.Name = "Mysterious House";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Landing Room

        public Location LoadLandingRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Landing Room";
            returnData.Description = "The landing room for the house is lit only by a dim torch. The flames flicker off the wall, revealing pealing paint. There is a hand print plastered on the wall with long dried up blood. The air smells foul. Proceed with caution";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MysteriousHouse.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = MysteriousHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetLandingRoomDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LANDING_ROOM_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Landing Room";
                returnData.DoLoadLocation = LoadLandingRoom;

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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.LIVING_ROOM_NECRO));

            if (!defeatedMobs)
            {
                returnData.Description = "The living room is lit only slightly better than the landing room. There are several necromancers bent over a body, using its decaying flesh as part of some dark ritual.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += LivingRoomNecro;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The living room is lit only slightly better than the landing room. The necromancer bodies have joined their poor victim on the ground.";
            

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MysteriousHouse.GetTownInstance().GetLandingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            if (defeatedMobs)
            {
                locationDefinition = MysteriousHouse.GetTownInstance().GetKitchenDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LivingRoomNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.LIVING_ROOM_NECRO, true);

                //Reload 
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
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.KITCHEN_NECRO));

            if (!defeatedMobs)
            {
                returnData.Description = "The kitchen is dark much like the rest of the house. The air smells a tad better in here due to the smells of fresh cooking food. There are two necromancers moving about the kitchen preparing meals for the rest in the house.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Necromancer());
                mobs.Add(new Necromancer());
                CombatAction combatAction = new CombatAction("Necromancers", mobs);
                combatAction.PostCombat += KitchenNecro;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The kitchen is dark much like the rest of the house. The air smells a tad better in here due to the smells of fresh cooking food. Two necromancers lay dead on the ground, their blood pouring at your feet.";


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MysteriousHouse.GetTownInstance().GetLivingRoomDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            if (defeatedMobs)
            {
                locationDefinition = MysteriousHouse.GetTownInstance().GetStorageRoomDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = MysteriousHouse.GetTownInstance().GetDarkMastersOfficeDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void KitchenNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.KITCHEN_NECRO, true);

                //Reload 
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

        #region Storage Room

        public Location LoadStorageRoom()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Storage Room";
            bool tookJournal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.STORAGE_ROOM_JOURNAL));
            returnData.Description = "A dark and musty storage room. There are several old pieces of parchment and journals lining the shelves";
            string journal = "- An excerpt from the art of necromancy volume II \nAt this point you need to obtain the blood of a young innocent. It's usually assumed that the sacrifice must be a virgin, and while that is true it is not the only criteria that must be met. The sacrifice must be innocent in all regards. Never stolen anything, never killed anyone, a virgin, etc. This ritual generally works better with females, though a male is acceptable in a pinch. Use your discretion while choosing who you will use.";

            if (!tookJournal)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                ReadPapersAction parchmentAction = new ReadPapersAction(journal);
                parchmentAction.PostPaper += Journal;
                locationActions.Add(parchmentAction);
                returnData.Actions = locationActions;
            }


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MysteriousHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void Journal(Object sender, PaperReadEventArgs paperReadEventArgs)
        {
            if (paperReadEventArgs.PaperResults == PaperReadResults.Read)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.STORAGE_ROOM_JOURNAL, true);

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

        #region Dark Master's Office

        public Location LoadDarkMastersOffice()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Dark Master's Office";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.DARK_MASTER));
            bool openedChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.DARK_MASTER_TREASURE));
            string darkMasterSpeechBefore = "''Hello, " + GameState.Hero.Identifier + ". '' A deep voice sounds from behind the hood of the cloack. It lacks all compasion and warmth, and instead feels cold and evil sending chills running down your spine.\n''I have to bring myself to wonder, why have you come here and disturbed the clouds that we enjoy so much? I have lived my life hidden in shadows, and I will not let you change that.''";
            string darkMasterSpeechAfter = "The Dark Master gasp for breath as his hood falls from his face. You can see that his eyes are a pale red, which were most likely a darker shade of red before the fight you just had. He looks up at you, both hatred and resignation seen in his eyes. He gasp out, ''I didn't want to be involved. He made me. I heard stories about,'' *coughs* ''you. Didn't want to fight. But he made me. Make him pay. Spies in the tower. They can... '' *coughs up blood* ''lead you to him. Go. Make him pay.''";

            if (!defeatedMobs)
            {
                returnData.Description = "The office is lit only by a small lamp sitting on the desk in the center of the room. The flames flicker on the walls, briefly illuminating skeletons hanging from them. The flames show a man in a dark cloak sitting at the desk, his face clouded by the darkness.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new DarkMaster());
                CombatAction combatAction = new CombatAction("Dark Master", mobs, darkMasterSpeechBefore, darkMasterSpeechAfter);
                combatAction.PostCombat += DarkMaster;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The office is lit only by a small lamp sitting on the desk in the center of the room. The flames flicker on the walls, briefly illuminating skeletons hanging from them. The Dark Master's body lays collapsed upon his desk.";

            if (defeatedMobs && openedChest)
            {
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += DarkMasterChest;
                returnData.Actions = locationActions;
            }


            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = MysteriousHouse.GetTownInstance().GetKitchenDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            if (defeatedMobs)
            {
                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DarkMaster(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.DARK_MASTER, true);

                //Reload 
                LocationHandler.ResetLocation(DARK_MASTERS_OFFICE);
            }
        }

        public void DarkMasterChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, MysteriousHouse.DARK_MASTER_TREASURE, true);

                //Reload
                LocationHandler.ResetLocation(DARK_MASTERS_OFFICE);
            }
        }

        public LocationDefinition GetDarkMastersOfficeDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = DARK_MASTERS_OFFICE;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Dark Master's Office";
                returnData.DoLoadLocation = LoadDarkMastersOffice;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static MysteriousHouse _MysteriousHouse;

        public static MysteriousHouse GetTownInstance()
        {
            if (_MysteriousHouse == null)
            {
                _MysteriousHouse = new MysteriousHouse();
            }

            return _MysteriousHouse;
        }

        #endregion
    }
}
