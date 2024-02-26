using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Personality.Core;

[StaticConstructorOnStartup]
public static class OnStartup
{
    static OnStartup()
    {
        if (ModsConfig.IsActive("effervescent.personalityplease"))
        {
            CoreSettings.MainModuleActive = true;
        }
        if (ModsConfig.IsActive("effervescent.personalityplease.romance"))
        {
            CoreSettings.RomanceModuleActive = true;
        }
        if (ModsConfig.IsActive("effervescent.personalityplease.lovin"))
        {
            CoreSettings.LovinModuleActive = true;
        }
    }
}