using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blimp_Movement : MonoBehaviour
{
    public PlayerState playerState;
    public Rigidbody2D rb2;
    public Button burstButton;
    public ParticleSystem steam; //Particle system  when jumping
    public ParticleSystem fire; //Particle system when using burst
    public Animator anim;

    [SerializeField] private Vector3 velocityForReturning;
    private Vector3 velocityForFlying;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float extraSpeed = 50f;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float burstSpeed = 1f;
    [SerializeField] private float returningSpeed;

    public bool flying;
    [SerializeField] private bool hasLeftArea = true;
    [SerializeField] private bool burstUsed = false;
    [SerializeField] private bool isBurstAvailable;
    public bool timerOut = false;
    public bool touchActivated;
    public bool canAttack = false;

    [SerializeField] private float timer2 = 0f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 5f;
    [SerializeField] private float timerBeforeAddBurst = 0.3f;

    //public AudioSource jumpsound; 
    public AudioSource burstSound; //Det ljud som spelas n�r man anv�nder burst
    public AudioSource flyingSound; //Det ljud som spelas n�r man hoppar

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

        if (touchActivated) {

            CheckTouchInput();
        }
        else {

            CheckInput();
        }

        if (playerState.GetBursts() > 0)
        {
            isBurstAvailable = true;
        }
        else
        {
            isBurstAvailable = false;
        }

        //DEFAULT BURST CHECK
        CheckDefaultBurst();


        CheckAnimations();

        if (burstUsed == true || hasLeftArea == true)
        {

            timer += Time.deltaTime;

            if (timer >= timeBeforeReset)
            {
                timerOut = true;
            }

            if (timerOut == true)
            {
                canAttack = false;
                ReturnToStartingArea();
            }
        }

        //Steam control
        var emission = steam.emission;
        if (flying == true && emission.enabled == false)
        {
            emission.enabled = true;
            //Debug.Log("Steam on");
        }
        else if (flying == false && emission.enabled == true)
        {
            emission.enabled = false;
            //Debug.Log("Steam off");
        }

        //FlyingSound control
        if (flying == true && flyingSound.mute == true && Time.timeScale > 0.1f)
        {
            flyingSound.mute = false;
            flyingSound.pitch = Random.Range(0.6f, 0.9f);
        }
        else if (flying == false && flyingSound.mute == false)
        {
            flyingSound.mute = true;
        }
    }


    private void FixedUpdate()
    {

        Vector3 movement = Vector3.zero;

        if (flying == true)
        {   
            movement.y = speed * extraSpeed;
            Move(movement);
        }

        CheckMaxAndLowestSpeed();

        if (burstUsed == true)
        {
            canAttack = true;
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
            fire.Stop();
            fire.Clear(); //needed for dubble/tripple burst
            fire.Play(); //Plays fire burst particle effect

            burstSound.pitch = Random.Range(0.9f, 1.0f); //1.0f, 1.1f L�ter ocks� ok
            burstSound.Play(); //Spela ljud n�r man anv�nder burst

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
                    flying = true;
                    break;
                case TouchPhase.Moved:
                    flying = true;
                    break;
                case TouchPhase.Stationary:
                    flying = true;
                    break;
                case TouchPhase.Ended:
                    flying = false;
                    break;
                case TouchPhase.Canceled:
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

            //if(!jumpsound.isPlaying) //used to make sure the audio doesn't play over itself
            //{
            //    jumpsound.Play(); //Spela ljud n�r man hoppar
            //}

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
                fire.Stop();
                fire.Clear(); //needed for dubble/tripple burst
                fire.Play(); //Plays fire burst particle effect

                burstSound.pitch = Random.Range(0.9f, 1.0f); //1.0f, 1.1f L�ter ocks� ok
                burstSound.Play(); //Spela ljud n�r man anv�nder burst

                burstUsed = true;
            }
        }

    }


    // Metoden f�r att blimpen inte flyger upp och ner som galen
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

    private void CheckAnimations() {

        if (hasLeftArea == false) {

            anim.SetBool("HasLeftArea", false);
        }
        else {

            anim.SetBool("HasLeftArea", true);
        }
        if (flying) {

            anim.SetBool("Flying", true);
        }
        else {

            anim.SetBool("Flying", false);
        }
    }

    private void Move(Vector3 moving)
    {

        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, moving, ref velocityForFlying, smoothTime, maxSpeed);
    }

    private void Burst()
    {
        rb2.velocity = new Vector2(0, rb2.velocity.y);
        rb2.AddForce(new Vector2(2 * burstSpeed, 0), ForceMode2D.Impulse);
        playerState.UseBurst();
        anim.SetTrigger("UseBurst");
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
        rb2.velocity = Vector3.SmoothDamp(rb2.velocity, new Vector2(returningSpeed, rb2.velocity.y), ref velocityForReturning, smoothTime);
    }

    private void ResetTimer()
    {
        timer = 0f;
        timerOut = false;
    }
    
    public void CheckDefaultBurst() {

        if(burstUsed && playerState.GetBursts() < 2 && playerState.defaultBurstUsed == false) {

            playerState.defaultBurstUsed = true;
        }
    }
}
