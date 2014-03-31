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

	private static RoleInfo roleInfo;

	public static void init(){
		roleInfo = new RoleInfo();
	}

	public void clear(){
		roleInfo = null;
		instance = null;
	}

	public RoleInfo RoleInfo {
		get { return roleInfo; }
		set { roleInfo = value; }
	}
	

}
