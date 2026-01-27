using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform topPoint;     // 升到哪里
    public Transform bottomPoint;  // 降到哪里
    public float speed = 2f;

    private bool goingUp = false;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving) return;

        Transform target = goingUp ? topPoint : bottomPoint;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // 到位就停
        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            isMoving = false;
        }
    }

    // 给开关调用的接口
    public void Toggle()
    {
        float distToTop = Vector3.Distance(transform.position, topPoint.position);
        float distToBottom = Vector3.Distance(transform.position, bottomPoint.position);

        goingUp = distToTop > distToBottom;
        isMoving = true;
    }
}
