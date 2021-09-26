using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавнер трассы
/// </summary>
public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private List<string> tracksId;
    [SerializeField]
    private int trackCount = 10;
    [SerializeField]
    private float distanceToRemove = 10;
    [SerializeField]
    private TrackSize lastTrack;
    [SerializeField]
    private Transform player;

    private Vector3 lastPosition = Vector3.zero;

    private List<TrackSize> listTracks = new List<TrackSize>();
    private List<string> availableId;
    private string lastTrackId = string.Empty;

    private void Start()
    {
        PlayerController.OnPlayerDie += OnPlayerDie;

        availableId = new List<string>(tracksId);
        lastTrack.Magnitude = lastTrack.gameObject.transform.position.magnitude;
        listTracks.Add(lastTrack);
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
        int currCount = listTracks.Count;

        for (int i = 0; i < listTracks.Count; i++)
        {
            if (listTracks[i].Magnitude + distanceToRemove < player.position.magnitude)
            {
                ObjectPoolController.Instance.FreeObject(listTracks[i].gameObject);
                listTracks.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < currCount - listTracks.Count; i++)
        {
            CreateTrack();
        }
    }

    private void CreateTrack()
    {
        string trackId = availableId[Random.Range(0, availableId.Count)];

        if (tracksId.Count > 1)
        {
            availableId.Remove(trackId);
            if (lastTrackId != string.Empty)
            {
                availableId.Add(lastTrackId);
            }

            lastTrackId = trackId;
        }
        
        GameObject go = ObjectPoolController.Instance.CreateObject(trackId, lastPosition += lastTrack.Position);
        if (go.TryGetComponent(out TrackSize track))
        {
            lastTrack = track;
            lastTrack.Magnitude = go.transform.position.magnitude;
            listTracks.Add(lastTrack);
        }
    }

    private void OnPlayerDie()
    {
        enabled = false;
    }
}
