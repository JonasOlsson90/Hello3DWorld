using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeTing : MonoBehaviour
{
    Rigidbody rb;
    int speed = 200;
    public static bool isScoreActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * speed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isScoreActive)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isScoreActive)
        {
            OnScreenText.bounce = 0;
            BallTing.totalScore = 10000000;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "DecreaseSpeed")
        {
            speed -= 50;
        }

        if (collision.gameObject.tag == "IncreaseSpeed")
        {
            speed += 50;
        }

        if (collision.gameObject.tag != "Ground")
            OnScreenText.bounce++;
    }
}
