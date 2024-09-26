using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
	/// <summary>
	/// An AIACtion used to have an AI start running
	/// </summary>
	[AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionRunStart")]
    public class AIDash : AIAction
    {
        AIBrain _brain;
        Vector3 _target;
        Vector3 _dashDirection;
        Character _character;
        CharacterDash3D _characterDash;
        float _dashTimer;

        public override void Initialization()
        {
            if(!ShouldInitialize) return;
            base.Initialization();
            _character = this.gameObject.GetComponentInParent<Character>();
            _characterDash = _character?.FindAbility<CharacterDash3D>();
        }

        void dash()
        {
            _target = _brain.Target.position;
            _dashDirection.x = -1 * (_target.x - transform.position.x);
            _dashDirection.y = transform.position.y;
            _dashDirection.z = -1 * (_target.z - transform.position.z);
        }


        public override void PerformAction()
        {
            // Check if dash is still within duration
                if (_dashTimer < DashDuration)
                {
        // Calculate normalized progress along the dash
                float dashProgress = DashCurve.Evaluate(_dashTimer / DashDuration);

        // Move the player along the path using Lerp for smooth interpolation
                _newPosition = Vector3.Lerp(_dashOrigin, _dashDestination, dashProgress);

        // Update the timer
                _dashTimer += Time.deltaTime;

                _controller.MovePosition(_newPosition);  // Or move however fits your system
                }
                else
                {
                    _dashTimer = 0f;
                }
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
        }

    }
}



