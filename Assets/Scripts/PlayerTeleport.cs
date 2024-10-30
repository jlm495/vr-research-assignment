using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;

    [SerializeField]
    private LayerMask teleportMask;

    [SerializeField]
    private InputActionReference teleportButtonPress;

    void Start(){

        teleportButtonPress.action.performed += DoRaycast;
    }

    void DoRaycast(InputAction.CallbackContext _){

        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask);

        if (didHit){

            Debug.Log(hit.collider.gameObject.name);
            playerOrigin.transform.position = hit.collider.gameObject.transform.position;

        }
    }


}
