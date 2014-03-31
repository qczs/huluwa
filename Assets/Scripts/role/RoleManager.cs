using UnityEngine;
using System.Collections;

public class RoleManager {

	private static RoleManager instance;

	public static RoleManager getInstance ()
	{
		if (instance == null) {
			instance = new RoleManager ();
			init();

		}
		return instance;  
	}

	public static RoleInfo roleInfo { get; set; }

	public static void init(){
		roleInfo = new RoleInfo();
	}

	public void clear(){
		roleInfo = null;
		instance = null;
	}

}
