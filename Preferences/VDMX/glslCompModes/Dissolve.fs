//	adapted from http://transitions.glsl.io/transition/b93818de23d4511fde10


const float		blockSize = 1.0;

float rand(vec2 co) {
    return fract(sin(dot(co, vec2(12.9898, 78.233))) * 43758.5453);
}


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	//vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = vec4(0.0);

	returnMe = mix(darkenedBottom, top, step(rand(floor(gl_FragCoord.xy/blockSize)), topAlpha));
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = vec4(0.0);

	returnMe = mix(darkenedBottom, bottom, step(rand(floor(gl_FragCoord.xy/blockSize)), bottomAlpha));
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}
