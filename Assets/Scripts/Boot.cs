using Infrastructure;
using UnityEngine;

public class Boot : MonoBehaviour
{
    private void Start()
    {
        var game = new Game();
        DontDestroyOnLoad(gameObject);
    }
}
