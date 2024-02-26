using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Personality.Core;

public static class CoreLovinHelper
{
    public static bool DoesOrientationMatch(Pawn actor, Pawn target, bool asexualityBlocks = false)
    {
        if (asexualityBlocks && actor.IsAsexual()) { return false; }

        if (actor.IsStraight() && actor.gender == target.gender) { return false; }

        if (actor.IsGay() && actor.gender != target.gender) { return false; }

        // if none of the ifs fail, then it's a match
        return true;
    }

    public static Building_Bed FindBed(Pawn actor, Pawn partner = null)
    {
        // find literally any bed
        List<Building_Bed> beds = actor.Map.listerBuildings.AllBuildingsColonistOfClass<Building_Bed>().ToList();
        if (beds.Count > 0)
        {
            return beds[0];
        }
        return null;
    }

    public static bool IsInOrByBed(Building_Bed bed, Pawn pawn)
    {
        for (int i = 0; i < bed.SleepingSlotsCount; i++)
        {
            if (bed.GetSleepingSlotPos(i).InHorDistOf(pawn.Position, 1f))
            {
                return true;
            }
        }
        return false;
    }

    public static bool CheckForPregnancy(Pawn pawn, Pawn partner, float basePregChance)
    {
        // leaving these separated out in case I decided to add some more modifiers later
        float updatedChance = basePregChance * pawn.GetStatValue(StatDefOf.Fertility) * partner.GetStatValue(StatDefOf.Fertility);
        return Rand.Value < updatedChance;
    }

    public static float GetPregnancyChance(LovinContext context)
    {
        CoreSettings settings = CoreMod.Settings;
        switch (context)
        {
            case LovinContext.Casual:
                return settings.CasualLovinPregnancyChance.Value / 100f;

            case LovinContext.Intimate:
                return settings.IntimateLovinPregnancyChance.Value / 100f;

            default:
                return .05f;
        }
    }

    public static void TryPregnancy(LovinProps props)
    {
        if (props.Actor.gender == Gender.Female && props.Partner.gender == Gender.Male)
        {
            bool gotPregnant = CheckForPregnancy(props.Actor, props.Partner, GetPregnancyChance(props.Context));
            if (gotPregnant)
            {
                GeneSet geneSet = PregnancyUtility.GetInheritedGeneSet(props.Partner, props.Actor, out bool ableToGenerateBaby);
                if (ableToGenerateBaby)
                {
                    Hediff_Pregnant pregnancy = (Hediff_Pregnant)HediffMaker.MakeHediff(HediffDefOf.PregnantHuman, props.Actor);
                    pregnancy.SetParents(null, props.Partner, geneSet);
                    props.Actor.health.AddHediff(pregnancy);
                }
            }
        }
    }
}