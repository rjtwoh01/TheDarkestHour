﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Darkest_Hour.Characters;
using The_Darkest_Hour.Combat;
//using The_Darkest_Hour.GUIForm;

namespace The_Darkest_Hour.Locations.Actions
{

    public delegate void PostCombatHandler(object sender, CombatEventArgs e);


    class CombatAction : LocationAction
    {
        private CombatResult _CombatResult = CombatResult.NoResults;
        private string _startText;
        private string _endText;
        private bool _extraQuestText = false;

        public event PostCombatHandler PostCombat;


        public string MobName { get; set; }
        public List<Mob> Mobs { get; set; }
        public CombatResult CombatResults { get { return _CombatResult; } }

        public virtual void OnPostCombat(CombatEventArgs combatEventArgs)
        {
            if (PostCombat != null)
            {
                PostCombat(this, combatEventArgs);
            }
        }        

        public CombatAction(string mobName, List<Mob> mobs)
        {
            this.MobName = mobName;
            this.Mobs = mobs;
            if ((mobs != null) && (mobs.Count > 0))
            {
                this.Name = String.Format("Fight {0} {1}", mobs.Count,mobName);
                this.Description = String.Format("Fight {0} {1}", mobs.Count, mobName);
            }
            else
            {
                this.Name = "Invalid MOBs";
                this.Description = "Invalid MOBs";
            }
        }

        public CombatAction(string mobName, List<Mob> mobs, string first, string second)
        {
            this.MobName = mobName;
            this.Mobs = mobs;
            if ((mobs != null) && (mobs.Count > 0))
            {
                this.Name = String.Format("Fight {0} {1}", mobs.Count, mobName);
                this.Description = String.Format("Fight {0} {1}", mobs.Count, mobName);
            }
            else
            {
                this.Name = "Invalid MOBs";
                this.Description = "Invalid MOBs";
            }

            this._startText = first;
            this._endText = second;
            this._extraQuestText = true;
        }

        public override LocationDefinition DoAction()
        {
            LocationDefinition returnData = GameState.CurrentLocation;

            CombatResult tempResult = CombatResult.NoResults;

            Battle battle = new Battle();

            Console.Clear();

            if (_extraQuestText)
            {
                Console.WriteLine(_startText);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            if (Mobs != null)
            {
                for (int i = 0; i < Mobs.Count; i++)
                {
                    Mobs[i].Scale();
                    tempResult = battle.DoBattle(GameState.Hero, Mobs[i]);

                    if (tempResult == CombatResult.PlayerFled)
                    {
                        _CombatResult = tempResult;
                        break;
                    }
                    else if (tempResult == CombatResult.PlayerLoss)
                    {
                        _CombatResult = tempResult;
                        break;
                    }
                    else
                    {
                        _CombatResult = tempResult;                       
                    }
                }
            }

            if (_CombatResult == CombatResult.PlayerVictory)
            {
                if (_extraQuestText)
                {
                    Console.WriteLine(_endText);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            CombatEventArgs combatEventArgs = new CombatEventArgs();
            combatEventArgs.CombatResults = _CombatResult;

            OnPostCombat(combatEventArgs);

            return returnData;
        }
    }
}
