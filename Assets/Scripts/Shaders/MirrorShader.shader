Shader "Unlit/MirrorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RedMult ("Red multiplier", Float) = 1.0
        _GreenMult ("Green multiplier", Float) = 1.0
        _BlueMult ("Blue multiplier", Float) = 1.0
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
                float4 screenPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _RedMult;
            float _GreenMult;
            float _BlueMult;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 screenSpaceUV = i.screenPos.xy / i.screenPos.w;
                screenSpaceUV.x = 1.0 - screenSpaceUV.x;
                float4 texColour = tex2D(_MainTex, screenSpaceUV);
                texColour.r *= _RedMult;
                texColour.g *= _GreenMult;
                texColour.b *= _BlueMult;
                return texColour;
            }
            ENDCG
        }
    }
}
