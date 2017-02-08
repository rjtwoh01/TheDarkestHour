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
    class BankenAshenForestWorshipRegion : Town
    {
        #region Location Keys

        public const string ENTRANCE_KEY = "Banken.BankenAshenForestWorshipRegion.Entrace";
        public const string STATUE_CLEARING_KEY = "Banken.BankenAshenForestWorshipRegion.SatueClearing";
        public const string TWISTING_PATH_KEY = "Banken.BankenAshenForestWorshipRegion.TwistPath";
        public const string RELIGIOUS_SHRINE_CLEARING_KEY = "Banken.BankenAshenForestWorshipRegion.ReligiousShrineClearing";
        public const string UNDERGROUND_PATH_KEY = "Banken.BankenAshenForestWorshipRegion.UndergroundPath";
        public const string CEMETERY_ENTRANCE_KEY = "Banken.BankenAshenForestWorshipRegion.CemeteryEntrance";
        public const string CEMETERY_PATH_KEY = "Banken.BankenAshenForestWorshipRegion.CemeteryPath";
        public const string CEMETERY_EAST_END_KEY = "Banken.BankenAshenForestWorshipRegion.CemeteryEastEnd";
        public const string CEMETERY_WEST_END_KEY = "Banken.BankenAshenForestWorshipRegion.CemeteryWestEnd";
        public const string CEMETERY_NORTH_END_KEY = "Banken.BankenAshenForestWorshipRegion.CemeteryNorthEnd";
        public const string FLEEING_LOCAL = "Banken.BankenAshenForestWorshipRegion.FleeingLocal";
        public const string TWISTING_PATH_ROCK_BLOCKADE = "Banken.BankenAshenForestWorshipRegion.TwistPathRockBlocakde";
        public const string TWISTING_PATH_SPIDERS = "Banken.BankenAshenForestWorshipRegion.TwistPathSpiders";
        public const string RELIGIOUS_SHRINE_CLEARING_MOBS = "Banken.BankenAshenForestWorshipRegion.ReligiousShrineClearingMobs";
        public const string UNDERGROUND_PATH_MOBS = "Banken.BankenAshenForestWorshipRegion.UndergroundPathMobs";
        public const string CEMETERY_ENTRANCE_GATE = "Banken.BankenAshenForestWorshipRegion.CemeteryEntranceGate";
        public const string CEMETERY_ENTRANCE_AMBUSH = "Banken.BankenAshenForestWorshipRegion.CemeteryEntranceAmbush";
        public const string CEMETERY_PATH_MOBS = "Banken.BankenAshenForestWorshipRegion.CemeteryPathMobs";
        public const string CEMETERY_EAST_END_MOBS = "Banken.BankenAshenForestWorshipRegion.CemeteryEastEnd";
        public const string CEMETERY_WEST_END_MOBS = "Banken.BankenAshenForestWorshipRegion.CemeteryWestEnd";
        public const string DEMONIC_NECROMANCER = "Banken.BankenAshenForestWorshipRegion.DemonicNecro";
        public const string TREASURE_CHEST = "Banken.BankenAshenForestWorshipRegion.TreasureChest";
        public const string JOURNAL = "Banken.BankenAshenForestWorshipRegion.Journal";

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
            returnData.Name = "Ashen Forest Path - Worship Region";
            returnData.Description = "You enter the worship region of the Ashen Forest. Many people travel here to pay homage in some kind to whatever Gods they believe in. This is ancient ground, that some believe used to be holy. But now, a dark presence is defiling it. Faint, but there none-the-less.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForest.GetTownInstance().GetForestPathStartDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetStatueClearingDefinition();
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
                returnData.Name = "Ashen Forest Path - Worship Region";
                returnData.DoLoadLocation = LoadEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Satue Clearing

        public Location LoadStatueClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Holy Statue Clearing";
            bool fleeingLocal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.FLEEING_LOCAL));

            if (!fleeingLocal)
            {
                returnData.Description = "You enter into a small clearing that has a giant statue placed at the back of it. It is adorned with flowers and personal trinkets from the locals that come here to worship and pray. As you enter, several locals push past you as they rush to flee the area.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Talk to", "fleeing local", "You stop one of the locals as he tries to push past you and demand to know what's going on. He looks at you wide eyed and lets out a strangled, gurgling noise. You put a calming hand on his should and tell him to take a moment and try again.\n\nThe local takes a deep breath then says, ''Dark... darkness... It's all that's left. The dead... Awful... Run. Run now. Run while you still can.''\n\nWith that the local pushes past you and continues his retreat out of the forest. You steal yourself for whatever horrors are beyond this clearing.");
                locationActions.Add(itemAction);
                itemAction.PostItem += TalkToFleeingLocal;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "You enter into a small clearing that has a giant statue placed at the back of it. It is adorned with flowers and personal trinkets from the locals that come here to worship and pray. You can feel darkness emanating from beyond the clearing. Evil awaits.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (fleeingLocal)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetTwistingPathDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            
            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void TalkToFleeingLocal(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.FLEEING_LOCAL, true);

                //Reload
                LocationHandler.ResetLocation(STATUE_CLEARING_KEY);
            }
        }

        public LocationDefinition GetStatueClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = STATUE_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Holy Statue Clearing";
                returnData.DoLoadLocation = LoadStatueClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Twisting Path

        public Location LoadTwistingPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Twisting Path";
            bool moveBoulder = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TWISTING_PATH_ROCK_BLOCKADE));
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TWISTING_PATH_SPIDERS));

            if (!moveBoulder)
            {
                returnData.Description = "A narrow twisting path that goes deep within the forest. The air is heavy and the skies dark. There are faint cries in the distance, and mist forms on the ground. There is a boulder blocking your way further.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Move", "boulder", "You walk up to the boulder and push with all your might to get it off the path and into the dense trees. It gives way with surprising ease and you topple over to the ground, face first. As you stand back up and wipe dirt from your face, you see giant spiders descending from the trees. This is not good.");
                locationActions.Add(itemAction);
                itemAction.PostItem += MoveBoulder;
                returnData.Actions = locationActions;
            }
            else if (!defeatedMobs)
            {
                returnData.Description = "A narrow twisting path that goes deep within the forest. The air is heavy and the skies dark. There are faint cries in the distance, and mist forms on the ground. Giant spiders are descending down threateningly toward you.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += TwistingPathSpiders;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A narrow twisting path that goes deep within the forest. The air is heavy and the skies dark. There are faint cries in the distance, and mist forms on the ground. With the spiders dead and boulder moved, the air here feels somewhat lighter. But the menacing presence in the distance grows even darker. It's almost as if the very forest is plotting against you.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetStatueClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetReligiousShrineClearingDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void MoveBoulder(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TWISTING_PATH_ROCK_BLOCKADE, true);

                //Reload
                LocationHandler.ResetLocation(TWISTING_PATH_KEY);
            }
        }

        public void TwistingPathSpiders(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TWISTING_PATH_SPIDERS, true);

                //Reload 
                LocationHandler.ResetLocation(TWISTING_PATH_KEY);
            }
        }

        public LocationDefinition GetTwistingPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = TWISTING_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Twisting Path";
                returnData.DoLoadLocation = LoadTwistingPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Religious Shrines Clearing

        public Location LoadReligiousShrineClearing()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Religious Shrine Clearing";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.RELIGIOUS_SHRINE_CLEARING_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "You walk into another clearing full of religious shrines. However these shrines are no longer holy. They've been desecrated by dark, vile, magic. The clearing is full of skeletons, all armed to the teeth and ready to end any foolish enough to trespess on their newly aquired unholy grounds.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += ReligiousShrineClearingMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "You walk into another clearing full of religious shrines. However these shrines are no longer holy. They've been desecrated by dark, vile, magic. Skeletal remains litter the ground";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetTwistingPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetUndergroundPathDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            
            Accomplishment recruitMage = Banken.GetBankenAccomplishments().Find(x => x.Name.Contains("Recruit Mage"));
            if (GameState.Hero.Accomplishments.Contains(recruitMage))
            {
                locationDefinition = BankenMagesRetreatHouse.GetTownInstance().GetEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }


        public void ReligiousShrineClearingMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.RELIGIOUS_SHRINE_CLEARING_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(RELIGIOUS_SHRINE_CLEARING_KEY);
            }
        }

        public LocationDefinition GetReligiousShrineClearingDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = RELIGIOUS_SHRINE_CLEARING_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Religious Shrine Clearing";
                returnData.DoLoadLocation = LoadReligiousShrineClearing;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Underground Path

        public Location LoadUndergroundPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Underground Path";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.UNDERGROUND_PATH_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "A path off the side of the Religious Shrine Clearing. The path goes underground and is made of ancient stone. It is filled with several stone coffins. As you walk through the path the tops to the coffins slide off as mist pours out of them. Slowly skeletons rise from their eternal slumber.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += UndergroundPathMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "A path off the side of the Religious Shrine Clearing. The path goes underground and is made of ancient stone. It is filled with several stone coffins. Mist continues to pour out of the coffins and the skeletons are once again resting in their eternal slumber.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetReligiousShrineClearingDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if(defeatedMobs)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryEntranceDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }


        public void UndergroundPathMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.UNDERGROUND_PATH_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(UNDERGROUND_PATH_KEY);
            }
        }

        public LocationDefinition GetUndergroundPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = UNDERGROUND_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Underground Path";
                returnData.DoLoadLocation = LoadUndergroundPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cemetery Entrance

        public Location LoadCemeteryEntrance()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cemetery Entrance";
            bool openGate = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_ENTRANCE_GATE));
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_ENTRANCE_AMBUSH));

            if (!openGate)
            {
                returnData.Description = "The entrance to the cemetery is blocked with a giant stone gate. The gate has seen better days as large pieces are broken off and others are rusted. It doesn't appear to be securely attached. A good swift kick should be all that's need to gain access to the cemetery.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Kick open", "gate", "You kick the gate open with as much force as you can. The gate swings open, giving way to the evil presence within. Thick mist pours out of the cemetery.");
                locationActions.Add(itemAction);
                itemAction.PostItem += OpenGate;
                returnData.Actions = locationActions;
            }
            else if (!defeatedMobs)
            {
                returnData.Description = "The entrance to the cemetery is blocked with a giant stone gate. The gate is open but a noise from behind you catches your attention. Several skeletons run at you from the dark forest screaming with unholy rage.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeltons", mobs);
                combatAction.PostCombat += CemeteryEntranceAmbush;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The entrance to the cemetery is blocked with a giant stone gate. The gate is open and thick mist pours out of the cemetery. With the skeletel ambush defeated, you steel yourself to face the darkness within the cemetery.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetUndergroundPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryPathDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void OpenGate(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_ENTRANCE_GATE, true);

                //Reload
                LocationHandler.ResetLocation(CEMETERY_ENTRANCE_KEY);
            }
        }

        public void CemeteryEntranceAmbush(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_ENTRANCE_AMBUSH, true);

                //Reload 
                LocationHandler.ResetLocation(CEMETERY_ENTRANCE_KEY);
            }
        }

        public LocationDefinition GetCemeteryEntranceDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CEMETERY_ENTRANCE_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cemetery Entrance";
                returnData.DoLoadLocation = LoadCemeteryEntrance;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cemetery Path

        public Location LoadCemeteryPath()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cemetery Path";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_PATH_MOBS));
            bool clearedEast = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_EAST_END_MOBS));
            bool clearedWest = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_WEST_END_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The path leads into the heart of the cemetery. There are giant spiders feasting on corpses scattered about the path.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                mobs.Add(new GiantSpider());
                CombatAction combatAction = new CombatAction("Giant Spiders", mobs);
                combatAction.PostCombat += CemeteryPathMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!clearedEast && !clearedWest)
                returnData.Description = "The path leads into the heart of the cemetery. The path comes to a three way split halfway through the cemetery. The path goes east, west, and north. The northern part of the path is blocked by some dark magic. Clear the cemetery of evil to gain access to the northern path";
            else
                returnData.Description = "The path leads into the heart of the cemetery. The path comes to a three way split halfway through the cemetery. The path goes east, west, and north. The dark magic blocking the northern path has vanished. You may now proceed.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryEntranceDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (defeatedMobs)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryEastEndDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryWestEndDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }
            if (clearedWest && clearedEast)
            {
                locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryNorthEndDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CemeteryPathMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_PATH_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CEMETERY_PATH_KEY);
            }
        }

        public LocationDefinition GetCemeteryPathDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CEMETERY_PATH_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cemetery Path";
                returnData.DoLoadLocation = LoadCemeteryPath;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cemetery East End

        public Location LoadCemeteryEastEnd()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cemetery East End";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_EAST_END_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The east end of the cemetery is full of coffins, most of them undisturbed. There are a few skeletons slowly roaming about.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += CemeteryEastEndMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The east end of the cemetery is full of coffins, most of them undisturbed. With the skeletons returned to rest the air feels lighter but a dark presence still lingers.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }


        public void CemeteryEastEndMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_EAST_END_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CEMETERY_EAST_END_KEY);
            }
        }

        public LocationDefinition GetCemeteryEastEndDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CEMETERY_EAST_END_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cemetery East End";
                returnData.DoLoadLocation = LoadCemeteryEastEnd;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cemetery West End

        public Location LoadCemeteryWestEnd()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cemetery West End";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_WEST_END_MOBS));

            if (!defeatedMobs)
            {
                returnData.Description = "The west end of the cemetery has many of its coffins broken open and lots of burial ground disturbed. There's a rather large group of skeletons walking about, ready to bring unholy death to all living creatures.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                mobs.Add(new Skeleton());
                CombatAction combatAction = new CombatAction("Skeletons", mobs);
                combatAction.PostCombat += CemeteryWestEndMobs;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The west end of the cemetery has many of its coffins broken open and lots of burial ground disturbed. There's a large pile of skeletel bones in the the center of the west end.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void CemeteryWestEndMobs(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.CEMETERY_WEST_END_MOBS, true);

                //Reload 
                LocationHandler.ResetLocation(CEMETERY_WEST_END_KEY);
            }
        }

        public LocationDefinition GetCemeteryWestEndDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CEMETERY_WEST_END_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cemetery West End";
                returnData.DoLoadLocation = LoadCemeteryWestEnd;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #region Cemetery North End

        public Location LoadCemeteryNorthEnd()
        {
            Location returnData;
            returnData = new Location();
            returnData.Name = "Cemetery West End";
            bool defeatedMobs = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.DEMONIC_NECROMANCER));
            bool tookJournal = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.JOURNAL));
            bool tookTreasure = Convert.ToBoolean(LocationHandler.GetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TREASURE_CHEST));
            string before = "The Demonic Necromancer continues to stare down at the ground and starts to speak, ''Hello, " + GameState.Hero.Identifier + ". You've come to save those poor, poor people from me? You're efforts have all been in vain. All that you have done, all that you have fought for. It's all pointless. For your journey ends here. And I'll take great pleasure in ending you.''\n\nThe Demonic Necromancer looks up and stars at you with glowing red eyes and smiles a sick and twisted smile, revealing his long, sharp, blood-coated teeth. Slowly and deliberately he unseathes a sword from beneath his cloak and holds it menacingly at his side, waiting for you to make the first move.";
            string after = "The Demonic Necromancer's body crumples to the ground, and his sword goes flying and embeds intself in the ground 20 feet away. A journal falls from inside his robes, grabbing your attention.";

            if (!defeatedMobs)
            {
                returnData.Description = "You walk forward to the north end of the cemetery. As you reach the end of the path, you come upon a sacrificial shrine covered in blood. Standing on it is a dark figure. The figure looks up at you briefly, revealing a twisted abomination of mix between demon and human. It's red eyes flash and it quickly looks back down as it raises its arms summoing dark energy to swirl around it.";

                List<LocationAction> locationActions = new List<LocationAction>();
                List<Mob> mobs = new List<Mob>();
                mobs.Add(new DemonicNecro());
                CombatAction combatAction = new CombatAction("Demonic Necromancer", mobs, before, after);
                combatAction.PostCombat += DemonicNecro;
                locationActions.Add(combatAction);
                returnData.Actions = locationActions;
            }
            else if (!tookJournal)
            {
                returnData.Description = "The northern end of the cemetery has a sacrificial shrine covered in blood. The Demonic Necromancer's body lays just before the shrine and his journal lays at his side.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TakeItemAction itemAction = new TakeItemAction("Journal");
                locationActions.Add(itemAction);
                itemAction.PostItem += TakeJournal;
                returnData.Actions = locationActions;
            }
            else if (!tookTreasure)
            {
                returnData.Description = "The northern end of the cemetery has a sacrificial shrine covered in blood. The Demonic Necromancer's body lays just before the shrine and there is a treasure chest behind it.";

                List<LocationAction> locationActions = new List<LocationAction>();
                TreasureChestAction itemAction = new TreasureChestAction(5);
                locationActions.Add(itemAction);
                itemAction.PostItem += TreasureChest;
                returnData.Actions = locationActions;
            }
            else
                returnData.Description = "The northern end of the cemetery has a sacrificial shrine covered in blood. The Demonic Necromancer's body lays just before the shrine.";

            //Adjacent Locations
            Dictionary<string, LocationDefinition> adjacentLocationDefintions = new Dictionary<string, LocationDefinition>();

            //Town Center
            LocationDefinition locationDefinition = BankenAshenForestWorshipRegion.GetTownInstance().GetCemeteryPathDefinition();
            adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);

            if (tookJournal)
            {
                locationDefinition = Banken.GetTownInstance().GetTownCenterDefinition();
                adjacentLocationDefintions.Add(locationDefinition.LocationKey, locationDefinition);
            }

            returnData.AdjacentLocationDefinitions = adjacentLocationDefintions;

            return returnData;
        }

        public void DemonicNecro(object sender, CombatEventArgs combatEventArgs)
        {
            if (combatEventArgs.CombatResults == CombatResult.PlayerVictory)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.DEMONIC_NECROMANCER, true);

                //Reload 
                LocationHandler.ResetLocation(CEMETERY_NORTH_END_KEY);
            }
        }

        public void TakeJournal(object sender, TakeItemEventArgs itemEventArgs)
        {
            if (itemEventArgs.ItemResults == TakeItemResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.JOURNAL, true);

                //Reload
                LocationHandler.ResetLocation(CEMETERY_NORTH_END_KEY);
            }
        }

        public void TreasureChest(object sender, ChestEventArgs chestEventArgs)
        {
            if (chestEventArgs.ChestResults == ChestResults.Taken)
            {
                LocationHandler.SetLocationStateValue(Banken.LOCATION_STATE_KEY, BankenAshenForestWorshipRegion.TREASURE_CHEST, true);

                //Reload
                LocationHandler.ResetLocation(CEMETERY_NORTH_END_KEY);
            }
        }

        public LocationDefinition GetCemeteryNorthEndDefinition()
        {
            LocationDefinition returnData = new LocationDefinition();
            string locationKey = CEMETERY_NORTH_END_KEY;

            if (LocationHandler.LocationExists(locationKey))
            {
                returnData = LocationHandler.GetLocation(locationKey);
            }
            else
            {
                returnData.LocationKey = locationKey;
                returnData.Name = "Cemetery North End";
                returnData.DoLoadLocation = LoadCemeteryNorthEnd;

                LocationHandler.AddLocation(returnData);
            }

            return returnData;
        }

        #endregion

        #endregion

        #region Get Town Instance

        private static BankenAshenForestWorshipRegion _BankenAshenForestWorshipRegion;

        public static BankenAshenForestWorshipRegion GetTownInstance()
        {
            if (_BankenAshenForestWorshipRegion == null)
            {
                _BankenAshenForestWorshipRegion = new BankenAshenForestWorshipRegion();
            }

            return _BankenAshenForestWorshipRegion;
        }

        #endregion
    }
}