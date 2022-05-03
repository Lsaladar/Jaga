using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AllInteractions))]
public class Door : MonoBehaviour
{
    public bool open = false;
    public Transform pivot;

    private Transform ogRotation;

    // Start is called before the first frame update
    void Start()
    {
        ogRotation.rotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && gameObject.transform.rotation.y != 90)
        {
            transform.RotateAround(pivot.position, Vector3.up, 30 * Time.deltaTime);
        }
        //else
        //{

        //}

    }
}
