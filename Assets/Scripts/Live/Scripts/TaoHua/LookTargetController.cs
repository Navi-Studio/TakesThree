using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.LookAt;
using System.IO;
using UnityEditor;

public class LookTargetController : MonoBehaviour, ICubismLookTarget
{
    private Animator animator;

    public TextAsset faceFile;

    private void Start() {
        animator = GameObject.FindGameObjectWithTag("Model").GetComponent<Animator>();
    }
    

    public Vector3 GetPosition()
    {
        if(animator.GetInteger("idleState") == -1){
            return Vector3.zero;
        }else{
            Vector3 targetPosition = Input.mousePosition;
            return targetPosition;
        }
    }

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }

}
