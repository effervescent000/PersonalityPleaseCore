using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Personality.Core;

public static class CoreGeneralHelper
{
    public static float DistanceBetweenColors(Color a, Color b)
    {
        return Math.Abs(a.r - b.r) + Math.Abs(a.g - b.g) + Math.Abs(a.b - b.b);
    }
}