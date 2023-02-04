using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackLeftRightUpDownMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Movement();
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
