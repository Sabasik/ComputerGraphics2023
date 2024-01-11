Shader "Unlit/AntiBlindSpotShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AntiBlindSpotLoc ("Anti blind spot location", Vector) = (0, 0, 1)
        _AntiBlindSpotColor ("Anti blind spot color", Color) = (0, 0, 0)
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
                float4 screenPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float2 _AntiBlindSpotLoc;
            float4 _AntiBlindSpotColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 textureColor = tex2D(_MainTex, i.uv);
                float2 screenSpaceUV = i.screenPos.xy / i.screenPos.w;
                float distanceFromSpot = sqrt(pow(screenSpaceUV.x - _AntiBlindSpotLoc.x, 2) + pow(screenSpaceUV.y - _AntiBlindSpotLoc.y, 2));
                float colorAmountFromTexture = clamp(distanceFromSpot * 5, 0, 1);
                return colorAmountFromTexture * textureColor + (1 - colorAmountFromTexture) * _AntiBlindSpotColor;
            }
            ENDCG
        }
    }
}
