using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 0.1f;
    [SerializeField] private float attenuation = 0.96f;
    [SerializeField] private float diviedNum = 500f;
    private float speed = 0;
    private Vector3 startPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("화면을 터치함");
            //speed = MaxSpeed;
            //터치한 화면 위치 가져오기
            Debug.Log(Input.mousePosition);
            startPosition = Input.mousePosition;
        }
        //else if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("화면을 터치중");
        //}
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("화면에서 손을 뗌");
            //손을뗀 지점 x -길이구하기
            float length = Input.mousePosition.x - startPosition.x;
            //Debug.Log(length);            
            //Debug.Log(length/500f);
            speed = length / diviedNum;
            Debug.LogFormat("<color=Yellow>speed : {0}</color>", speed);

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //0.1유닛씩 프레임마다 이동
        transform.Translate(new Vector3(speed, 0, 0));
        //프레임마다 속도를 감쇄
        speed *= attenuation;
    }
}
