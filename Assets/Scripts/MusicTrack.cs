using UnityEngine;

[CreateAssetMenu(menuName = "MusicTrack")]
public class MusicTrack : ScriptableObject
{
    [SerializeField] private AudioClip _track;
    [SerializeField] private int _musicGroup;

    public AudioClip Track => _track;
    public int MusicGroup => _musicGroup;
}
