using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Personality.Core;

public class CoreSettings : ModSettings
{
    public SettingValues<int> MaxInteractionDistance = new(100, "PP.MaxInteractDistance.Label", "PP.MaxInteractDistance.Desc", 50, 500);

    // pregnancy settings

    public SettingValues<int> CasualLovinPregnancyChance = new(5, "PP.CasualLovinPregChance.Label", "PP.CasualLovinPregChance.Desc", 0, 100);
    public SettingValues<int> IntimateLovinPregnancyChance = new(5, "PP.IntimateLovinPregChance.Label", "PP.IntimateLovinPregChance.Desc", 0, 100);
    public SettingValues<int> SeducedLovinPregnancyChance = new(5, "PP.SeducedLovinPregChance.Label", "PP.SeducedLovinPregChance.Desc", 0, 100);

    // not set by user -------------------------------------------

    public static bool MainModuleActive = false;
    public static bool RomanceModuleActive = false;
    public static bool LovinModuleActive = false;

    public override void ExposeData()
    {
        base.ExposeData();
        if (RomanceModuleActive)
        {
            Scribe_Values.Look(ref CasualLovinPregnancyChance.Value, "casualLovinPregnancyChance", 5);
            Scribe_Values.Look(ref IntimateLovinPregnancyChance.Value, "intimateLovinPregnancyChance", 5);
        }
        if (LovinModuleActive)
        {
            Scribe_Values.Look(ref SeducedLovinPregnancyChance.Value, "seducedLovinPregnancyChance", 5);
        }
    }
}