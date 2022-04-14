using System.Collections;
using UnityEngine;

public class CamaraMotor : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 offset = new Vector3(0, 5.4f, -0.5f);
    public Vector3 rotation = new Vector3(35, 0, 0);
    private bool normal = false;

    public bool IsMoving { set; get; }

    public void Start()
    {
        normal = true;
    }

    private void LateUpdate()
    {
        if (!IsMoving)
        {
            return;
        }
        else if (normal == true)
        {
            moverCamara(lookAt.position + offset);
        }
    }

    public void moverCamara(Vector3 desirePosition)
    {
        desirePosition.x = lookAt.transform.position.x;
        transform.position = Vector3.Lerp(transform.position, desirePosition, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), 0.1f);
    }
}
