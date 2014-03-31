using UnityEngine;
using System.Collections;

public class RoleManager {

	private static RoleManager instance;

	public static RoleManager getInstance ()
	{
		if (instance == null) {
			instance = new RoleManager ();
			instance.init();

		}
		return instance;  
	}

	public void init(){
		roleInfo = new RoleInfo();
	}

	public RoleInfo roleInfo { get; set; }
	
	public void clear(){
		roleInfo = null;
		instance = null;
	}

}
