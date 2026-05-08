using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerrigidbody;
    int speed = 5;
    int jumpforce = 15;
    public Animator animator;
    public SpriteRenderer sprite;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            playerrigidbody.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerrigidbody.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);

            sprite.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (playerrigidbody.IsTouchingLayers(3))
            {
            playerrigidbody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }
        playerrigidbody.linearVelocityX /= 2;
        playerrigidbody.linearVelocityY -= 1;
        animator.SetFloat("Movespeed", playerrigidbody.linearVelocityX);
    }
}
