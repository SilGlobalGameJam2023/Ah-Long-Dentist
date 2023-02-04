using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHighlighted : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;


    private void OnTriggerEnter(Collider other)
    {
        if(highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (other.gameObject.tag == ("Tooth"))
        {
            highlight = other.gameObject.transform;
            if(highlight.CompareTag("Tooth") && highlight != selection)
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

        if(Input.GetMouseButtonDown(0))
        {
            if(highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = other.gameObject.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if(selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Tooth"))
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
