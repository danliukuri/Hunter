using UnityEngine;
using System.Collections.Generic;

public class ObjectsPool : MonoBehaviour
{
	#region Properies
	public Transform ObjectsParent => objectsParent;
	#endregion

	#region Fields
	[SerializeField] GameObject gameObjectPrefab;
	[SerializeField] Transform objectsParent;

	[SerializeField] List<GameObject> objects = new List<GameObject>();
	#endregion

	#region Methods
	/// <summary>
	/// Finds a free object or creates a new one
	/// </summary>
	/// <returns> Found or newly created object </returns>
	public GameObject GetFreeObject()
	{
		GameObject gameObject = TryToGetObject();
		if (gameObject == null)
			gameObject = CreateNewObject();
		return gameObject;
	}
	/// <summary>
	/// Finds a free object
	/// </summary>
	/// <returns> Found object </returns>
	GameObject TryToGetObject()
    {
		GameObject gameObject = null;
		for (int i = 0; i < objects?.Count; i++)
			if (!objects[i].activeSelf)
			{
				gameObject = objects[i];
				break;
			}
		return gameObject;
	}
	/// <summary>
	/// Creates a new free object
	/// </summary>
	/// <returns> Newly created object </returns>
	GameObject CreateNewObject()
    {
		GameObject gameObject = Instantiate(gameObjectPrefab, objectsParent);
		objects.Add(gameObject);
		return gameObject;
	}

	/// <summary>
	/// Fills empty cells in the objects list with new game object prefabs
	/// </summary>
	[ContextMenu("Fill empty cells")]
	void FillEmptyCells()
	{
		for (int i = 0; i < objects.Count; i++)
			if (objects[i] == null)
			{
				objects[i] = Instantiate(gameObjectPrefab, objectsParent);
				objects[i].SetActive(false);
			}
	}

    void OnValidate()
    {
		if (objectsParent == null)
			objectsParent = transform;
    }
    void Awake()
	{
		FillEmptyCells();
	}
	#endregion
}