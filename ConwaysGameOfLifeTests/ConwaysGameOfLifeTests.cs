using System;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        [Fact]
        public void ShouldInitialiseWith50X30World()
        {
            var world = new World("50X30");
            
            Assert.Equal(1500, world.GetSize());
        }
        
        [Fact]
        public void ShouldInitialise50X80World()
        {
            var world = new World("50X80");
            
            Assert.Equal(4000, world.GetSize());
        }
    }
}