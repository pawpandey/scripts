using UnityEngine;
using System.Collections;
using UnityEditor;

[InitializeOnLoad]
public class PrefabValidator
{
    static PrefabValidator()
    {
        Debug.Log("Prefab Validator enabled");
        PrefabUtility.prefabInstanceUpdated += PrefabUpdated;
    }

    public static void PrefabUpdated(GameObject go)
    {
        if (go)
        {
            if (go.activeSelf)
            {
                // Debug.LogError("Set prefab: {0} was left active on last \"Apply\", be sure to set the active flag to false (Sets are always marked inactive)".Fmt(setCom.GetType().Name));
                /// Eventually we want this, but there are some gotchas with writing out a prefab
                /// e.g. if the set gets parented to a blank gameobject and then applied, we would end up writing out that prefab
                Debug.LogError("Set prefab: {0} was left active on last \"Apply\", auto-correcting the active flag to false (Sets are always marked inactive)".Fmt(GetType().Name));
                // TODO: Make sure the correct object is written out and not just simply the root prefab
                go.SetActive(false);
                PrefabUtilityExtensions.WritePrefabToDisk(go);
            }
        }
    }
}
