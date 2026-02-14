using UnityEngine;

public class SceneResetManager : MonoBehaviour
{
    private ResettableObject[] resetObjects;
    private Rigidbody2D[] allRigidbodies;

    void Start()
    {
        resetObjects = FindObjectsOfType<ResettableObject>(true);
        allRigidbodies = FindObjectsOfType<Rigidbody2D>();
    }

    public void ResetScene()
    {
        ResettableObject[] resetObjects = FindObjectsOfType<ResettableObject>(true);

        
        StopAllPhysics();
        ResetAllObjects();
    }

    void StopAllPhysics()
    {
        foreach (var rb in allRigidbodies)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = false;  // 暂停物理
        }
    }

    void ResetAllObjects()
    {
        foreach (var obj in resetObjects)
        {
            obj.ResetState();
        }

        // 重置完后再恢复物理
        foreach (var rb in allRigidbodies)
        {
            rb.simulated = true;
        }
    }
}
