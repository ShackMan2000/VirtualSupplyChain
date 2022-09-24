using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class AllPaths : ScriptableObject
{
    public List<Path> paths;



    
    [ContextMenu("CreatePath")]
    public void CreatePath()
    {
        paths.Add(new Path());

    }


    public void AddPointToCurrentPath(Vector3 pos)
    {
        paths[0].points.Add(pos);

    }


}
