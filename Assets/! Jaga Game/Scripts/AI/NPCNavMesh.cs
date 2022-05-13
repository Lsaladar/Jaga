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
    
    public bool hasContact; 

    public float range;
    [SerializeField] private GameObject wnpcs;


    //private NPCLook npcLook;

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

        //npcLook = GetComponent<NPCLook>();
    }

    private void Update() 
    {
        Debug.Log(hasContact);

        if (hasContact == true)
        {
            FunctionTimer.Create(WNpcsInteracting, Random.Range(5f, 10f));
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
            Debug.Log("ww");
        }

        if(Vector3.Distance(wnpcs.transform.position, transform.position) <= range)
        {
            Debug.Log("!");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesPoints")
        {
            FunctionTimer.Create(DestSelect, Random.Range(5f, 10f));
            //Debug.Log("e");
        }

        

    }

    private void WNpcsInteracting()
    {
        navMeshAgent.Stop(true);
        //bool isStopped = true;
        Debug.Log("s");
    }



}
