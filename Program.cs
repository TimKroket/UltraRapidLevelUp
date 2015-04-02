


using System;
using LeagueSharp;
using LeagueSharp.Common;


namespace URFLevelup
{
    class Program
    {
        public static int[] abilitySequence;
        public static int qOff = 0, wOff = 0, eOff = 0, rOff = 0;
        public static string type = "";
        private static SpellSlot Smite;
        public static Obj_AI_Base Player = ObjectManager.Player;
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        static void Game_OnGameLoad(EventArgs args)
        {
            Smite = ObjectManager.Player.GetSpellSlot("SummonerSmite");
            //WorkInProgress

            if (Player.BaseSkinName == "Jinx") abilitySequence = new int[] { 2, 1, 2, 3, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
            else if (Player.BaseSkinName == "Katarina") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
            else if (Player.BaseSkinName == "Sona") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 3, 4, 2, 2, 2, 3, 4, 3, 3 };
            else if (Player.BaseSkinName == "Ahri") abilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
            else if (Player.BaseSkinName == "Hecarim") abilitySequence = new int[] { 1, 2, 3, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
            else if (Player.BaseSkinName == "Shaco") type = "AP"; abilitySequence = new int[] { 2, 1, 3, 3, 3, 4, 3, 1, 3, 1, 1, 1, 4, 2, 2, 4, 1, 1 };        
            Game.OnUpdate += Game_OnUpdate;
            Game.PrintChat("<font color='#C80046'>UltraRapidLevelup - TimKroket</font>");
            Game.PrintChat("<font color='#03ff3e'>Upvote if you like it ^^</font>");
            Game.PrintChat("<font color='#ea03ff'> URLevelup for:" + Player.BaseSkinName + type + " loaded");
        }

        static void Game_OnUpdate(EventArgs args)
        {
            int qL = Player.Spellbook.GetSpell(SpellSlot.Q).Level + qOff;
            int wL = Player.Spellbook.GetSpell(SpellSlot.W).Level + wOff;
            int eL = Player.Spellbook.GetSpell(SpellSlot.E).Level + eOff;
            int rL = Player.Spellbook.GetSpell(SpellSlot.R).Level + rOff;
            if (qL + wL + eL + rL < ObjectManager.Player.Level)
            {
                int[] level = new int[] { 0, 0, 0, 0 };
                for (int i = 0; i < ObjectManager.Player.Level; i++)
                {
                    level[abilitySequence[i] - 1] = level[abilitySequence[i] - 1] + 1;
                }
                if (qL < level[0]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.Q);
                if (wL < level[1]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.W);
                if (eL < level[2]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.E);
                if (rL < level[3]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.R);

            }
        }
    }
}