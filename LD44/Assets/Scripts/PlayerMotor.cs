using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{

    Rigidbody2D rb;
    float velocity;

    [SerializeField]
    float bonusGravity;
    [SerializeField]
    bool isGrounded;

    [SerializeField]
    LayerMask layers;
    // Use this for initialization
    void Start()
    {
        // There will always be a Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 5000, layers);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, layers);
        if (hit.distance < 0.9f && hit.collider != null)
        {
            // print("We hit: "+hit.collider.gameObject.name+" distance: "+hit.distance);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            Vector3 vel = rb.velocity;
            vel.y -= bonusGravity * Time.deltaTime;
            rb.velocity = vel;
        }
    }

    public void MoveBody(float _velocity)
    {
        velocity = _velocity;
    }

    public void jump(float jumpForce)
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce * 100));
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    */
}
