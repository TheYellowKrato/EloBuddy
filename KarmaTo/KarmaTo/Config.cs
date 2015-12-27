using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace KarmaTo
{

    public static class Config
    {
        private const string MenuName = "KarmaTo";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to KarmaTo!");
            Menu.AddLabel("This is my first addon so be easy");
            Menu.AddLabel("Don't hesitate to comment and suggest !");
            Menu.AddLabel("Have Fun !");
            Menu.AddLabel("A big thanks to HellSing for his AddonTemplate");

            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                Menu = Config.Menu.AddSubMenu("Modes");

                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                Menu.AddSeparator();

                // Flee
                Flee.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                /*public static int PredictionChance
                {
                    get { return Menu["predictionHit"].Cast<Slider>().CurrentValue; }
                }*/

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q", true));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W", true));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E", true));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", true));

                    //Menu.Add("predictionHit", new Slider("Prediction for Q (not implemented : 2 by default)",2,1,3));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return Menu["harassUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseQ", new CheckBox("Use Q", false));
                    Menu.Add("harassUseR", new CheckBox("Use R", false));

                    Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                public static bool UseQ
                {
                    get { return Menu["fleeUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["fleeUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return Menu["fleeUseR"].Cast<CheckBox>().CurrentValue; }
                }
            
                static Flee()
                {
                    Menu.AddGroupLabel("Flee");
                    Menu.Add("fleeUseQ", new CheckBox("Use Q", true));
                    Menu.Add("fleeUseE", new CheckBox("Use E", true));
                    Menu.Add("fleeUseR", new CheckBox("Use R", true));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
