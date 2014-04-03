using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static readonly string 	VERSION = "V1.1";
	public static readonly int 		SERVERVERSION = 0;
	public static readonly string 	BUNDLEVERSION = "20140331";
	public static Globals It;
	public string	urlResource;
	public bool bUseLocalResources = false;
	public BundleManager bundleManager;
	void Awake (){
		It = this;
		bundleManager = gameObject.AddComponent<BundleManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum kLanguage {
	Chinese = 0,
	English,
}

public enum kResource {
	Config,
	View,
	Common,
	Font,
	Effect,
}

public enum kLoadResult {
	None = 0,
	SUCC,
	Load,
	Fail,
}
