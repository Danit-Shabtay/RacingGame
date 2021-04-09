using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;
    private AudioSource collectSound;
    private int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        collectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        collectSound.Play();
        score++;
        scoreText.text = score.ToString();
        
    }
}
