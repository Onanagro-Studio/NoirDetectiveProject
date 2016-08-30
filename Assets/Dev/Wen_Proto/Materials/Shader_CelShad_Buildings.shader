// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-6105-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:9127,x:32250,y:32508,varname:node_9127,prsc:2;n:type:ShaderForge.SFN_Dot,id:6507,x:31309,y:32732,varname:node_6507,prsc:2,dt:1|A-6089-OUT,B-9212-OUT;n:type:ShaderForge.SFN_NormalVector,id:9212,x:31100,y:32826,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:6089,x:31100,y:32705,varname:node_6089,prsc:2;n:type:ShaderForge.SFN_Dot,id:9916,x:31309,y:32905,varname:node_9916,prsc:2,dt:1|A-9212-OUT,B-2394-OUT;n:type:ShaderForge.SFN_Add,id:8043,x:32271,y:32943,varname:node_8043,prsc:2|A-6961-OUT,B-559-OUT,C-7893-OUT;n:type:ShaderForge.SFN_Power,id:2069,x:31511,y:33005,cmnt:Specular Light,varname:node_2069,prsc:2|VAL-9916-OUT,EXP-9086-OUT;n:type:ShaderForge.SFN_HalfVector,id:2394,x:31100,y:32965,varname:node_2394,prsc:2;n:type:ShaderForge.SFN_LightColor,id:7977,x:32250,y:32637,varname:node_7977,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6105,x:32975,y:32913,varname:node_6105,prsc:2|A-9339-OUT,B-5207-OUT,C-8043-OUT;n:type:ShaderForge.SFN_Color,id:1782,x:31579,y:32598,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6961,x:31974,y:32636,cmnt:Diffuse Light,varname:node_6961,prsc:2|A-6836-RGB,B-1782-RGB,C-533-OUT;n:type:ShaderForge.SFN_AmbientLight,id:8021,x:31940,y:32826,varname:node_8021,prsc:2;n:type:ShaderForge.SFN_Slider,id:8675,x:30362,y:33073,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:9933,x:31100,y:33122,varname:node_9933,prsc:2|A-6728-OUT,B-6168-OUT;n:type:ShaderForge.SFN_Vector1,id:6168,x:30932,y:33210,varname:node_6168,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6728,x:30932,y:33060,varname:node_6728,prsc:2|A-8675-OUT,B-879-OUT;n:type:ShaderForge.SFN_Vector1,id:879,x:30621,y:33179,varname:node_879,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Exp,id:9086,x:31271,y:33122,varname:node_9086,prsc:2,et:1|IN-9933-OUT;n:type:ShaderForge.SFN_Posterize,id:533,x:31746,y:32826,varname:node_533,prsc:2|IN-6507-OUT,STPS-9031-OUT;n:type:ShaderForge.SFN_Posterize,id:7893,x:31746,y:32957,varname:node_7893,prsc:2|IN-879-OUT,STPS-9031-OUT;n:type:ShaderForge.SFN_TexCoord,id:6178,x:31445,y:32308,varname:node_6178,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:9339,x:32526,y:32355,varname:node_9339,prsc:2|A-9127-OUT,B-5027-OUT;n:type:ShaderForge.SFN_Vector1,id:5027,x:32533,y:32490,varname:node_5027,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp,id:5207,x:32752,y:32651,varname:node_5207,prsc:2|IN-7977-RGB,MIN-6862-OUT,MAX-7399-OUT;n:type:ShaderForge.SFN_Vector1,id:6862,x:32458,y:32736,varname:node_6862,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7399,x:32437,y:32846,varname:node_7399,prsc:2,v1:5;n:type:ShaderForge.SFN_Vector1,id:9031,x:31539,y:32842,varname:node_9031,prsc:2,v1:3;n:type:ShaderForge.SFN_Subtract,id:7243,x:31987,y:33151,varname:node_7243,prsc:2|A-8021-RGB,B-1317-OUT;n:type:ShaderForge.SFN_Vector1,id:1317,x:31761,y:33239,varname:node_1317,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3735,x:32240,y:33203,varname:node_3735,prsc:2|A-7243-OUT,B-917-OUT;n:type:ShaderForge.SFN_Add,id:6052,x:32524,y:33099,varname:node_6052,prsc:2|A-3735-OUT,B-6849-OUT;n:type:ShaderForge.SFN_Vector1,id:917,x:32044,y:33387,varname:node_917,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:6849,x:32407,y:33384,varname:node_6849,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:559,x:32731,y:33099,varname:node_559,prsc:2|A-6052-OUT,B-917-OUT;n:type:ShaderForge.SFN_Tex2d,id:6836,x:31640,y:32349,ptovrint:False,ptlb:node_6836,ptin:_node_6836,varname:_node_6836,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6178-UVOUT;proporder:1782-6836;pass:END;sub:END;*/

Shader "Shader Forge/ShaderCelShad_NoirDetective" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _node_6836 ("node_6836", 2D) = "white" {}
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _node_6836; uniform float4 _node_6836_ST;
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
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _node_6836_var = tex2D(_node_6836,TRANSFORM_TEX(i.uv0, _node_6836));
                float node_9031 = 3.0;
                float node_917 = 2.0;
                float node_879 = 0.01;
                float3 finalColor = ((attenuation*1.0)*clamp(_LightColor0.rgb,0.0,5.0)*((_node_6836_var.rgb*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * node_9031) / (node_9031 - 1))+((((UNITY_LIGHTMODEL_AMBIENT.rgb-0.5)*node_917)+1.0)/node_917)+floor(node_879 * node_9031) / (node_9031 - 1)));
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _node_6836; uniform float4 _node_6836_ST;
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
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _node_6836_var = tex2D(_node_6836,TRANSFORM_TEX(i.uv0, _node_6836));
                float node_9031 = 3.0;
                float node_917 = 2.0;
                float node_879 = 0.01;
                float3 finalColor = ((attenuation*1.0)*clamp(_LightColor0.rgb,0.0,5.0)*((_node_6836_var.rgb*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * node_9031) / (node_9031 - 1))+((((UNITY_LIGHTMODEL_AMBIENT.rgb-0.5)*node_917)+1.0)/node_917)+floor(node_879 * node_9031) / (node_9031 - 1)));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
