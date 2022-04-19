using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAI2 : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;
    public float MinDist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }
}
