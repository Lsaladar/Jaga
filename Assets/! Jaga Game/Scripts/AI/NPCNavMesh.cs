using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private void Update()
    {
        if (atDes == true)
        {
            FunctionTimer.Create(DestSelect, 0.5f);

        }

        DestSelect();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DesPoints")
        {
            atDes = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DesPoints")
        {
            atDes = false;
        }
    }


}
