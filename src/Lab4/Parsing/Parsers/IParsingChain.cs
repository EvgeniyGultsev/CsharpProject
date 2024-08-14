using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public interface IParsingChain<TBuilder>
{
    void AddNext(IParsingChain<TBuilder> link);
    ParsingArgumentResult Handle(IEnumerator<string> command, TBuilder builder);
}