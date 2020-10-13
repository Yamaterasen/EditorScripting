using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class RotateAround : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 100;
    public Vector3 RotateVector = Vector3.up;
    private Vector3 pos;
    private Color color;

    // Update is called once per frame
    void Update()
    {
        //Spin the object around the target
        transform.RotateAround(target.transform.position, RotateVector, rotateSpeed * Time.deltaTime);
    }

    public void GoClockwise()
    {
        RotateVector = Vector3.up;
    }

    public void GoCounterClockwise()
    {
        RotateVector = Vector3.down;
    }

    public void SetColor(Color newColor)
    {
        GetComponent<Renderer>().sharedMaterial.color = newColor;
    }
}
