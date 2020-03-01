using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{

    public float speed = 25;
    public Text countText;
    public Text winText;
    public float jump_force = 10;
    public bool grounded = true;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 targetDirection = new Vector3(moveHorizontal, 0f, moveVertical);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;


        rb.AddForce(targetDirection * speed);
        if (Input.GetKey("space") && grounded == true)
        {
            grounded = false;
            GetComponent<Rigidbody>().velocity = Vector3.up * jump_force;
        }
        if (rb.position.y < -1.2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "" + count.ToString();
        if (count >= 3)
        {
            winText.text = "Borð Klárað";
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}