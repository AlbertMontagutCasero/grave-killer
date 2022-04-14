using System;
using UnityEngine;

namespace GraveKiller
{
    public class Pad
    {
        private bool registred;
        private Vector2? startPosition;
        private Vector2? knobPosition;
        private Vector2? direction;

        public bool IsRegistred()
        {
            return this.registred;
        }
        
        public void RegisterJustTouched(Vector2 position)
        {
            if (this.registred)
            {
                throw new InvalidOperationException(
                    "Start position shouldn't be set before calling it. Maybe you should call RegisterReleaseTouch() before");
            }

            this.registred = true;
            this.startPosition = position;
            this.knobPosition = position;
            this.CalculateDirection();
        }
        
        private void CalculateDirection()
        {
            if (!this.registred)
            {
                throw new InvalidOperationException(
                    "You should call RegisterJustTouched before registring new touches.");
            }
            
            this.direction = (this.knobPosition.Value - this.startPosition.Value).normalized;
        }
        
        public void RegisterTouched(Vector2 touchedPosition)
        {
            if (!this.registred)
            {
                throw new InvalidOperationException(
                    "You should call RegisterJustTouched before registring new touches.");
            }

            this.knobPosition = touchedPosition;
            this.CalculateDirection();
        }

        public Vector2 GetKnobPosition()
        {
            if (!this.registred)
            {
                throw new InvalidOperationException(
                    "The pad is never touched. Considere calling RegisterJustTouched before trying to get the KnobPosition.");
            }

            return this.knobPosition.Value;
        }

        public Vector2 GetDireciton()
        {
            if (!this.registred)
            {
                throw new InvalidOperationException(
                    "The pad is never touched. Considere calling RegisterJustTouched before trying to get the direction.");
            }

            return this.direction.Value;
        }

        public void RegisterReleaseTouch()
        {
            this.direction = null;
            this.startPosition = null;
            this.knobPosition = null;
            this.registred = false;
        }

        public Vector2 GetFirstTouchedPosition()
        {
            if (!this.registred)
            {
                throw new InvalidOperationException(
                    "The pad is never touched. Considere calling RegisterJustTouched before trying to get the start position.");
            }
            
            return this.startPosition.Value;
        }
    }
}
