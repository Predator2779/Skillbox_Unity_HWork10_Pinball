using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube26 : MonoBehaviour
{
    [SerializeField] private Transform _plane;
    [SerializeField] private float _force = 100;
    private float _bumperScale = 1.1f;

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Q)) {            
            StartCoroutine(Scale());
        }
    }

    private void OnCollisionStay(Collision ball) {        
        if (Input.GetKey(KeyCode.Q)) {
            Vector3 bump = (_plane.transform.forward + _plane.transform.right);
            ball.rigidbody.AddForce(bump.normalized * _force, ForceMode.Impulse);
        }
    }

    IEnumerator Scale() {
        transform.localScale *= _bumperScale;
        yield return new WaitForSeconds(0.1f);
        transform.localScale /= _bumperScale;
    }
}
