using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HangGlider : MonoBehaviour, IKillable {
    private Rigidbody2D rb;
    public ObjectDeactivator objectDeactivator;

    private bool isGrounded;
    private bool isAirborn;

    [SerializeField] private float minAirForce = 3f;
    [SerializeField] private float maxAirForce = 5f;

    [SerializeField] private float groundedMin = 1f;
    [SerializeField] private float groundedMax = 3f;

    [SerializeField] private float groundedDistance;
    [SerializeField] private float airbornDistance = 1f;
    [SerializeField] private float hitWallDistance = 1f;
    [SerializeField] private float horizontalFactor = 1f;
    [SerializeField] private float horizontalSpeed = 1f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask airLayer;

    public Animator animator;
    public float yVel;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundedDistance = Random.Range(groundedMin, groundedMax);
        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();
    }

    // Update is called once per frame
    void Update() {
        yVel = rb.velocity.y;

        animator.SetFloat("yVel", yVel);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        // ground
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundedDistance, transform.position.z));

        // air
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + airbornDistance, transform.position.z));

    }

    private void FixedUpdate() {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance, groundLayer);


        isAirborn = Physics2D.Raycast(transform.position, Vector2.up, airbornDistance, airLayer);

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
            rb.AddForce(new Vector2(horizontalSpeed * horizontalFactor, Random.Range(minAirForce, maxAirForce)), ForceMode2D.Force);
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

    public void KillMe() {

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        foreach (Transform child in transform) {

            child.gameObject.SetActive(false);
        }

        //objectDeactivator.IncrementObjectCounter();
    }
}
