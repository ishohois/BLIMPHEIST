using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HangGlider : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isAirborn;
    private bool hitLWall;
    private bool hitRWall;

    [SerializeField] private float groundedDistance = 1f;
    [SerializeField] private float airbornDistance = 1f;
    [SerializeField] private float hitWallDistance = 1f;
    [SerializeField] private float horizontalFactor = 1f;
    [SerializeField] private float horizontalSpeed = 1f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask airLayer;
    //[SerializeField] private LayerMask rightWall;
    //[SerializeField] private LayerMask leftWall;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        // ground
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundedDistance, transform.position.z));

        // air
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + airbornDistance, transform.position.z));

        //// left wall
        //Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - hitWallDistance, transform.position.y, transform.position.z));

        //// right wall
        //Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + hitWallDistance, transform.position.y, transform.position.z));
    }

    private void FixedUpdate() {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance, groundLayer);


        isAirborn = Physics2D.Raycast(transform.position, Vector2.up, airbornDistance, airLayer);


        //hitLWall = Physics2D.Raycast(transform.position, Vector2.left, hitWallDistance, leftWall);


        //hitRWall = Physics2D.Raycast(transform.position, Vector2.right, hitWallDistance, rightWall);


        //if (hitRWall) {
        //    horizontalFactor = -1f;
        //    if ((rb.velocity.x != 0f)) {
        //        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0f, 0.05f), rb.velocity.y);
        //    }

        //}
        //if (hitLWall) {
        //    horizontalFactor = 1f;
        //    if ((rb.velocity.x != 0f)) {
        //        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0f, 0.05f), rb.velocity.y);
        //    }
        //}

        if (isAirborn) {
            if ((rb.velocity.y != 0f)) {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0f, 0.05f));
            }
        }

        Fly();


        modifyPhysics();
    }

    private void takeOff() {

    }

    private void Fly() {

        if (isGrounded && !(rb.velocity.y > 3f)) {
            rb.AddForce(new Vector2(horizontalSpeed * horizontalFactor, Random.Range(2f, 5f)), ForceMode2D.Force);
        }

    }

    private void modifyPhysics() {
        if (isGrounded) {
            rb.gravityScale = 0.1f;
        }
        else {
            rb.gravityScale = 0.5f;
        }
    }
}
