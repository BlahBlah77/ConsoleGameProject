Shader "Custom/Ripple" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormTex("Normal", 2D) = "bump" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Scale("Ripple Scale", Range(0.2, 100.0)) = 1.0
		_Speed("Ripple Speed", Range(-50.0, 50.0)) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NormTex;

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_NormTex;
		};

		half _Glossiness;
		half _Metallic;
		half _Scale;
		half _Speed;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {

			// Metallic and smoothness come from slider variables
			half2 newuv = (IN.uv_MainTex - 0.5) * _Scale;
			half b = sqrt(newuv.x * newuv.x + newuv.y * newuv.y);
			half l = sin(b + _Time[1] * _Speed) / b;

			fixed4 c = tex2D(_MainTex, IN.uv_MainTex + l) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = _Color.a;
			half norc = UnpackNormal(tex2D(_NormTex, IN.uv_NormTex + l));
			o.Normal = norc + (l, l, l);
			//o.Normal = (norl, norl, norl) + (l, l, l);
			//o.Normal = UnpackNormal(tex2D(_NormTex, IN.uv_NormTex)) * (l, l, l);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
