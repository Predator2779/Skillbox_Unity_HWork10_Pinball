using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFalse : MonoBehaviour
{
    private Collider _collider;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other) {
        _collider.isTrigger = false;
    }
}
