using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class TimeUtil
{
		public static long UNIX_TIMESTAMP (DateTime dateTime)
		{
				return (dateTime.Ticks - DateTime.Parse ("1970-01-01 00:00:00").Ticks) / 10000000;
		}

}
