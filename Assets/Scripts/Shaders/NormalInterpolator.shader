Shader "Custom/NormalInterpolator"
{
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
         
            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };
            
            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                fixed3 worldSpaceNormal = mul(unity_WorldToObject, v.normal);
                fixed3 normalTargetCloseness = clamp(dot(worldSpaceNormal, float3(0, 0, 1)), 0, 1);
                o.color.xyz = normalTargetCloseness * normalTargetCloseness;
                o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target { return i.color; }
            ENDCG
        }
    } 
}
