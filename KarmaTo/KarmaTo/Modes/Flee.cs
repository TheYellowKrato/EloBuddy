using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = KarmaTo.Config.Modes.Flee;

//TODO
//Use E on ally behind me 

namespace KarmaTo.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            Orbwalker.DisableAttacking = true;
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && Settings.UseQ)
            {
                var pred = Q.GetPrediction(target);
                if (pred.HitChance >= (target.IsMoving ? HitChance.High : HitChance.Medium))
                {
                    Q.Cast(pred.CastPosition);
                }
            }
            if (E.IsReady() && Settings.UseE)
            {
                if (R.IsReady())
                    R.Cast();
                E.Cast(ObjectManager.Player);
            }
        }
    }
}
