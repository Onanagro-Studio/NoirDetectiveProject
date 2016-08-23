// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:0,x:34855,y:31981,varname:node_0,prsc:2|custl-64-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:37,x:33872,y:32026,varname:node_37,prsc:2;n:type:ShaderForge.SFN_Dot,id:40,x:32931,y:32250,varname:node_40,prsc:2,dt:1|A-42-OUT,B-41-OUT;n:type:ShaderForge.SFN_NormalVector,id:41,x:32722,y:32344,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:42,x:32722,y:32223,varname:node_42,prsc:2;n:type:ShaderForge.SFN_Dot,id:52,x:32931,y:32423,varname:node_52,prsc:2,dt:1|A-41-OUT,B-62-OUT;n:type:ShaderForge.SFN_Add,id:55,x:33893,y:32461,varname:node_55,prsc:2|A-84-OUT,B-5807-OUT,C-265-OUT;n:type:ShaderForge.SFN_Power,id:58,x:33133,y:32523,cmnt:Specular Light,varname:node_58,prsc:2|VAL-52-OUT,EXP-244-OUT;n:type:ShaderForge.SFN_HalfVector,id:62,x:32722,y:32483,varname:node_62,prsc:2;n:type:ShaderForge.SFN_LightColor,id:63,x:33872,y:32155,varname:node_63,prsc:2;n:type:ShaderForge.SFN_Multiply,id:64,x:34597,y:32431,varname:node_64,prsc:2|A-9323-OUT,B-6681-OUT,C-55-OUT;n:type:ShaderForge.SFN_Color,id:80,x:33201,y:32116,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:82,x:33485,y:31896,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:False|UVIN-272-UVOUT;n:type:ShaderForge.SFN_Multiply,id:84,x:33573,y:32160,cmnt:Diffuse Light,varname:node_84,prsc:2|A-3449-OUT,B-80-RGB,C-264-OUT;n:type:ShaderForge.SFN_AmbientLight,id:187,x:33562,y:32344,varname:node_187,prsc:2;n:type:ShaderForge.SFN_Slider,id:239,x:31984,y:32591,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:240,x:32722,y:32640,varname:node_240,prsc:2|A-242-OUT,B-241-OUT;n:type:ShaderForge.SFN_Vector1,id:241,x:32554,y:32728,varname:node_241,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:242,x:32554,y:32578,varname:node_242,prsc:2|A-239-OUT,B-243-OUT;n:type:ShaderForge.SFN_Vector1,id:243,x:32243,y:32697,varname:node_243,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Exp,id:244,x:32893,y:32640,varname:node_244,prsc:2,et:1|IN-240-OUT;n:type:ShaderForge.SFN_Posterize,id:264,x:33368,y:32344,varname:node_264,prsc:2|IN-40-OUT,STPS-8696-OUT;n:type:ShaderForge.SFN_Posterize,id:265,x:33368,y:32475,varname:node_265,prsc:2|IN-243-OUT,STPS-8696-OUT;n:type:ShaderForge.SFN_TexCoord,id:272,x:33308,y:31803,varname:node_272,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector3,id:3449,x:33201,y:31961,varname:node_3449,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Multiply,id:9323,x:34148,y:31873,varname:node_9323,prsc:2|A-37-OUT,B-1704-OUT;n:type:ShaderForge.SFN_Vector1,id:1704,x:34155,y:32008,varname:node_1704,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp,id:6681,x:34374,y:32169,varname:node_6681,prsc:2|IN-63-RGB,MIN-6618-OUT,MAX-1054-OUT;n:type:ShaderForge.SFN_Vector1,id:6618,x:34080,y:32254,varname:node_6618,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1054,x:34059,y:32364,varname:node_1054,prsc:2,v1:5;n:type:ShaderForge.SFN_Vector1,id:8696,x:33161,y:32360,varname:node_8696,prsc:2,v1:3;n:type:ShaderForge.SFN_Subtract,id:1263,x:33609,y:32669,varname:node_1263,prsc:2|A-187-RGB,B-899-OUT;n:type:ShaderForge.SFN_Vector1,id:899,x:33383,y:32757,varname:node_899,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9234,x:33862,y:32721,varname:node_9234,prsc:2|A-1263-OUT,B-6025-OUT;n:type:ShaderForge.SFN_Add,id:6342,x:34146,y:32617,varname:node_6342,prsc:2|A-9234-OUT,B-1174-OUT;n:type:ShaderForge.SFN_Vector1,id:6025,x:33666,y:32905,varname:node_6025,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:1174,x:34029,y:32902,varname:node_1174,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:5807,x:34353,y:32617,varname:node_5807,prsc:2|A-6342-OUT,B-6025-OUT;proporder:80-82-239;pass:END;sub:END;*/

Shader "Shader Forge/Examples/Custom Lighting" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "bump" {}
        _Gloss ("Gloss", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_8696 = 3.0;
                float node_6025 = 2.0;
                float node_243 = 0.01;
                float3 finalColor = ((attenuation*1.0)*clamp(_LightColor0.rgb,0.0,5.0)*((float3(1,1,1)*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * node_8696) / (node_8696 - 1))+((((UNITY_LIGHTMODEL_AMBIENT.rgb-0.5)*node_6025)+1.0)/node_6025)+floor(node_243 * node_8696) / (node_8696 - 1)));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_8696 = 3.0;
                float node_6025 = 2.0;
                float node_243 = 0.01;
                float3 finalColor = ((attenuation*1.0)*clamp(_LightColor0.rgb,0.0,5.0)*((float3(1,1,1)*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * node_8696) / (node_8696 - 1))+((((UNITY_LIGHTMODEL_AMBIENT.rgb-0.5)*node_6025)+1.0)/node_6025)+floor(node_243 * node_8696) / (node_8696 - 1)));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
