using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(m_Camera.transform.position, Vector3.up);
    }
}
