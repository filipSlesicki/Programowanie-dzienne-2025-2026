using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField]
    private TMP_Text timerText;
    private Health health;
    private Vector2 moveInput;
    private float horizontalInput;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
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
        UpdateIsAboveGround();
        UpdateTimer();
        UpdateMovement();
    }

    private void UpdateIsAboveGround()
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
    }

    private void UpdateMovement()
    {
        transform.position += new Vector3(
        horizontalInput * horizontalSpeed * Time.deltaTime,
        0,
        forwardSpeed * Time.deltaTime);
    }

    private void UpdateTimer()
    {
        if (timerFinished == false)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F1");
            if (timer <= 0)
            {
                timerText.text = "Timer finished";
                timerFinished = true;
                print("Timer finished");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = startPosition;
            health.TakeDamage(1);
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
        if(!EventSystem.current.IsPointerOverGameObject()) // Kursor jest nad elementem UI
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            // bullet to w³aœnie stworzony bullet. Teraz mo¿emy coœ z nim zrobiæ
        }
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
