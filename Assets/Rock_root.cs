using UnityEngine;
using System.Collections;

public class Rock_root : MonoBehaviour
{
    public GameObject rockHang;   // Ðü¹Ò×´Ì¬
    public GameObject rockFall;   // µôÂä×´Ì¬

    public float dropDelay = 0.3f; // ¿ÉÑ¡ÑÓ³Ù

    private bool hasDropped = false;

    public void DropRock()
    {
        if (hasDropped) return;

        hasDropped = true;
        StartCoroutine(DropRoutine());
    }

    IEnumerator DropRoutine()
    {
        yield return new WaitForSeconds(dropDelay);

        rockHang.SetActive(false);
        rockFall.SetActive(true);
    }
}