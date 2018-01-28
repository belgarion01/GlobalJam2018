using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public void Screenshake(float intensity, float duration) {
		StartCoroutine(Shake(intensity, duration));
	}

	IEnumerator Shake(float intensity, float duration) {
		if (duration != 0) {
			Vector3 initialPosition = transform.position;
			float initialDuration = duration;
			float initialIntensity = intensity;

			while (duration > 0) {
				duration -= Time.deltaTime;
				transform.position = initialPosition + Random.insideUnitSphere * intensity;
				intensity = initialIntensity * (duration/initialDuration) * (duration/initialDuration);
				yield return null;
			}

			transform.position = initialPosition;
		}
	}
}