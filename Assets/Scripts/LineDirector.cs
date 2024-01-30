using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LineDirector : MonoBehaviour
{
    Transform dartPos;//ǥâ�� ��ġ
    Transform linePos;//����(������)�� ��ġ
    Text text;//�ؽ�ƮUI
    Text resultText;//�ؽ�ƮUI
    public GameObject retryButton;
    [SerializeField] private int tryNumber = 10;//�õ�Ƚ��
    void Start()
    {
        dartPos = GameObject.Find("Dart").transform;//Dart������Ʈ�� ã�Ƽ� Transform�ν��Ͻ��� �����Ѵ�
        linePos = GameObject.Find("Line").transform;//Line������Ʈ�� ã�Ƽ� Transform�ν��Ͻ��� �����Ѵ�
        text = GameObject.Find("Text").GetComponent<Text>();//Text������Ʈ�� ã�� Text������Ʈ�� �����Ѵ�
        resultText = GameObject.Find("ResultText").GetComponent<Text>();//ResultText������Ʈ�� ã�� Text������Ʈ�� �����Ѵ�
    }
    //ǥâ�� ���� Ư�� �õ� Ƚ�� ���� ���ο� ��ġ���Ѿ� �Ѵ�.
    void Update()
    {
        if (tryNumber - DartController.count <= 0) //Ʈ���� Ƚ���� ������ ���� �ʵ��� �Ѵ�
        {
            text.text = "���� Ʈ���� : 0";
        }
        else
        {
            text.text = "���� Ʈ���� : " + (tryNumber - DartController.count);//�ؽ�Ʈ�� ���� Ʈ���� Ƚ���� ����Ѵ�
        }
        //Debug.LogFormat("<color=yellow>�õ�Ƚ�� : {0}</color>", DartController.count);//�ܼ�â�� Ȯ��
        float length = linePos.position.y - dartPos.position.y;//ǥâ�� ������������ �Ÿ��� ����Ѵ�
                                                               //�������� �����̹Ƿ� y���� ������ ���ϸ� �ȴ�.
                                                               //Debug.LogFormat("�����Ÿ� : {0}", length);//�ܼ�â�� Ȯ��

        if (DartController.moveSpeed == 0)//ǥâ�� �̵��� ���߸� ������ ����ȴ�
        {
            //���ӽ�������.���� Ʈ���̰� 0���ϰ� �Ǹ�                                                                               
            if (tryNumber - DartController.count <= 0)
            {
                resultText.text = "����!";//resultText�� �ؽ�Ʈ ���
                DartController.isGameOver = true;//���ӿ����� ���콺Ŭ���� ���ϰ��Ѵ�
                retryButton.SetActive(true);//��ư Ȱ��ȭ
            }
            //���Ӽ�������.������������ �Ÿ��� 0.05�̳����
            else if (Mathf.Abs(length) < 0.05f)
            {
                //ǥâ�� �������� �Ѿ�� length�� ������ �ǹǷ� �������� ó�����ش�.
                resultText.text = "����!";
                DartController.isGameOver = true;
                retryButton.SetActive(true);
            }
        }
        //Debug.Log("isGameOver : " + DartController.isGameOver);
        //Debug.LogFormat("IsSuccess : {0}", Mathf.Abs(length) < 0.05f && DartController.moveSpeed == 0);
    }
    public void ResetButton()//�� ��ε� ��ư
    {
        //static������ ���� ��� �ʱ�ȭ�Ѵ�.
        DartController.count = -1;
        DartController.isGameOver = false;
        SceneManager.LoadScene("ThrowDart");
    }
}
