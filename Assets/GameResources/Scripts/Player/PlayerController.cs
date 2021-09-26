using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Контроллер игрока
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDie = delegate { };

    public PlayerHealth HealthController;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float dieY = 0.4f;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float timeToIncSpeed = 5f;
    [SerializeField]
    private float incSpeed = 0.2f;
    [SerializeField]
    private float jumpForce = 4000f;
    [SerializeField]
    private Transform rayTransform;
    [SerializeField]
    private float rayDistance = 1;

    private const string ANIM_STATE = "Run";

    private const int beginSpeed = 3;

    private Rigidbody rigid;

    private float jumpHeight = 3f;

    private bool canJump = true;
    private bool onGround = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim.speed = speed;
        anim.SetBool(ANIM_STATE, true);
    }

    private void Update()
    {
        if (transform.position.y <= dieY)
        {
            Die();
        }

        onGround = Physics.Raycast(rayTransform.position, Vector3.down, rayDistance);

        if (transform.position.y > jumpHeight || (canJump && !onGround))
        {
            rigid.AddRelativeForce(Vector3.down * jumpForce / 10, ForceMode.Force);
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
#endif
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        rigid.AddRelativeForce(Vector3.forward * beginSpeed * speed, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Поворот игрока
    /// </summary>
    public void Rotate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y == 0 ? -90 : 0, 0);
    }

    /// <summary>
    /// Прыжок
    /// </summary>
    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rigid.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Force);
            StartCoroutine(CheckJump());
        }
    }

    private IEnumerator CheckJump()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            if (Physics.Raycast(rayTransform.position, Vector3.down, rayDistance))
            {
                canJump = true;
                yield break;
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Die()
    {
        OnPlayerDie();
        gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(rayTransform.position, Vector3.down * rayDistance);
    }
#endif
}
