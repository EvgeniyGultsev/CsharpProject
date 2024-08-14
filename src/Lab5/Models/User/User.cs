namespace Models.User;

public abstract record User
{
    private User() { }
    public sealed record Card(long CardId, int PinCode) : User;

    public sealed record Admin : User;
}