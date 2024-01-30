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
            Debug.Log("ȭ���� ��ġ��");
            //speed = MaxSpeed;
            //��ġ�� ȭ�� ��ġ ��������
            Debug.Log(Input.mousePosition);
            startPosition = Input.mousePosition;
        }
        //else if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("ȭ���� ��ġ��");
        //}
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ȭ�鿡�� ���� ��");
            //������ ���� x -���̱��ϱ�
            float length = Input.mousePosition.x - startPosition.x;
            //Debug.Log(length);            
            //Debug.Log(length/500f);
            speed = length / diviedNum;
            Debug.LogFormat("<color=Yellow>speed : {0}</color>", speed);

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //0.1���־� �����Ӹ��� �̵�
        transform.Translate(new Vector3(speed, 0, 0));
        //�����Ӹ��� �ӵ��� ����
        speed *= attenuation;
    }
}
