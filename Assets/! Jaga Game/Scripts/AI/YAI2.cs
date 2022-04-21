using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class YAI2 : MonoBehaviour
{
    [SerializeField] private GameObject[] des;
    [SerializeField] private GameObject playerDes;
    [SerializeField] private bool atDes;
    [SerializeField] private int rand;
    [SerializeField] private bool isStalking;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void DestSelect()
    {
        int rand = Random.Range(0, 9);

        navMeshAgent.destination = des[rand].transform.position;

        Debug.Log(rand);
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = playerDes.transform.position;
    }

    private void Start()
    {
        DestSelect();
    }

    void OnTriggerEnter(Collider other)
    {
        FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
        //Debug.Log("e");

    }

}