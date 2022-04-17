using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerHeight;
    [SerializeField] private Segment _segment;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private float _segmentsRotation;
    [SerializeField] private Color[] _colors;

    private List<Segment> _segments;

    public List<Segment> Build()
    {
        _buildPoint.transform.localScale = _segment.transform.localScale;

        _segments = new List<Segment>();

        _buildPoint.transform.Translate (Vector3.down * _segment.transform.localScale.y);

        for (int i = 0; i < _towerHeight; i++)
        {
            Segment newSegment = BuildSegment(_buildPoint);
            _segments.Add(newSegment);
        }

        SetItarartedSegmentColors(_segments, _colors);

        return _segments;
    }

    private Segment BuildSegment (Transform buildPoint)
    {
        buildPoint = GetBuildPoint(buildPoint);
        return Instantiate(_segment, buildPoint.position, buildPoint.rotation);
    }

    private Transform GetBuildPoint (Transform buildPoint)
    {
        buildPoint.position += Vector3.up * buildPoint.localScale.y;
        buildPoint.Rotate(Vector3.up, _segmentsRotation);

        return buildPoint;
    }

    private void SetItarartedSegmentColors(List<Segment> segments, Color[] colors)
    {
        for (int i = 0; i < segments.Count; i++)
        {
            segments[i].SetColor(colors[i % colors.Length]);
        }
    }

    private void SetRandomSegmentColors(List<Segment> segments, Color[] colors)
    {

    }
}
