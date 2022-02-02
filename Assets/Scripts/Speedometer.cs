using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text speedometer;

    public float CurrentSpeed
    {
        get { return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; }
    }

    void Update()
    {
        speedometer.text = ($"{Mathf.RoundToInt(CurrentSpeed)} km/h");
    }
}