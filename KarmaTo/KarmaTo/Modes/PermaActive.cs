using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using System.Linq;
//using Settings = KarmaTo.Config.Modes.PermaActive;

//TODO :
//Shield ally before he takes damage from turret
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
            Obj_AI_Base.OnProcessSpellCast += autoShield;
        }
        //Seems to be the cause of FPS drop
        private void autoShield(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (E.IsReady())
            {
                if (!args.SData.IsAutoAttack() &&
                    sender.IsEnemy && args.Target != null &&
                    args.Target is AIHeroClient &&
                    (args.Target as AIHeroClient).IsAlly &&
                    (args.Target as AIHeroClient).IsValidTarget(SpellManager.E.Range))
                {
                    E.Cast((Obj_AI_Base)args.Target);
                }
            }
        }
    }
}
