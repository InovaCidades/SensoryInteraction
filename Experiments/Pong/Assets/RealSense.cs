using UnityEngine;
using System.Collections;

public class RealSense : MonoBehaviour {

	private PXCUPipeline pipe;
	private PXCUPipeline.Mode   mode=PXCUPipeline.Mode.GESTURE;
	
	void Start () 
	{
		pipe = new PXCUPipeline(); 
		if (!pipe.Init(mode)) 
		{
			print("Unable to initialize gesture mode");
			return;
		}
	}
	void Update()
	{
		if (!pipe.AcquireFrame(false)) 
			return;
		
		pipe.ReleaseFrame();      
	}

	void OnDisable() 
	{
		pipe.Close();
		pipe.Dispose ();
	}
}
