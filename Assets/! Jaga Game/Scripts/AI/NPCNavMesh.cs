using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] des;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        DestSelect();   
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "")
    }

    private void DestSelect()
    {
        int rand = Random.Range(0, 9);

        navMeshAgent.destination = des[rand].transform.position;

        Debug.Log(des[rand]);
    }
}
