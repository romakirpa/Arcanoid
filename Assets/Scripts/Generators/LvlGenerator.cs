using Assets.Scripts.Generators;
using Assets.Scripts.Infrastructure.Services.Interfaces;
using Helpers;
using Infrastructure;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField]
    private float _deepZ = 25;

    [SerializeField]
    private int _horizontalBlocksCount = 10;

    [SerializeField]
    private int _verticalBlocksCount = 10;

    private WallsGenerator _wallsGenerator;
    private BlocksGenerator _blocksGenerator;
    private LiftGenerator _liftGenerator;
    private BallGenerator _ballGenerator;
    private HealthMonitorGenerator _healthMonitorGenerator;

    private void Start()
    {
        var camera = GameObject.Find(Constants.Camera).GetComponent<Camera>();
        InitializeGenerators(camera);
        GenerateLvl();
    }

    private void InitializeGenerators(Camera camera)
    {
        var screenService = DiContainer.GetInstance<IScreenService>();

        var topSide = screenService.GetTopScreenCenterPoint(camera, _deepZ);
        var downSide = screenService.GetDownScreenCenterPoint(camera, _deepZ);
        var leftSide = screenService.GetLeftScreenCenterPoint(camera, _deepZ);
        var rightSide = screenService.GetRightScreenCenterPoint(camera, _deepZ);

        _wallsGenerator = new WallsGenerator(topSide, downSide, leftSide, rightSide);
        _blocksGenerator = new BlocksGenerator(_horizontalBlocksCount, _verticalBlocksCount, leftSide, rightSide);
        _ballGenerator = new BallGenerator();
        _liftGenerator = new LiftGenerator(leftSide, rightSide, downSide);
        _healthMonitorGenerator = new HealthMonitorGenerator(topSide, leftSide);
    }

    private void GenerateLvl()
    {
        _wallsGenerator.GenerateWalls();
        _blocksGenerator.GenerateBlocks();
        var lift = _liftGenerator.GenerateLift();
        _ballGenerator.GenerateBall(lift.transform.position);
        _healthMonitorGenerator.Generate();
    }
}