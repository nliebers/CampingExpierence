using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {

	public float speed = 20.0f;
	private float xMax = 100f;



	private float xMin = -80.0f; //starting position
	private int direction = 1; //positive to start

	void Update () {
		float xNew = transform.position.x +
		direction * speed * Time.deltaTime;
		if (xNew >= xMax) {
			xNew = xMax;
            transform.Rotate(new Vector3(0, 180, 0));
			direction *= -1;
 		} else if (xNew <= xMin) {
			xNew = xMin;
            transform.Rotate(new Vector3(0, 180, 0));
			direction *= -1;
		}
		transform.position = new Vector3(xNew, transform.position.y, transform.position.z);
	}
}

