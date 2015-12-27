using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = KarmaTo.Config.Modes.Combo;

//TODO :
// Draw W Range when is active

namespace KarmaTo.Modes
{
    public sealed class Combo : ModeBase
    {
        private static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }

        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            Orbwalker.DisableAttacking = false;
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && Settings.UseQ)
            {
                var pred = Q.GetPrediction(target);
                if (pred.HitChance >= (target.IsMoving ? HitChance.High : HitChance.Medium) && !pred.Collision)
                {
                    if (R.IsReady() && Settings.UseR)
                    {
                        R.Cast();
                    }
                    Q.Cast(pred.CastPosition);
                }
            }
            if(target.IsValidTarget(W.Range) && W.IsReady() && Settings.UseW)
            {
                W.Cast(target);
            }
        }
    }
}
