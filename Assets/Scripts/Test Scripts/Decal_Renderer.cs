using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DecalSystem
{
    static DecalSystem instance;

    internal HashSet<Decal> diffuseDecals = new HashSet<Decal>();
    internal HashSet<Decal> normalDecals = new HashSet<Decal>();
    internal HashSet<Decal> combineDecals = new HashSet<Decal>();

    public static DecalSystem Instance
    {
        get
        {
            if (instance == null) instance = new DecalSystem();
            return instance;
        }
    }

    public void AddDecal(Decal newDecal)
    {
        DeleteDecal(newDecal);
        if (newDecal.decalOutput == Decal.DecalOutput.Diffuse) diffuseDecals.Add(newDecal);
        if (newDecal.decalOutput == Decal.DecalOutput.Normals) normalDecals.Add(newDecal);
        if (newDecal.decalOutput == Decal.DecalOutput.Both) combineDecals.Add(newDecal);
    }

    public void DeleteDecal(Decal oldDecal)
    {
        diffuseDecals.Remove(oldDecal);
        normalDecals.Remove(oldDecal);
        combineDecals.Remove(oldDecal);
    }
}

[ExecuteInEditMode]
public class Decal_Renderer : MonoBehaviour {

    public Mesh customMesh;
    private Dictionary<Camera, CommandBuffer> cameras = new Dictionary<Camera, CommandBuffer>();

    public void OnDisable()
    {
        foreach (var cam in cameras)
        {
            if (cam.Key)
            {
                cam.Key.RemoveCommandBuffer(CameraEvent.BeforeLighting, cam.Value);
            }
        }
    }

    private void OnWillRenderObject()
    {
        var vara = gameObject.activeInHierarchy && enabled;
        if (!vara)
        {
            OnDisable();
            return;
        }

        DecalSystem instance = DecalSystem.Instance;
        Camera cam = Camera.current;

        CommandBuffer buffer = null;

        if (cameras.ContainsKey(cam))
        {
            buffer = cameras[cam];
            buffer.Clear();
        }
        else
        {
            buffer = new CommandBuffer();
            buffer.name = "Decals";
            cameras[cam] = buffer;
            cam.AddCommandBuffer(CameraEvent.BeforeLighting, buffer);
        }


        var normals = Shader.PropertyToID("_NormalTexCopy");
        Debug.Log(normals.ToString());
        buffer.GetTemporaryRT(normals, -1, 1);
        buffer.Blit(BuiltinRenderTextureType.GBuffer2, normals);

        //buffer.SetRenderTarget(BuiltinRenderTextureType.GBuffer0, BuiltinRenderTextureType.CameraTarget);
        //foreach (Decal decal in instance.diffuseDecals)
        //{
        //    buffer.DrawMesh(customMesh, decal.transform.localToWorldMatrix, decal.decalMaterial);
        //}

        //buffer.SetRenderTarget(BuiltinRenderTextureType.GBuffer2, BuiltinRenderTextureType.CameraTarget);
        //foreach (Decal decal in instance.normalDecals)
        //{
        //    buffer.DrawMesh(customMesh, decal.transform.localToWorldMatrix, decal.decalMaterial);
        //}

        RenderTargetIdentifier[] rti = { BuiltinRenderTextureType.GBuffer0, BuiltinRenderTextureType.GBuffer2 };
        buffer.SetRenderTarget(rti, BuiltinRenderTextureType.CameraTarget);
        foreach(Decal decal in instance.combineDecals)
        {
            buffer.DrawMesh(customMesh, decal.transform.localToWorldMatrix, decal.decalMaterial);
        }

        buffer.ReleaseTemporaryRT(normals);
    }
}
