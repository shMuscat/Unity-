using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)  //스페이스바를 눌렀을때 점프
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;   //초기 키값, 누르지 않았을 때
        if (Input.GetKey(KeyCode.RightArrow))   //오른쪽으로 이동
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))    //왼쪽으로 이동 시키기 위한 키값
            key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx<this.maxWalkSpeed) //최대 속도를 넘지 않도록 속도 조절
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        if(transform.position.y<-10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
