using System;
using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class PadTests
    {
        [Test]
        public void RegisterJustTouchedAndGetKnobPosition_ShouldBeTheTouchedPosition()
        {
            // Arrange
            var sut = new Pad();

            // Act
            var touchedPosition = new Vector2(0, 5);
            sut.RegisterJustTouched(touchedPosition);
            var result = sut.GetKnobPosition();
            
            // Assert
            var expectedPosition = touchedPosition;
            Assert.That(result.Equals(expectedPosition));
        }

        [Test]
        public void GetKnobPositionAfterMultipleTouches_ShouldBeTheLastTouchedPosition()
        {
            // Arrange
            var sut = new Pad();

            // Act
            var touchedPosition = new Vector2(0, 5);
            sut.RegisterJustTouched(touchedPosition);
            var lastTouchedPosition = new Vector2(0, 6);
            sut.RegisterTouched(lastTouchedPosition);

            // Assert
            var result = sut.GetKnobPosition();
            Assert.That(result.Equals(lastTouchedPosition));
        } 
        
        [Test]
        public void GetDirectionAfterMultipleTouches_ShouldBeTheDirectionFromTheCenter()
        {
            // Arrange
            var sut = new Pad();

            // Act
            var touchedPosition = new Vector2(-2, -5);
            sut.RegisterJustTouched(touchedPosition);
            touchedPosition = new Vector2(-3, -5);
            sut.RegisterTouched(touchedPosition);
            var result = sut.GetDireciton();

            // Assert
            var expectedResult = new Vector2(-1, 0);
            Assert.That(result.Equals(expectedResult));
        }
        
        [Test]
        public void TouchingThenMovingAndGetFirstTouchedPosition_ShouldBeTheFirstTouchedPosition()
        {
            // Arrange
            var sut = new Pad();

            // Act
            var firstTouchedPosition = new Vector2(-2, -5);
            sut.RegisterJustTouched(firstTouchedPosition);
            var touchedPosition = new Vector2(-3, -5);
            sut.RegisterTouched(touchedPosition);
            var result = sut.GetFirstTouchedPosition();

            // Assert
            var expectedResult = firstTouchedPosition;
            Assert.That(result.Equals(expectedResult));
        }

        [Test]
        public void WhenRegistringJustTouchedTwiceOrMoreWithoutRelease_ThenShouldThrowAnInvalidOperation()
        {
            // Arrange
            var sut = new Pad();
            var someTouchPosition = Vector2.zero;

            // Act
            var act = new Action(() =>
            {
                sut.RegisterJustTouched(someTouchPosition);
                sut.RegisterReleaseTouch();
                sut.RegisterJustTouched(someTouchPosition);
            });
                
            // Assert
            Assert.That(act.Invoke, Throws.Nothing);
        }
        
        [Test]
        public void WhenRegistringJustTouchedRelasingAndRegistring_ThenShouldBeAllowed()
        {
            // Arrange
            var sut = new Pad();
            var someTouchPosition = Vector2.zero;

            // Act
            var act = new Action(() =>
            {
                sut.RegisterJustTouched(someTouchPosition);
                sut.RegisterJustTouched(someTouchPosition);
            });
                
            // Assert
            Assert.That(act.Invoke, Throws.InvalidOperationException);
        }
    }
}
