using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : Bumper
{
    [SerializeField] private float _seconds = 1.5f;

    private void OnTriggerStay(Collider ball) {
        StartCoroutine(Kick(ball));
    }

    IEnumerator Kick(Collider ball) {
        yield return new WaitForSeconds(_seconds);

        ball.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * _force, mode: _forceMode);
    }
}
