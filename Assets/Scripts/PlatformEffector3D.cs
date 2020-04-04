using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffector3D : MonoBehaviour
{

    private Collider[] colliders;
    public Transform checkPoint;
    public LayerMask mask;
    private bool enter;

    // Update is called once per frame
    void FixedUpdate()
    {
        // need to set players layer to Player
        colliders = Physics.OverlapBox(checkPoint.position, transform.localScale, Quaternion.identity, mask);
        if (colliders.Length <= 0) {
            GetComponent<Collider>().isTrigger = true;
        } else {
            if (!enter) {
                GetComponent<Collider>().isTrigger = false;
            }
        }
    
    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerController>()) {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            enter = false;

            if (colliders.Length > 0) {
                GetComponent<Collider>().isTrigger = false;
            } else {
                GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
