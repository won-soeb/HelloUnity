using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    //1.마우스 왼쪽 클릭을 하면
    //2.회전한다
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float attenuation = 0.01f;
    private float speed = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = maxSpeed;
        }
        transform.Rotate(0, 0, 1 * speed);
        //speed *= attenuation;
        speed -= attenuation;
        if (speed < 0.01f)
        {
            speed = 0;
        }
    }
}
