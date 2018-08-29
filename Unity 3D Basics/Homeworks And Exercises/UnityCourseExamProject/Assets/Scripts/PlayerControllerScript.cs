using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : MonoBehaviour
{
    public bool isMoving;
    public bool isGrounded;
    public Rigidbody2D attachedRigidbody;
    public float charachterMovingSpeed = 2f;

    Text scoreText;
    AudioSource[] audioSources;

    float speedMultiplier;

    Animator dumpyAnimator;

    public float jumpForce;
    
    int score;

	// Use this for initialization
	void Start ()
	{    
	    scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        dumpyAnimator = GetComponent<Animator>();
	    audioSources = GetComponents<AudioSource>();

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = string.Format("Score: {0}", score);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovement();

    }


    void UpdateMovement()
    {
        if (!isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dumpyAnimator.Play("CharachterAttack");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            attachedRigidbody.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            audioSources[0].Play();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speedMultiplier = 1f;

            if (!dumpyAnimator.GetBool("Run"))
            {
                dumpyAnimator.SetBool("Run", true);
            }

            if (transform.rotation.y != 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speedMultiplier = -1.5f;

            if (!dumpyAnimator.GetBool("Run"))
            {
                dumpyAnimator.SetBool("Run", true);
            }

            if (transform.rotation.y != 180)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        
        else
        {
            speedMultiplier = -0.8f;

            if (dumpyAnimator.GetBool("Run"))
            {
                dumpyAnimator.SetBool("Run", false);
            }

        }
        
        attachedRigidbody.velocity = new Vector2(speedMultiplier * charachterMovingSpeed * Time.deltaTime, attachedRigidbody.velocity.y);
    }
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Land") && coll.transform.position.y < transform.position.y)
        {
            isGrounded = true;
        }
        else if (coll.collider.CompareTag("ResetCollider"))
        {
            score = 0;
            PlayerPrefs.SetInt("Score",0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Land") && coll.transform.position.y < transform.position.y && !isGrounded)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Land") && coll.transform.position.y < transform.position.y)
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Banana"))
        {
            Destroy(coll.gameObject);
            score++;
            PlayerPrefs.SetInt("Score", score);
            scoreText.text = string.Format("Score: {0}", score);
            audioSources[1].Play();
        }
    }
}
