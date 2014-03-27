/* **************************************************************************
   Copyright 2012 Calvin Rien
   (http://the.darktable.com)
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
 
     http://www.apache.org/licenses/LICENSE-2.0
 
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
************************************************************************** */

#if UNITY_EDITOR || DEVELOPMENT_BUILD
#define DEBUG
#endif

using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class UpdateXcodeProject : ScriptableObject {
	
	const string DESTINATION_PATH = "../ios";
	static readonly string[] SKIP_FILES = {@"Classes",@"^.*\.xcodeproj$",@"^.*info\.plist$"};
	
	// Requires Unity 3.51+
	// We want this to execute after all other PostProcesses
	[PostProcessBuild(999)]
	static void OnPostProcessBuildPlayer(BuildTarget target, string buildPath) {
		if (target == BuildTarget.iPhone) {
			UpdateXcode(buildPath);
		}
	}
	
	static void UpdateXcode(string srcProject) {
		var destProj = DESTINATION_PATH.StartsWith("/") ? DESTINATION_PATH : Path.Combine(srcProject, DESTINATION_PATH);
		
		Debug.Log(string.Format("UpdateXcode: Copy from {0}\nto {1}",srcProject, destProj));
		
		if (!Directory.Exists(destProj)) {
			DirectoryCopy(srcProject, destProj);
			
			return;
		}
		
		DirectoryCopy(srcProject, destProj, SKIP_FILES);
	}
	
	static bool CompareMD5(string file1, string file2) {
		byte[] file1hash, file2hash;
		
		if (!File.Exists(file1) || !File.Exists(file2)) {
			return false;
		}
		
		file1hash = GetMD5Hash(file1);
		file2hash = GetMD5Hash(file2);
		
		return ArrayCompare(file1hash, file2hash);
	}
	
	static bool ArrayCompare<T>(T[] a1,T[] a2) {
		if (a1.Length != a2.Length) {
			return false;
		}
		
		for (int i=0; i<a1.Length; i++) {
			if (!a1[i].Equals(a2[i])) {
				return false;
			}
		}
		
		return true;
	}
	
	static byte[] GetMD5Hash(string fileName) {
		using (var file = File.OpenRead(fileName)) {
			using (var md5 = new MD5CryptoServiceProvider()) {
				return md5.ComputeHash(file);
			}
		}
	}
	
	static void DirectoryCopy(string sourceDirName, string destDirName, string[] skipList=null, bool replace=true, bool copySubDirs=true) {
		DirectoryInfo dir = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] dirs = dir.GetDirectories();
		
		if (!dir.Exists) {
			throw new DirectoryNotFoundException(
				"Source directory does not exist or could not be found: "
				+ sourceDirName);
		}
		
		if (!Directory.Exists(destDirName)) {
			Directory.CreateDirectory(destDirName);
		}
		
		FileInfo[] files = dir.GetFiles();
		foreach (FileInfo file in files) {
			if (skipList != null) {
				bool skip = false;
				
				foreach (var pattern in skipList) {
					if (Regex.IsMatch(file.FullName, pattern, RegexOptions.IgnoreCase)) {
						skip = true;
						break;
					}
				}
				
				if (skip) {
					Debug.Log("skipping: " + file.Name);
					
					continue;
				}
			}
			
			string temppath = Path.Combine(destDirName, file.Name);
			
			if (CompareMD5(file.FullName, temppath)) {
				continue;
			}
			
			file.CopyTo(temppath, replace);
		}
		
		if (copySubDirs) {
			foreach (DirectoryInfo subdir in dirs) {
				if (skipList != null) {
					bool skip = false;
					
					foreach (var pattern in skipList) {
						if (Regex.IsMatch(subdir.Name, pattern, RegexOptions.IgnoreCase)) {
							skip = true;
							break;
						}
					}
					
					if (skip) {
						Debug.Log("skipping: " + subdir.FullName);
						
						continue;
					}
				}
				
				string temppath = Path.Combine(destDirName, subdir.Name);
				DirectoryCopy(subdir.FullName, temppath, skipList, replace, copySubDirs);
			}
		}
	}
}