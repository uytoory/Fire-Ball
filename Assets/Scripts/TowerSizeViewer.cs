using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text TMP;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdated += UpdateSizeViewer;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= UpdateSizeViewer;
    }

    private void UpdateSizeViewer(int size)
    {
        TMP.text = size.ToString();
        if (size == 0)
        {
            Debug.Log("Win!");
            TMP.text = "Win!";
        }
    }
}
