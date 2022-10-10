using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform _targetFollow = default;
    private NavMeshAgent _moveAgent = default;

    private void Awake()
    {
        _moveAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_targetFollow != null)
        {
            _moveAgent.SetDestination(_targetFollow.position);
        }
    }

    public void PointMove(Vector3 point)
    {
        _moveAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newfollowTarget)
    {
        _targetFollow = newfollowTarget.transform;
    }

    public void stopFollowTarget()
    {
        _targetFollow = null;
    }
    
}
