Shader "Cartoon/Texture" {
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	
	SubShader {
		Tags { "RenderType"="Opaque"}
		
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surfX Lambert exclude_path:deferred exclude_path:prepass noforwardadd halfasview 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 2.0

		sampler2D _MainTex;

		struct Input 
		{
			float2 viewDir   ;
		};


		void surfX (Input IN, inout SurfaceOutput o) {
			
			fixed4 c = tex2D (_MainTex, IN.viewDir   );
			o.Albedo = c.rgb;
			
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
