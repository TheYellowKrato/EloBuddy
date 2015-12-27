using EloBuddy.SDK;
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
            
        }
    }
}
