using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask moveMask = default;
    [SerializeField] private PlayerMotor _playerMotor = default;
    private Camera cam = default;
    [SerializeField] private Interactable _focus = default;

    private void Awake()
    {
        cam = Camera.main;
        _playerMotor = GetComponent<PlayerMotor>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, moveMask))
            {
                _playerMotor.PointMove(hit.point);
                //PlayerMotor.Instance.PointMove(hit.point);
                // Stop foucsing any object
                Unfocusing();
            }
        }
    }

    public void Interact()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Focusing(interactable);
            }
        }
    }

    private void Focusing(Interactable newFocusing)
    {
        _focus = newFocusing;
        _playerMotor.FollowTarget(newFocusing);
    }

    private void Unfocusing()
    {
        _focus = null;
        _playerMotor.stopFollowTarget();
    }
}
