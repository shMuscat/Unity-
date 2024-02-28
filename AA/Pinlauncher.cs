using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinlauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject pinObject;
    private Pin currPin;

    // Start is called before the first frame update
    void Start()
    {
        PreparePin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&currPin !=null)
        {
            currPin.Launch();
            currPin = null;
            Invoke("PreparePin", 0.2f);
        }
    }

    void PreparePin()
    {
        if (GameManager.instance.isGameOver == false)
        {
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
    }
}
