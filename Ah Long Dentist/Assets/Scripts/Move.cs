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
        float updownInput = Input.GetAxis("Jump");

        Vector3 direction = new Vector3(leftrightInput, updownInput, forwardbackwardInput);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
