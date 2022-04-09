using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 5f;

    private Rigidbody2D rigidbody;

    private Vector3 movement;

    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            PJump();
    }

    private void PJump()
    {
        if (rigidbody.velocity.y != 0f)
            return;

        rigidbody.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
}
