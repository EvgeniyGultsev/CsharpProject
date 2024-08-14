using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.ConnectParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileCopyParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileDeleteParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileMoveParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileRenameParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.FileShowParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.TreeGoToParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers.TreeListParser;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;
using Itmo.ObjectOrientedProgramming.Lab4.Reader;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        // first connect link
        IParsingChain<ConnectModel.Builder> connectParsingChain = new ConnectPathParser();
        connectParsingChain.AddNext(new ConnectMFlagParser());

        // second disconnect link
        IParsingCommandChainLink startChain = new ConnectParserChainLink(connectParsingChain);
        startChain.AddNext(new DisconnectParserChainLink());

        // third tree link
        IParsingCommandChainLink goTo = new GoToParserChainLink(new TreeGoToPathParser());
        goTo.AddNext(new ListParserChainLink(new TreeListDepthParser()));
        IParsingCommandChainLink tree = new TreeParserChainLink(goTo);
        startChain.AddNext(tree);

        // fourth file parsers
        IParsingCommandChainLink copy = new CopyParserChainLink(new FileCopyPathParser());
        copy.AddNext(new DeleteParserChainLink(new FileDeletePathParser()));
        copy.AddNext(new MoveParserChainLink(new FileMovePathParser()));
        copy.AddNext(new RenameParserChainLink(new FileRenamePathNameParser()));

        IParsingChain<FileShowModel.Builder> showParsingChain = new FileShowPathParser();
        showParsingChain.AddNext(new FileShowMFlagParser());
        copy.AddNext(new ShowParserChainLink(showParsingChain));

        IParsingCommandChainLink file = new FileParserChainLink(copy);

        startChain.AddNext(file);
        IReader reader = new ConsoleReader();
        IContext context = new Context.Context(new Signs("Dir: ", "File: ", "-"));

        // while (true)
        // {
        IEnumerator<string> enumerator = reader.Read().Split().ToList().GetEnumerator();
        enumerator.MoveNext();
        ParsingResult parsingResult = startChain.Handle(enumerator);
        switch (parsingResult)
            {
                case ParsingResult.Fail:
                    Console.WriteLine("Failed to handle the command");
                    break;
                case ParsingResult.Success success:
                {
                    CommandExecutingResult result = success.Command.Execute(context);
                    if (result is CommandExecutingResult.Fail executingFail)
                    {
                        Console.WriteLine(executingFail);
                    }

                    break;
                }
            }

        // }
    }
}