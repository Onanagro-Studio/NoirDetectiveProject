// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:14,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:34899,y:31737,varname:node_4013,prsc:2|diff-1759-OUT,alpha-9167-A,clip-6147-OUT;n:type:ShaderForge.SFN_Time,id:4904,x:31909,y:32555,varname:node_4904,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:9501,x:32550,y:32147,ptovrint:False,ptlb:texture_1,ptin:_texture_1,varname:_texture_001,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6391-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2730,x:31576,y:32141,varname:node_2730,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:1077,x:31909,y:32453,ptovrint:False,ptlb:Speed_Text1,ptin:_Speed_Text1,varname:_speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:7241,x:32218,y:32277,varname:node_7241,prsc:2|A-1077-OUT,B-4904-T;n:type:ShaderForge.SFN_Panner,id:6391,x:32218,y:32463,varname:node_6391,prsc:2,spu:0.5,spv:0|UVIN-2730-UVOUT,DIST-7241-OUT;n:type:ShaderForge.SFN_Clamp01,id:1759,x:34338,y:31737,varname:node_1759,prsc:2|IN-8940-OUT;n:type:ShaderForge.SFN_Color,id:4218,x:32547,y:31796,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:400,x:31573,y:31952,varname:node_400,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:7184,x:32547,y:31561,ptovrint:False,ptlb:texture_2,ptin:_texture_2,varname:_texture_002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-646-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1025,x:33181,y:31706,varname:node_1025,prsc:2|A-9066-OUT,B-4521-OUT;n:type:ShaderForge.SFN_TexCoord,id:8006,x:31573,y:31555,varname:node_8006,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:6740,x:31573,y:31850,ptovrint:False,ptlb:Speed_Text2,ptin:_Speed_Text2,varname:_speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5469,x:31809,y:31745,varname:node_5469,prsc:2|A-6740-OUT,B-400-T;n:type:ShaderForge.SFN_Add,id:9066,x:32880,y:31650,varname:node_9066,prsc:2|A-7184-RGB,B-4218-RGB;n:type:ShaderForge.SFN_Slider,id:4521,x:32801,y:31849,ptovrint:False,ptlb:intensity2,ptin:_intensity2,varname:_intensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0.5322515,max:3;n:type:ShaderForge.SFN_Panner,id:476,x:32041,y:31613,varname:node_476,prsc:2,spu:-0.25,spv:0|UVIN-8006-UVOUT,DIST-5469-OUT;n:type:ShaderForge.SFN_Color,id:4325,x:32551,y:31208,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:_Color_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:988,x:31910,y:31381,varname:node_988,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8213,x:32551,y:30973,ptovrint:False,ptlb:texture_3,ptin:_texture_3,varname:_texture_003,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1113-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4368,x:33185,y:31118,varname:node_4368,prsc:2|A-7189-OUT,B-3086-OUT;n:type:ShaderForge.SFN_TexCoord,id:3491,x:31910,y:30984,varname:node_3491,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:3906,x:31910,y:31279,ptovrint:False,ptlb:Speed_Text3,ptin:_Speed_Text3,varname:_speed_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5847,x:32219,y:31103,varname:node_5847,prsc:2|A-3906-OUT,B-988-T;n:type:ShaderForge.SFN_Add,id:7189,x:32884,y:31062,varname:node_7189,prsc:2|A-8213-RGB,B-4325-RGB;n:type:ShaderForge.SFN_Slider,id:3086,x:32805,y:31261,ptovrint:False,ptlb:intensity3,ptin:_intensity3,varname:_intensity_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0.7932316,max:3;n:type:ShaderForge.SFN_Panner,id:1113,x:32219,y:31289,varname:node_1113,prsc:2,spu:-0.5,spv:0|UVIN-3491-UVOUT,DIST-5847-OUT;n:type:ShaderForge.SFN_Slider,id:5649,x:32792,y:32468,ptovrint:False,ptlb:intensity1,ptin:_intensity1,varname:_intensity_copy_copy02,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:1.100924,max:3;n:type:ShaderForge.SFN_Add,id:154,x:32871,y:32269,varname:node_154,prsc:2|A-9501-RGB,B-5179-RGB;n:type:ShaderForge.SFN_Color,id:5179,x:32538,y:32415,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color_copy_copy02,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2344,x:33169,y:32277,varname:node_2344,prsc:2|A-154-OUT,B-5649-OUT;n:type:ShaderForge.SFN_Multiply,id:8940,x:33709,y:31733,varname:node_8940,prsc:2|A-4368-OUT,B-1025-OUT,C-2344-OUT;n:type:ShaderForge.SFN_Panner,id:646,x:32357,y:31615,varname:node_646,prsc:2,spu:0,spv:1|UVIN-476-UVOUT,DIST-1462-OUT;n:type:ShaderForge.SFN_Sin,id:9356,x:31945,y:31907,varname:node_9356,prsc:2|IN-400-T;n:type:ShaderForge.SFN_Multiply,id:1462,x:32165,y:31907,varname:node_1462,prsc:2|A-9356-OUT,B-855-OUT;n:type:ShaderForge.SFN_Slider,id:855,x:31740,y:32088,ptovrint:False,ptlb:sinwave2,ptin:_sinwave2,varname:_sinwave2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05176616,max:0.5;n:type:ShaderForge.SFN_ComponentMask,id:6147,x:34583,y:31544,varname:node_6147,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1759-OUT;n:type:ShaderForge.SFN_Color,id:9167,x:34660,y:31989,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_9167,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:0.5;proporder:9501-1077-4218-7184-6740-4521-4325-8213-3906-3086-5649-5179-855-9167;pass:END;sub:END;*/

