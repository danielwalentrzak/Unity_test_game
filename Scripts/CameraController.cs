using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform tg;
   [SerializeField]
    private float speed, minX, maxX, minY, maxY;
    
    // Start is called before the first frame update
    void Start()
    {
        tg = PlayerMovment.singleton.transform;
      
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(tg.position.x,tg.position.y, transform.position.z), speed*Time.deltaTime);
       
    }
 /*   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(maxX, maxY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(minX, minY));
    }*/
}
