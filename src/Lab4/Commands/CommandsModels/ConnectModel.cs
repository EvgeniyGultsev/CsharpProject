using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
[GenerateBuilder]
public partial record ConnectModel(string Address, Mode MFlag);