Shader "VinegarShader/MixShader"
{
    Properties
    {
        _Tex1 ("Texture1", 2D) = "white" {}
        _mix_Tex1 ("BlendTexture1", Range(0,1)) = 1
        _Tex2 ("Texture2", 2D) = "white" {}
        _mix_Tex2 ("BlendTexture2", Range(0,1)) = 1
        _Tex3 ("Texture3", 2D) = "white" {}
        _mix_Tex3 ("BlendTexture3", Range(0,1)) = 1
        _Tex4 ("Texture4", 2D) = "white" {}
        _mix_Tex4 ("BlendTexture4", Range(0,1)) = 1
        _Tex5 ("Texture5", 2D) = "white" {}
        _mix_Tex5 ("BlendTexture5", Range(0,1)) = 1
        _Tex6 ("Texture6", 2D) = "white" {}
        _mix_Tex6 ("BlendTexture6", Range(0,1)) = 1
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

            sampler2D _Tex1;
            float4 _Tex1_ST;
            sampler2D _Tex2;
            float4 _Tex2_ST;
            sampler2D _Tex3;
            float4 _Tex3_ST;
            sampler2D _Tex4;
            float4 _Tex4_ST;
            sampler2D _Tex5;
            float4 _Tex5_ST;
            sampler2D _Tex6;
            float4 _Tex6_ST;
            float _mix_Tex1;
            float _mix_Tex2;
            float _mix_Tex3;
            float _mix_Tex4;
            float _mix_Tex5;
            float _mix_Tex6;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _Tex1);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_Tex1, i.uv)*(_mix_Tex1) + tex2D(_Tex2,i.uv)*(_mix_Tex2)+ tex2D(_Tex3,i.uv)*(_mix_Tex3)+ tex2D(_Tex4,i.uv)*(_mix_Tex4)+ tex2D(_Tex5,i.uv)*(_mix_Tex5)+ tex2D(_Tex6,i.uv)*(_mix_Tex6);
                return col;
            }
            ENDCG
        }
    }
}
