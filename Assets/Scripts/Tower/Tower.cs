using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private int _currentLevel;
    private List<Segment> _segments;
    private TowerBuilder _towerBuilder;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();

        _segments = _towerBuilder.Build();

        foreach (var segment in _segments)
        {
            segment.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_segments.Count);
    }

    private void OnBulletHit(Segment hittedSegment)
    {
        hittedSegment.BulletHit -= OnBulletHit;

        _segments.Remove(hittedSegment);

        foreach (var segment in _segments)
        {
            segment.transform.Translate(-Vector3.up * segment.transform.localScale.y );
        }

        SizeUpdated?.Invoke(_segments.Count);
    }
}
