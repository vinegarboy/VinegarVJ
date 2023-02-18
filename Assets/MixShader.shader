Shader "VinegarShader/MixShader"
{
    Properties
    {
        _Tex1 ("Texture1", 2D) = "white" {}
        _mix_Tex1 ("BlendTexture1", Range(0,1)) = 1
        [MaterialToggle] _IsNega1 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray1 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono1 ("モノクロ", Float) = 0
        _Tex2 ("Texture2", 2D) = "white" {}
        _mix_Tex2 ("BlendTexture2", Range(0,1)) = 1
        [MaterialToggle] _IsNega2 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray2 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono2 ("モノクロ", Float) = 0
        _Tex3 ("Texture3", 2D) = "white" {}
        _mix_Tex3 ("BlendTexture3", Range(0,1)) = 1
        [MaterialToggle] _IsNega3 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray3 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono3 ("モノクロ", Float) = 0
        _Tex4 ("Texture4", 2D) = "white" {}
        _mix_Tex4 ("BlendTexture4", Range(0,1)) = 1
        [MaterialToggle] _IsNega4 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray4 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono4 ("モノクロ", Float) = 0
        _Tex5 ("Texture5", 2D) = "white" {}
        _mix_Tex5 ("BlendTexture5", Range(0,1)) = 1
        [MaterialToggle] _IsNega5 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray5 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono5 ("モノクロ", Float) = 0
        _Tex6 ("Texture6", 2D) = "white" {}
        _mix_Tex6 ("BlendTexture6", Range(0,1)) = 1
        [MaterialToggle] _IsNega6 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray6 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono6 ("モノクロ", Float) = 0
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
            float _IsNega1;
            float _IsNega2;
            float _IsNega3;
            float _IsNega4;
            float _IsNega5;
            float _IsNega6;
            float _IsGray1;
            float _IsGray2;
            float _IsGray3;
            float _IsGray4;
            float _IsGray5;
            float _IsGray6;
            float _IsMono1;
            float _IsMono2;
            float _IsMono3;
            float _IsMono4;
            float _IsMono5;
            float _IsMono6;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _Tex1);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex1 = tex2D(_Tex1,i.uv);

                if(_IsNega1>0.5){
                    tex1.rgb = 1-tex1.rgb;
                }

                float gray1 = dot(tex1.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray1>0.5){
                    tex1 = fixed4(gray1, gray1, gray1, 1);
                }

                if(_IsMono1>0.5){
                    if(gray1<0.5){
	                    tex1 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex1 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 tex2 = tex2D(_Tex2,i.uv);

                if(_IsNega2>0.5){
                    tex2.rgb = 1-tex2.rgb;
                }

                float gray2 = dot(tex2.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray2>0.5){
                    tex2 = fixed4(gray2, gray2, gray2, 1);
                }

                if(_IsMono2>0.5){
                    if(gray2<0.5){
	                    tex2 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex2 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 tex3 = tex2D(_Tex3,i.uv);

                if(_IsNega3>0.5){
                    tex3.rgb = 1-tex3.rgb;
                }

                float gray3 = dot(tex3.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray3>0.5){
                    tex3 = fixed4(gray3, gray3, gray3, 1);
                }

                if(_IsMono3>0.5){
                    if(gray3<0.5){
	                    tex3 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex3 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 tex4 = tex2D(_Tex4,i.uv);

                if(_IsNega4>0.5){     
                    tex4.rgb = 1-tex4.rgb;
                }

                float gray4 = dot(tex4.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray4>0.5){
                    tex4 = fixed4(gray4, gray4, gray4, 1);
                }

                if(_IsMono4>0.5){
                    if(gray4<0.5){
	                    tex4 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex4 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 tex5 = tex2D(_Tex5,i.uv);

                if(_IsNega5>0.5){
                    tex5.rgb = 1-tex5.rgb;
                }

                float gray5 = dot(tex5.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray5>0.5){
                    tex5 = fixed4(gray5, gray5, gray5, 1);
                }

                if(_IsMono5>0.5){
                    if(gray5<0.5){
	                    tex5 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex5 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 tex6 = tex2D(_Tex6,i.uv);

                if(_IsNega6>0.5){
                    tex6.rgb = 1-tex6.rgb;
                }

                float gray6 = dot(tex6.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray6>0.5){
                    tex6 = fixed4(gray6, gray6, gray6, 1);
                }

                if(_IsMono6>0.5){
                    if(gray6<0.5){
	                    tex6 = fixed4(0, 0, 0, 1);
                    }else{
	                    tex6 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 col = 
                    tex1*(_mix_Tex1) + tex2*(_mix_Tex2)+ tex3*(_mix_Tex3)
                    + tex4*(_mix_Tex4)+ tex5*(_mix_Tex5)+ tex6*(_mix_Tex6);
                return col;
            }
            ENDCG
        }
    }
}
