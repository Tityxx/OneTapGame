using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ротатор
/// </summary>
public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float speedX = 0;
    [SerializeField]
    private float speedY = -180;
    [SerializeField]
    private float speedZ = 0;

    [SerializeField]
    private bool rotateX = false;
    [SerializeField]
    private bool rotateY = true;
    [SerializeField]
    private bool rotateZ = false;

    private void Update()
    {
        float x = rotateX ? transform.eulerAngles.x + speedX * Time.deltaTime : transform.eulerAngles.x;
        float y = rotateY ? transform.eulerAngles.y + speedY * Time.deltaTime : transform.eulerAngles.y;
        float z = rotateZ ? transform.eulerAngles.z + speedZ * Time.deltaTime : transform.eulerAngles.z;
        transform.eulerAngles = new Vector3(x, y, z);
    }
}
