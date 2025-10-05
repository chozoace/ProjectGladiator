using UnityEngine;

public interface Action
{
    void Execute(GameObject obj);
    string GetActionName();
}