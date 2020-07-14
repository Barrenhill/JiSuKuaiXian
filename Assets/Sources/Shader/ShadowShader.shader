Shader "Custom/Shadow"
{
	Properties
     {
        _MainTex ("Texture", 2D) = "white" {}
		_ShadowInvLen ("ShadowInvLen", float) = 1.0 //0.4449261
		_ShadowPlane ("_ShadowPlane",Vector) = (0.0, 1.0, 0.0, 0.0)
		_ShadowProjDir("ShadowProjDir",Vector)=(-0.3, -0.8, 0.6, 0.0)
		_WorldPos("WorldPos",Vector)=(0.0, -0.5, 0.0,0.0)
		_ShadowFadeParams("ShadowFadeParams",Vector) = (0.4, 1.26, 0.8, 0.0)
		_ShadowFalloff ("ShadowFalloff",float)=1.35
         	
     }
         	
   SubShader
    {
        Tags{ "RenderType" = "Opaque" "Queue" = "Geometry+10" }
        LOD 100
        
		Pass
		{
			Blend SrcAlpha  OneMinusSrcAlpha
			ZWrite Off
			Cull Back
			ColorMask RGB
			
			Stencil
			{
				Ref 0			
				Comp Equal			
				WriteMask 255		
				ReadMask 255
				//Pass IncrSat
				Pass Invert
				Fail Keep
				ZFail Keep
			}
			
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag

			float4 _ShadowPlane;
			float4 _ShadowProjDir;
			float4 _WorldPos;
			float _ShadowInvLen;
			float4 _ShadowFadeParams;
			float _ShadowFalloff;
			
			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 xlv_TEXCOORD0 : TEXCOORD0;
				float3 xlv_TEXCOORD1 : TEXCOORD1;
			};

			v2f vert(appdata v)
			{
			    float _Distance = 209.5;
                float4 _QOffset = float4(0,-166.5,0,0);
			
				v2f o;

				float3 lightdir = normalize(_ShadowProjDir);
				// M
				float3 worldpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				// _ShadowPlane.w = p0 * n  // 平面的w分量就是p0 * n
				float distance = (_ShadowPlane.w - dot(_ShadowPlane.xyz, worldpos)) / dot(_ShadowPlane.xyz, lightdir.xyz);
				worldpos = worldpos + distance * lightdir.xyz;
				// V 
				float4 mvPos = mul(unity_MatrixV, float4(worldpos, 1.0));
				o.xlv_TEXCOORD0 = _WorldPos.xyz;
				o.xlv_TEXCOORD1 = worldpos;

				// P
				float zOff = mvPos.z/_Distance;
// 				mvPos += float4(0,0,0,0)*zOff*zOff;
              	mvPos += _QOffset*zOff*zOff;
				o.vertex = mul(UNITY_MATRIX_P, mvPos);

				return o;
			}
			
			float4 frag(v2f i) : SV_Target
			{
				float3 posToPlane_2 = (i.xlv_TEXCOORD0 - i.xlv_TEXCOORD1);
				float4 color;
				color.xyz = float3(0.0, 0.0, 0.0);
                //不衰减
                color.w = 0.2;
				return color;
			}
			
			ENDCG
		}
    }
}
