using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{

    public NavMeshSurface navMeshSurface; 

    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface.BuildNavMesh();          // <- Generates (bakes) the navigation mesh UPDATE TO CALL AFTER GENERATING MAP 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
