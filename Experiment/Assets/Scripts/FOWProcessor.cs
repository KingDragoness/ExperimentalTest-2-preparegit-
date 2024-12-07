using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FOWProcessor : MonoBehaviour
{



    public Shader blendShader;
    public Camera cam_active;
    public Camera cam_explored;
    public RenderTexture TEMPLATE_2048;
    public RenderTexture TEMPLATE_256;
    public Material reusableTerrainMat;

    [Space]
    public RenderTexture rt_FOWActive;
    public RenderTexture rt_FOWExplored;
    public RenderTexture rt_FOWData;

    [Space]
    public Faction.Player currentFaction;
    public bool DEBUG_CaptureAll = true;

    private Material matPostFX;
    public List<GameUnit> everyUnits = new List<GameUnit>();


    private void Awake()
    {
        everyUnits = FindObjectsOfType<GameUnit>().ToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        matPostFX = new Material(blendShader);
    }

    // Update is called once per frame
    void Update()
    {
        CaptureFOW(Faction.Player.Player1);
        if (DEBUG_CaptureAll)
        {
            CaptureFOW(Faction.Player.Player2);
            CaptureFOW(Faction.Player.Player3);
            CaptureFOW(Faction.Player.Player4);
            CaptureFOW(Faction.Player.Player5);
            CaptureFOW(Faction.Player.Player6);
            CaptureFOW(Faction.Player.Player7);
            CaptureFOW(Faction.Player.Player8);
        }

    }



    public void CaptureFOW(Faction.Player faction)
    {

        RenderTexture rt_temp = RenderTexture.GetTemporary(rt_FOWActive.width, rt_FOWActive.height, 0, rt_FOWActive.format);

        cam_active.targetTexture = rt_FOWActive;
        cam_active.Render();
        cam_explored.targetTexture = rt_FOWExplored;
        cam_explored.Render();
        matPostFX.SetTexture("_ExploredTex", rt_FOWExplored);

        Graphics.Blit(rt_FOWActive, rt_temp);
        Graphics.Blit(rt_temp, rt_FOWActive, matPostFX);
        Graphics.Blit(rt_FOWActive, rt_FOWData);

        RenderTexture.ReleaseTemporary(rt_temp);
    }
}
