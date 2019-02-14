namespace Resolver.Contracts
{
    public interface IResolver
    {
        string Name { get; }
        int[] Resolve(int[] input);
    }
}
