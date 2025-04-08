using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class path : MonoBehaviour
{

    //for AI car

    public Color lineColor;
    private List<Transform>nodes= new List<Transform>();


    private void Start()
    {
        Time.timeScale = 1f;
     }
    private void OnDrawGizmos()
    {
       
        Gizmos.color = lineColor;
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        Vector3 currentNode;
        Vector3 previousNode=Vector3.zero;


        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }

        for(int i = 0; i < nodes.Count; i++)
        {
            currentNode = nodes[i].position;
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }else if (i == 0 && nodes.Count > 2)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
            Gizmos.DrawLine(currentNode,previousNode);
            Gizmos.DrawWireSphere(currentNode, 0.3f);
        }
    }
    
}
