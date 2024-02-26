using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Personality.Core;

public class CoreMod : Mod
{
    public static CoreSettings Settings;

    public CoreMod(ModContentPack content) : base(content)
    {
        Settings = GetSettings<CoreSettings>();
    }
}