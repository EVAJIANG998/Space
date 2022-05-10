Shader "Transparent_Color" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_Alpha("Alpha",Range(0,255))=100
		_RimColor("Rim Color",Color)=(0,1,1,1)
		_RimPower("Rim Power",Range(0,10)) = 1
	}

	SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 300

		CGPROGRAM
	#pragma surface surf Lambert alpha:fade

		fixed4 _Color;
		fixed _Alpha;
		fixed4 _RimColor;
		fixed _RimPower;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
			float3 worldNormal;

		};

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			o.Alpha = _Alpha/255.0f;

			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), IN.worldNormal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		}
		ENDCG
	}

	FallBack "Legacy Shaders/Transparent/Diffuse"
}
