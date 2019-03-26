using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        [Fact]
        public void ShouldInitialiseWith50X30World()
        {
            var world = new World(new Area{Length = 50, Width = 30});
            
            Assert.Equal(1500, world.GetSize());
        }
        
        [Fact]
        public void ShouldInitialise50X80World()
        {
            var world = new World(new Area{Length = 50, Width = 80});
            
            Assert.Equal(4000, world.GetSize());
        }
    }
}