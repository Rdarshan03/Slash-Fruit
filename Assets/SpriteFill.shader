Shader "Custom/WaterFillEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FillAmount ("Fill Amount", Range(0, 1)) = 1.0
        _FillColor ("Fill Color", Color) = (0.0, 0.5, 1.0, 1.0) // Default water color (light blue)
        _WaveSpeed ("Wave Speed", Float) = 1.0
        _WaveAmplitude ("Wave Amplitude", Float) = 0.01
        _WaveFrequency ("Wave Frequency", Float) = 10.0
    }
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _FillAmount;
            fixed4 _FillColor;
            float _WaveSpeed;
            float _WaveAmplitude;
            float _WaveFrequency;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Apply wave distortion to the y-coordinate
                float wave = sin(i.texcoord.x * _WaveFrequency + _Time.y * _WaveSpeed) * _WaveAmplitude;
                i.texcoord.y += wave;

                fixed4 col = tex2D(_MainTex, i.texcoord);

                // Preserve the original alpha of the sprite
                float originalAlpha = col.a;

                // Check for vertical fill with wave distortion
                if (i.texcoord.y > _FillAmount)
                {
                    col.a = 0; // Make part of the texture transparent beyond the fill amount
                }
                else
                {
                    // Apply fill color while preserving the original alpha
                    col.rgb = lerp(col.rgb, _FillColor.rgb, _FillColor.a);
                    col.a = originalAlpha;
                }

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent"
}
