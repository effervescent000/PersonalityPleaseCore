using Verse;

namespace Personality.Core;

public enum LovinContext
{
    SelfLovin,
    Casual,
    Intimate,
}

public class LovinProps
{
    public Pawn Actor;
    public Pawn Partner;
    public LovinContext Context;

    public LovinProps(LovinContext context, Pawn actor, Pawn partner = null)
    {
        this.Actor = actor;
        this.Partner = partner;
        this.Context = context;
    }
}