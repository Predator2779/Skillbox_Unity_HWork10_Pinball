using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpForBall : MonoBehaviour
{

    [SerializeField] Transform _anchor;
    [SerializeField] Collider _cube32;
    [SerializeField] float _pullFactor = 0.01f;

    private SpringJoint _springJoint;
    private Rigidbody _springRigidbody;

    private void Start() {
        _springJoint = GetComponent<SpringJoint>();
        _springRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space))
            Pulling();
        if (Input.GetKeyUp(KeyCode.Space))
            _springJoint.spring = 100000;
         
        if (transform.localPosition.z >= -1.67 && transform.localPosition.z <= -1.64)
            _springRigidbody.mass = 1000;
    }


    /// <summary>
    /// Cжатие пружины до якоря.
    /// PullFactor - величина сжатия.
    /// </summary>
    private void Pulling() {
        _springRigidbody.mass = 1;
        _springJoint.spring = 0;
        transform.position += new Vector3(0, 0, _pullFactor);            

        if (transform.position.z >= _anchor.transform.position.z)
            transform.position = _anchor.transform.position;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 3)
            _cube32.isTrigger = true;
    }
}
