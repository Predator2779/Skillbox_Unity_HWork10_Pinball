//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SteeringWheel : MonoBehaviour
//{
//    [SerializeField] private Transform _wheel;
//    [SerializeField] private Transform _rover;

//    private void Update()
//    {
//        if (Input.GetKey(KeyCode.A))
//            KeyA_Down();
//        if (Input.GetKeyUp(KeyCode.A))
//            Key_Up();
//        if (Input.GetKey(KeyCode.D))
//            KeyD_Down();
//        if (Input.GetKeyUp(KeyCode.D))
//            Key_Up();
//    }

//    ///доделать свободное вращение колесы при повороте
//    private void KeyA_Down()
//    {
//        transform.localRotation = Quaternion.Euler(_wheel.transform.localRotation.x, _rover.transform.localRotation.y - 20f, 90f);
//    }

//    private void KeyD_Down()
//    {
//        transform.localRotation = Quaternion.Euler(Time.deltaTime * 10000 * (1), _rover.transform.localRotation.y + 20f, 90f);
//    }

//    private void Key_Up()
//    {
//        transform.localRotation = Quaternion.Euler(_wheel.transform.rotation.x, _wheel.transform.rotation.y, 90f);
//    }
//}
