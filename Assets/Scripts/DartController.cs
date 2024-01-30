using UnityEngine;

public class DartController : MonoBehaviour
{
    [SerializeField] private float attenuation = 0.98f;//감쇄값.1미만으로 설정할 것
    private float divide = 1;//힘조절 수치.나누는 값이므로 0이 되어선 안된다.
    public static float moveSpeed;//이동 속도
    [SerializeField] private float minDivide = 1000;//힘조절값(최소)
    [SerializeField] private float maxDivide = 5000;//힘조절값(최대)

    private Vector3 startPos;//마우스 클릭좌표
    private Vector3 dir;//마우스 드래그 거리
    public static int count = 0;//시도횟수
    public static bool isGameOver = false;//게임종료여부

    void Update()
    {
        if (isGameOver) //게임오버가 되면
            return;//이후의 로직(마우스 클릭)을 막는다
        //마우스를 드래그하면 드래그한 방향과 길이 * 랜덤수치의 힘으로 표창이 날아간다.
        if (Input.GetMouseButtonDown(0))//마우스를 누를 때
        {
            divide = Random.Range(minDivide, maxDivide);//날아가는 힘을 랜덤하게 지정한다
            startPos = Input.mousePosition;//마우스를 누르는 지점
            //Debug.Log("random : " + divide);
        }
        else if (Input.GetMouseButtonUp(0))//마우스를 뗄 때
        {
            dir = Input.mousePosition - startPos;//마우스를 눌렀다 떼는 지점 - 시작점과의 거리
            moveSpeed = 1;//이동시작
            count++;//시도횟수를 카운트한다.
        }
        //transform.Translate(dir.x / divide * moveSpeed, dir.y / divide * moveSpeed, 0);
        //Translate()는 회전각도의 영향을 받는다.그래서 position프로퍼티로 좌표값만 바꿔줘야함
        //transform.position += new Vector3(dir.x, dir.y, 0) / divide * moveSpeed;//이동
        transform.Translate(dir.x / divide * moveSpeed, dir.y / divide * moveSpeed, 0, Space.World);
        transform.Rotate(0, 0, moveSpeed * divide / 100);//회전
        //Debug.LogFormat("x , y : {0}, {1}", dir.x, dir.y);

        moveSpeed *= attenuation;//이동속도감소
        if (moveSpeed < 0.001f)
        {
            //속도가 특정 수치 아래가 되면 완전히 정지하도록 한다 
            moveSpeed = 0;
        }
    }
}
