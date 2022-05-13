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
        int rand = Random.Range(0, 9);

        yagaAgent.destination = des[rand].transform.position;
    }

}