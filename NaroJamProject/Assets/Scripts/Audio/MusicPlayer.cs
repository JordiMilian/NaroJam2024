using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> SongsList;
    [SerializeField] float minPauseBetweenSongs, maxPauseBetweenSongs;
    [SerializeField] CatGenerator catGenerator;
    AudioSource musicSource;
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

        yield return new WaitForSeconds(SongsList[RandomIndex].length);
        yield return new WaitForSeconds(Random.Range(minPauseBetweenSongs,maxPauseBetweenSongs));

        StartCoroutine(playRandomSong(RandomIndex));
    }
}
