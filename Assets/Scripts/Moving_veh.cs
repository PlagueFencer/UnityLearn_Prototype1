using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Moving_veh : MonoBehaviour
{
    // Private Variables
    private float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        //Moving forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}

