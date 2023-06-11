using System.Linq;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private MusicTrack[] _musics;    

    private AudioSource _audioSource;

    public void PlayMusic(int musicGroup)
    {
        _audioSource = GetComponent<AudioSource>();

        var collection = _musics.Where(x => x.MusicGroup == musicGroup).ToArray();

        _audioSource.clip = collection[Random.Range(0, collection.Length)].Track;
        _audioSource.Play();
    }
}
