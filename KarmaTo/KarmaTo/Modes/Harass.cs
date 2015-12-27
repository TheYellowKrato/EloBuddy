using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = KarmaTo.Config.Modes.Harass;

//TODO : 
//DISABLE LAST HIT MINION

namespace KarmaTo.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            Orbwalker.DisableAttacking = false;
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana)
            {
                var pred = Q.GetPrediction(target);
                if (pred.HitChance >= (target.IsMoving ? HitChance.High : HitChance.Medium))
                {
                    if (R.IsReady() && Settings.UseR)
                    {
                        R.Cast();
                    }
                    Q.Cast(pred.CastPosition);
                }
            }
        }
    }
}
