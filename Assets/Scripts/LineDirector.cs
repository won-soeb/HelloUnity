using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LineDirector : MonoBehaviour
{
    Transform dartPos;//표창의 위치
    Transform linePos;//라인(도착선)의 위치
    Text text;//텍스트UI
    Text resultText;//텍스트UI
    public GameObject retryButton;
    [SerializeField] private int tryNumber = 10;//시도횟수
    void Start()
    {
        dartPos = GameObject.Find("Dart").transform;//Dart오브젝트를 찾아서 Transform인스턴스를 추출한다
        linePos = GameObject.Find("Line").transform;//Line오브젝트를 찾아서 Transform인스턴스를 추출한다
        text = GameObject.Find("Text").GetComponent<Text>();//Text오브젝트를 찾아 Text컴포넌트에 접근한다
        resultText = GameObject.Find("ResultText").GetComponent<Text>();//ResultText오브젝트를 찾아 Text컴포넌트에 접근한다
    }
    //표창을 던져 특정 시도 횟수 내에 라인에 위치시켜야 한다.
    void Update()
    {
        if (tryNumber - DartController.count <= 0) //트라이 횟수가 음수가 되지 않도록 한다
        {
            text.text = "남은 트라이 : 0";
        }
        else
        {
            text.text = "남은 트라이 : " + (tryNumber - DartController.count);//텍스트에 남은 트라이 횟수를 출력한다
        }
        //Debug.LogFormat("<color=yellow>시도횟수 : {0}</color>", DartController.count);//콘솔창에 확인
        float length = linePos.position.y - dartPos.position.y;//표창과 도착지까지의 거리를 계산한다
                                                               //도착선이 가로이므로 y축을 추출해 비교하면 된다.
                                                               //Debug.LogFormat("남은거리 : {0}", length);//콘솔창에 확인

        if (DartController.moveSpeed == 0)//표창의 이동이 멈추면 게임이 종료된다
        {
            //게임실패조건.남은 트라이가 0이하가 되면                                                                               
            if (tryNumber - DartController.count <= 0)
            {
                resultText.text = "실패!";//resultText에 텍스트 출력
                DartController.isGameOver = true;//게임오버시 마우스클릭을 못하게한다
                retryButton.SetActive(true);//버튼 활성화
            }
            //게임성공조건.도착선까지의 거리가 0.05이내라면
            else if (Mathf.Abs(length) < 0.05f)
            {
                //표창이 도착선을 넘어가면 length가 음수가 되므로 절댓값으로 처리해준다.
                resultText.text = "성공!";
                DartController.isGameOver = true;
                retryButton.SetActive(true);
            }
        }
        //Debug.Log("isGameOver : " + DartController.isGameOver);
        //Debug.LogFormat("IsSuccess : {0}", Mathf.Abs(length) < 0.05f && DartController.moveSpeed == 0);
    }
    public void ResetButton()//씬 재로드 버튼
    {
        //static변수의 값을 모두 초기화한다.
        DartController.count = -1;
        DartController.isGameOver = false;
        SceneManager.LoadScene("ThrowDart");
    }
}
