Shader "Unlit/Portal"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)

        _Scale ("Scale", Range(0,8)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv0 : TEXCOORD1;
            };


            float4 _Color;
            float4 _ColorB;
            float _Scale;

            Interpolators vert (MeshData v)
            {
                Interpolators o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.uv0 = v.uv0;
                return o;
            }

            float InvLerp(float a, float b, float v) {
                return (v - a) / (b - a);
            }

            float4 frag(Interpolators i) : SV_Target{
                float value = distance(i.uv0, float2(0.5,0.5))*2;

                float remapped = frac(InvLerp(0.25, 0.5, value)+_Time.y);
                float4 col = lerp(_Color, _ColorB, remapped);
                return col;
            }
            ENDCG
        }
    }
}
