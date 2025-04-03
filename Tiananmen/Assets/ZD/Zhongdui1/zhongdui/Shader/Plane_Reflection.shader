Shader "Plane_Reflection"
{
    Properties
    {
        _BumpMap ("法线贴图", 2D) = "bump" {}
		[NoScaleOffset]_Ref ("镜面反射，不用设置!", 2D) = "white" {}
		_Distortion ("反射扭曲", Range (0, 1)) = 0
		_ReflectAmount ("反射强度",Range(0,1)) = 1
		[Toggle(_NORMAL_MODE)] _Mode ("普通模式开启", Float) = 0
    }
    SubShader
    {
        Tags {"Queue"="Transparent+5" "RenderType"="Transparent" "IgnoreProjector"="True"}

        Pass
        {
            Tags {"LightMode"="ForwardBase"}
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #pragma shader_feature _NORMAL_MODE
            #include "UnityCG.cginc"

			sampler2D _Ref;
			fixed _Distortion;
			fixed _ReflectAmount;
			sampler2D _BumpMap;
			float4 _BumpMap_ST;

            struct a2v
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
				float2 uv_BumpMap : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
            };

            

            v2f vert (a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv_BumpMap = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
				o.screenPos = ComputeScreenPos(o.pos);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 normal = UnpackNormal (tex2D(_BumpMap, i.uv_BumpMap));
				float2 screenUV = i.screenPos.xy / i.screenPos.w;
	            screenUV += normal.xy * _Distortion;
				fixed4 ref = tex2D(_Ref, screenUV);
				#ifndef _NORMAL_MODE
				    ref.a = Luminance(ref.rgb)*_ReflectAmount*2;
				    fixed4 col = fixed4(ref.rgb*ref.a,ref.a);
                #else
                    ref.a = _ReflectAmount;
                    fixed4 col = fixed4(ref.rgb,ref.a);
                #endif

                return col;
            }
            ENDCG
        }
    }
}
