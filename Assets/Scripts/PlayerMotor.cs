using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    public static PlayerMotor Instance { set; get; }

    private bool isRunning = false;

    public float speed;
    public static float x;
    private Rigidbody rb;

    private float aumentoVel;
    private float aumentoVelTiempo;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        aumentoVel = 2;
        aumentoVelTiempo = 0;
        x = 0;
    }

    private void FixedUpdate()
    {
        aumentoVelTiempo += Time.deltaTime;
        if (!isRunning)
        {
            return;
        }

        if (aumentoVelTiempo >= aumentoVel)
        {
            if (LevelManager.Instance.currentSpawnZ <= 1000)
            {
                speed += 0.2f;
            }
            if (LevelManager.Instance.currentSpawnZ > 1000 && LevelManager.Instance.currentSpawnZ <= 2000)
            {
                speed+= 0.1f;
            }
            if (LevelManager.Instance.currentSpawnZ > 2000)
            {
                speed += 0.05f;
            }   
            aumentoVel ++;
            if(MobileInput.swipeIntensity < 25)
            {
                MobileInput.swipeIntensity += 0.15f;
            }
        }

        Vector3 move = new Vector3(x, Physics.gravity.y, speed);
        rb.velocity = move;

        if (transform.position.y < -30)
        {
            GameManager.Instance.onDeath();
            isRunning = false;
        }

    }

    public void StartRunning()
    {
        isRunning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && isRunning== true)
        {
            GameManager.Instance.onDeath();
            isRunning = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" && isRunning == true)
        {
            GameManager.Instance.onDeath();
            isRunning = false;
        }
    }
}
