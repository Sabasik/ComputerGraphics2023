Shader"Custom/ColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PickerCenter ("Picker Center", Vector) = (0.5, 0.5, 0, 0)
        _PickerRadius ("Picker Radius", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        
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
                            UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            
            float4 _PickerCenter;
            float _PickerRadius;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed3 HSVtoRGB(float H, float S, float V)
            {
                float C = V * S;
                float X = C * (1 - abs(fmod(H * 6, 2) - 1));
                float m = V - C;
                
                float3 color;
                
                if (H < 1)
                    color = float3(C, X, 0);
                else if (H < 2)
                    color = float3(X, C, 0);
                else if (H < 3)
                    color = float3(0, C, X);
                else if (H < 4)
                    color = float3(0, X, C);
                else if (H < 5)
                    color = float3(X, 0, C);
                else
                    color = float3(C, 0, X);
                
                return (color + m);
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = _PickerCenter.xy;
                float radius = _PickerRadius;
                
                float2 uvRelativeToCenter = i.uv - center;
                float dist = length(uvRelativeToCenter);
                
                if (dist <= radius)
                {
                    // Convert UV coordinates to HSV color space
                    float hue = atan2(uvRelativeToCenter.y, uvRelativeToCenter.x);
                    if (hue < 0.0)
                    {
                        hue += 6.28318530718; // 2 * PI
                    }
                    hue /= 6.28318530718; // 2 * PI
                    
                    return fixed4(HSVtoRGB(hue, 1.0, 1.0), 1.0);
                }
                
                // If the condition fails, return a transparent color
                return fixed4(0, 0, 0, 0);
            }
            ENDCG
        }
    }
}
