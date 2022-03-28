using NUnit.Framework;
using Rover.Cli;
using Should;
using SpecsFor.StructureMap;
using System.Collections.Generic;

namespace Rover.Tests
{
    public class RoverPositioningSpecs
    {
        public class When_rover_moves_within_plateau : SpecsFor<RoverPositioning>
        {
            protected override void Given()
            {
                var plateau = new MarsPlateau(10, 10);
                SUT.XCoordinate = 0;
                SUT.YCoordinate = 0;
                SUT.Orientation = "N";
            }

            public void When()
            {
                var seriesOfMoves = new List<PositioningSeriesType>
                {
                    PositioningSeriesType.M,
                    PositioningSeriesType.M,
                    PositioningSeriesType.R,
                    PositioningSeriesType.M,
                    PositioningSeriesType.R,
                    PositioningSeriesType.L
                };
                SUT.Move(seriesOfMoves);
            }

            [Test]
            public void Then_we_should_know_position_and_orientation()
            {
                SUT.Orientation.ShouldEqual("E");
                SUT.XCoordinate.ShouldEqual(2);
                SUT.YCoordinate.ShouldEqual(1);
            }
        }
    }
}