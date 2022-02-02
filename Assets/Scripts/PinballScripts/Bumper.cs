using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float _force = 100;
    public float _bumperScale = 1.1f;
    public ForceMode _forceMode = ForceMode.Impulse;

    private void OnCollisionEnter(Collision ball) {
        Bumped(ball, this.transform);
        StartCoroutine(Scale());
    }

    public void Bumped(Collision ball, Transform obj) {
        Vector3 bump = obj.transform.position - ball.transform.position;
        ball.rigidbody.AddForce(bump.normalized * _force, _forceMode);        
    }

    IEnumerator Scale() {
        transform.localScale *= _bumperScale;
        yield return new WaitForSeconds(0.1f);
        transform.localScale /= _bumperScale;
    }
}
