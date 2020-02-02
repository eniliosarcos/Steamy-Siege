using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public int level;
	public int startAngle = 0;
	public int totalLinesOfFOV = 18;
	public int anglePerLine = 20;
	public float distance = 5;
	public Vector3 OriginPoint;
	public Transform visibleTarget;
	public LayerMask LayersToCollide;
    private float _timer;
    public float shootTime;
    public GameObject bullet;
    public int damage;

    float timer()
    {
        return _timer += Time.deltaTime;
    }

	// Update is called once per frame
	void Update()
	{
				RaycastDetectionMethod();
		
	}

	/// <summary>
	/// This method make the behavior detection with colliders around.
	/// </summary>
	private void RaycastDetectionMethod()
	{
		Quaternion InitAngle = Quaternion.AngleAxis(startAngle, Vector3.down);
		Quaternion stepAngle = Quaternion.AngleAxis(anglePerLine, Vector3.down);
		var angle = transform.rotation * InitAngle;
		var direction = angle * Vector3.forward;
		bool playerdetected = false;
		for (int i = 0; i < totalLinesOfFOV; i++)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position,direction,out hit,distance,LayersToCollide))
			{
				float distance = hit.distance;

				if (hit.collider != null)
				{
					Debug.DrawRay(transform.position, direction * distance, Color.red);
					visibleTarget = hit.collider.transform;

                    if(timer() > shootTime )
                    {
                        _timer = 0.0f;
                        GameObject go = Instantiate(bullet,transform.position,Quaternion.identity);
                        go.GetComponent<bulletmovement>().damage = damage;
                        go.GetComponent<bulletmovement>().target = visibleTarget;
                    }

					playerdetected = true;
				}
				else
				{
						Debug.DrawRay(transform.position, direction * distance, Color.green);
				}
			}
			else
			{
					Debug.DrawRay(transform.position, direction * distance, Color.green);
			}
			direction = stepAngle * direction;
		}

		if (playerdetected == false)
			visibleTarget = null;
	}

	private void OnDrawGizmosSelected()
	{
					RaycastDetectionMethod();
			
		
	}
}
