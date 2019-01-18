#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

//A lot of this code was found on gamedev.net, https://www.gamedev.net/articles/programming/engines-and-middleware/2d-lighting-system-in-monogame-r4131/

sampler BrightSampler ;

//this texture will hold the texture that will be acted apon by the effects class
texture light;


//this sampler stores the texture ina a register that HLSL can use
sampler lightSampler = sampler_state { texture = <light>; };

float4 PixleLight(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
	float4 colour = tex2D(BrightSampler, coords);

	float4 lightColour = tex2D(lightSampler, coords);

	return colour * lightColour;
}

technique BrightEffect
{
	pass Pass1
	{
		PixelShader = compile PS_SHADERMODEL PixleLight();
	}

	
}