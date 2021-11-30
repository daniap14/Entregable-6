using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;


    private Rigidbody playerRigidbody;
    public float gravityModifier = 1;

    public float jumpForce = 400;

    private float limYPos = 14.0f;

    private AudioSource playerAudioSource;

    public AudioClip jumpClip;
    public AudioClip explosionClip;

    public ParticleSystem explosionParticleSystem;



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < limYPos && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 30);

        }

        if (transform.position.y >= limYPos)
        {
            transform.position = new Vector3(transform.position.x, limYPos, transform.position.z);
        }

        if (transform.position.y < -1)
        {
            playerAudioSource.PlayOneShot(explosionClip, 30);

           

            gameOver = true;
        }

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Bomb"))
        {
            playerAudioSource.PlayOneShot(explosionClip, 30);

            explosionParticleSystem.Play();

            gameOver = true;
        }
    }

}
