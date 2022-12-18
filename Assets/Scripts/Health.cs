using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

public class Health : MonoBehaviour
{
    private List<GameObject> _getComponentsInChildren;
    private IProgressService _progressService;
        
    private  void Start()
    {
        _progressService = DIConteiner.GetInstance<IProgressService>();
        _progressService.OnDied += HealthChanged;
        
        _getComponentsInChildren = new List<GameObject>();
        var count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            _getComponentsInChildren.Add(transform.GetChild(i).gameObject);
        }
    }

    private void HealthChanged()
    {
        var health = _progressService.HealthCount;
        for (int i = 0; i < _getComponentsInChildren.Count; i++)
        {
            _getComponentsInChildren[i].SetActive(health > i);
        }
    }
}