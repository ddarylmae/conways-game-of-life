namespace ConwaysGameOfLife
{
    public interface IStateGenerator
    {
        IWorld GetNextWorldState(IWorld world);
    }
}