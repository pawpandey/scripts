using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameVars<T> where T: struct
{
    Dictionary<T, bool> vars = new Dictionary<T, bool>();
    bool gameVarsInitialized = false;
    
    public GameVars(Dictionary<T, bool> initializer)
    {
        vars = initializer;
    }
    
    public bool Get(T var, bool defaultVal = false)
    {
        TryInit();    
        
        if (vars.ContainsKey(var))
            return vars[var];
        
        return defaultVal;
    }
    
    public void Set(T var, bool val)
    {
        TryInit();
        
        vars[var] = val;
        
        #if MF_DEBUG
        string keyName = EnumUtl.ToString(var);
        PlayerPrefsUtl.SetBool(keyName, val);
        
        string msg = keyName + " = " + val;
        Debug.Log(msg);
        #endif
    }
    
    public void TryInit()
    {
        #if MF_DEBUG
        if (!gameVarsInitialized)
        {
            // Print var button
            DebugMenuManager.Inst.AddPreDBInitDebugOption("Game Vars", "Print", 
                                                          DebugMenuManager.DebugOption.eType.eButton, null, () => { PrintVars(); }, null);
            DebugMenuManager.Inst.AddPreDBInitDebugOption("Game Vars", "Delete Prefs", 
                                                          DebugMenuManager.DebugOption.eType.eButton, null, () => { PlayerPrefsUtl.DeleteAll(); }, null);
            
            // Init each var
            if (vars != null)
            {
                var gameVarList = vars.ToList();
                if (gameVarList != null)
                {
                    foreach (var kvp in gameVarList)
                    {
                        // Deserialize from prefs if available
                        string keyName = EnumUtl.ToString(kvp.Key);
                        
                        if (PlayerPrefsUtl.HasKey(keyName))
                            vars[kvp.Key] = PlayerPrefsUtl.GetBool(keyName);
                        
                        T gvCopy = kvp.Key;
                        
                        // Create a debug button
                        DebugMenuManager.Inst.AddPreDBInitDebugOption("Game Vars", keyName, 
                                                                      DebugMenuManager.DebugOption.eType.eButton, null, 
                                                                      () => { Set(gvCopy, !Get(gvCopy)); }, null);
                    }
                }
            }
            
            gameVarsInitialized = true;
        }
        #endif
    }
    
    
    public void PrintVars()
    {
        #if MF_DEBUG
        TryInit();
        
        if (vars != null)
        {
            string msg = "";
            
            foreach (var kvp in vars)
            {
                string keyName = EnumUtl.ToString(kvp.Key);
                msg += keyName + " = " + kvp.Value + "\n";
            }
            Debug.Log(msg);
        }
        #endif
    }
}