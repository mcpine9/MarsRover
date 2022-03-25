using NUnit.Framework;
using Rover.Cli;
using Should;
using SpecsFor.StructureMap;

namespace Rover.Tests
{
    public class MarsPlateauSpecs
    {
        public class WhenXyCoordinatesWithinPlateauAreGiven : SpecsFor<MarsPlateau>

        {
            private int roverX, roverY;
            protected override void InitializeClassUnderTest()
            {
                SUT = new MarsPlateau(5, 5);
            }

            protected override void When()
            {
                roverX = 1;
                roverY = 1;
            }

            [Test]
            public void then_IsCoordinatesWithinPlateauPlane_should_be_true()
            {
                var result = SUT.IsCoordinatesWithinPlateauPlane(roverX, roverY);
                result.ShouldBeTrue();
            }
        }
        public class WhenXyCoordinatesOutsideOdPlateauAreGiven : SpecsFor<MarsPlateau>

        {
            private int roverX, roverY;
            protected override void InitializeClassUnderTest()
            {
                SUT = new MarsPlateau(5, 5);
            }

            protected override void When()
            {
                roverX = 6;
                roverY = 1;
            }

            [Test]
            public void then_IsCoordinatesWithinPlateauPlane_should_be_false()
            {
                var result = SUT.IsCoordinatesWithinPlateauPlane(roverX, roverY);
                result.ShouldBeFalse();
            }
        }
    }
}