using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float speed = 0;      //�ʱ� �ӵ� ����
    Vector2 startPos;   // �������� ����

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;   //��� ��⿡�� 60FPS�� �۵�
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;        //���콺 ���������� ��ġ�� ���������� ����
        }

        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;       //���콺�� �������� ��ġ�� �������� ����
            float swipeLength = endPos.x - this.startPos.x;     // ������ �������� ���̷� ������������ ����

            this.speed = swipeLength / 500.0f;              // ���ǵ� ����

            GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);      //��ġ ��ȭ
        this.speed *= 0.98f;        //���� �پ��� �ӵ�
    }
}
