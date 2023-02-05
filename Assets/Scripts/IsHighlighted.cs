using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHighlighted : MonoBehaviour
{
    public ObjectiveManager objectiveManager;

    [SerializeField]
    private Transform highlight;
    private GameObject curTooth;
    private bool isHighlighted = false;
    private bool success = false;
    private bool startTimer = false;
    private float timer = 2.0f;
    private float originalTimer;

    private void Start()
    {
        originalTimer = timer;
    }

    private void OnTriggerEnter(Collider other)
    {
        isHighlighted = true;
        curTooth = other.gameObject;

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (other.gameObject.tag == ("Tooth"))
        {
            highlight = other.gameObject.transform;
            if(highlight.CompareTag("Tooth"))
            {
                if(highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 5.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Tooth"))
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;

            isHighlighted = false;
            curTooth = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && curTooth != null)
        {
            startTimer = true;
        }
        else if(curTooth == null && success)
        {
            success = false;
            startTimer = false;
            timer = originalTimer;
        }

        if (startTimer == true && success == false && curTooth != null)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0.0f)
        {
            success = true;
            timer = originalTimer;
            success = false;
            curTooth.gameObject.SetActive(false);
            if(curTooth.gameObject.GetComponent<GoldTooth>() != null) objectiveManager.removeTooth();
        }
    }
}
