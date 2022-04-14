using System;
using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public class GameplayPadView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform knob;

        [SerializeField]
        private RectTransform background;

        private Dictionary<TouchPhase, Action> touchProcessor;
        private Pad pad;
        private TouchProvider touchProvider;
        private PlayerView playerView;

        private void Awake()
        {
            this.pad = new Pad();

            this.touchProvider = GameplayPadProvider.GetPadImplementation();


            this.touchProcessor = new Dictionary<TouchPhase, Action> {
                { TouchPhase.Began, this.RegisterJustTouched },
                { TouchPhase.Moved, this.RegisterTouched },
                { TouchPhase.Stationary, this.RegisterTouched },
                { TouchPhase.Canceled, this.ReleaseTouch },
                { TouchPhase.Ended, this.ReleaseTouch },
            };

            this.ShowPad(false);
        }

        private void ShowPad(bool hasToShow = true)
        {
            this.knob.gameObject.SetActive(hasToShow);
            this.background.gameObject.SetActive(hasToShow);
        }

        public void SetUp()
        {
            this.playerView = GameControllerLocator.GetInstance()
                .GetController<PlayerView>();
        }

        private void RegisterJustTouched()
        {
            this.EnsureIsReleased();
            this.pad.RegisterJustTouched(this.touchProvider.GetTouchPosition());
            this.ShowPad();
            this.UpdatePadPositon();
        }

        private void EnsureIsReleased()
        {
            if (this.pad.IsRegistred())
            {
                this.ReleaseTouch();
            }
        }

        private void ReleaseTouch()
        {
            this.pad.RegisterReleaseTouch();
            this.ShowPad(false);
        }

        private void UpdatePadPositon()
        {
            var knobPosition = this.pad.GetKnobPosition();
            this.knob.position = knobPosition;
            this.background.position = knobPosition;
        }

        private void RegisterTouched()
        {
            this.EnsureIsRegistred();
            var touchedPosition = this.touchProvider.GetTouchPosition();
            this.pad.RegisterTouched(touchedPosition);
            this.knob.position = touchedPosition;

            var direction = this.pad.GetDireciton();
            var movementRequest = new MovementRequest();
            movementRequest.SetHorizontal(direction.x);
            movementRequest.SetForward(direction.y);
            this.playerView.RequestMovement(movementRequest);
        }

        private void EnsureIsRegistred()
        {
            if (!this.pad.IsRegistred())
            {
                this.RegisterJustTouched();
            }
        }

        private void Update()
        {
            if (this.touchProvider.GetTouchCount() == 0)
            {
                return;
            }

            this.touchProcessor[this.touchProvider.GetTouchPhase()]();
        }
    }
}
