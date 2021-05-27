using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HangGlider : MonoBehaviour, IKillable
{

    public ObjectDeactivator objectDeactivator;
    public float groundedDistance = 0f;
    public Animator animator;
    public AudioSource audio;

    [SerializeField] private float minAirForce = 3f;
    [SerializeField] private float maxAirForce = 5f;
    [SerializeField] private float groundedMin = 1f;
    [SerializeField] private float groundedMax = 3f;

    [SerializeField] private float airbornDistance = 1f;
    [SerializeField] private float hitWallDistance = 1f;
    [SerializeField] private float horizontalFactor = 1f;
    [SerializeField] private float horizontalSpeed = 1f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask airLayer;
    [SerializeField] private float timer = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAirborn;
    private float yViewPortMax;
    private float offsetGroundDistance = 0.5f;

    private void Awake()
    {
        yViewPortMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y;
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Audio Source- EnemyDeath").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();

        SetGroundedDistance();
    }

    private void SetGroundedDistance()
    {
        float posDiff = yViewPortMax * 2 - (yViewPortMax - transform.position.y) - offsetGroundDistance;
        groundedDistance = posDiff;
    }

    private void OnEnable()
    {
        Invoke(nameof(SetGroundedDistance), 0.1f);
        
        foreach (Transform child in transform)
        {

            child.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        groundedDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVel", rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // ground
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundedDistance, transform.position.z));

        // air
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + airbornDistance, transform.position.z));

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance, groundLayer);
        isAirborn = Physics2D.Raycast(transform.position, Vector2.up, airbornDistance, airLayer);

        if (isAirborn)
        {
            if ((rb.velocity.y != 0f))
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0f, 0.05f));
            }
        }

        Fly();

        modifyPhysics();

    }

    private void Fly()
    {

        if (isGrounded && !(rb.velocity.y > 3f))
        {
            rb.AddForce(new Vector2(horizontalSpeed * horizontalFactor, Random.Range(minAirForce, maxAirForce)), ForceMode2D.Force);
        }

    }

    private void modifyPhysics()
    {
        if (isGrounded)
        {
            rb.gravityScale = 0.1f;
        }
        else
        {
            rb.gravityScale = 0.5f;
        }
    }

    IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //gameObject.SetActive(false);
        gameObject.transform.position = objectDeactivator.transform.position;
    }

    public void KillMe()
    {
        //Död Ljudeffekter + Partikeleffekter
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        audio.Play();
        //gameObject.GetComponent<ParticleSystem>().Stop();

        foreach (Transform child in transform)
        {

            if (child.GetComponent<ParticleSystem>())
            {

                child.GetComponent<ParticleSystem>().Stop();
            }
            else
            {

                child.gameObject.SetActive(false);
            }
        }
        StartCoroutine(WaitingCoroutine());
    }
}
