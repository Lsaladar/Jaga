using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class YAI2 : MonoBehaviour
{
    public GameObject yagaDest;
    NavMeshAgent yagaAgent;
    [SerializeField] private GameObject[] des;
    [SerializeField] private int rand;
    public static bool isStalking;

    void Start()
    {
        yagaAgent = GetComponent<NavMeshAgent>();
        isStalking = false;
    }

    void Update()
    {
        if (isStalking)
        {
            yagaAgent.SetDestination(yagaDest.transform.position);
        }
        else
        {
            YagaIdle();
        }
        

    }

    void YagaIdle()
    {
        yagaAgent.enabled = true;
        int rand = Random.Range(0, 9);
        yagaAgent.destination = des[rand].transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesPoints")
        {
            yagaAgent.enabled = false;
            FunctionTimer.Create(YagaIdle, Random.Range(5f, 10f));
            Debug.Log("e");
        } 

    }

}