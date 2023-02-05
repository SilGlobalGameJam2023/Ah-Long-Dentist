using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackLeftRightUpDownMovement : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject hand;
    public float speed;

    private void Start()
    {
        resetHandPos();
    }

    public void resetHandPos()
    {
        gameObject.transform.position = Vector3.zero;
    }

    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Z)) resetHandPos();
    }

    void Movement()
    {
        float leftrightInput = Input.GetAxis("Mouse X");
        float forwardbackwardInput = Input.GetAxis("Mouse Y");
        float updownInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(leftrightInput, updownInput, forwardbackwardInput);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
