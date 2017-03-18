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
using System;
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
			if (assembly == null)
			{
				return;
			}
			var allScriptableObjects = (from t in assembly.GetTypes() where t.IsSubclassOf(typeof(ScriptableObject)) select t).ToArray();

			// Inicializar sistema MIcaros
			if (allScriptableObjects != null)
			{
				ScriptableObjectGUI.Init(allScriptableObjects);
			}
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

	#region GUI
	/// <summary>
	/// <para>Interfaz de MIcaros.</para>
	/// </summary>
	public class ScriptableObjectGUI : EditorWindow
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Scripts seleccionado para crear el scriptableobjet.</para>
		/// </summary>
		private int scriptSeleccionado;											// Scripts seleccionado para crear el scriptableobjet
		/// <summary>
		/// <para>Nombres de los scriptableobjects.</para>
		/// </summary>
		private static string[] nombres;										// Nombres de los scriptableobjects
		/// <summary>
		/// <para>Tipos</para>
		/// </summary>
		private static Type[] tipos;											// Tipos
		/// <summary>
		/// <para>Propiedad de tipos.</para>
		/// </summary>
		private static Type[] Types												// Propiedad de tipos
		{
			get { return tipos; }
			set
			{
				tipos = value;
				nombres = tipos.Select(t => t.FullName).ToArray();
			}
		}
		#endregion

		#region Inicializador
		/// <summary>
		/// <para>Inicializa el sistema MIcaros.</para>
		/// </summary>
		/// <param name="scriptableObjects">El tipo scriptableobject</param>
		public static void Init(Type[] scriptableObjects)// Inicializa el sistema MIcaros
		{
			Types = scriptableObjects;

			ScriptableObjectGUI window = EditorWindow.GetWindow<ScriptableObjectGUI>(true, "MIcaros", true);
			window.ShowPopup();
		}
		#endregion

		#region UI
		/// <summary>
		/// <para>Interfaz de MIcaros.</para>
		/// </summary>
		public void OnGUI()// Interfaz de MIcaros
		{
			GUILayout.Label("Elegit Clase ->");
			scriptSeleccionado = EditorGUILayout.Popup(scriptSeleccionado, nombres);

			if (GUILayout.Button("Crear"))
			{
				Crear();
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Crear ScriptableObject.</para>
		/// </summary>
		private void Crear()// Crear ScriptableObject
		{
			ScriptableObject asset = ScriptableObject.CreateInstance(tipos[scriptSeleccionado]);

			ProjectWindowUtil.StartNameEditingIfProjectWindowExists(asset.GetInstanceID(),ScriptableObject.CreateInstance<EndNameEdit>(),string.Format("{0}.asset", nombres[scriptSeleccionado]),AssetPreview.GetMiniThumbnail(asset), null);

			Close();
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
