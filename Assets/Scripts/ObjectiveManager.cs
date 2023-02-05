using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private bool objectiveCompleted = false;
    public GameObject [] goldenTooth;
    void Update()
    {
        for(int i = 0; i < goldenTooth.Length; i++)
        {
            if(goldenTooth[i].activeInHierarchy)
            {
                objectiveCompleted = false;
                Debug.Log("Objective completed = " + objectiveCompleted);
            }
            else
            {
                objectiveCompleted = true;
                Debug.Log("Obective completed = " + objectiveCompleted);
                //win game
            }
        }
    }
}
