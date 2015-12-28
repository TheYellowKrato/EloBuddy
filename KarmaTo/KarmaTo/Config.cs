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
            static Modes()
            {
                Combo.Initialize(Menu.AddSubMenu("Combo"));
                Menu.AddSeparator();
                Harass.Initialize(Menu.AddSubMenu("Harass"));
                Menu.AddSeparator();
                Flee.Initialize(Menu.AddSubMenu("Flee"));
                Menu.AddSeparator();
                LaneClear.Initialize(Menu.AddSubMenu("LaneClear"));
                Menu.AddSeparator();
                Draw.Initialize(Menu.AddSubMenu("Draw"));
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static  CheckBox _useQ;
                private static  CheckBox _useW;
                private static  CheckBox _useR;
                private static Menu myMenu;
                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }
                public static Menu getMenu()
                {
                    return myMenu;
                }

                /*public static int PredictionChance
                {
                    get { return Menu["predictionHit"].Cast<Slider>().CurrentValue; }
                }*/

                static Combo()
                {
                    // Initialize the menu values


                    //Menu.Add("predictionHit", new Slider("Prediction for Q (not implemented : 2 by default)",2,1,3));
                }

                public static void Initialize(Menu menu)
                {
                    myMenu = menu;
                    myMenu.AddGroupLabel("Combo");
                    _useQ = myMenu.Add("comboUseQ", new CheckBox("Use Q", true));
                    _useW = myMenu.Add("comboUseW", new CheckBox("Use W", true));
                    _useR = myMenu.Add("comboUseR", new CheckBox("Use R", true));
                }
            }

            public static class LaneClear
            {
                public static bool UseQ
                {
                    get { return myMenu["clearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return myMenu["clearMana"].Cast<Slider>().CurrentValue; }
                }
                public static Menu getMenu()
                {
                    return myMenu;
                }
                private static Menu myMenu;
                static LaneClear()
                {

                }

                public static void Initialize(Menu menu)
                {
                    myMenu = menu;
                    myMenu.AddGroupLabel("LaneClear");
                    myMenu.Add("clearUseQ", new CheckBox("Use Q", false));
                    myMenu.Add("clearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }
            }

            public static class Harass
            {
                private static Menu myMenu;
                public static bool UseQ
                {
                    get { return myMenu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return myMenu["harassUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return myMenu["harassMana"].Cast<Slider>().CurrentValue; }
                }
                public static Menu getMenu()
                {
                    return myMenu;
                }

                static Harass()
                {

                }

                public static void Initialize(Menu menu)
                {
                    myMenu = menu;
                    myMenu.AddGroupLabel("Harass");
                    myMenu.Add("harassUseQ", new CheckBox("Use Q", true));
                    myMenu.Add("harassUseR", new CheckBox("Use R", false));

                    myMenu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }
            }

            public static class Draw
            {
                private static Menu myMenu;
                public static Menu getMenu()
                {
                    return myMenu;
                }
                public static bool DrawQ
                {
                    get { return myMenu["drawQ"].Cast<CheckBox>().CurrentValue; }
                }

                static Draw()
                {

                }

                public static void Initialize(Menu menu)
                {
                    myMenu = menu;
                    myMenu.AddGroupLabel("Draw");
                    myMenu.Add("drawQ", new CheckBox("Draw Q", true));
                }
            }

            public static class Flee
            {
                private static Menu myMenu;
                public static bool UseQ
                {
                    get { return myMenu["fleeUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return myMenu["fleeUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return myMenu["fleeUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static Menu getMenu()
                {
                    return myMenu;
                }
            
                static Flee()
                {
 
                }

                public static void Initialize(Menu menu)
                {
                    myMenu = menu;
                    myMenu.AddGroupLabel("Flee");
                    myMenu.Add("fleeUseQ", new CheckBox("Use Q", true));
                    myMenu.Add("fleeUseE", new CheckBox("Use E", true));
                    myMenu.Add("fleeUseR", new CheckBox("Use R", true));
                }
            }
        }
    }
}
