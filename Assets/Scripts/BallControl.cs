using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallControl : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody rigidbody;
    public GameObject collectableObject;
    public GameObject impactObject;
    public GameObject canvas;
    public GameObject explosion;
    private float scoreValue = 0;
    private int destroyCount = 5;
    AudioSource redObjectAudio;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        redObjectAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            rigidbody.AddForce(Vector3.right * ballSpeed);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            rigidbody.AddForce((-1) * Vector3.right * ballSpeed);
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            rigidbody.AddForce(Vector3.forward * ballSpeed);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            rigidbody.AddForce((-1) * Vector3.forward * ballSpeed);
        }

        if(destroyCount >= 15)
            {
                Time.timeScale = 0F;
                canvas.SetActive(true);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Red Object"))
        {
            scoreValue += 10f;
            redObjectAudio.Play();
            Destroy(other.gameObject);
            CreateCollectableObject();
        }

        if(other.gameObject.CompareTag("Turtle"))
        {
            if(scoreValue == 10)
            {
                scoreValue -= 10f;
            }
            else if(scoreValue >= 20)
            {
                scoreValue -= 20f;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            CreateImpactObject();   
            destroyCount++;
        }

        if(other.gameObject.CompareTag("Center Dot"))
        {
            if(scoreValue >= 50)
            {
                Destroy(GameObject.FindWithTag("Turtle"));
                scoreValue -= 50;
                destroyCount--;
                if(destroyCount == 0)
                {
                    Time.timeScale = 0F;
                    canvas.SetActive(true);
                }
            }
        }
        scoreText.text = "SCORE : " + scoreValue;
    }

    private void CreateImpactObject()
    {
        Instantiate(impactObject, new Vector3(Random.Range(-11, 11), 0.5f, Random.Range(-11, 11)), Quaternion.identity);
        this.impactObject.SetActive(true);
    }

    private void CreateCollectableObject()
    {
        Instantiate(collectableObject, new Vector3(Random.Range(-11, 11), 0.5f, Random.Range(-11, 11)), Quaternion.identity);
    }
}
