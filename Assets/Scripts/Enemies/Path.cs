using System.Collections.Generic;
using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    public IReadOnlyList<Transform> Waypoints => Array.AsReadOnly(_waypoints);

    #if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _waypoints = new Transform[pointCount];

        for (int i = 0; i < pointCount; i++)
            _waypoints[i] = transform.GetChild(i);
    }
    #endif
    
    private void OnDrawGizmos()
    {
        if (_waypoints == null || _waypoints.Length < 2) return;

        Gizmos.color = Color.red;
        const float radius = 0.1f;

        for (int i = 0; i < _waypoints.Length; i++)
        {
            Gizmos.DrawSphere(_waypoints[i].position, radius);

            if (i + 1 < _waypoints.Length)
                Gizmos.DrawLine(
                    _waypoints[i].position,
                    _waypoints[i + 1].position
                );
        }
    }
}
