using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movementLR;
    [SerializeField] float movementUD;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        movementLR = Input.GetAxis("Horizontal");
        movementUD = Input.GetAxis("Vertical");
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movementLR * speed, movementUD * speed);
        if (readyToFlip())
            Flip();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    //to be used by PinMovement script
    public bool getDirection() {
        if (isFacingRight)
            return true;
        return false;
    }

    public bool readyToFlip()
    {
        if (movementLR < 0 && isFacingRight || movementLR > 0 && !isFacingRight)
            return true;
        else
            return false;
    }

    public float GetMovementLR()
    {
        return movementLR;
    }

    public float GetMovementUD()
    {
        return movementUD;
    }

}