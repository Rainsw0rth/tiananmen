// Made with Amplify Shader Editor v1.9.2.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ASE/vertexcolor"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Maintex("Maintex", 2D) = "white" {}
		_SecTex("SecTex", 2D) = "black" {}
		[HDR]_Color0("Color 0", Color) = (1,1,1,0)
		_Animation("Animation", Range( 0 , 1)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Background+0" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float4 vertexColor : COLOR;
			float2 uv_texcoord;
		};

		uniform float4 _Color0;
		uniform sampler2D _Maintex;
		uniform float4 _Maintex_ST;
		uniform float _Animation;
		uniform sampler2D _SecTex;
		uniform float4 _SecTex_ST;
		uniform float _Cutoff = 0.5;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_Maintex = i.uv_texcoord * _Maintex_ST.xy + _Maintex_ST.zw;
			float4 tex2DNode1 = tex2D( _Maintex, uv_Maintex );
			float temp_output_21_0 =  ( _Animation - 0.0 > 1.0 ? 0.0 : _Animation - 0.0 <= 1.0 && _Animation + 0.0 >= 1.0 ? 1.0 : 0.0 ) ;
			float temp_output_12_0 = ( 1.0 - temp_output_21_0 );
			float2 uv_SecTex = i.uv_texcoord * _SecTex_ST.xy + _SecTex_ST.zw;
			float4 tex2DNode8 = tex2D( _SecTex, uv_SecTex );
			o.Emission = ( _Color0 * i.vertexColor * ( ( tex2DNode1 * temp_output_21_0 ) + ( temp_output_12_0 * tex2DNode8 ) ) ).rgb;
			o.Alpha = 1;
			clip( ( ( tex2DNode1.a * temp_output_21_0 ) + ( temp_output_12_0 * tex2DNode8.a ) ) - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19202
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;ASE/vertexcolor;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;True;0;True;Opaque;;Background;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;0;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.ColorNode;6;-1182.403,-357.9155;Inherit;False;Property;_Color0;Color 0;3;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;4;-1424.325,-128.0209;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-395.8655,-99.77099;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-1498.007,50.94943;Inherit;True;Property;_Maintex;Maintex;1;0;Create;True;0;0;0;False;0;False;-1;8c64e97d0e03f084ba865c4c6723274c;c92d87ab054182c46aa59f56bc720a8c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-903.6826,57.2316;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;12;-1033.683,333.2316;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-741.3735,326.582;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-736.3735,466.582;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-617.3735,37.58203;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-913.6826,179.2316;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;8;-1111.715,436.5778;Inherit;True;Property;_SecTex;SecTex;2;0;Create;True;0;0;0;False;0;False;-1;8c64e97d0e03f084ba865c4c6723274c;ec439e0d47b6b7542b6a7d56ae538a69;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-371.3735,247.582;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-1759.846,425.384;Inherit;False;Constant;_Float0;Float 0;5;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-1616.579,553.7212;Inherit;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCIf;21;-1388.759,347.8528;Inherit;False;6;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-1789.929,335.7989;Inherit;False;Property;_Animation;Animation;4;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
WireConnection;0;2;5;0
WireConnection;0;10;16;0
WireConnection;5;0;6;0
WireConnection;5;1;4;0
WireConnection;5;2;15;0
WireConnection;10;0;1;0
WireConnection;10;1;21;0
WireConnection;12;0;21;0
WireConnection;13;0;12;0
WireConnection;13;1;8;0
WireConnection;14;0;12;0
WireConnection;14;1;8;4
WireConnection;15;0;10;0
WireConnection;15;1;13;0
WireConnection;11;0;1;4
WireConnection;11;1;21;0
WireConnection;16;0;11;0
WireConnection;16;1;14;0
WireConnection;21;0;9;0
WireConnection;21;1;19;0
WireConnection;21;3;20;0
ASEEND*/
//CHKSM=F343BE1A7B303B6B99A29547BD66F563619F2D5B