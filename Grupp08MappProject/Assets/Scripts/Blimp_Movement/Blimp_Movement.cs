using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blimp_Movement : MonoBehaviour
{
    public GameObject startingArea;
    public Rigidbody2D rb2;
    public CapsuleCollider2D capsuleCollider2D;
    public Transform targetPoint;

    [SerializeField] private Vector3 defaultVelocity;
    [SerializeField] private Vector3 velocityForReturning = new Vector3(-7,0);
    private Vector3 velocityForFlying;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float extraSpeed = 50f;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] private float burstSpeed = 1f;

    [SerializeField] private bool flying;
    [SerializeField] private bool hasLeftArea;
    [SerializeField] private bool burstUsed = false;
    public bool returnedToStartArea;

    private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 0.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        defaultVelocity.x = 0;
        defaultVelocity.y = transform.position.y;

        if (Input.GetKey(KeyCode.Space) == true) {

            flying = true;
        }
        else {

            flying = false;
        }

        if(burstUsed == true && hasLeftArea == true) {

            timer += Time.deltaTime;

            if(timer >= timeBeforeReset) {

                ReturnToStartingArea();
                burstUsed = false;
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

        if (Input.GetKeyDown(KeyCode.D) == true) {

            Burst();
            
        }

        if (returnedToStartArea == true) {

            rb2.velocity = defaultVelocity;
            returnedToStartArea = false;
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
    }

    private void ReturnToStartingArea() {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, startingArea.transform.position, ref velocityForReturning, smoothTime);
    }

}
