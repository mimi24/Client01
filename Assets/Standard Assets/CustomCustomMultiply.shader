Shader "Custom/CustomMultiply" {
	Properties{
		_MainTex("Particle Texture", 2D) = "white" {}
	}

		Category{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Blend Zero SrcColor
		Cull Off Lighting Off ZWrite Off Fog{ Mode Off }

		BindChannels{
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}

		SubShader{

		Pass{
		SetTexture[_MainTex]{
		combine texture * primary
	}
		SetTexture[_MainTex]{
		constantColor(1,1,1,1)
		combine previous lerp(previous) constant
	}
	}
	}
	}
}
