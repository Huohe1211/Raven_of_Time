using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public Rock_root rockRoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rockRoot.DropRock();
        }
    }
}
