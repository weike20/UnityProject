using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BakeMesh : MonoBehaviour
{
    #region Fields / Properties
    [SerializeField]
    Material maleMaterial;


    private SkinnedMeshRenderer skinRenderer;
    private GameObject maleAvatar;
    private int avatarCount = 0;
    private List<GameObject> avatars = new List<GameObject>();
    #endregion


    #region MonoBehaviour
    void Start()
    {
        skinRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            avatarCount++;
            CreateAvatar();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClearAvatar();
        }
    }



    void OnDestory()
    {
        if (maleAvatar)
            ClearAvatar();
    }
    #endregion

    #region Private
    private void CreateAvatar()
    {
        maleAvatar = new GameObject("Male Avatar");
        MeshFilter filter = maleAvatar.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = maleAvatar.AddComponent<MeshRenderer>();

        meshRenderer.material = maleMaterial;
        meshRenderer.transform.position = transform.position;
        meshRenderer.transform.rotation = transform.rotation;

        Mesh maleMesh = new Mesh();
        
        skinRenderer.BakeMesh( maleMesh);
       
        filter.mesh = maleMesh;

        maleAvatar.transform.position = transform.position + transform.rotation*new Vector3(0, 0f, -avatarCount);

        avatars.Add(maleAvatar);
    }
    private void ClearAvatar()
    {
        for(int i = 0;i < avatars.Count; ++i)
        {
            Destroy(avatars[i]);
        }
        ResetAvatarCount();
    }
    private void ResetAvatarCount()
    {
        avatarCount = 0;
    }
    #endregion


}
