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
    
    [SerializeField] private NPCLook npcLook;

    //public bool isStopped;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void DestSelect()
    {
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
        //Debug.Log(npcLook.contact);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesPoints")
        {
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
            //Debug.Log("e");
        }

        if (npcLook.contact == true)
        {
            FunctionTimer.Create(WNpcsInteracting, Random.Range(5f, 10f));
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
            Debug.Log("ww");
        }

    }

    private void WNpcsInteracting()
    {
        navMeshAgent.Stop(true);
        //bool isStopped = true;
        Debug.Log("s");
    }

}
