using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AIDash : AIAction
{
    public float DashDistance = 5f;
    public float DashSpeed = 20f;

    protected Vector3 _dashDirection;
    protected Character _character;
    protected CharacterMovement _characterMovement;
    protected Transform _target;

    public override void Initialization()
    {
        base.Initialization();
        _character = this.gameObject.GetComponent<Character>();
        _characterMovement = _character?.FindAbility<CharacterMovement>();
        _brain = this.gameObject.GetComponentInParent<AIBrain>(); // Add this line
        _target = _brain.Target;
    }

    public override void PerformAction()
    {
        LockOntoTarget();
        Dash();
    }

    protected void LockOntoTarget()
    {
        Vector3 _targetPosition = _target.position;
        _dashDirection = (_targetPosition - this.transform.position).normalized;
    }

    protected void Dash()
    {
        // Calculate the destination based on the locked target position
        Vector3 destination = this.transform.position + _dashDirection * DashDistance;

        // Dash towards the destination
        StartCoroutine(DashCoroutine(destination));
    }

    protected IEnumerator DashCoroutine(Vector3 destination)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = this.transform.position;

        while (elapsedTime < DashDistance / DashSpeed)
        {
            _characterMovement.SetMovement(_dashDirection * DashSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Stop the dash movement
        _characterMovement.SetMovement(Vector3.zero);
    }
}