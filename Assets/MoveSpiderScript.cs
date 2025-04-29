using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpiderScript : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * speed;

        if (movement.magnitude > 0)
        {
            rb.velocity = movement;

            animator.SetBool("isMovingForward", vertical > 0);
            animator.SetBool("isMovingBackward", vertical < 0);
            animator.SetBool("isMovingLeft", horizontal < 0);
            animator.SetBool("isMovingRight", horizontal > 0);
        }
        else
        {
            rb.velocity = Vector2.zero;

            animator.SetBool("isMovingForward", false);
            animator.SetBool("isMovingBackward", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
        }

        ConstrainPosition();
    }

    void ConstrainPosition()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.225f;
        min.y = min.y + 0.225f;

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
