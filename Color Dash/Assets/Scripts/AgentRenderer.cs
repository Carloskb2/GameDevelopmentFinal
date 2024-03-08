using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
   public void FaceDirection(Vector2 input) 
    {
        if(input.x < 0) 
        {
            //We multiply * Mathf... in case we have a bigger or smaller player
            transform.parent.localScale = new Vector3(-1 * Mathf.Abs(transform.parent.localScale.x),
                                                                     transform.parent.localScale.y,
                                                                     transform.parent.localScale.z);
        }
        else if(input.x > 0) 
        {
            transform.parent.localScale = new Vector3(Mathf.Abs(transform.parent.localScale.x),
                                                                   transform.parent.localScale.y,
                                                                   transform.parent.localScale.z);

        }
    }
}
