using Assets.Scripts.Generators;
using Helpers;
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
        InitializeGenerators(new ScreenServices(), camera);
        GenerateLvl();
    }
    
    private void InitializeGenerators(ScreenServices screenService, Camera camera)
    {
        _wallsGenerator = new WallsGenerator(screenService.GetTopScreenCenterPoint(camera, _deepZ),
                                             screenService.GetDownScreenCenterPoint(camera, _deepZ),
                                             screenService.GetLeftScreenCenterPoint(camera, _deepZ),
                                             screenService.GetRightScreenCenterPoint(camera, _deepZ));
        _blocksGenerator = new BlocksGenerator(_horizontalBlocksCount,
                                               _verticalBlocksCount,
                                               screenService.GetLeftScreenCenterPoint(camera, _deepZ),
                                               screenService.GetRightScreenCenterPoint(camera, _deepZ));
        _ballGenerator = new BallGenerator();
        _liftGenerator = new LiftGenerator(screenService.GetLeftScreenCenterPoint(camera, _deepZ),
                                           screenService.GetRightScreenCenterPoint(camera, _deepZ),
                                           screenService.GetDownScreenCenterPoint(camera, _deepZ));
        _healthMonitorGenerator = new HealthMonitorGenerator(screenService.GetTopScreenCenterPoint(camera, _deepZ),
                                                             screenService.GetLeftScreenCenterPoint(camera, _deepZ));
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