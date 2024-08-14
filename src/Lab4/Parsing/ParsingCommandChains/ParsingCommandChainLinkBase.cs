using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public abstract class ParsingCommandChainLinkBase : IParsingCommandChainLink
{
    protected IParsingCommandChainLink? Next { get; private set; }
    public void AddNext(IParsingCommandChainLink link)
    {
        if (Next is null)
            Next = link;
        else
            Next.AddNext(link);
    }

    public abstract ParsingResult Handle(IEnumerator<string> word);
}