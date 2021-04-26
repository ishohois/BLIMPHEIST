using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blimp_Movement : MonoBehaviour
{
    public PlayerState playerState;
    public GameObject startingArea;
    public Rigidbody2D rb2;
    public Button burstButton;

    [SerializeField] private Vector3 velocityForReturning;
    private Vector3 velocityForFlying;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float extraSpeed = 50f;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] private float burstSpeed = 1f;

    public bool flying;
    [SerializeField] private bool hasLeftArea = true;
    [SerializeField] private bool burstUsed = false;
    [SerializeField] private bool isBurstAvailable;
    public bool hasWeight = false;
    public bool timerOut = false;

    [SerializeField] private float timer2 = 0f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 5f;
    [SerializeField] private float timerBeforeAddBurst = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        hasLeftArea = true;
        burstButton.onClick.AddListener(OnBurstClick);
    }

    // Update is called once per frame
    void Update()
    {
        velocityForReturning.y = rb2.velocity.y;
        //CheckTouchInput();

        if (playerState.GetBursts() > 0)
        {

            isBurstAvailable = true;
        }
        else
        {

            isBurstAvailable = false;
        }
        if (hasLeftArea == false && playerState.GetBursts() == 0)
        {

            timer2 += Time.deltaTime;

            if (timer2 >= timerBeforeAddBurst)
            {

                playerState.AddBurst(1);
                timer2 = 0f;
            }

        }
        CheckInput();

        if (burstUsed == true || hasLeftArea == true)
        {

            timer += Time.deltaTime;

            if (timer >= timeBeforeReset)
            {

                timerOut = true;

            }

            if (timerOut == true)
            {

                ReturnToStartingArea();
            }
        }
    }


    private void FixedUpdate()
    {

        Vector3 movement = Vector3.zero;

        if (flying == true)
        {

            if (hasWeight)
            {

                rb2.mass = 2;
                movement.y = speed * 70f;
            }

            rb2.mass = 1;
            movement.y = speed * extraSpeed;
            Move(movement);
        }

        CheckMaxAndLowestSpeed();

        if (burstUsed == true)
        {
            hasLeftArea = true;
            Burst();
        }

        if (hasLeftArea == false)
        {
            rb2.velocity = new Vector2(0, rb2.velocity.y);
        }

    }

    private void OnBurstClick()
    {
        if (isBurstAvailable == true)
        {
            burstUsed = true;
        }
    }


    private void CheckTouchInput()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touch began");
                    flying = true;
                    break;
                case TouchPhase.Moved:
                    Debug.Log("Touch moved");
                    flying = true;
                    break;
                case TouchPhase.Stationary:
                    Debug.Log("Touch stationary");
                    flying = true;
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch ended");
                    flying = false;
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("Touch canceled");
                    flying = false;
                    break;
            }
            Debug.Log(flying);
        }
    }

    private void CheckInput()
    {

        if (Input.GetKey(KeyCode.Space) == true)
        {

            flying = true;
        }
        else
        {

            flying = false;
        }
        if (isBurstAvailable == true)
        {

            if (Input.GetKeyDown(KeyCode.D) == true)
            {

                burstUsed = true;
            }
        }

    }


    // Metoden för att blimpen inte flyger upp och ner som galen
    private void CheckMaxAndLowestSpeed()
    {

        if (rb2.velocity.y <= -5)
        {

            Vector2 vectorDown = new Vector2(rb2.velocity.x, -3.5f);

            rb2.velocity = vectorDown;
        }
        else if (rb2.velocity.y >= 7)
        {

            Vector2 vectorUp = new Vector2(rb2.velocity.x, 7f);

            rb2.velocity = vectorUp;
        }
    }


    private void Move(Vector3 moving)
    {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, moving, ref velocityForFlying, smoothTime, maxSpeed);
    }

    private void Burst()
    {

        rb2.mass = 1;
        rb2.velocity = new Vector2(0, rb2.velocity.y);
        rb2.AddForce(new Vector2(2 * burstSpeed, 0), ForceMode2D.Impulse);
        playerState.UseBurst();
        ResetTimer();
        burstUsed = false;
    }

    public void SetHasLeftAreaToTrue()
    {

        hasLeftArea = true;
    }

    public void SetHasLeftAreaToFalse()
    {

        hasLeftArea = false;
        ResetTimer();
    }

    private void ReturnToStartingArea()
    {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, new Vector2(-4, rb2.velocity.y), ref velocityForReturning, smoothTime);

    }

    private void ResetTimer()
    {

        timer = 0f;
        timerOut = false;
    }

}
