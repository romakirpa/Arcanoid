using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class Health : MonoBehaviour
{
    private List<GameObject> _getComponentsInChildren;
        
    void Start()
    {
        Game.MinusHealth += HealthChanged;
        
        _getComponentsInChildren = new List<GameObject>();
        var count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            _getComponentsInChildren.Add(transform.GetChild(i).gameObject);
        }
    }

    private void HealthChanged()
    {
        for (int i = 0; i < _getComponentsInChildren.Count; i++)
        {
            _getComponentsInChildren[i].SetActive(Game.Health > i);
        }
    }
}