using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Personality.Core;

public static class PawnExtensions
{
    private static List<string> queerDefNames = new()
    {
        TraitDefOf.Gay.defName, TraitDefOf.Bisexual.defName, TraitDefOf.Asexual.defName
    };

    public static bool IsOk(this Pawn pawn)
    {
        if (pawn == null || pawn.health.Downed || pawn.health.Dead) return false;

        return true;
    }

    public static bool IsBloodRelatedTo(this Pawn pawn, Pawn target)
    {
        List<Pawn> familyMembers = (from member in pawn.relations.FamilyByBlood
                                    where member.ThingID == target.ThingID
                                    select member).ToList();

        if (familyMembers.Count > 0) { return true; }
        return false;
    }

    public static void ThrowHeart(this Pawn pawn)
    {
        FleckMaker.ThrowMetaIcon(pawn.Position, pawn.Map, FleckDefOf.Heart);
    }

    public static bool IsAsexual(this Pawn pawn)
    {
        if (pawn?.story?.traits != null)
        {
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def.defName == TraitDefOf.Asexual.defName) { return true; }
            }
        }
        return false;
    }

    public static bool IsGay(this Pawn pawn)
    {
        if (pawn?.story?.traits != null)
        {
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def.defName == TraitDefOf.Gay.defName) { return true; };
            }
        }
        return false;
    }

    public static bool IsStraight(this Pawn pawn)
    {
        if (pawn?.story?.traits != null)
        {
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (queerDefNames.Contains(trait.def.defName)) { return false; }
            }
        }
        return true;
    }

    public static bool IsBisexual(this Pawn pawn)
    {
        if (pawn?.story?.traits != null)
        {
            foreach (var trait in pawn.story.traits.allTraits)
            {
                if (trait.def.defName == TraitDefOf.Bisexual.defName) { return true; }
            }
        }
        return false;
    }
}