using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Services.Interfaces;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    private List<GameObject> _getComponentsInChildren;
    private IProgressService _progressService;
        
    private  void Start()
    {
        _progressService = DiContainer.GetInstance<IProgressService>();
        _progressService.OnDied += HealthChanged;
        
        _getComponentsInChildren = new List<GameObject>();
        var count = transform.childCount;
        for (var i = 0; i < count; i++)
        {
            _getComponentsInChildren.Add(transform.GetChild(i).gameObject);
        }
    }

    private void HealthChanged()
    {
        var health = _progressService.HealthCount;
        for (var i = 0; i < _getComponentsInChildren.Count; i++)
        {
            _getComponentsInChildren[i].SetActive(health > i);
        }
    }
}