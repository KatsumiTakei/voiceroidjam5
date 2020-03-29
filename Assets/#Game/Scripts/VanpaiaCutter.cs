using UnityEngine;
using System.Collections.Generic;
using UnitySpriteCutter;

public static class VanpaiaCutter 
{

	static Vector2 GetVelocity(int index)
	{
		var table = new Vector3[] {
			new Vector3(Random.Range(-1.0f, -0.5f), Random.Range(0.5f, 1.0f), 1f),
			new Vector3(Random.Range(-1.0f, -0.5f), Random.Range(-1.0f, -0.5f), 1f),
			new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), 1f),
			new Vector3(Random.Range(0.5f, 1.0f), Random.Range(-1.0f, -0.5f), 1f),
		};

		return table[index];
	}


	public static void Cut(Vector2 start, Vector2 end)
	{
		LinecastCut(start, end, 256);
	}

	static void LinecastCut( Vector2 lineStart, Vector2 lineEnd, int layerMask = Physics2D.AllLayers ) {
		List<GameObject> gameObjectsToCut = new List<GameObject>();
		RaycastHit2D[] hits = Physics2D.LinecastAll( lineStart, lineEnd, layerMask );
		foreach ( RaycastHit2D hit in hits ) {
			if ( HitCounts( hit ) ) {
				gameObjectsToCut.Add( hit.transform.gameObject );
			}
		}
		
		foreach ( GameObject go in gameObjectsToCut ) {
			SpriteCutterOutput output = SpriteCutter.Cut( new SpriteCutterInput() {
				lineStart = lineStart,
				lineEnd = lineEnd,
				gameObject = go,
				gameObjectCreationMode = SpriteCutterInput.GameObjectCreationMode.CUT_OFF_ONE,
			} );

			if ( output != null && output.secondSideGameObject != null ) {
				Rigidbody2D newRigidbody = output.secondSideGameObject.AddComponent<Rigidbody2D>();
				newRigidbody.velocity = GetVelocity(Random.Range(0, 4));
			}
		}
	}

	static bool HitCounts( RaycastHit2D hit ) {
		return ( hit.transform.GetComponent<SpriteRenderer>() != null ||
		         hit.transform.GetComponent<MeshRenderer>() != null );
	}

}
