// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Effects/Matrix/Additive" {
	Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}
}

Category {
	Tags { "Queue"="Transparent" "RenderType"="Transparent" }
	Blend SrcAlpha One
	Cull Off 
	Lighting Off 
	ZWrite Off 
	Fog { Color (0,0,0,0) }
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles
		
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			float4x4 _DecalMatr;  
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float3 pTex : TEXCOORD1;
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				
				float4 trasformed = mul(_DecalMatr,  v.vertex);
                o.pTex = trasformed.xyz+float3(0.5, 0.5, 0);
				o.texcoord = TRANSFORM_TEX(o.pTex,_MainTex);
				return o;
			}

			float _InvFade;
			
			fixed4 frag (v2f i) : COLOR
			{
				fixed4 tex = tex2D(_MainTex, float2(i.texcoord));
				if(i.pTex.y<0 || i.pTex.y>1 || i.pTex.x < 0 || i.pTex.x > 1) {
				  tex.a=0; 
				}
				return 2.0f * _TintColor * tex ;
			}
			ENDCG 
		}
	}	
}
}
