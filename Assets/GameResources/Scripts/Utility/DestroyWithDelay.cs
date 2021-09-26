using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� ������� � ���������
/// </summary>
public class DestroyWithDelay : MonoBehaviour
{
    [SerializeField, Header("������������ RealTime ��� Time?")]
    private bool useRealTime = false;
    [SerializeField]
    private float delay = 2;

    private void OnEnable()
    {
        StartCoroutine(WaitForDestroy());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private IEnumerator WaitForDestroy()
    {
        if (useRealTime)
        {
            yield return new WaitForSecondsRealtime(delay);
        }
        else
        {
            yield return new WaitForSeconds(delay);
        }

        Destroy(gameObject);
    }
}
