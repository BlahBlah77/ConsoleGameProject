Shader "Custom/Decal"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NormalTex ("Normal Map", 2D) = "bump" {}
	}
	SubShader
	{
		Pass
		{
			Fog {Mode Off}
			ZWrite Off

			CGPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers nomrt

			#include "UnityCG.cginc"

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 uv : TEXCOORD0;
				float4 screenuv : TEXCOORD1;
				float3 ray : TEXCOORD2;
				half3 orientation : TEXCOORD3;
				half3 orientationx : TEXCOORD4;
				half3 orientationz : TEXCOORD5;
			};

			v2f vert (float3 v : POSITION)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(float4(v,1));
				o.uv = v.xz + 0.5;
				o.screenuv = ComputeScreenPos(o.vertex);
				o.ray = mul(UNITY_MATRIX_MV, float4(v, 1)).xyz * float3(-1, -1, 1);
				o.orientation = mul((float3x3)unity_ObjectToWorld, float3(0, 1, 0));
				o.orientationx = mul((float3x3)unity_ObjectToWorld, float3(1, 0, 0));
				o.orientationz = mul((float3x3)unity_ObjectToWorld, float3(0, 0, 1));
				return o;
			}

			CBUFFER_START(UnityPerCamera2)
			CBUFFER_END

			sampler2D _MainTex;
			sampler2D _NormalTex;
			sampler2D _NormalTexCopy;
			sampler2D_float _CameraDepthTex;
			
			void frag (v2f i, out half4 diffuseOUT : COLOR0, out half4 normalOUT : COLOR1)
			{
				i.ray = i.ray * (_ProjectionParams.z / i.ray.z);
				float2 uv = i.screenuv.xy / i.screenuv.w;

				float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTex, uv);
				depth = Linear01Depth(depth);
				float4 vpos = float4(i.ray * depth,1);
				float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
				float3 opos = mul(unity_WorldToObject, float4(wpos,1)).xyz;

				clip(float3(0.5,0.5,0.5) - abs(opos.xyz));

				i.uv = opos.xz + 0.5;

				half3 normal = tex2D(_NormalTexCopy, uv).rgb;
				fixed3 wnormal = normal.rgb * 2.0 - 1.0;
				clip(dot(wnormal, i.orientation) - 0.3);

				fixed4 col = tex2D(_MainTex, i.uv);
				clip(col.a - 0.2);
				diffuseOUT = col;

				fixed3 nor = UnpackNormal(tex2D(_NormalTex, i.uv));
				half3x3 norMat = half3x3(i.orientationx, i.orientationz, i.orientation);
				nor = mul(nor, norMat);
				normalOUT = fixed4(nor*0.5 + 0.5,1);
			}
			ENDCG
		}
	}
	Fallback Off
}
