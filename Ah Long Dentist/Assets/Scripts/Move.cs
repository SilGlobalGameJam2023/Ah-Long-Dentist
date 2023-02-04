using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float leftrightInput = Input.GetAxis("Mouse X");
        float forwardbackwardInput = Input.GetAxis("Mouse Y");
        float updownInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(leftrightInput, forwardbackwardInput, updownInput);
        Vector3 rotation = new Vector3(0.0f, 0.0f, rotateInput * 10.0f);

        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
