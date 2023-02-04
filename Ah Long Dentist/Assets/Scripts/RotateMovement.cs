using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rotateInput = Input.GetAxis("Horizontal");

        Vector3 rotation = new Vector3(0.0f, 0.0f, rotateInput);

        transform.Rotate(rotation * -speed * Time.deltaTime);
    }
}
