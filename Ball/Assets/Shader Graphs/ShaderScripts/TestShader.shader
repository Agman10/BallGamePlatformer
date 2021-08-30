Shader "Unlit/TestShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _ColorB("ColorB", Color) = (1,1,1,1)

        _RotationSpeed("Rotation Speed", Float) = 2.0
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

            float _RotationSpeed;

            Interpolators vert(MeshData v)
            {
                Interpolators o;

                float sinX = sin(_RotationSpeed * _Time);
                float cosX = cos(_RotationSpeed * _Time);
                float sinY = sin(_RotationSpeed * _Time);
                float cosY = cos(_RotationSpeed * _Time);
                float2x2 rotationMatrix = float2x2(cosX, sinX, -sinY, cosY);
                v.vertex.xy = mul(v.vertex.xy, rotationMatrix);

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.uv0 = v.uv0;

                return o;
            }

            float InvLerp(float a, float b, float v) {
                return (v - a) / (b - a);
            }

            float4 frag(Interpolators i) : SV_Target{
                float value = i.uv0.xy;
                float remapped = InvLerp(0.6, 0.7, value);
                float4 col = lerp(_Color, _ColorB, remapped);
                return col;
        }
        ENDCG
    }
    }
}
