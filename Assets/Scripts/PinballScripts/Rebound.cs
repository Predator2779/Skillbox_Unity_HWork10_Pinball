using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebound : Bumper
{
    private void OnCollisionEnter(Collision ball) {
        Bumped(ball, this.transform);
        StartCoroutine(Scale());
    }

    IEnumerator Scale() {
        transform.parent.localScale *= _bumperScale;
        yield return new WaitForSeconds(0.1f);
        transform.parent.localScale /= _bumperScale;
    }
}
