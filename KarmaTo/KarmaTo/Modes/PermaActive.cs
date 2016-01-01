using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;

using Settings = KarmaTo.Config.Modes.PermaActive;

namespace KarmaTo.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {

        }
        public void onSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!Settings.autoShieldSpell)
                return;
            if (sender.Team != Utils.getPlayer().Team && args.Target != null && (args.Target as AIHeroClient).IsValidTarget(SpellManager.E.Range))
            {
                if (sender is AIHeroClient)
                {
                    E.Cast((Obj_AI_Base)args.Target);
                }
            }
        }

        public void OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!Settings.autoShieldTurret)
                return;
            if (E.IsReady())
            {
                if (sender is Obj_AI_Turret)
                {
                    if (sender.IsEnemy && args.Target != null &&
                        args.Target is AIHeroClient &&
                        (args.Target as AIHeroClient).IsValidTarget(SpellManager.E.Range))
                    {
                        E.Cast((Obj_AI_Base)args.Target);
                        return;
                    }
                }
            }
        }
    }
}
