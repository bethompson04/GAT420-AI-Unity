using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgentSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AIAgent[] agents;
	[SerializeField] LayerMask layerMask;
 
	int index = 0;
 
	void Update()
	{
        // Press 'tab' to switch agent to spawn
		if (Input.GetKeyDown(KeyCode.Tab)) index = (++index % agents.Length);
    
        // Click to spawn or hold left control and mouse button to spawn multiple
		if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)))
		{
            // Get ray from camera to screen position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Raycast and see if it hits an object with layer
			if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
                // Spawn agent at hit point and random rotation
				Instantiate(agents[index], hitInfo.point, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
			}
		}
	}
}
