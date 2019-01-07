Shader "Custom/Dissolve" {
	Properties {
		_Color ("Colour", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormTex ("Normal", 2D) = "bump" {}
		_DissTex ("Dissolve", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		[Header(Dissolve Properties)]
		_DissAmount ("Dissolve Time", Range(0,1)) = 0
		_DissColor ("Dissolve Colour", Color) = (1,1,1,1)
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

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_NormTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _DissColor;
		sampler2D _DissTex;
		sampler2D _NormTex;
		half _DissAmount;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			half diss_val = tex2D(_DissTex, IN.uv_MainTex).r;
			clip(diss_val - _DissAmount);
			if (diss_val - _DissAmount < 0.05f)
			{
				o.Emission = _DissColor;

			}

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Normal = UnpackNormal(tex2D(_NormTex, IN.uv_NormTex));
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
