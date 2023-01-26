using Helpers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class BlocksGenerator
    {
        private readonly List<GameObject> _prefabs = new();
        private readonly int _horizontalBlocksCount = 10;
        private readonly int _verticalBlocksCount = 10;

        private float _blockSize;
        private Vector3 _startPosition;

        private Vector3 _leftCenterPoint;
        private Vector3 _rightCenterPoint;

        public BlocksGenerator(int horizontalBlocksCount,
                               int verticalBlocksCount,
                               Vector3 leftCenterPoint,
                               Vector3 rightCenterPoint) 
        {
            _horizontalBlocksCount = horizontalBlocksCount;
            _verticalBlocksCount = verticalBlocksCount;
            _leftCenterPoint = leftCenterPoint;
            _rightCenterPoint = rightCenterPoint;
        }

        public void GenerateBlocks()
        {
            MakePrefabsList();
            _blockSize = GetBlockSize();
            _startPosition = GetStartPosition();
            GenerateRandomBlocks();
        }

        private void MakePrefabsList()
        {
            AddPrefabToList(Constants.BlockIron);
            AddPrefabToList(Constants.BlockWood);
            AddPrefabToList(Constants.BlockGlass);
            AddPrefabToList(Constants.BlockBrick);
        }

        private Vector3 GetStartPosition()
        {
            var halfBlockSize = _prefabs[0].GetComponent<Renderer>().bounds.size.x / 2;
            return new Vector3(_leftCenterPoint.x + halfBlockSize, _leftCenterPoint.y, _leftCenterPoint.z);
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
            var block = Resources.Load($"Prefabs/{name}") as GameObject;
            var scale = Vector3.Distance(_leftCenterPoint, _rightCenterPoint) / _horizontalBlocksCount;
            block.transform.localScale = new Vector3(scale, 1, 1);
            return block;
        }

        private void GenerateRandomBlocks()
        {
            for (var i = 0; i < _verticalBlocksCount; i++)
            {
                for (var j = 0; j < _horizontalBlocksCount; j++)
                {
                    var block = GetRandomBlock();
                    var blockPosition = new Vector3(_startPosition.x + (j * _blockSize), _startPosition.y + i, _startPosition.z);
                    block.transform.position = blockPosition;
                    GameObject.Instantiate(block);
                }
            }
        }

        private GameObject GetRandomBlock() => _prefabs[Random.Range(0, 4)];
    }
}
