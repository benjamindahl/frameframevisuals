//	adapted from http://transitions.glsl.io/transition/35e8c18557995c77278e


const vec2 direction = vec2(1.0,1.0);
const vec2 center = vec2(0.5, 0.5);
const float smoothness = 0.25;
const float SQRT_2 = 1.414213562373;
const bool opening = true;


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;

	float		x = opening ? topAlpha : 1.0-topAlpha;
	float		m = smoothstep(-smoothness, 0.0, SQRT_2*distance(center, p) - x*(1.+smoothness));
	
	returnMe = mix(darkenedBottom, top, opening ? 1.-m : m);
	return returnMe;
}

vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;

	float		x = opening ? bottomAlpha : 1.0-bottomAlpha;
	float		m = smoothstep(-smoothness, 0.0, SQRT_2*distance(center, p) - x*(1.+smoothness));
	
	returnMe = mix(darkenedBottom, bottom, opening ? 1.-m : m);
	return returnMe;
}

vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}
