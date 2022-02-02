using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOnTheGround : MonoBehaviour
{    
    private void Update() {
        if (transform.position.y >= 15.7f)
            transform.position = new Vector3(transform.position.x, 15f, transform.position.z);
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            var yPos = collision.transform.position.y + transform.localScale.y;

            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
