using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PandaMove : MonoBehaviour
{
    Animator PandaAnimator;
    Rigidbody2D rb;
    float InputX, InputY;
    public float speed;
    SpriteRenderer sr;
    bool checkDead = false;
    public int Hp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PandaAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal") * speed;
        InputY = Input.GetAxis("Vertical") * speed;
        if(InputX ==0)
        {

            PandaAnimator.SetInteger("PandaState", 0);
        }
        down();
        jump();
        dead();
        fall();
        hurt();
        if (checkDead)
        {
            PandaAnimator.SetInteger("PandaState", 8);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(InputX, rb.velocity.y, InputY);
        PandaAnimator.SetInteger("PandaState", 1);
        flip();
    }

    void flip()
    {
        if(InputX <0)
        {
            sr.flipX = true;
        }
        if(InputX >0)
        {
            sr.flipX = false;
        }
    }

    void down()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            PandaAnimator.SetInteger("PandaState", 4);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            PandaAnimator.SetInteger("PandaState", 5);
        }
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            PandaAnimator.SetInteger("PandaState", 10);
            transform.position += new Vector3(InputX, 10f, InputY);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            PandaAnimator.SetInteger("PandaState", 11);
        }
    }

    void hurt()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            PandaAnimator.SetInteger("PandaState", 8);
        }
        if(Input.GetKeyUp(KeyCode.N))
        {
            PandaAnimator.SetInteger("PandaState", 9);
        }
    }

    void dead()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PandaAnimator.SetInteger("PandaState", 2);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            PandaAnimator.SetInteger("PandaState", 3);
        }
    }

    void fall()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            PandaAnimator.SetInteger("PandaState", 6);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            PandaAnimator.SetInteger("PandaState", 7);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dictionary<string, string> Alert = new Dictionary<string, string>(5);
        Alert.Add("Coin", "Score Increase");
        Alert.Add("Poison", "Hp Decrease");
        Alert.Add("Potion", "Hp Increase");

        if (collision.gameObject.tag == "Boss")
        {
            checkDead = true;
            SceneManager.LoadScene("Lose");
        }
        if (collision.gameObject.tag == "poison")
        {
            PandaAnimator.SetInteger("PandaState", 8);
            Debug.Log("Alert: " + Alert["Poison"].ToString());
        }
        if (collision.gameObject.tag == "HealthPotion")
        {
            PandaAnimator.SetInteger("PandaState", 9);
            Debug.Log("Alert: " + Alert["Potion"].ToString());
        }
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("Alert: " + Alert["Coin"].ToString());
        }
        if (collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }
    }

}
