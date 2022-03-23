using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class NPCNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] des;
    [SerializeField] private bool atDes;
    [SerializeField] private int rand;

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

    private void Start()
    {
        DestSelect();   
    }

    void OnTriggerEnter(Collider other)
    {       
        FunctionTimer.Create(DestSelect, Random.Range(10f, 20f));

        //Debug.Log("e");
    }

}
