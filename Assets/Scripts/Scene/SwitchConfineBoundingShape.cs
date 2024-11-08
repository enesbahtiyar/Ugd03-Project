using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    private void Start()
    {
        SwitchBoundingShape();
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }


    /// <summary>
    /// Switching the bounding shape of the cinemachine confiner when level changed
    /// </summary>
    private void SwitchBoundingShape()
    {
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.boundsConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        //since we changed the bounding shape we have to clear the cache
        cinemachineConfiner.InvalidatePathCache();
    }
}
