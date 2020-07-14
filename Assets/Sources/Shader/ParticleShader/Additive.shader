Shader "Custom/Additive" {
Properties {
    _MainTex ("Particle Texture", 2D) = "white" {}
    _TintColor("Tint Color", Color) = (1.0, 1.0, 1.0, 1.0)
     
//    _QOffset ("Offset", Vector) = (0,-189.5,0,0)
//    _Distance("distance",float) = 209.5
}

SubShader
{
//        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        Blend SrcAlpha One
        Cull Off Lighting Off ZWrite Off Fog { Mode Off }
    Pass
    {
            CGPROGRAM
           
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _TintColor;
            float _Distance;
            float4 _QOffset;

            #pragma vertex vert
            #pragma fragment frag
            

            struct a2v {
                 float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 position : SV_POSITION;
                fixed4 color : COLOR;
               	float2 uv : TEXCOORD0;
            };

            v2f vert(a2v v) {
               float _Distance= 209.5;
               float4 _QOffset= fixed4(0,-166.5,0,0);
                
                v2f o;
                // UnityObjectToClipPos拆分成mvp
//                o.position = UnityObjectToClipPos(v.vertex);
                // M
				float3 worldpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				// V 
				float4 mvPos = mul(unity_MatrixV, float4(worldpos, 1.0));
			    // P
				float zOff = mvPos.z/_Distance;
               	mvPos += _QOffset*zOff*zOff;
                o.position = mul (UNITY_MATRIX_P, mvPos);
                
                o.color = v.color;
                o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                
                return o;
            }

            fixed4 frag(v2f i) : SV_Target{
                fixed4 col = i.color * _TintColor * tex2D(_MainTex, i.uv.xy);
                return fixed4(col);
            }

            ENDCG
        }
    }
}

//    }
// Category {
//     Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
//     Blend SrcAlpha One
//     Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }

//     BindChannels {
//         Bind "Color", color
//         Bind "Vertex", vertex
//         Bind "TexCoord", texcoord
//     }

//     SubShader {
//         Pass {
//             SetTexture [_MainTex] {
//                 combine texture * primary
//             }
//         }
//     }
// }
//}
