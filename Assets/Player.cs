using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // int - liczba ca³kowita
    // float - liczba z przecinkiem
    // string - tekst
    // bool - true/false
    float timer = 3;
    float finishTime;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private float horizontalSpeed = 4;
    [SerializeField]
    private float forwardSpeed = 4;
    private bool timerFinished;
    private bool isAboveGround;
    [SerializeField]
    private Transform floor;
    [SerializeField]
    private Transform wall;
    private Vector2 moveInput;
    private float horizontalInput;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        finishTime = Time.time + timer;
        float someValue = 5.0f;
        int someOtherValue = 3;

        someValue = someValue * 3;
        someValue *= 2;
        someValue += 1;
        someValue += someOtherValue;

        Debug.Log(someValue);


        print("Hello");
        //Debug.LogWarning("Hello2");
        // = to przypisanie nowej wartoœci

        // transform.Translate(10, 5, -2);
    }

    // Update is called once per frame
    void Update()
    {
        isAboveGround = transform.position.y >= floor.position.y;
        if (isAboveGround == false)
        {
            Debug.Log("Move above ground");
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 position = transform.position;
            position.y = floor.position.y;
            transform.position = position;
        }
        if (timerFinished == false)
        {
            //if (Time.time > finishTime)
            //{
            //    timerFinished = true;
            //    print("Timer finished");
            //}
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timerFinished = true;
                print("Timer finished");
            }
        }

        //bool someBool = true;
        //someBool = speed == 5;
        //if(speed > 5)
        //{
        //    print(speed);
        //}

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            print("Space pressed");
        }

        //if (Keyboard.current.dKey.isPressed)
        //{
        //    // mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê na prêdkoœæ na sekundê
        //    transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        //}

        //if (Keyboard.current.aKey.isPressed)
        //{
        //    // mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê na prêdkoœæ na sekundê
        //    transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        //}

        //transform.position += new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime;
        transform.position += new Vector3(
            horizontalInput * horizontalSpeed * Time.deltaTime,
            0,
            forwardSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = startPosition;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            print("You win");
        }
    }

    private void OnAttack()
    {
        Instantiate(bulletPrefab,bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnMoveHorizontal(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }
}
