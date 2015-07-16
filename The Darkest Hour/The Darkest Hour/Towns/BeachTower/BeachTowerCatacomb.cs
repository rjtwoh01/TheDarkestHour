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
    class BeachTowerCatacomb : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "BeachTower.BeachTowerCatacomb.Entrace";
        public const string SMALL_HALLWAY_KEY = "BeachTower.BeachTowerCatacomb.Entrace";
        public const string LEFT_TOMBS_KEY = "BeachTower.BeachTowerCatacomb.LeftTombs";
        public const string RIGHT_TOMBS_KEY = "BeachTower.BeachTowerCatacomb.RightTombs";
        public const string SECRET_PASSAGE_WAY_KEY = "BeachTower.BeachTowerCatacomb.SecretPassageWay";
        public const string SECRET_TOMB_KEY = "BeachTower.BeachTowerCatacomb.SecretTomb";
        public const string LEFT_TOMBS_MOBS = "BeachTower.BeachTowerCatacomb.LeftTombMobs";
        public const string RIGHT_TOMBS_MOBS = "BeachTower.BeachTowerCatacomb.RightTombMobs";
        public const string CONFRONT_MASKED_BANDIT = "BeachTower.BeachTowerCatacomb.ConfrontMaskedBandit";
        public const string DEFEAT_NECROMANCER = "BeachTower.BeachTowerCatacomb.DefeatNecromancer";
        public const string TREASURE_CHEST = "BeachTower.BeachTowerCatacomb.TreasureChest";

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
            returnData.Name = "Opened Catacomb";
            returnData.Description = "An opened catacomb. The feeling of evil is seeping within this catacomb";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCemetery.GetTownInstance().GetCatacombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
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
                returnData.Name = "Opened Catacomb";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Small Hallway

        public Location LoadSmallHallway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Small Hallway";
            returnData.Description = "A small hallway in the bottom of the catacomb. There are rooms to the right and left filled with tombs.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetLeftTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetRightTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSmallHallwayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SMALL_HALLWAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Small Hallway";
                returnData.DoLoadLocation = LoadSmallHallway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Left Tombs

        public Location LoadLeftTombs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Left Tombs";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.LEFT_TOMBS_MOBS));            

            if (!defeatedMobs)
            {
                returnData.Description = "There are tombs stacked one ontop of another against all sides of the wall. There are risen skeletons mingling about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += LeftTombMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "There are tombs stacked one ontop of another against all sides of the wall.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void LeftTombMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.LEFT_TOMBS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(LEFT_TOMBS_KEY);
            }
        }

        public LocationDefinition GetLeftTombsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = LEFT_TOMBS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Left Tombs";
                returnData.DoLoadLocation = LoadLeftTombs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Right Tombs

        public Location LoadRightTombs()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Right Tombs";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.RIGHT_TOMBS_KEY));

            if (!defeatedMobs)
            {
                returnData.Description = "There are lots of tombs stacked ontop of eachother on the walls. There are several skeletons meandering around.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += LeftTombMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "There are lots of tombs stacked ontop of eachother on the walls.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSmallHallwayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretPassageWayDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void RightTombMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.RIGHT_TOMBS_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(RIGHT_TOMBS_KEY);
            }
        }

        public LocationDefinition GetRightTombsDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RIGHT_TOMBS_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Right Tombs";
                returnData.DoLoadLocation = LoadRightTombs;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Secret Passageway

        public Location LoadSecretPassageway()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Secret Passageway";
            returnData.Description = "A small secret passageway behind one of the tombs that was cracked open. It doesn't lead far and it looks like there is a large tomb on the other side of it.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetRightTombsDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretTombDefintion();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public LocationDefinition GetSecretPassageWayDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SECRET_PASSAGE_WAY_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Secret Passageway";
                returnData.DoLoadLocation = LoadSecretPassageway;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Secret Tomb

        public Location LoadSecretTomb()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Secret Tomb";            
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.DEFEAT_NECROMANCER));
            bool confrontBandit = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.CONFRONT_MASKED_BANDIT));
            bool openChest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.TREASURE_CHEST));

            string before = "Welcome, " + GameState.Hero.Identifier + ". What a welcome surprise to see you here. I assume you've tracked this fool before me. He obviously failed at his job. No matter, I'll finish you myself.";
            string after = "The Necromancer gasp for air as you kneel over him, a dagger you found on the floor lodged in his chest. You can see into his hood and red eyes are staring back at you. As he takes his last breath a major burst of energy releases from his body, knocking you back onto the ground. You slowly stand up, hoping that broke the barrier to the Mayor's House. Either way, you need to report to the Captain of the Guard.";

            //Add action to confront masked bandit
            //After confronting the masked bandit a necromancer steps out from the shadows and kills the masked bandit
            //Fight the necromancer
            //Killing the necromancer releases the shield on the mayor's house stopping you from getting back.
            if (!confrontBandit)
            {
                returnData.Description = "A large room with a tomb against the back wall. There is a large mural painting behind the tomb depicting what appears to be a person of royalty. This tomb must belong to a very important person. The masked bandit is kneeling before the tomb, his back turned to you";
                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Confront", "Masked Bandit", "You walk up behind the Masked Bandit. He stands upm turning around to face you. Just as he's about to say something his body is crushed by an invisible force and crumples to the ground, dead. Out from a darkened corner steps a necromancer, a dark hood covering his face. You feel trepidation as evil pours off his body like a waterfall.");
                itemAction.PostItem += ConfrontMaskedBandit;
                locationActions.Add(itemAction);
                returnData.Actions = locationActions;
            }

            else if (!defeatedMobs)
            {
                returnData.Description = "A large room with a tomb against the back wall. There is a large mural painting behind the tomb depicting what appears to be a person of royalty. This tomb must belong to a very important person. The masked bandit's body lays crumpled on the floor as the necromancer stands over it, glaring menacingly at you.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new CatacombsNecromancer());
                CombatAction combatAction = new CombatAction("Catacombs Necromancer", mobs, before, after);
                combatAction.PostCombat += LeftTombMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }

            else if (defeatedMobs && !openChest)
            {
                returnData.Description = "A large room with a tomb against the back wall. There is a large mural painting behind the tomb depicting what appears to be a person of royalty. This tomb must belong to a very important person. There is a treasure chest behind the tomb.";
                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A large room with a tomb against the back wall. There is a large mural painting behind the tomb depicting what appears to be a person of royalty. This tomb must belong to a very important person.";

            
            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BeachTowerCatacomb.GetTownInstance().GetSecretPassageWayDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            

            //Figure out where you want the player to go after this
            //Maybe both
            if (openChest)
            {
                locationDefinition = BeachTowerCapturedVillage.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

                locationDefinition = BeachTower.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }


            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void Necromancer(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.DEFEAT_NECROMANCER, true);

                //Reload 
                LocationHandler.ResetLocation(SECRET_TOMB_KEY);
            }
        }

        public void ConfrontMaskedBandit(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.CONFRONT_MASKED_BANDIT, true);

                //Reload 
                LocationHandler.ResetLocation(SECRET_TOMB_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(BeachTower.LOCATION_STATE_KEY, BeachTowerCatacomb.TREASURE_CHEST, true);

                //Reload
                LocationHandler.ResetLocation(SECRET_TOMB_KEY);
            }
        }

        public LocationDefinition GetSecretTombDefintion()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = SECRET_TOMB_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Secret Tomb";
                returnData.DoLoadLocation = LoadSecretTomb;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BeachTowerCatacomb _BeachTowerCatacomb;

        public static BeachTowerCatacomb GetTownInstance()
        {
            if (_BeachTowerCatacomb == null)
            {
                _BeachTowerCatacomb = new BeachTowerCatacomb();
            }

            return _BeachTowerCatacomb;
        }

        #endregion
    }
}
