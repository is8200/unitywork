using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    float jumpForce = 780.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2d.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2d.AddForce(transform.up * this.jumpForce);

        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2d.velocity.x);

        if(speedx < this.maxWalkSpeed)
        {
           
            //여기에 기기마다 속도차이를 감안하려면 Time.deltaTime 곱해줌
            this.rigid2d.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("ClearScene");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }

}
