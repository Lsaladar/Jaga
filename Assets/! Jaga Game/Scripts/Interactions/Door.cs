using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AllInteractions))]
public class Door : MonoBehaviour
{
    public bool open = false;
    public Transform pivot;

    [Range(10, 100)] public int rotationSpeed;

    public float duration = 10f;
    private float openCounter = 0f;
    private float closeCounter = 0f;
    private float wait = 0f;

    private Vector3 ogRotation;

    // Start is called before the first frame update
    void Start()
    {
        ogRotation = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            openCounter = 0f;
            wait = 0f;
            closeCounter = 0f;
        }

        if (open && openCounter <= duration)
        {
            openCounter += Time.deltaTime;
            transform.RotateAround(pivot.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (openCounter >= duration && wait <= 3f)
        {
            wait += Time.deltaTime;
        }
        
        if (wait >= 3f && closeCounter <= duration)
        {
            closeCounter += Time.deltaTime;
            transform.RotateAround(pivot.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (closeCounter >= duration)
        {
            open = false;
        }

    }
}
