Shader "ITGGame/IceBlock"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MainColor("Main Color", Color) = (1,1,1,1)
		_Bump("Bump", 2D) = "bump" {}
		_LUT("LUT", 2D) = "white" {}
		_ThicknessMap("Thickness Map", 2D) = "white" {}
		_Noise("Noise Map", 2D) = "white" {}
		_SpecColor("Spec Color", Color) = (1,1,1,1)
		_sigma_t("sigma_t", float) = 1
		_lightParams("lightParams", Vector) = (0,0,0,0)
		_EnvMap ("Env Map", Cube) = "defaulttexture" {}
	}
	SubShader
	{
		Tags{ "Queue" = "Geometry" }
		LOD 200
		Cull Off

		Pass
		{
			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag  

			#include "UnityCG.cginc"  

			sampler2D _MainTex;
			sampler2D _Bump;
			sampler2D _LUT;
			sampler2D _ThicknessMap;
			sampler2D _Noise;
			samplerCUBE _EnvMap;

			fixed4 _MainColor;
			float4 _MainTex_ST;
			float4 _ThicknessMap_ST;
			fixed4 _SpecColor;
			float _sigma_t;
			float4 _lightParams;

			struct a2v 
			{
				float4 vertex : POSITION;
				fixed3 normal : NORMAL;
				fixed4 texcoord : TEXCOORD0;
				fixed4 tangent : TANGENT;
			};

			struct v2f 
			{
				float4 pos : POSITION;
				fixed2 uv : TEXCOORD0;
				fixed3 lightDir : TEXCOORD1;
				fixed4 TtoW0 : TEXCOORD2;
				fixed4 TtoW1 : TEXCOORD3;
				fixed4 TtoW2 : TEXCOORD4;
				fixed2 uv2 : TEXCOORD5;
			};

			v2f vert(a2v v) 
			{
				v2f o;

				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.texcoord, _ThicknessMap);

				TANGENT_SPACE_ROTATION;
				o.lightDir = mul(rotation, ObjSpaceLightDir(v.vertex));

				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
				//fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
				//fixed3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

				float3x3 WtoT = mul(rotation, (float3x3)unity_WorldToObject);
				o.TtoW0 = float4(WtoT[0].xyz, worldPos.x);
				o.TtoW1 = float4(WtoT[1].xyz, worldPos.y);
				o.TtoW2 = float4(WtoT[2].xyz, worldPos.z);

				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				fixed4 thicknessMap = tex2D(_ThicknessMap, i.uv2);
				fixed4 diffuseColor = tex2D(_MainTex, i.uv) * _MainColor * _lightParams.x;
				fixed3 norm = UnpackNormal(tex2D(_Bump, i.uv));

				float3 worldPos = float3(i.TtoW0.w, i.TtoW1.w, i.TtoW2.w);
				fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
				fixed3 lightDir = (-worldViewDir + float3(thicknessMap.xyz * 2 - 1));
				float3 H = normalize(lightDir + worldViewDir);
				half3 worldNormal = normalize(mul(norm, float3x3(i.TtoW0.xyz, i.TtoW1.xyz, i.TtoW2.xyz)));

				thicknessMap *= pow(dot(worldNormal, worldViewDir), 8);

				half2 s;
				s.x = dot(worldNormal, lightDir);
				s.y = dot(worldNormal, H);
				float thickness = exp(thicknessMap.r * _sigma_t);
				half4 light = tex2D(_LUT, s * 0.5 + 0.5);
				half4 c = diffuseColor * half4(light.rgb * thickness,1) + _SpecColor * light.a + (1-saturate(thickness)) * texCUBE(_EnvMap, worldViewDir + worldNormal)*_lightParams.y;

				fixed3 noise = UnpackNormal(tex2D(_Noise, i.uv));
				half3 glitter = frac(0.6 * worldNormal + 9 * noise.xyz + worldViewDir * lightDir);
				glitter = saturate(1 - 2.5 * (glitter.x + glitter.y + glitter.z)) * _SpecColor * 1.25;
				c.rgb += glitter;

				return c;
			}

			ENDCG
		}
	}
}
