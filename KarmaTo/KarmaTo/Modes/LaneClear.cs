using EloBuddy;
using EloBuddy.SDK;

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
            if (Q.IsReady() && Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana)
            {
                var minions = Orbwalker.LaneclearMinions;
                foreach (Obj_AI_Minion target in minions)
                {
                    float x = Utils.getPlayer().Distance(target);
                    int nb = 1;
                    foreach (Obj_AI_Minion minion in minions)
                    {
                        float y = target.Distance(minion);
                        if (Utils.sqrt(Utils.square(x+(minion.BoundingRadius)/2) + Utils.square(y + (minion.BoundingRadius) / 2)) >= Utils.getPlayer().Distance(minion) + (minion.BoundingRadius) / 2)
                        {
                            nb++;
                        }
                    }
                    if (nb >= Settings.useQOn)
                    {
                        if (Settings.UseR && R.IsReady())
                            R.Cast();
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
