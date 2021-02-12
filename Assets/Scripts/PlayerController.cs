using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public GameObject player;


    private Rigidbody rb;
    private int count;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        print(player.transform.localScale);
        print("aaaaahhhh");
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log(player.transform.localScale);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        print(player.transform.localScale);
        if (other.gameObject.CompareTag("Pick Up") && player.transform.localScale == new Vector3(1, 1, 1))
        {
            print(player.transform.localScale);
            source.Play();
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!";
        }
    }
}