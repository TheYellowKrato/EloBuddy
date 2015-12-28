using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Settings = KarmaTo.Config.Modes.Draw;

namespace KarmaTo
{
    public static class Program
    {
        public const string ChampName = "Karma";

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();
            Drawing.OnDraw += OnDraw;
            Chat.Print("KarmaTo loaded");
        }

        private static void OnDraw(EventArgs args)
        {   
            if(Settings.DrawQ)
                Circle.Draw(Color.Red, SpellManager.Q.Range, Player.Instance.Position);
        }
    }
}
