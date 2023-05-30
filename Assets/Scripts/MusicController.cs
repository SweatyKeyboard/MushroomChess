using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _musics;
    [SerializeField] private int _songsInGroup;

    private AudioSource _audioSource;

    public void PlayMusic(int collection)
    {
        _audioSource = GetComponent<AudioSource>();        
        int min = collection * _songsInGroup;
        int max = min + _songsInGroup;

        _audioSource.clip = _musics[Random.Range(min, max)];
        _audioSource.Play();
    }
}
