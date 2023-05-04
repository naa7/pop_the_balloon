using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BalloonTwo_Movement : MonoBehaviour
{
    [SerializeField] float movementLR;
    [SerializeField] float movementUD;
    [SerializeField] float moveFactorLR = 1.0f;
    [SerializeField] float moveFactorUD = 1.0f;
    [SerializeField] int speed = 2;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool directionDown = true;
    [SerializeField] int level;

    [SerializeField] Vector2 theScale;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject balloon2;
    [SerializeField] AudioSource audioPop;
    public AudioClip pop;
    [SerializeField] GameObject controller;
    [SerializeField] GameObject player;

    //Hardcoded boundaries for Camera in Game
    [SerializeField] float leftBound = -14.5f;
    [SerializeField] float rightBound = 14.5f;
    [SerializeField] float upBound = 5.0f;
    [SerializeField] float downBound = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        theScale = transform.localScale;
        level = SceneManager.GetActiveScene().buildIndex;
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (balloon2 == null)
            balloon2 = GameObject.FindGameObjectWithTag("Balloon2");
        if (audioPop == null)
            audioPop = balloon2.GetComponent<AudioSource>();
        speed = 4;
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("ScoreBoard");
    }

    // Update is called once per frame
    void Update()
    {
        movementLR = moveFactorLR;
        movementUD = moveFactorUD;
        if (level == 1)
        {
            speed = 10;
        }
        else if (level == 2)
        {
            speed = 40;
        }
        else if (level  == 3)
        {
            speed = 70;
        }

    }

    private void FixedUpdate()
    {

        if (level == 1)
        {
            EasyMovement();
            VerticalMovement();        }
        else if (level == 2)
        {
            EasyMovement();
            VerticalMovement();        }
        else if (level == 3)
        {
            EasyMovement();
            VerticalMovement();        }

    }

    public void EasyMovement()
    {
        rigid.velocity = new Vector2(movementLR * speed, rigid.velocity.y);
        if (movementLR < 0 && isFacingRight || movementLR > 0 && !isFacingRight)
            Flip();
        Movement();

    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    void Movement()
    {
        if((transform.position.x <= leftBound && !isFacingRight) || (transform.position.x >= rightBound && isFacingRight))
        {
            moveFactorLR = -moveFactorLR;
            VerticalMovement();
        }
        
    }

    public void VerticalMovement()
    {
        if (transform.position.y + moveFactorUD > upBound && !directionDown)
        {
            transform.position = new Vector2(transform.position.x, upBound);
            directionDown = !directionDown;
        }
        else if (transform.position.y - moveFactorUD < downBound && directionDown)
        {
            transform.position = new Vector2(transform.position.x, downBound);
            directionDown = !directionDown;
        }
        else if (transform.position.y - moveFactorUD >= downBound && directionDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveFactorUD);
        }
        else if (transform.position.y + moveFactorUD <= upBound && !directionDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveFactorUD);
        }

    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            audioPop.PlayOneShot(pop);
            yield return new WaitForSeconds(0.3f);
            controller.GetComponent<Scorekeeper>().UpdateScoreNegative(500);
            Destroy(this.gameObject);
            SceneManager.LoadScene("Level " + level);
        }
        
    }

}
