using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blimp_Movement : MonoBehaviour
{
    public GameObject startingArea;
    public Rigidbody2D rb2;
    public CapsuleCollider2D capsuleCollider2D;

    [SerializeField] private Vector3 defaultVelocity;
    [SerializeField] private Vector3 velocityForReturning = new Vector3(-7,0);
    private Vector3 velocityForFlying;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float extraSpeed = 50f;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] private float burstSpeed = 1f;

    [SerializeField] private bool flying;
    [SerializeField] private bool hasLeftArea = true;
    [SerializeField] private bool burstUsed = false;
    public bool returnedToStartArea = false;
    public bool timerOut = false;

    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 5f;


    // Start is called before the first frame update
    void Start()
    {
        hasLeftArea = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) == true) {

            flying = true;
        }
        else {

            flying = false;
        }
        if (Input.GetKeyDown(KeyCode.D) == true) {

            burstUsed = true;
        }

        if (hasLeftArea == true) {

            timer += Time.deltaTime;

            if (timer >= timeBeforeReset) {

                timerOut = true;

            }

            if(timerOut == true) {

                ReturnToStartingArea();
            }
        }
    }


    private void FixedUpdate() {

        Vector3 movement = Vector3.zero;
        movement.y = speed * extraSpeed;

        if (flying == true) {

            Move(movement);
        }

        CheckMaxAndLowestSpeed();

        if(burstUsed) {

            hasLeftArea = true;
            Burst();
        }

        if (hasLeftArea == false) {

            rb2.velocity = new Vector2(0,rb2.velocity.y);
        }

    }


    // Metoden för att blimpen inte flyger upp och ner som galen
    private void CheckMaxAndLowestSpeed() {

        if (rb2.velocity.y <= -5) {

            Vector2 vectorDown = new Vector2(rb2.velocity.x, -3.5f);

            rb2.velocity = vectorDown;
        }
        else if (rb2.velocity.y >= 7) {

            Vector2 vectorUp = new Vector2(rb2.velocity.x, 7f);

            rb2.velocity = vectorUp;
        }
    }


    private void Move(Vector3 moving) {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, moving, ref velocityForFlying, smoothTime, maxSpeed);
    }

    private void Burst() {

        rb2.AddForce(transform.right * burstSpeed, ForceMode2D.Impulse);
        burstUsed = true;
    }

    public void SetHasLeftAreaToTrue() {

        hasLeftArea = true;
    }

    public void SetHasLeftAreaToFalse() {

        hasLeftArea = false;
        timer = 0f;
        timerOut = false;
    }

    private void ReturnToStartingArea() {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, new Vector2(-5,0), ref velocityForReturning, smoothTime);

    }

}
