using DG.Tweening;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public Rock_root rockRoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {

            rockRoot.DropRock();
            Destroy(gameObject); // 触发一次就删掉
            
        }
    }
}
