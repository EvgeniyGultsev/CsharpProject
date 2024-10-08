﻿namespace Contracts.Logging;

public abstract record LoginResult
{
    private LoginResult() { }
    public sealed record Success : LoginResult;

    public sealed record Fail : LoginResult;
}