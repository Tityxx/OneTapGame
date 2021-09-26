using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавнер трассы
/// </summary>
public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private List<TrackSize> trackPrefabs;
    [SerializeField]
    private int trackCount = 10;
    [SerializeField]
    private float distanceToRemove = 10;
    [SerializeField]
    private TrackSize lastTrack;
    [SerializeField]
    private Transform player;

    private Vector3 lastPosition = Vector3.zero;

    private List<TrackSize> tracks = new List<TrackSize>();

    private void Awake()
    {
        PlayerController.OnPlayerDie += OnPlayerDie;

        lastTrack.Magnitude = lastTrack.gameObject.transform.position.magnitude;
        tracks.Add(lastTrack);
        for (int i = 0; i < trackCount; i++)
        {
            CreateTrack();
        }
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerDie -= OnPlayerDie;
    }

    private void Update()
    {
        int currCount = tracks.Count;

        for (int i = 0; i < tracks.Count; i++)
        {
            if (tracks[i].Magnitude + distanceToRemove < player.position.magnitude)
            {
                Destroy(tracks[i].gameObject);
                tracks.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < currCount - tracks.Count; i++)
        {
            CreateTrack();
        }
    }

    private void CreateTrack()
    {
        TrackSize track = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Count)], lastPosition += lastTrack.Position, Quaternion.identity);
        lastTrack = track;
        lastTrack.Magnitude = track.transform.position.magnitude;
        tracks.Add(lastTrack);
    }

    private void OnPlayerDie()
    {
        enabled = false;
    }
}
