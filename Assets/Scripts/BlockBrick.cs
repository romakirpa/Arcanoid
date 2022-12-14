using System.Collections;
using Infrastructure;
using UnityEngine;

public class BlockBrick : MonoBehaviour, IBlock
{
    private float _health;
    private AudioSource _audioSource;

    private void Start()
    {
        _health = 3;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Hit(float damage)
    {
        _health -= damage;
        _audioSource.Play();
        if (_health > 0)
        {
            return;
        }
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