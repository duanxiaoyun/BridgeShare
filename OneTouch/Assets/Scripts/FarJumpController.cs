using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarJumpController : MonoBehaviour {

    public Slider sliderBar;
    //public Text ScoreUI;

    public Sprite[] numbers;

    int[] nums = new int[2];

    public GameObject TimeNum;

    private float timer = 30.0f;
    private bool isJump = false;

    private Rigidbody2D rigidBody;

    private Animator anim;
    public float jumpForce = 0.0f;
    public float runningSpeed = 0.0f;

    public LayerMask groundLayer;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        //ScoreUI.text = timer.ToString();

    }

    public void Jump()
    {
        jumpForce += 0.01f;
        runningSpeed += 0.1f;
    }

    public void Score()
    {
        Debug.Log("~~~");
    }

    // Update is called once per frame
    void Update ()
    {
        sliderBar.value = jumpForce;

        if (timer >= 0.1f)
        {
            timer -= Time.deltaTime;
            //ScoreUI.text = timer.ToString("0.0");
        
            for (int i = 0; i< 2; i++)
            {
                nums[0] = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]) / 10;
                nums[1] = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]) % 10;
                TimeNum.transform.GetChild(i).GetComponent<Image>().sprite = numbers[nums[i]];
            }
        }
        else if (timer >= 0.0f && timer<=0.1f)
        {
            //ScoreUI.text = "Jump".ToString();
        }

        if (timer < 0.4f && timer >= 0.1f)
        {
            anim.SetBool("isReady", true);
        }

        if (timer <= 0.1 && isJump == false)
        {
            anim.SetBool("isJump", true);
            rigidBody.AddForce(Vector2.up * runningSpeed, ForceMode2D.Impulse);
            rigidBody.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }

        if (!IsGrounded())
        {
            return;
        }

        else if (IsGrounded())
        {
            anim.SetBool("isGround", true);
            Score();
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.2f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

}
