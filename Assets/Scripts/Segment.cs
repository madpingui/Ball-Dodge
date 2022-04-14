using UnityEngine;

public class Segment : MonoBehaviour
{
    public int SegId { set; get; }
    public bool transition;

    public int lenght;

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);        
    }
}
