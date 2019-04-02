namespace ConwaysGameOfLife
{
    public interface IStateGenerator
    {
        IWorld Evolve(IWorld currentWorld);
    }
}