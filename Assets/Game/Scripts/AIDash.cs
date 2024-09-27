using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [AddComponentMenu("TopDown Engine/Character/AI/Actions/AIDash")]
    public class AIDash : AIAction
    {
        protected AIBrain _brain;
        protected Character _character;
        protected Vector3 _target;
        protected Vector3 _dashDirection;
        protected Vector3 _dashOrigin;
        protected Vector3 _dashDestination;
        protected float _dashTimer;
        public float DashDuration = 1f;  // Exposed to inspector
        public AnimationCurve DashCurve;  // Exposed to inspector
        protected Rigidbody rb; 


        public override void Initialization()
        {
            if (!ShouldInitialize) return;
            base.Initialization();
            _character = this.gameObject.GetComponentInParent<Character>();
            _brain = this.gameObject.GetComponentInParent<AIBrain>();
            rb = GetComponent<Rigidbody>();

        }

        /// <summary>
        /// Prepares the dash direction when entering the state
        /// </summary>
        public override void OnEnterState()
        {
            base.OnEnterState();
            _dashTimer = 0f;  // Reset dash timer

            // Calculate the dash origin and target destination
            _dashOrigin = transform.position;
            Debug.Log(_brain.Target.position);
            _target = _brain.Target.position;
            _dashDirection = (_target - _dashOrigin).normalized;  // Calculate direction to target

            _dashDestination = _dashOrigin + _dashDirection;
        }

        /// <summary>
        /// Handles the dashing behavior each frame
        /// </summary>
        public override void PerformAction()
        {

                // Calculate normalized progress along the dash
            float dashProgress = DashCurve.Evaluate(_dashTimer / DashDuration);

                // Move the player along the path using Lerp for smooth interpolation
            Vector3 _newPosition = Vector3.Lerp(_dashOrigin, _dashDestination, dashProgress);

                // Update the timer
            _dashTimer += Time.deltaTime;

                // Apply movement directly to transform position
            transform.position = _newPosition;
            Debug.Log("Dash");
            Debug.Log(_newPosition);
        }

        /// <summary>
        /// Called when exiting the state, if needed
        /// </summary>
        public override void OnExitState()
        {
            base.OnExitState();
            // Cleanup or transition actions after dash
        }
    }
}
