using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public interface IParsingCommandChainLink
{
    void AddNext(IParsingCommandChainLink link);
    ParsingResult Handle(IEnumerator<string> word);
}