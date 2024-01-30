using UnityEngine;

public class DartController : MonoBehaviour
{
    [SerializeField] private float attenuation = 0.98f;//���Ⱚ.1�̸����� ������ ��
    private float divide = 1;//������ ��ġ.������ ���̹Ƿ� 0�� �Ǿ �ȵȴ�.
    public static float moveSpeed;//�̵� �ӵ�
    [SerializeField] private float minDivide = 1000;//��������(�ּ�)
    [SerializeField] private float maxDivide = 5000;//��������(�ִ�)

    private Vector3 startPos;//���콺 Ŭ����ǥ
    private Vector3 dir;//���콺 �巡�� �Ÿ�
    public static int count = 0;//�õ�Ƚ��
    public static bool isGameOver = false;//�������Ῡ��

    void Update()
    {
        if (isGameOver) //���ӿ����� �Ǹ�
            return;//������ ����(���콺 Ŭ��)�� ���´�
        //���콺�� �巡���ϸ� �巡���� ����� ���� * ������ġ�� ������ ǥâ�� ���ư���.
        if (Input.GetMouseButtonDown(0))//���콺�� ���� ��
        {
            divide = Random.Range(minDivide, maxDivide);//���ư��� ���� �����ϰ� �����Ѵ�
            startPos = Input.mousePosition;//���콺�� ������ ����
            //Debug.Log("random : " + divide);
        }
        else if (Input.GetMouseButtonUp(0))//���콺�� �� ��
        {
            dir = Input.mousePosition - startPos;//���콺�� ������ ���� ���� - ���������� �Ÿ�
            moveSpeed = 1;//�̵�����
            count++;//�õ�Ƚ���� ī��Ʈ�Ѵ�.
        }
        //transform.Translate(dir.x / divide * moveSpeed, dir.y / divide * moveSpeed, 0);
        //Translate()�� ȸ�������� ������ �޴´�.�׷��� position������Ƽ�� ��ǥ���� �ٲ������
        //transform.position += new Vector3(dir.x, dir.y, 0) / divide * moveSpeed;//�̵�
        transform.Translate(dir.x / divide * moveSpeed, dir.y / divide * moveSpeed, 0, Space.World);
        transform.Rotate(0, 0, moveSpeed * divide / 100);//ȸ��
        //Debug.LogFormat("x , y : {0}, {1}", dir.x, dir.y);

        moveSpeed *= attenuation;//�̵��ӵ�����
        if (moveSpeed < 0.001f)
        {
            //�ӵ��� Ư�� ��ġ �Ʒ��� �Ǹ� ������ �����ϵ��� �Ѵ� 
            moveSpeed = 0;
        }
    }
}
