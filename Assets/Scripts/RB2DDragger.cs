using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StickyBodies {

	public class RB2DDragger : MonoBehaviour {

		public float forceScale = 1f;

		Rigidbody2D _draggedRb2d;

		void Update() {
			if(Input.GetMouseButtonDown(0)) {
				Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
				if(hit) {
					_draggedRb2d = hit.collider.GetComponent<Rigidbody2D>();
				}
			} else if(Input.GetMouseButtonUp(0)) {
				_draggedRb2d = null;
			}

			if(_draggedRb2d) {
				Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				Vector2 mousePosition = mouseRay.origin + mouseRay.direction * (mouseRay.origin.z / mouseRay.direction.z);
				Vector2 force = mousePosition - _draggedRb2d.position;
				_draggedRb2d.AddForce(force * forceScale);
			}
		}
	}
}