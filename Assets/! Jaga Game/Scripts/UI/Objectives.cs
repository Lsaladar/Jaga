using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Objectives : MonoBehaviour
{
    public List<GameObject> crossOuts = new List<GameObject>();

    public List<bool> objectivesDone = new List<bool>();
    
    public PlayerController player;

    public Flowchart priestFlowchart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        objectivesDone[1] = priestFlowchart.GetBooleanVariable("Objective");

        if(player.journalOn)
        {
            for(int j = 0; j < crossOuts.Count; j++)
            {
                if(objectivesDone[j]){
                    crossOuts[j].SetActive(true);
                }
            }
        }
        else
        {
            for(int i = 0; i < crossOuts.Count; i++)
            {
                crossOuts[i].SetActive(false);
            }
        }
    }
}
