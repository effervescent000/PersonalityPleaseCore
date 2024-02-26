using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Personality.Core;

public static class CoreGeneralHelper
{
    public static float DistanceBetweenColors(Color a, Color b)
    {
        return Math.Abs(a.r - b.r) + Math.Abs(a.g - b.g) + Math.Abs(a.b - b.b);
    }

    public static int GetHourBasedDuration(float hourMulti, float lowerBound = 0.5f, float upperBound = 1.5f)
    {
        return (int)(GenDate.TicksPerHour * hourMulti * Rand.Range(lowerBound, upperBound));
    }
}