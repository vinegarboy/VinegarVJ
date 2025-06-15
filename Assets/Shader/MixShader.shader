Shader "VinegarShader/MixShader"
{
    Properties
    {
        [MainTexture]_Tex1 ("Texture1", 2D) = "white" {}
        _mix_Tex1 ("Blend Texture1", Range(0,1)) = 1
        _Tex1_Offset ("Texture1 Offset", Vector) = (0, 0, 0, 0)
        _Tex1_Scale ("Texture1 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega1 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray1 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono1 ("モノクロ", Float) = 0


        _Tex2 ("Texture2", 2D) = "white" {}
        _mix_Tex2 ("Blend Texture2", Range(0,1)) = 1
        _Tex2_Offset ("Texture2 Offset", Vector) = (0, 0, 0, 0)
        _Tex2_Scale ("Texture2 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega2 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray2 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono2 ("モノクロ", Float) = 0


        _Tex3 ("Texture3", 2D) = "white" {}
        _mix_Tex3 ("Blend Texture3", Range(0,1)) = 1
        _Tex3_Offset ("Texture3 Offset", Vector) = (0, 0, 0, 0)
        _Tex3_Scale ("Texture3 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega3 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray3 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono3 ("モノクロ", Float) = 0
        

        _Tex4 ("Texture4", 2D) = "white" {}
        _mix_Tex4 ("Blend Texture4", Range(0,1)) = 1
        _Tex4_Offset ("Texture4 Offset", Vector) = (0, 0, 0, 0)
        _Tex4_Scale ("Texture4 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega4 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray4 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono4 ("モノクロ", Float) = 0


        _Tex5 ("Texture5", 2D) = "white" {}
        _mix_Tex5 ("Blend Texture5", Range(0,1)) = 1
        _Tex5_Offset ("Texture5 Offset", Vector) = (0, 0, 0, 0)
        _Tex5_Scale ("Texture5 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega5 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray5 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono5 ("モノクロ", Float) = 0


        _Tex6 ("Texture6", 2D) = "white" {}
        _mix_Tex6 ("Blend Texture6", Range(0,1)) = 1
        _Tex6_Offset ("Texture6 Offset", Vector) = (0, 0, 0, 0)
        _Tex6_Scale ("Texture6 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega6 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray6 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono6 ("モノクロ", Float) = 0


        _Tex7 ("Texture7", 2D) = "white" {}
        _mix_Tex7 ("Blend Texture7", Range(0,1)) = 1
        _Tex7_Offset ("Texture7 Offset", Vector) = (0, 0, 0, 0)
        _Tex7_Scale ("Texture7 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega7 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray7 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono7 ("モノクロ", Float) = 0

        
        _Tex8 ("Texture8", 2D) = "white" {}
        _mix_Tex8 ("Blend Texture8", Range(0,1)) = 1
        _Tex8_Offset ("Texture8 Offset", Vector) = (0, 0, 0, 0)
        _Tex8_Scale ("Texture8 Scale", Vector) = (1, 1, 1, 1)
        [MaterialToggle] _IsNega8 ("ネガポジ", Float) = 0
        [MaterialToggle] _IsGray8 ("グレースケール", Float) = 0
        [MaterialToggle] _IsMono8 ("モノクロ", Float) = 0		
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
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
            sampler2D _Tex7;
            float4 _Tex7_ST;
            sampler2D _Tex8;
            float4 _Tex8_ST;
            float _mix_Tex1;
            float _mix_Tex2;
            float _mix_Tex3;
            float _mix_Tex4;
            float _mix_Tex5;
            float _mix_Tex6;
            float _mix_Tex7;
            float _mix_Tex8;
            float _IsNega1;
            float _IsNega2;
            float _IsNega3;
            float _IsNega4;
            float _IsNega5;
            float _IsNega6;
            float _IsNega7;
            float _IsNega8;
            float _IsGray1;
            float _IsGray2;
            float _IsGray3;
            float _IsGray4;
            float _IsGray5;
            float _IsGray6;
            float _IsGray7;
            float _IsGray8;
            float _IsMono1;
            float _IsMono2;
            float _IsMono3;
            float _IsMono4;
            float _IsMono5;
            float _IsMono6;
            float _IsMono7;
            float _IsMono8;
            float4 _Tex1_Offset;
            float4 _Tex1_Scale;
            float4 _Tex2_Offset;
            float4 _Tex2_Scale;
            float4 _Tex3_Offset;
            float4 _Tex3_Scale;
            float4 _Tex4_Offset;
            float4 _Tex4_Scale;
            float4 _Tex5_Offset;
            float4 _Tex5_Scale;
            float4 _Tex6_Offset;
            float4 _Tex6_Scale;
            float4 _Tex7_Offset;
            float4 _Tex7_Scale;
            float4 _Tex8_Offset;
            float4 _Tex8_Scale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv1 = (i.uv + _Tex1_Offset.xy) * _Tex1_Scale.xy;
                fixed4 tex1 = tex2D(_Tex1,uv1);

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

                float2 uv2 = (i.uv + _Tex2_Offset.xy) * _Tex2_Scale.xy;
                fixed4 tex2 = tex2D(_Tex2, uv2);  

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

                float2 uv3 = (i.uv + _Tex3_Offset.xy) * _Tex3_Scale.xy;
                fixed4 tex3 = tex2D(_Tex3, uv3);

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

                float2 uv4 = (i.uv + _Tex4_Offset.xy) * _Tex4_Scale.xy;
                fixed4 tex4 = tex2D(_Tex4, uv4);

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

                float2 uv5 = (i.uv + _Tex5_Offset.xy) * _Tex5_Scale.xy;
                fixed4 tex5 = tex2D(_Tex5, uv5);

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

                float2 uv6 = (i.uv + _Tex6_Offset.xy) * _Tex6_Scale.xy;
                fixed4 tex6 = tex2D(_Tex6, uv6);


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

                float2 uv7 = (i.uv + _Tex7_Offset.xy) * _Tex7_Scale.xy;
                fixed4 tex7 = tex2D(_Tex7, uv7);


                if(_IsNega7>0.5){
                    tex7.rgb = 1-tex7.rgb;
                }

                float gray7 = dot(tex7.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray7>0.5){
                    tex7 = fixed4(gray7, gray7, gray7, 1);
                }

                if(_IsMono7>0.5){
                    if(gray7<0.5){
                        tex7 = fixed4(0, 0, 0, 1);
                    }else{
                        tex7 = fixed4(1, 1, 1, 1);
                    }
                }

                float2 uv8 = (i.uv + _Tex8_Offset.xy) * _Tex8_Scale.xy;
                fixed4 tex8 = tex2D(_Tex8, uv8);


                if(_IsNega8>0.5){
                    tex8.rgb = 1-tex8.rgb;
                }

                float gray8 = dot(tex8.rgb, fixed3(0.299, 0.587, 0.114));

                if(_IsGray8>0.5){
                    tex8 = fixed4(gray8, gray8, gray8, 1);
                }

                if(_IsMono8>0.5){
                    if(gray8<0.5){
                        tex8 = fixed4(0, 0, 0, 1);
                    }else{
                        tex8 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed4 col = 
                    tex1*(_mix_Tex1) + tex2*(_mix_Tex2)+ tex3*(_mix_Tex3)
                    + tex4*(_mix_Tex4)+ tex5*(_mix_Tex5)+ tex6*(_mix_Tex6)+tex7*(_mix_Tex7)+tex8*(_mix_Tex8);
                return col;
            }
            ENDCG
        }
    }
}
