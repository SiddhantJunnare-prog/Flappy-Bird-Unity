using UnityEngine;

public class birdBehavior : MonoBehaviour
{
    public float flapStrength = 10;
    public Rigidbody2D rigidbody2;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private float currentAngle = 0f;
    private float flapTimer = 0f;
    private float flapDuration = 0.5f;

    [SerializeField] private GameObject UpperWing;
    [SerializeField] private GameObject LowerWing;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        UpperWing.SetActive(true);
        LowerWing.SetActive(false);
    }

    void Update()
    {
        Flap();
        birdRotation();

        float YPos = transform.position.y;
        if(YPos >= 16)
        {
            birdIsAlive = false;
            logic.gameOver();
        }

    }

    void Flap()
    {
        bool isFlapping = false;

        // PC (Space key)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlapping = true;
        }

        // Android / Mobile (Touch)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isFlapping = true;
        }

        if (isFlapping && birdIsAlive)
        {
            rigidbody2.linearVelocity = Vector2.up * flapStrength;
            Vector3 vector3 = new Vector3(0, 0, 30);

            flapTimer = flapDuration; // start flap animation
            UpperWing.SetActive(false);
            LowerWing.SetActive(true);
        }

        //wing animation timer
        if(flapTimer >  0)
        {
            flapTimer -= Time.deltaTime;

            if(flapTimer <= 0)
            {
                UpperWing.SetActive(true);
                LowerWing.SetActive(false);
            }
        }

    }

    void birdRotation()
    {
        float targetAngle;

        if (rigidbody2.linearVelocity.y > 0)
        {
            targetAngle = 30f;      // look up
        }
        else
        {
            targetAngle = -30f;     // look down
        }

        // Smoothly move the angle toward the target
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, 3f * Time.deltaTime);

        // Apply rotation
        transform.eulerAngles = new Vector3(0, 0, currentAngle);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("TopPipe") || collision.gameObject.CompareTag("BottomPipe") || collision.gameObject.CompareTag("Land"))
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }
}
