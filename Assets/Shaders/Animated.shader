Shader "Custom/Animated"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ScrollSpeeds ("Scroll Speeds", vector) = (0, 0, 0, 0)
		_RotatSpeeds ("Rotation Speeds", float) = 0
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
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _ScrollSpeeds;
			float _RotatSpeeds;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				float sX = sin ( _RotatSpeeds * _Time );
            	float cX = cos ( _RotatSpeeds * _Time );
            	float sY = sin ( _RotatSpeeds * _Time );
            	float2x2 rotatMatrix = float2x2(cX, -sX, sY, cX);
            	//v.texcoord.xy = mul(v.texcoord.xy, rotatMatrix);
            	o.uv.xy = mul(o.uv.xy, rotatMatrix);

				o.uv += _ScrollSpeeds * _Time.x;
				//o.uv += rotatMatrix;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 albedo = tex2D(_MainTex, i.uv);
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				//half4 output = half4(albedo.rgb * lighting.rgb, albedo.a);
				//output.rgb += emission.rgb;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
