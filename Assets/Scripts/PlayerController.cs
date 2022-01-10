using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody Player;
    public float speed = 1000f;
    private int score = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            Player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            Player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            Player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            Player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        if (other.CompareTag("Goal"))
        {
            Debug.Log($"You win!");
        }
    }
}
