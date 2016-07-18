﻿using UnityEngine;
using System.Collections;
using EPPZ.Geometry;
using EPPZ.DebugTools;


public class TestScene_03_Controller : MonoBehaviour
{


	// 03 Polygon permiter-point containment (default)


	public Material polygonMaterial;
	public Material intersectingMaterial;

	public PolygonSource polygonSource;
	public GameObject pointSource;
	public PolygonDebugRenderer polygonRenderer;

	private Polygon polygon { get { return polygonSource.polygon; } }
	private Vector2 point  { get { return pointSource.transform.position.xy(); } }

	void Update()
	{
		RenderTestResult(PointContainmentTest());
	}

	bool PointContainmentTest()
	{
		float accuracy = 0.1f;
		return polygon.PermiterContainsPoint(point, accuracy);
	}

	void RenderTestResult(bool testResult)
	{
		// Set corresponding materials.
		Material renderMaterial = (testResult) ? intersectingMaterial : polygonMaterial;
		polygonRenderer.lineMaterial = renderMaterial;
		pointSource.GetComponent<Renderer>().material = renderMaterial;
	}
}
