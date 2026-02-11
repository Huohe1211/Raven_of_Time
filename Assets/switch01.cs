using UnityEngine;

public class switch01 : MonoBehaviour
{
    public Elevator elevator;

    private bool canUse = false;

    void Update()
    {
        if (canUse && Input.GetKeyDown(KeyCode.F))
        {
            elevator.Toggle();
            Debug.Log("Switch activated by F");
            transform.localScale = new Vector3(transform.localScale.x, (float)(-1), transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canUse = true;
            Debug.Log("Player near switch");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canUse = false;
            Debug.Log("Player left switch");
        }
    }
}