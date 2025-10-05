
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldGrid", menuName = "ScriptableObjects/WorldGrid", order = 0)]
public class GameWorld : ScriptableObject
{
    private List<IUpdateable> updateables = new List<IUpdateable>();

    public List<IUpdateable> Updateables { get { return updateables; } }

    public void AddToWorld(IUpdateable updateable)
    {
        if (!updateables.Contains(updateable))
            updateables.Add(updateable);
    }

    public void RemoveFromWorld(IUpdateable updateable)
    {
        if (updateables.Contains(updateable))
            updateables.Remove(updateable);
    }
}