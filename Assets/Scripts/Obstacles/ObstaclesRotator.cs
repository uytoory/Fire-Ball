using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclesRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;

    private void Start()
    {
        transform.DORotate(Vector3.up * 360, _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
