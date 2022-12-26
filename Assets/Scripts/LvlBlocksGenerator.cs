using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

public class LvlBlocksGenerator : MonoBehaviour
{
    private readonly List<GameObject> _prefabs = new List<GameObject>();
    private readonly Vector3 _startPosition = new Vector3(-17.34f, 19.9f, 0);
    private float _blockSize;
    
    private void Start()
    {
        AddPrefabToList(Constants.BlockIron);
        AddPrefabToList(Constants.BlockWood);
        AddPrefabToList(Constants.BlockGlass);
        AddPrefabToList(Constants.BlockBrick);
        _blockSize = GetBlockSize();
        GenerateRandomBlocks();
    }

    private float GetBlockSize()
    {
        return _prefabs.FirstOrDefault()!
            .GetComponent<MeshRenderer>()
            .bounds
            .size
            .x;
    }
    
    private void AddPrefabToList(string name)
    {
        _prefabs.Add(LoadPrefab(name));
    }

    private GameObject LoadPrefab(string name)
    {
        return Resources.Load($"Prefabs/{name}") as GameObject;
    }

    private void GenerateRandomBlocks()
    {
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 6; j++)
            {
                var block = GetRandomBlock();
                var blockPosition = new Vector3(_startPosition.x + (j * _blockSize), _startPosition.y + i, _startPosition.z);
                block.transform.position = blockPosition;
                Instantiate(block);
            }
        }
    }

    private GameObject GetRandomBlock()
    {
        return _prefabs[Random.Range(0, 4)];
    }
}
