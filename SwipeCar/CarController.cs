using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float speed = 0;      //초기 속도 설정
    Vector2 startPos;   // 시작지점 선언

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;   //모든 기기에서 60FPS로 작동
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;        //마우스 눌렀을때의 위치를 시작점으로 저장
        }

        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;       //마우스를 땠을때의 위치를 끝점으로 저장
            float swipeLength = endPos.x - this.startPos.x;     // 끝점과 시작점의 차이로 스와이프길이 저장

            this.speed = swipeLength / 500.0f;              // 스피드 설정

            GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);      //위치 변화
        this.speed *= 0.98f;        //점점 줄어드는 속도
    }
}
