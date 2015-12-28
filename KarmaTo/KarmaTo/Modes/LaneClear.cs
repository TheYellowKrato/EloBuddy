using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = KarmaTo.Config.Modes.LaneClear;
//AA minions in order to have multiple minion to one shot with Q
//Use Q to touch the most of minion killable 
namespace KarmaTo.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            AutoClear();
        }
        //Different logic : Use Q to make damage on minion
        //TODO : Add 2 or 3 in settings
        private void AutoClear()
        {
            if (Q.IsReady() && Player.Instance.ManaPercent > Settings.Mana)
            {
                var minions = Orbwalker.LaneclearMinions;
                foreach (Obj_AI_Minion target in minions)
                {
                    float x = Utils.getPlayer().Distance(target);
                    int nb = 1;
                    foreach (Obj_AI_Minion minion in minions)
                    {
                        float y = target.Distance(minion);
                        if (System.Math.Sqrt(x * x + y * y) >= Utils.getPlayer().Distance(minion))
                        {
                            nb++;
                        }
                    }
                    if (nb > 1)
                    {
                        var pred = Q.GetPrediction(target);
                        if (!pred.Collision)
                        {
                            Q.Cast(target);
                            break;
                        }
                    }
                }
            }
        }
    }
}