Shader "Shader Forge/offsettext" {
    Properties {
        _texture_1 ("texture_1", 2D) = "white" {}
        _Speed_Text1 ("Speed_Text1", Float ) = 0.2
        _Color2 ("Color2", Color) = (1,1,1,1)
        _texture_2 ("texture_2", 2D) = "white" {}
        _Speed_Text2 ("Speed_Text2", Float ) = 0.5
        _intensity2 ("intensity2", Range(-3, 3)) = 0.5322515
        _Color3 ("Color3", Color) = (1,1,1,1)
        _texture_3 ("texture_3", 2D) = "white" {}
        _Speed_Text3 ("Speed_Text3", Float ) = 0.5
        _intensity3 ("intensity3", Range(-3, 3)) = 0.7932316
        _intensity1 ("intensity1", Range(-3, 3)) = 1.100924
        _Color1 ("Color1", Color) = (1,1,1,1)
        _sinwave2 ("sinwave2", Range(0, 0.5)) = 0.05176616
        _Opacity ("Opacity", Color) = (0.5,0.5,0.5,0.5)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _texture_1; uniform float4 _texture_1_ST;
            uniform float _Speed_Text1;
            uniform float4 _Color2;
            uniform sampler2D _texture_2; uniform float4 _texture_2_ST;
            uniform float _Speed_Text2;
            uniform float _intensity2;
            uniform float4 _Color3;
            uniform sampler2D _texture_3; uniform float4 _texture_3_ST;
            uniform float _Speed_Text3;
            uniform float _intensity3;
            uniform float _intensity1;
            uniform float4 _Color1;
            uniform float _sinwave2;
            uniform float4 _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 node_988 = _Time + _TimeEditor;
                float2 node_1113 = (i.uv0+(_Speed_Text3*node_988.g)*float2(-0.5,0));
                float4 _texture_3_var = tex2D(_texture_3,TRANSFORM_TEX(node_1113, _texture_3));
                float4 node_400 = _Time + _TimeEditor;
                float2 node_646 = ((i.uv0+(_Speed_Text2*node_400.g)*float2(-0.25,0))+(sin(node_400.g)*_sinwave2)*float2(0,1));
                float4 _texture_2_var = tex2D(_texture_2,TRANSFORM_TEX(node_646, _texture_2));
                float4 node_4904 = _Time + _TimeEditor;
                float2 node_6391 = (i.uv0+(_Speed_Text1*node_4904.g)*float2(0.5,0));
                float4 _texture_1_var = tex2D(_texture_1,TRANSFORM_TEX(node_6391, _texture_1));
                float3 node_1759 = saturate((((_texture_3_var.rgb+_Color3.rgb)*_intensity3)*((_texture_2_var.rgb+_Color2.rgb)*_intensity2)*((_texture_1_var.rgb+_Color1.rgb)*_intensity1)));
                clip(node_1759.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = node_1759;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _texture_1; uniform float4 _texture_1_ST;
            uniform float _Speed_Text1;
            uniform float4 _Color2;
            uniform sampler2D _texture_2; uniform float4 _texture_2_ST;
            uniform float _Speed_Text2;
            uniform float _intensity2;
            uniform float4 _Color3;
            uniform sampler2D _texture_3; uniform float4 _texture_3_ST;
            uniform float _Speed_Text3;
            uniform float _intensity3;
            uniform float _intensity1;
            uniform float4 _Color1;
            uniform float _sinwave2;
            uniform float4 _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 node_988 = _Time + _TimeEditor;
                float2 node_1113 = (i.uv0+(_Speed_Text3*node_988.g)*float2(-0.5,0));
                float4 _texture_3_var = tex2D(_texture_3,TRANSFORM_TEX(node_1113, _texture_3));
                float4 node_400 = _Time + _TimeEditor;
                float2 node_646 = ((i.uv0+(_Speed_Text2*node_400.g)*float2(-0.25,0))+(sin(node_400.g)*_sinwave2)*float2(0,1));
                float4 _texture_2_var = tex2D(_texture_2,TRANSFORM_TEX(node_646, _texture_2));
                float4 node_4904 = _Time + _TimeEditor;
                float2 node_6391 = (i.uv0+(_Speed_Text1*node_4904.g)*float2(0.5,0));
                float4 _texture_1_var = tex2D(_texture_1,TRANSFORM_TEX(node_6391, _texture_1));
                float3 node_1759 = saturate((((_texture_3_var.rgb+_Color3.rgb)*_intensity3)*((_texture_2_var.rgb+_Color2.rgb)*_intensity2)*((_texture_1_var.rgb+_Color1.rgb)*_intensity1)));
                clip(node_1759.r - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = node_1759;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _Opacity.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _texture_1; uniform float4 _texture_1_ST;
            uniform float _Speed_Text1;
            uniform float4 _Color2;
            uniform sampler2D _texture_2; uniform float4 _texture_2_ST;
            uniform float _Speed_Text2;
            uniform float _intensity2;
            uniform float4 _Color3;
            uniform sampler2D _texture_3; uniform float4 _texture_3_ST;
            uniform float _Speed_Text3;
            uniform float _intensity3;
            uniform float _intensity1;
            uniform float4 _Color1;
            uniform float _sinwave2;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_988 = _Time + _TimeEditor;
                float2 node_1113 = (i.uv0+(_Speed_Text3*node_988.g)*float2(-0.5,0));
                float4 _texture_3_var = tex2D(_texture_3,TRANSFORM_TEX(node_1113, _texture_3));
                float4 node_400 = _Time + _TimeEditor;
                float2 node_646 = ((i.uv0+(_Speed_Text2*node_400.g)*float2(-0.25,0))+(sin(node_400.g)*_sinwave2)*float2(0,1));
                float4 _texture_2_var = tex2D(_texture_2,TRANSFORM_TEX(node_646, _texture_2));
                float4 node_4904 = _Time + _TimeEditor;
                float2 node_6391 = (i.uv0+(_Speed_Text1*node_4904.g)*float2(0.5,0));
                float4 _texture_1_var = tex2D(_texture_1,TRANSFORM_TEX(node_6391, _texture_1));
                float3 node_1759 = saturate((((_texture_3_var.rgb+_Color3.rgb)*_intensity3)*((_texture_2_var.rgb+_Color2.rgb)*_intensity2)*((_texture_1_var.rgb+_Color1.rgb)*_intensity1)));
                clip(node_1759.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
