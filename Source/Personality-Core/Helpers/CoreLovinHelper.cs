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
}