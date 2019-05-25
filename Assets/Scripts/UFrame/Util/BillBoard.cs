using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFrame.Util
{
    public class BillBoard : MonoBehaviour
    {
        Camera cam;
        Quaternion dir = Quaternion.identity;
        void Awake()
        {
            cam = Camera.main;
            dir = transform.rotation;

        }

        void Update()
        {

            transform.rotation = cam.transform.rotation * dir;

        }
    }

}
