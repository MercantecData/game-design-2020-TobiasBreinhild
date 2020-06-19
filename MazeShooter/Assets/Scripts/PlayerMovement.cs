using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    public float playerHealth;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * inputX;
        position.y += speed * Time.deltaTime * inputY;

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win Zone")
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (collision.tag == "Enemy")
        {
            playerHealth--;
        }

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
