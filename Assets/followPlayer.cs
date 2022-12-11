using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        Vector3 pos = new Vector3(Mathf.Clamp(target.position.x, -30, 30),
     Mathf.Clamp(target.position.y, -40, 40), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 3.0f);
    }
}
