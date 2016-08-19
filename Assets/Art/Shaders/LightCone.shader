Shader "TheShining_2.0" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
	}

		SubShader{
		Tags{ "Queue" = "Overlay" }
		LOD 400 Pass{ Tags{ "LightMode" = "ForwardBase" } Blend One One ZWrite Off


		CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fwdbase

#include "UnityCG.cginc"
#include "AutoLight.cginc"

		float4 _Color;

	struct VertexOut
	{
		float4 pos : SV_POSITION;
		LIGHTING_COORDS(0, 1)
	};

	VertexOut vert(appdata_base v)
	{
		VertexOut o;

		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		TRANSFER_VERTEX_TO_FRAGMENT(o)

			return o;
	}

	float4 frag(VertexOut i) : COLOR
	{
		return _Color * LIGHT_ATTENUATION(i);
	}

		ENDCG
	}
		Pass{
		Tags{ "LightMode" = "ForwardAdd" }
		Blend One One
		ZWrite Off

		CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fwdadd

#include "UnityCG.cginc"
#include "AutoLight.cginc"

		float4 _Color;

	struct VertexOut
	{
		float4 pos : SV_POSITION;
		LIGHTING_COORDS(0, 1)
	};

	VertexOut vert(appdata_base v)
	{
		VertexOut o;

		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		TRANSFER_VERTEX_TO_FRAGMENT(o)

			return o;
	}

	float4 frag(VertexOut i) : COLOR
	{
		return _Color * LIGHT_ATTENUATION(i);
	}

		ENDCG
	}
	}
}