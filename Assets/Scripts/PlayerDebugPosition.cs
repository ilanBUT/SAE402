using UnityEngine;
 
public class PlayerDebugPosition : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField]
    private Transform debugTransform;
 
 
    void Awake()
    {
        if (debugTransform)
        {
            transform.position = debugTransform.position;
        }
    }
    #endif
}