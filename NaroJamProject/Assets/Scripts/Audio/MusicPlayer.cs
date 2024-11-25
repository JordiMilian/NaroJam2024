using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> SongsList;
    [SerializeField] AudioClip deathSong;
    [SerializeField] float minPauseBetweenSongs, maxPauseBetweenSongs;
    [SerializeField] CatGenerator catGenerator;
    AudioSource musicSource;

    public static MusicPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    private void OnEnable()
    {
        musicSource = GetComponent<AudioSource>();
        catGenerator.OnFirstCatSpawned += startPlaying;
    }
    private void OnDisable()
    {
        catGenerator.OnFirstCatSpawned -= startPlaying;
    }
    void startPlaying()
    {
        StartCoroutine(playRandomSong(-1));
    }
    IEnumerator playRandomSong(int lastSongIndex)
    {
        int RandomIndex;
        do
        {
            RandomIndex = Random.Range(0, SongsList.Count);
        }
        while (RandomIndex == lastSongIndex);

        musicSource.clip = SongsList[RandomIndex];
        musicSource.Play();
        yield return new WaitForSeconds(SongsList[RandomIndex].length);
        musicSource.Stop();
        yield return new WaitForSeconds(Random.Range(minPauseBetweenSongs,maxPauseBetweenSongs));

        StartCoroutine(playRandomSong(RandomIndex));
    }

    public void PlayDeathMusic()
    {
        StopAllCoroutines();
        musicSource.Stop();
        musicSource.clip = deathSong;
        musicSource.Play();
    }
}
