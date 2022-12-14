using System.Collections;
using Infrastructure;
using UnityEngine;

public class BlockGlass : MonoBehaviour, IBlock
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Hit(float damage)
    {
        _audioSource.Play();
        HideObject();
        StartCoroutine(DestroyAfterPlay());
    }

    private void HideObject()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
    }
    
    private IEnumerator DestroyAfterPlay()
    {
        while (_audioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}