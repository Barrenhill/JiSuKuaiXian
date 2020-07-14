Shader "Custom/Curved" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _QOffset ("Offset", Vector) = (0,-189.5,0,0)
        _Distance("distance",float) = 209.5
    }
    
    SubShader {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
			#pragma multi_compile_fog
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Distance;
            float4 _QOffset;
            
            struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			
            struct v2f {
 //               float4 pos : POSITION;
                UNITY_FOG_COORDS(1)
                float2 uv  : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
               v2f o;
               
//               UnityObjectToViewPos(v.vertex);
               float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
               float zOff = vPos.z/_Distance;
                vPos += _QOffset*zOff*zOff;
 //              vPos += float4(0,0,0,0)*zOff*zOff;
               o.vertex = mul (UNITY_MATRIX_P, vPos);
               o.uv = v.texcoord;
               UNITY_TRANSFER_FOG(o,o.vertex);
               return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				UNITY_OPAQUE_ALPHA(col.a);
				return col;
            }
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}