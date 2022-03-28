using NUnit.Framework;
using Rover.Cli;
using Should;
using SpecsFor.StructureMap;

namespace Rover.Tests
{
    public class RoverPositioningSpecs
    {
        public class When_rover_moves_within_plateau : SpecsFor<RoverPositioning>
        {
            protected override void InitializeClassUnderTest()
            {
                var plateau = new MarsPlateau(10, 10);
                SUT = new RoverPositioning(plateau, 0, 0, "N");
            }

            protected override void When()
            {
                var seriesOfMoves = "mmrmll".ToCharArray();
                SUT.Move(seriesOfMoves);
            }

            [Test]
            public void Then_we_should_know_position_and_orientation()
            {
                SUT.Orientation.ShouldEqual("E");
                SUT.XCoordinate.ShouldEqual(1);
                SUT.YCoordinate.ShouldEqual(2);
            }
        }
    }
}