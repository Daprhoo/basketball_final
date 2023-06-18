using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketballController : MonoBehaviour {

    public int playerNumber;
    //[SerializeField]
    //private int score = 0;
    //[SerializeField]
    //private TextMeshProUGUI scoreText;
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField] private Transform ball, posDribble, posOverHead, arms, target;

    [SerializeField]
    private float throwingDuration = 0.66f; // topu fırlatma süresi
    [SerializeField]
    private float throwingHeight = 5; // topun fırlatılma yüksekliği

    private bool isBallInHands = true; 
    private bool isBallFlying = false; 
    private float throwingProgress = 0;  

    private Rigidbody ballRigidbody;
    private float ballScorePosition;

    private void Awake() {
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleMovement();
        HandleBallControl();
        HandleBallThrowing();
    }

    // oyuncunun hareket kontrolü:
    private void HandleMovement() {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + direction);
    }
    //topun kontrolü ve oyuncunun hareketlerine yanıt vermesi:
    private void HandleBallControl() {
        if (isBallInHands) {
            if (Input.GetKey(KeyCode.Space)) {
                ball.position = posOverHead.position;
                arms.localEulerAngles = Vector3.right * 180;
                transform.LookAt(target.parent.position);
            } else {
                ball.position = posDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                arms.localEulerAngles = Vector3.zero;
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                isBallInHands = false;
                isBallFlying = true;
                throwingProgress = 0;
            }
        }
    }
    //topun fırlatılması:
    private void HandleBallThrowing() {
        if (isBallFlying) {
            throwingProgress += Time.deltaTime;
            float t = throwingProgress / throwingDuration;
            Vector3 a = posOverHead.position;
            Vector3 b = target.position;
            Vector3 pos = Vector3.Lerp(a, b, t);
            Vector3 arc = Vector3.up * throwingHeight * Mathf.Sin(t * Mathf.PI);
            ball.position = pos + arc;
            if (t >= 1) {
                isBallFlying = false;
                ballRigidbody.isKinematic = false;
            }
        }
    }
    //topun çembere girmesi ve skorlama:
    private void OnTriggerEnter(Collider other) {
        if (!isBallInHands && !isBallFlying) {
            isBallInHands = true;
            ballRigidbody.isKinematic = true;
        }
    }

    

    //topun çembere çarpması ve geri tepmesi:
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