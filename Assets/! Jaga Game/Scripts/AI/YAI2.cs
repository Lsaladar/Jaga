using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(Rigidbody))]
public class YAI2 : MonoBehaviour
{
    public GameObject yagaDest;
    NavMeshAgent yagaAgent;
    [SerializeField] private GameObject[] des;
    [SerializeField] private int rand;
    public static bool atDest;
    public float chaseMovementSpeed = 5.0f;

    public bool isDone;

    [Header("Field of view variables")]
    public float radius;
    [Range(0, 360)]
    public float angle;

    [Space(20)]
    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;



    void Start()
    {
        yagaAgent = GetComponent<NavMeshAgent>();
        bool isDone = false;
        YagaIdle();

        //field of view start
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    //Finding player coroutine done 5x every sec
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                    
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }


    void Update()
    {
        if (canSeePlayer)
        {
            //yagaAgent.SetDestination(yagaDest.transform.position);
            yagaAgent.enabled = false;
            transform.LookAt(yagaDest.transform);
            transform.position = Vector3.MoveTowards(transform.position, yagaDest.transform.position, chaseMovementSpeed * Time.deltaTime);
            bool isDone = false;
        }
        else if (!canSeePlayer)
        {
            if (!atDest)
            {
                yagaAgent.enabled = true;

                if (!isDone)
                {
                    YagaIdle();
                    isDone = true;
                    Debug.Log("isdonetrue");
                }
            }
            
        }

    }

    void YagaIdle()
    {
        //Assign destination
        bool atDest = false;
        yagaAgent.enabled = true;
        int rand = Random.Range(0, 9);
        yagaAgent.destination = des[rand].transform.position;
        Debug.Log(rand);
        isDone = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesPoints")
        {
            bool atDest = true;
            yagaAgent.enabled = false;
            FunctionTimer.Create(YagaIdle, Random.Range(5f, 10f));
            Debug.Log("e");
        } 

    }

}