using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class NPCNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] des;
    [SerializeField] private int rand;
    

    [SerializeField] private GameObject wnpcs;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void DestSelect()
    {
        navMeshAgent.enabled = true;
        int rand = Random.Range(0, 9);
        navMeshAgent.destination = des[rand].transform.position;

        //Debug.Log(rand);
    }

    private void Start()
    {
        DestSelect();
    }

    private void Update() 
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesPoints")
        {
            navMeshAgent.enabled = false;
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
            //Debug.Log("e");
        } 

        if (other.tag == "WNPC")
        {
            navMeshAgent.enabled = false;
            transform.LookAt(other.gameObject.transform);
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
        }

    }

}
