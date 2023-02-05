using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public bool objectiveCompleted = false;
    public int nextLevelIndex = 0;

    public GameObject winPanel;
    public GameObject[] goldenTooth;

    public int totalTeethLeft = 0;

    private void Start()
    {
        totalTeethLeft = goldenTooth.Length;
        Debug.Log("GoldenTooth: " + goldenTooth.Length);
    }

    public void removeTooth()
    {
        totalTeethLeft--;
        if(totalTeethLeft<=0)
        {
            Win();
            objectiveCompleted = true;
        }
    }


    /*
    void Update()
    {
        if (objectiveCompleted) return;

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
                Win();
                Debug.Log("Obective completed = " + objectiveCompleted);
                //win game
            }
        }
    }
    */

    void Win()
    {
        winPanel.SetActive(true);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
}
