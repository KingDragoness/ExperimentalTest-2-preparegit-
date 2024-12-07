Shader "Unlit/FOWProcessBlend"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ExploredTex("Explored Map", 2D) = "white" {}
        _ExploredFogCol("Explored Fog Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _ExploredTex;
            uniform float4 _ExploredFogCol;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 col_explored = tex2D(_ExploredTex, i.uv);

                if (col.r < col_explored.r)
                {
                    col.r = _ExploredFogCol.r;
                    col.g = _ExploredFogCol.r;
                    col.b = _ExploredFogCol.r;

                }
                if (col.g < col_explored.g)
                {
                    col.r = _ExploredFogCol.g;
                    col.g = _ExploredFogCol.g;
                    col.b = _ExploredFogCol.g;

                    //col.g = _ExploredFogCol.g;
                }
                if (col.b < col_explored.b)
                {
                    col.r = _ExploredFogCol.b;
                    col.g = _ExploredFogCol.b;
                    col.b = _ExploredFogCol.b;
                }

                return col;
            }
            ENDCG
        }
    }
}
