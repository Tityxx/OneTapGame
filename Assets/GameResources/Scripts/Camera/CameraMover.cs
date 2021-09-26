using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Передвижение камеры вслед за целью
/// </summary>
public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private bool followX;
    [SerializeField]
    private bool followY;
    [SerializeField]
    private bool followZ;

    private Vector3 diff;

    private void Awake()
    {
        diff = transform.position - target.position;
        PlayerController.OnPlayerDie += OnPlayerDie;
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerDie -= OnPlayerDie;
    }

    private void LateUpdate()
    {
        Vector3 pos = target.position + diff;
        transform.position = new Vector3(followX ? pos.x : transform.position.x, followY ? pos.y : transform.position.y, followZ ? pos.z : transform.position.z);
    }

    private void OnPlayerDie()
    {
        enabled = false;
    }
}
