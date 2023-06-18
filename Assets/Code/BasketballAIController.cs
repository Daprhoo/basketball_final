using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballAIController : MonoBehaviour
{
    public int playerScore;
     public int playerNumber;
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField] 
    private Transform ball;
    [SerializeField] 
    private Transform posDribble;
    [SerializeField] 
    private Transform posOverHead;
    [SerializeField] 
    private Transform arms;
    [SerializeField] 
    private Transform target;

    private bool isBallInHands = true;
    private bool isBallFlying = false;
    private float throwingDuration = 0.66f;
    private float throwingHeight = 5;
    private float throwingProgress = 0;
    private Rigidbody ballRigidbody;

    private void Awake()
    {
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        HandleBallControl();
        HandleBallThrowing();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Vertical2");
        float verticalInput = Input.GetAxisRaw("Horizontal2");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + moveDirection);
    }

    private void HandleBallControl()
    {
        if (isBallInHands)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ball.position = posOverHead.position;
                arms.localEulerAngles = Vector3.right * 180;
                transform.LookAt(target.parent.position);
            }
            else
            {
                ball.position = posDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                arms.localEulerAngles = Vector3.zero;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isBallInHands = false;
                isBallFlying = true;
                throwingProgress = 0;
            }
        }
    }

    private void HandleBallThrowing()
    {
        if (isBallFlying)
        {
            throwingProgress += Time.deltaTime;
            float t = throwingProgress / throwingDuration;
            Vector3 a = posOverHead.position;
            Vector3 b = target.position;
            Vector3 pos = Vector3.Lerp(a, b, t);
            Vector3 arc = Vector3.up * throwingHeight * Mathf.Sin(t * Mathf.PI);
            ball.position = pos + arc;

            if (t >= 1)
            {
                isBallFlying = false;
                ballRigidbody.isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isBallInHands && !isBallFlying)
        {
            isBallInHands = true;
            ballRigidbody.isKinematic = true;
        }
        
    }

    

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hoop"))
        {
            Vector3 normal = collision.contacts[0].normal;
            float bounce = 10f;
            Vector3 bounceVector = Vector3.Reflect(ballRigidbody.velocity, normal);
            ballRigidbody.velocity = bounceVector * bounce;
        }
    }
}
