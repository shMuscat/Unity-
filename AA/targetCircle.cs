using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCircle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = -30f; //�ð���� (����)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
