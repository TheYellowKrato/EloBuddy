using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KarmaTo
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Active R { get; private set; }

        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 950, SkillShotType.Linear, 250, 1500, 100);
            W = new Spell.Targeted(SpellSlot.W, 675);
            E = new Spell.Targeted(SpellSlot.E, 800);
            R = new Spell.Active(SpellSlot.R);
        }

        public static void castR()
        {
            if (R.IsReady())
            {
                R.Cast();
            }
        }

        public static void castE(Obj_AI_Base target,bool useR)
        {
            if(E.IsReady() && target.IsValidTarget(E.Range))
            {
                if (useR)
                    castR();
                E.Cast(target);
            }
        }

        public static void castQ(Obj_AI_Base target, bool useR, double predictionHitChance)
        {
            if (Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                var pred = Q.GetPrediction(target);
                //No collisions we cast it directly
                if (pred.HitChancePercent >= predictionHitChance && !pred.Collision)
                {
                    if (useR)
                        castR();
                    Q.Cast(pred.CastPosition);
                }
                //Collisions : Damn we need to reflect ...
                else
                {

                    var collisions = pred.CollisionObjects;
                    foreach (Obj_AI_Base objet in collisions)
                    {
                        if (objet is Obj_AI_Minion)
                        {

                            if (target.Distance(objet) <= (objet as Obj_AI_Minion).BoundingRadius + target.BoundingRadius)
                            {
                                if (useR)
                                    castR();
                                Q.Cast(objet);
                            }
                        }
                        else if (objet is AIHeroClient)
                        {
                            var predObj = Q.GetPrediction(objet);
                            if (pred.HitChance >= (objet.IsMoving ? HitChance.High : HitChance.Medium))
                            {
                                if (useR)
                                    castR();
                                Q.Cast(predObj.CastPosition);
                            }
                        }
                    }
                }
            }
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
