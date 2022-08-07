using UnityEngine;

public class LanternPhysicsMod : Mod
{
    public void Start() {
        HandleMetalLanterns(Action.Load);
        HandleBasicLanterns(Action.Load);
        Debug.Log("Mod LanternPhysicsMod has been loaded!");
    }

    public void OnModUnload()
    {
        HandleMetalLanterns(Action.Unload);
        HandleBasicLanterns(Action.Unload);
        Debug.Log("Mod LanternPhysicsMod has been unloaded!");
    }
    
    private void HandleMetalLanterns(Action action) {
        Item_Base metalLantern = ItemManager.GetItemByName("Placeable_Lantern_Metal");
        Block[] lanternPrefabs = metalLantern.settings_buildable.GetBlockPrefabs();
        GameObject ceilingLantern = lanternPrefabs[1].gameObject;
        GameObject wallLantern = lanternPrefabs[2].gameObject;
        if (action == Action.Load) {
            ceilingLantern.AddComponent<LanternMetalPhysics>();
            wallLantern.AddComponent<LanternMetalPhysics>();
        } else if(action == Action.Unload) {
            Destroy(ceilingLantern.GetComponent<LanternMetalPhysics>());
            Destroy(wallLantern.GetComponent<LanternMetalPhysics>());
        }
    }
    
    private void HandleBasicLanterns(Action action) {
        Item_Base basicLantern = ItemManager.GetItemByName("Placeable_Lantern_Basic");
        Block[] lanternPrefabs = basicLantern.settings_buildable.GetBlockPrefabs();
        GameObject ceilingLantern = lanternPrefabs[1].gameObject;
        if (action == Action.Load) {
            ceilingLantern.AddComponent<LanternBasicPhysics>();
        } else if(action == Action.Unload) {
            Destroy(ceilingLantern.GetComponent<LanternBasicPhysics>());
        }
    }
    
    private enum Action {
        Load,
        Unload
    }
}