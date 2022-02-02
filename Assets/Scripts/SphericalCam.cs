using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCam : MonoBehaviour
{
    public Transform playSphere;
    public Transform cameraOrbit;
    public float rotateSpeed = 8f;

    private float _distanceCam;

    private void Start()
    {
        _distanceCam = Vector3.Distance(playSphere.transform.position, transform.position);
        cameraOrbit.position = playSphere.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;

            float h = rotateSpeed * Input.GetAxis("Mouse X");
            float v = rotateSpeed * Input.GetAxis("Mouse Y");

            if (cameraOrbit.transform.eulerAngles.z + v <= 0.1f || cameraOrbit.transform.eulerAngles.z + v >= 75.0f)
                v = 0;

            cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);
        }
        else
            Cursor.visible = true;

        cameraOrbit.transform.position = playSphere.position;       
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.LookAt(playSphere.position);       
    }

    private void FixedUpdate()
    {
        Vector3 to_camera = (transform.position - playSphere.transform.position) * _distanceCam;
        if (Physics.Raycast(playSphere.transform.position, to_camera, out RaycastHit hit, _distanceCam))
            transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
    }
}
