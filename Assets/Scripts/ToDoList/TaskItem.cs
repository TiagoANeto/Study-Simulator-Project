using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public void DeleteTask()
    {
        Destroy(this.gameObject);
    }
}
