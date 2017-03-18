//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MIcarosEditor.cs (18/03/2017)												\\
// Autor: Antonio Mateo (Moon Pincho) 									        \\
// Descripcion:		Tool para crear scriptableobjects rapidamente				\\
// Fecha Mod:		18/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System.Reflection;
using System.Linq;
#endregion

namespace MoonPincho
{
	#region ICaros Core
	/// <summary>
	/// <para>Core de la herramienta para crear scriptableobjects rapidamente.</para>
	/// </summary>
	public class MIcarosEditor : MonoBehaviour 
	{
		#region Menus
		/// <summary>
		/// <para>Menu para crear scriptableobjects.</para>
		/// </summary>
		[MenuItem("Assets/Create/Moon Antonio/MIcaros")]
		public static void CrearScriptableObject()// Menu para crear scriptableobjects
		{
			var assembly = GetAssembly();

			// Obtener todas las clases derivadas de ScriptableObject
			var allScriptableObjects = (from t in assembly.GetTypes() where t.IsSubclassOf(typeof(ScriptableObject)) select t).ToArray();

			// TODO Iniciar windows

		}

		/// <summary>
		/// <para>Menu para crear scriptableobjects.</para>
		/// </summary>
		[MenuItem("Moon Antonio/MIcaros")]
		public static void MenuScriptableObject()// Menu para crear scriptableobjects
		{
			CrearScriptableObject();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Devuelve el ensamblado que contiene el codigo de secuencia de comandos para este proyecto.</para>
		/// </summary>
		private static Assembly GetAssembly()// Devuelve el ensamblado que contiene el codigo de secuencia de comandos para este proyecto
		{
			return Assembly.Load(new AssemblyName("Assembly-CSharp"));
		}
		#endregion
	}
	#endregion

	#region API Externa
	/// <summary>
	/// <para>Miembros abstractos</para>
	/// </summary>
	internal class EndNameEdit : EndNameEditAction
	{
		#region Miembros abstractos implementados de EndNameEditAction
		public override void Action(int id, string path, string file)
		{
			AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(id), AssetDatabase.GenerateUniqueAssetPath(path));
		}

		#endregion
	}
	#endregion
}
