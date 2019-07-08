Shader "Custom/toonshader"
{
    Properties
    {
		_LitOffset ("Lit Offset",Range(0,1))=0.25
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
	_SSSText("SSS Map",2D)="black"{}
	_SSColor("SSS Tint",Color)=(1,1,1,1)
		_CombMap("Comb ",2D)="white"{}
	_SpecPower("Specular Power",Range(0,100)) = 20.0
		_SpecScale("Specular Scale",Range(0,10)) = 1.0
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineThickness("Outline Thickness",Range(0,10)) = 0.3

	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

Pass{
		Cull Front

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag


	   #include "UnityCG.cginc"
		half4 _OutlineColor;
		half4 _OutlineThickness;
		struct  appdata {
			float4 vertex:POSITION;
			float3 normal:NORMAL;
		};
		struct v2f {
			float4 vertex:SV_POSITION;
		};
		v2f vert(appdata v) {
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex + normalize(v.normal)*(_OutlineThickness/100));
			return o;
		}
		fixed4 frag(v2f i) :SV_Target{
			return _OutlineColor;
		}
			ENDCG
	}
		CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
       #pragma surface surf ToonLighting

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
	     sampler2D _SSSTex;
		 sampler2D _CombMap;
	    half4 _Color;
		half4 _SSSColor;
		half _LitOffset;
		half _SpecPower;
		half _SpecScale;

		

		struct CustomSurfaceOutput {
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Alpha;
			half3 SSS;
			half vertexOc;
			half Glossy;
			half Glossiness;
			half shadow;
			half InnerLine;
		};
		half4 LightingToonLighting(CustomSurfaceOutput s, half3 lightDir,half viewDir, half atten) {
			float oc = step(0.9, s.vertexOc);
			float nDotl = saturate(dot(s.Normal, lightDir))*atten;
		    
			float toonL = step(_LitOffset, nDotl)*s.shadow *oc;
			half3 albedoColor = lerp(s.Albedo*s.SSS, s.Albedo*_LightColor0*toonL, toonL);
			half3 specularColor = saturate(pow(dot(reflect(-lightDir, s.Normal), viewDir),s.Glossiness* _SpecPower)) *toonL* _LightColor0*s.Glossy*_SpecScale;
			//return half4(s.Glossy, s.Glossy);
			return half4((albedoColor+specularColor)*s.InnerLine,1);
		}


		struct Input
		{
			float2 uv_MainTex;
			float4 vertColor:COLOR;
		};


        void surf (Input IN, inout CustomSurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			half4 comb = tex2D(_CombMap, IN.uv_MainTex);
            o.Albedo = c.rgb;
			o.SSS = tex2D(_SSSTex, IN.uv_MainTex)*_SSSColor;
			o.vertexOc = IN.vertColor.r;
			o.Glossy = comb.r;
			o.Glossiness = comb.b;
			o.shadow = comb.g;
			o.InnerLine = comb.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
