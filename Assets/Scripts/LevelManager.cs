using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { set; get; }

    private const float DISTANCE_BEFORE_SPAWN = 80.0f;
    private const int INITIAL_SEGMENTS = 5;
    private const int INITIAL_TRANSITION_SEGMENTS = 2;
    private const int MAX_SEGMENTS_ON_SCREEN = 7;
    private Transform cameraContainer;
    private int amountOfActiveSegments;
    public int currentSpawnZ;
    public bool Iniciado = false;

    //List of segments
    public List<Segment> availableSegments = new List<Segment>();
    public List<Segment> availableSegments2 = new List<Segment>();
    public List<Segment> availableSegments3 = new List<Segment>();
    public List<Segment> availableTransitions = new List<Segment>();
    [HideInInspector]
    public List<Segment> segments = new List<Segment>();

    private void Awake()
    {
        Instance = this;
        cameraContainer = Camera.main.transform;
        currentSpawnZ = 0;
    }
    private void Start()
    {
        if(GameManager.Once == false)
        {
            for (int i = 0; i < INITIAL_SEGMENTS; i++)
            {
                if (i < INITIAL_TRANSITION_SEGMENTS)
                {
                    SpawnTransition();
                }
                else
                {
                    Iniciado = true;
                    SpawnSegment();
                }
            }
        }
    }

    private void Update()
    {
        if(currentSpawnZ - cameraContainer.position.z < DISTANCE_BEFORE_SPAWN)
        {
            if(currentSpawnZ < 500)
            {
                SpawnSegment();
            }
            if(currentSpawnZ >= 500 && currentSpawnZ < 1000)
            {
                int r = Random.Range(0,2);
                switch (r)
                {
                    case 0:
                        SpawnSegment();
                        break;
                    case 1:
                        SpawnSegment2();
                        break;
                }
            }
            if(currentSpawnZ >= 1000)
            {
                int r = Random.Range(0, 3);
                switch (r)
                {
                    case 0:
                        SpawnSegment();
                        break;
                    case 1:
                        SpawnSegment2();
                        break;
                    case 2:
                        SpawnSegment3();
                        break;
                }
            }

        }

        if(amountOfActiveSegments >= MAX_SEGMENTS_ON_SCREEN)
        {
            segments[amountOfActiveSegments - 1].DeSpawn();
            amountOfActiveSegments--;
        }
    }

    private void SpawnSegment()
    {
        List<Segment> possibleSeg = availableSegments;
        int id = Random.Range(0, possibleSeg.Count);

        Segment s = GetSegment(id, false);

        s.transform.SetParent(transform);
        s.transform.localPosition = new Vector3(0, -10, 1 * currentSpawnZ);

        currentSpawnZ += s.lenght;
        amountOfActiveSegments++;
        s.Spawn();
    }

    private void SpawnSegment2()
    {
        List<Segment> possibleSeg = availableSegments2;
        int id = Random.Range(0, possibleSeg.Count);

        Segment s = GetSegment2(id, false);

        s.transform.SetParent(transform);
        s.transform.localPosition = new Vector3(0, -10, 1 * currentSpawnZ);

        currentSpawnZ += s.lenght;
        amountOfActiveSegments++;
        s.Spawn();
    }

    private void SpawnSegment3()
    {
        List<Segment> possibleSeg = availableSegments3;
        int id = Random.Range(0, possibleSeg.Count);

        Segment s = GetSegment3(id, false);

        s.transform.SetParent(transform);
        s.transform.localPosition = new Vector3(0, -10, 1 * currentSpawnZ);

        currentSpawnZ += s.lenght;
        amountOfActiveSegments++;
        s.Spawn();
    }

    private void SpawnTransition()
    {
        List<Segment> possibleTransition = availableTransitions;
        int id = Random.Range(0, possibleTransition.Count);

        Segment s = GetSegment(id, true);

        s.transform.SetParent(transform);
        s.transform.localPosition = new Vector3(0, -10, 1 * currentSpawnZ);

        currentSpawnZ += s.lenght;
        amountOfActiveSegments++;
        s.Spawn();
    }

    public Segment GetSegment(int id, bool transition)
    {
        Segment s = null;
        s = segments.Find(x => x.SegId == id && x.transition == transition && !x.gameObject.activeSelf);

        if(s == null)
        {
            GameObject go = Instantiate((transition) ? availableTransitions[id].gameObject : availableSegments[id].gameObject) as GameObject;
            s = go.GetComponent<Segment>();

            s.SegId = id;
            s.transition = transition;

            segments.Insert(0, s);
        }
        else
        {
            segments.Remove(s);
            segments.Insert(0, s);
        }
        return s;
    }

    public Segment GetSegment2(int id, bool transition)
    {
        Segment s = null;
        s = segments.Find(x => x.SegId == id && x.transition == transition && !x.gameObject.activeSelf);

        if (s == null)
        {
            GameObject go = Instantiate((transition) ? availableTransitions[id].gameObject : availableSegments2[id].gameObject) as GameObject;
            s = go.GetComponent<Segment>();

            s.SegId = id;
            s.transition = transition;

            segments.Insert(0, s);
        }
        else
        {
            segments.Remove(s);
            segments.Insert(0, s);
        }
        return s;
    }

    public Segment GetSegment3(int id, bool transition)
    {
        Segment s = null;
        s = segments.Find(x => x.SegId == id && x.transition == transition && !x.gameObject.activeSelf);

        if (s == null)
        {
            GameObject go = Instantiate((transition) ? availableTransitions[id].gameObject : availableSegments3[id].gameObject) as GameObject;
            s = go.GetComponent<Segment>();

            s.SegId = id;
            s.transition = transition;

            segments.Insert(0, s);
        }
        else
        {
            segments.Remove(s);
            segments.Insert(0, s);
        }
        return s;
    }
}
