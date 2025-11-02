Shader "Custom/FlatRain"
{
    Properties
    {
        _RainTex ("Rain Texture", 2D) = "white" {}
        _Speed ("Rain Speed", Range(0, 2)) = 0.5
        _Intensity ("Rain Intensity", Range(0, 1)) = 1
        _Color ("Rain Color", Color) = (1,1,1,0.5)
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _RainTex;
            float _Speed;
            float _Intensity;
            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 rainUV = i.uv;
                rainUV.y += _Time.y * _Speed;

                fixed4 rain = tex2D(_RainTex, rainUV) * _Color;
                rain.a *= _Intensity;

                return rain;
            }
            ENDCG
        }
    }
}
