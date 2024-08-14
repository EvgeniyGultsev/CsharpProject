using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
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
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTest
{
    private readonly IParsingCommandChainLink _startChain;
    public ParserTest()
    {
        // first connect link
        IParsingChain<ConnectModel.Builder> connectParsingChain = new ConnectPathParser();
        connectParsingChain.AddNext(new ConnectMFlagParser());

        // second disconnect link
        _startChain = new ConnectParserChainLink(connectParsingChain);
        _startChain.AddNext(new DisconnectParserChainLink());

        // third tree link
        IParsingCommandChainLink goTo = new GoToParserChainLink(new TreeGoToPathParser());
        goTo.AddNext(new ListParserChainLink(new TreeListDepthParser()));
        IParsingCommandChainLink tree = new TreeParserChainLink(goTo);
        _startChain.AddNext(tree);

        // fourth file parsers
        IParsingCommandChainLink copy = new CopyParserChainLink(new FileCopyPathParser());
        copy.AddNext(new DeleteParserChainLink(new FileDeletePathParser()));
        copy.AddNext(new MoveParserChainLink(new FileMovePathParser()));
        copy.AddNext(new RenameParserChainLink(new FileRenamePathNameParser()));

        IParsingChain<FileShowModel.Builder> showParsingChain = new FileShowPathParser();
        showParsingChain.AddNext(new FileShowMFlagParser());
        copy.AddNext(new ShowParserChainLink(showParsingChain));

        IParsingCommandChainLink file = new FileParserChainLink(copy);

        _startChain.AddNext(file);
    }

    [Theory]

    [InlineData("connect c:\\ -m local", typeof(ConnectCommand))]
    [InlineData("disconnect", typeof(DisconnectCommand))]
    [InlineData("tree list -d 2", typeof(TreeListCommand))]
    [InlineData("file show c:\\a.txt -m console", typeof(FileShowCommand))]
    [InlineData("tree goto c:\\a.txt", typeof(TreeGoToCommand))]
    [InlineData("file move a.txt c:\\b\\a.txt", typeof(FileMoveCommand))]
    [InlineData("file copy c:\\a.txt a.txt", typeof(FileCopyCommand))]
    [InlineData("file delete c:\\a.txt", typeof(FileDeleteCommand))]
    [InlineData("file rename c:\\a.txt b.txt", typeof(FileRenameCommand))]
#pragma warning disable CA1707
    public void GetCommand_ShouldReturnSuccess_IfCommandIsRight(string input, Type commandType)
#pragma warning restore CA1707
    {
        // Arrange
        ParsingResult parsingResult;
        IEnumerator<string> enumerator;

        // Act
        enumerator = input.Split().ToList().GetEnumerator();
        enumerator.MoveNext();
        parsingResult = _startChain.Handle(enumerator);

        // Assert
        Assert.IsType<ParsingResult.Success>(parsingResult);
        var success = parsingResult as ParsingResult.Success;
        Assert.Same(commandType, success?.Command.GetType());
    }
}