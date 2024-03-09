using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class VFXmanager : Singleton<VFXmanager>
{
    public enum VFXType
    {
        JUMP
    }

    public List<VFXmanagerSetup> vfxSetup;

    public void PlayVFXbyType(VFXType vfxType, Vector3 position)
    {
        foreach (var vfx in vfxSetup)
        {
            if(vfx.vfxType == vfxType)
            {
                var item = Instantiate(vfx.vfxPrefab);
                item.transform.position = position;
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXmanagerSetup
{
    public VFXmanager.VFXType vfxType;
    public GameObject vfxPrefab;
}
