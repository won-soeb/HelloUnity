using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //�� ��ũ��Ʈ�� Canvas�� �����Ѵ�.
    private GameObject carGo;
    private GameObject flagGo;
    private GameObject distanceGo;

    private Text distanceText;

    private void Start()
    {
        this.carGo = GameObject.Find("car");
        this.flagGo = GameObject.Find("flag");
        this.distanceGo = GameObject.Find("distanceText");
        //Debug.LogFormat("this.carGo : {0}", this.carGo);
        //Debug.LogFormat("this.flagGo : {0}", this.flagGo);
        //Debug.LogFormat("this.distanceGo : {0}", this.distanceGo);

        distanceText = distanceGo.GetComponent<Text>();
        Debug.LogFormat("distanceText : {0:0.00}", distanceText);
        //distanceText.text = "test";
    }
    private void Update()
    {
        //�� �����Ӹ��� �ڵ����� ����� �Ÿ��� ���
        float length = flagGo.transform.position.x - carGo.transform.position.x;
        distanceText.text = string.Format("�����Ÿ� : {0:0.00}m", length);
        Debug.Log(string.Format("�����Ÿ� : {0:0.00}m", length.ToString()));
    }
}
